using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;
using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetGeneratedMaze_MinimumSize_CreatesValidMaze()
        {
            var dimensions = (3u, 3u);
            var rnd = new RandomProvider(42);

            var maze = MazeGenerationUtils.GetGeneratedMaze(dimensions, rnd);

            Assert.IsNotNull(maze);
            Assert.AreEqual(dimensions, maze.Dimensions);
            Assert.IsTrue(maze.IsComplete());
            Assert.IsNotNull(maze.GetOpeningCell());
            Assert.IsTrue(maze.ExitExists());
        }

        [TestMethod]
        public void GetGeneratedMaze_LargeSize_CreatesValidMaze()
        {
            var dimensions = (50u, 50u);
            var rnd = new RandomProvider(42);

            var maze = MazeGenerationUtils.GetGeneratedMaze(dimensions, rnd);

            Assert.IsNotNull(maze);
            Assert.AreEqual(dimensions, maze.Dimensions);
            Assert.IsTrue(maze.IsComplete());
            Assert.IsNotNull(maze.GetOpeningCell());
            Assert.IsTrue(maze.ExitExists());
        }

        [TestMethod]
        public void MoveUp_NullMaze_Throws()
        {
            var cell = new Mock<IMazeCell>().Object;
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveUp(cell, null));
        }

        [TestMethod]
        public void MoveUp_WithNeighbor_SetsWalls()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            var toCell = new Mock<IMazeCell>();
            maze.Setup(m => m.GetNeighbor(fromCell.Object, Direction.Up)).Returns(toCell.Object);

            MazeGenerationUtils.MoveUp(fromCell.Object, maze.Object);

            toCell.Verify(c => c.SetWallStatus(Direction.Down, WallStatus.Open), Times.Once);
            toCell.Verify(c => c.SetWallStatus(Direction.Right, WallStatus.Closed), Times.Once);
        }

        [TestMethod]
        public void MoveLeft_WithNeighbor_SetsWalls()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            var toCell = new Mock<IMazeCell>();
            maze.Setup(m => m.GetNeighbor(fromCell.Object, Direction.Left)).Returns(toCell.Object);

            MazeGenerationUtils.MoveLeft(fromCell.Object, maze.Object);

            toCell.Verify(c => c.SetWallStatus(Direction.Down, WallStatus.Closed), Times.Once);
            toCell.Verify(c => c.SetWallStatus(Direction.Right, WallStatus.Open), Times.Once);
        }

        [TestMethod]
        public void MoveDown_BottomRow_CreatesExit()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellBottomRow(fromCell.Object)).Returns(true);
            maze.Setup(m => m.ExitExists()).Returns(false);
            maze.Setup(m => m.CreateExit(fromCell.Object));

            try
            {
                MazeGenerationUtils.MoveDown(fromCell.Object, maze.Object);
            }
            catch { }

            maze.Verify(m => m.CreateExit(fromCell.Object), Times.Once);
        }

        [TestMethod]
        public void MoveDown_NotBottomRow_SetsWallAndMoves()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            var toCell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellBottomRow(fromCell.Object)).Returns(false);
            maze.Setup(m => m.GetNeighbor(fromCell.Object, Direction.Down)).Returns(toCell.Object);

            var result = MazeGenerationUtils.MoveDown(fromCell.Object, maze.Object);

            fromCell.Verify(c => c.SetWallStatus(Direction.Down, WallStatus.Open), Times.Once);
            Assert.AreEqual(toCell.Object, result);
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_SetsWalls()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            var toCell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellRightEdge(fromCell.Object)).Returns(false);
            maze.Setup(m => m.GetNeighbor(fromCell.Object, Direction.Right)).Returns(toCell.Object);
            fromCell.Setup(c => c.GetBottomWall()).Returns((IMazeCellWall)null);
            fromCell.Setup(c => c.GetRightWall()).Returns((IMazeCellWall)null);

            var result = MazeGenerationUtils.MoveRight(fromCell.Object, maze.Object);

            fromCell.Verify(c => c.SetWallStatus(Direction.Down, WallStatus.Open), Times.Once);
            fromCell.Verify(c => c.SetWallStatus(Direction.Right, WallStatus.Open), Times.Once);
            Assert.AreEqual(toCell.Object, result);
        }

        [TestMethod]
        public void IsBlockedRight_RightEdge_ReturnsTrue()
        {
            var maze = new Mock<IMaze>();
            var cell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellRightEdge(cell.Object)).Returns(true);

            Assert.IsTrue(MazeGenerationUtils.IsBlockedRight(maze.Object, cell.Object));
        }

        [TestMethod]
        public void IsBlockedLeft_LeftEdge_ReturnsTrue()
        {
            var maze = new Mock<IMaze>();
            var cell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellLeftEdge(cell.Object)).Returns(true);

            Assert.IsTrue(MazeGenerationUtils.IsBlockedLeft(maze.Object, cell.Object));
        }

        [TestMethod]
        public void IsBlockedUp_TopRow_ReturnsTrue()
        {
            var maze = new Mock<IMaze>();
            var cell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellTopRow(cell.Object)).Returns(true);

            Assert.IsTrue(MazeGenerationUtils.IsBlockedUp(maze.Object, cell.Object));
        }

        [TestMethod]
        public void IsBlockedDown_BottomRow_ReturnsNotCreateExit()
        {
            var maze = new Mock<IMaze>();
            var cell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellBottomRow(cell.Object)).Returns(true);
            maze.Setup(m => m.ExitExists()).Returns(true);

            Assert.IsTrue(MazeGenerationUtils.IsBlockedDown(maze.Object, cell.Object));
        }

        [TestMethod]
        public void CreateCellWall_SetsWallOnBothCells()
        {
            var cell = new Mock<IMazeCell>();
            var neighbor = new Mock<IMazeCell>();
            cell.Setup(c => c.GetWall(Direction.Right)).Returns((IMazeCellWall)null);
            neighbor.Setup(c => c.GetWall(Direction.Left)).Returns((IMazeCellWall)null);

            MazeGenerationUtils.CreateCellWall(cell.Object, neighbor.Object, Direction.Right);

            cell.Verify(c => c.CreateWall(Direction.Right, It.IsAny<IMazeCellWall>()), Times.Once);
            neighbor.Verify(c => c.CreateWall(Direction.Left, It.IsAny<IMazeCellWall>()), Times.Once);
        }

        [TestMethod]
        public void SetTopOpening_ThrowsIfNoCell()
        {
            var maze = new Mock<IMaze>();
            maze.Setup(m => m.MazeCells).Returns(new List<IMazeCell>());

            Assert.ThrowsException<ApplicationException>(() =>
                MazeGenerationUtils.SetTopOpening(maze.Object, (0, 0)));
        }

        [TestMethod]
        public void ProcessMazeCell_MoveReturnsNull_ReturnsNextOpenCell()
        {
            // Arrange
            var maze = new Mock<IMaze>();
            var cell = new Mock<IMazeCell>();
            var unsetCell = new Mock<IMazeCell>();
            var setCell = new Mock<IMazeCell>();

            // Setup coordinates for the test
            unsetCell.SetupGet(c => c.Coordinates).Returns((0u, 0u));
            unsetCell.Setup(c => c.IsSet()).Returns(false);

            setCell.SetupGet(c => c.Coordinates).Returns((1u, 0u));
            setCell.Setup(c => c.IsSet()).Returns(true);

            // First call to GetCell returns unsetCell, second call returns setCell
            var callCount = 0;
            maze.Setup(m => m.GetCell(It.IsAny<(uint, uint)>()))
                .Returns(() =>
                {
                    callCount++;
                    return callCount == 1 ? unsetCell.Object : setCell.Object;
                });

            // Setup so that the cell is not on the right edge or bottom row
            maze.Setup(m => m.IsCellRightEdge(It.IsAny<IMazeCell>())).Returns(false);
            maze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);

            // Setup MoveUp to return null, so ProcessMazeCell will call GetNextOpenCell
            maze.Setup(m => m.GetNeighbor(cell.Object, Direction.Up)).Returns((IMazeCell?)null);

            // Act
            var result = MazeGenerationUtils.GetNextCellToVisit(maze.Object, cell.Object, Direction.Up);

            // Assert
            Assert.AreEqual(setCell.Object, result);
        }
    }

}