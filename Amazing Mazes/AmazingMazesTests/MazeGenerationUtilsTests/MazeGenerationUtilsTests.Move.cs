using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using static ObjectivelyAmazingProgramCore.Enums;
using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void MoveUp_NullFromCell_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveUp(null, maze!.Object));
        }

        [TestMethod]
        public void MoveUp_MazeNull_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveUp(fromCell, null));
        }

        [TestMethod]
        public void MoveUp_FromCellIsTopRow_ReturnsNull()
        {
            Assert.IsNull(MazeGenerationUtils.MoveUp(fromCellTopRow, maze!.Object));
        }

        [TestMethod]
        public void MoveUp_Valid_ReturnsUpperNeighbor()
        {
            Assert.AreSame(upperNeighbor, MazeGenerationUtils.MoveUp(fromCell, maze!.Object));
        }

        [TestMethod]
        public void MoveUp_Valid_UpperNeighborWallsSetCorrectly()
        {
            var cell = MazeGenerationUtils.MoveUp(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Open, cell!.GetWall(Direction.Down)!.Status);
            Assert.AreEqual(WallStatus.Closed, cell.GetWall(Direction.Right)!.Status);
        }

        [TestMethod]
        public void MoveLeft_NullFromCell_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveLeft(null, maze!.Object));
        }

        [TestMethod]
        public void MoveLeft_MazeNull_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveLeft(fromCell, null));
        }

        [TestMethod]
        public void MoveLeft_FromCellIsLeftEdge_ReturnsNull()
        {
            Assert.IsNull(MazeGenerationUtils.MoveLeft(fromCellLeftEdge, maze!.Object));
        }

        [TestMethod]
        public void MoveLeft_Valid_ReturnsLeftNeighbor()
        {
            Assert.AreSame(leftNeighbor, MazeGenerationUtils.MoveLeft(fromCell, maze!.Object));
        }

        [TestMethod]
        public void MoveLeft_Valid_LeftNeighborWallsSetCorrectly()
        {
            var cell = MazeGenerationUtils.MoveLeft(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Closed, cell!.GetWall(Direction.Down)!.Status);
            Assert.AreEqual(WallStatus.Open, cell.GetWall(Direction.Right)!.Status);
        }

        [TestMethod]
        public void MoveDown_NullFromCell_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveDown(null, maze!.Object));
        }

        [TestMethod]
        public void MoveDown_MazeNull_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveDown(fromCell, null));
        }

        [TestMethod]
        public void MoveDown_FromCellIsBottomRow_ExitExists_ReturnsNull()
        {
            Assert.IsNull(MazeGenerationUtils.MoveDown(fromCellBottomRow, maze!.Object));
        }

        [TestMethod]
        public void MoveDown_FromCellIsBottomRow_ExitExists_SetsDownWallOpen()
        {
            _ = MazeGenerationUtils.MoveDown(fromCellBottomRow, maze!.Object);
            Assert.AreEqual(WallStatus.Open, fromCellBottomRow!.GetWall(Direction.Down)!.Status);
        }

        [TestMethod]
        public void MoveDown_NotBottomRow_ExitNotExists_ReturnsLowerNeighbor()
        {
            maze!.Setup(x => x.ExitExists()).Returns(false);
            Assert.AreSame(lowerNeighbor, MazeGenerationUtils.MoveDown(fromCell, maze.Object));
        }

        [TestMethod]
        public void MoveDown_NotBottomRow_ExitNotExists_SetsDownWallOpen()
        {
            maze!.Setup(x => x.ExitExists()).Returns(false);
            _ = MazeGenerationUtils.MoveDown(fromCell, maze.Object);
            Assert.AreEqual(WallStatus.Open, fromCell!.GetWall(Direction.Down)!.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void MoveDown_FromCellIsBottomRow_ExitNotExists_ReturnsNull()
        {
            var mazeMock = new Mock<IMaze>();
            mazeMock.Setup(m => m.IsCellBottomRow(fromCellBottomRow!)).Returns(true);
            mazeMock.Setup(m => m.ExitExists()).Returns(false);

            MazeGenerationUtils.MoveDown(fromCellBottomRow, mazeMock.Object);
        }

        [TestMethod]
        public void MoveRight_NullFromCell_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveRight(null, maze!.Object));
        }

        [TestMethod]
        public void MoveRight_MazeNull_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MazeGenerationUtils.MoveRight(fromCell, null));
        }

        [TestMethod]
        public void MoveRight_FromCellIsRightEdge_ReturnsNull()
        {
            Assert.IsNull(MazeGenerationUtils.MoveRight(fromCellRightEdge, maze!.Object));
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_BottomWallClosed_RightWallClosed_ReturnsRightNeighbor()
        {
            fromCell!.SetWallStatus(Direction.Down, WallStatus.Closed);
            fromCell.SetWallStatus(Direction.Right, WallStatus.Closed);
            Assert.AreSame(rightNeighbor, MazeGenerationUtils.MoveRight(fromCell, maze!.Object));
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_BottomWallClosed_RightWallClosed_SetsRightWallOpen()
        {
            fromCell!.SetWallStatus(Direction.Down, WallStatus.Closed);
            fromCell.SetWallStatus(Direction.Right, WallStatus.Closed);
            _ = MazeGenerationUtils.MoveRight(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Open, fromCell.GetWall(Direction.Right)!.Status);
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_BottomWallOpen_ReturnsRightNeighbor()
        {
            fromCell!.SetWallStatus(Direction.Down, WallStatus.Open);
            Assert.AreSame(rightNeighbor, MazeGenerationUtils.MoveRight(fromCell, maze!.Object));
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_RightWallOpen_ReturnsRightNeighbor()
        {
            fromCell!.SetWallStatus(Direction.Right, WallStatus.Open);
            Assert.AreSame(rightNeighbor, MazeGenerationUtils.MoveRight(fromCell, maze!.Object));
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_BottomWallOpen_SetsRightWallOpen()
        {
            fromCell!.SetWallStatus(Direction.Down, WallStatus.Open);
            _ = MazeGenerationUtils.MoveRight(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Open, fromCell.GetWall(Direction.Right)!.Status);
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_BottomWallOpen_SetsDownWallOpen()
        {
            fromCell!.SetWallStatus(Direction.Down, WallStatus.Open);
            _ = MazeGenerationUtils.MoveRight(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Open, fromCell.GetWall(Direction.Down)!.Status);
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_RightWallOpen_SetsRightWallOpen()
        {
            fromCell!.SetWallStatus(Direction.Right, WallStatus.Open);
            _ = MazeGenerationUtils.MoveRight(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Open, fromCell.GetWall(Direction.Right)!.Status);
        }

        [TestMethod]
        public void MoveRight_NotRightEdge_RightWallOpen_SetsDownWallOpen()
        {
            fromCell!.SetWallStatus(Direction.Right, WallStatus.Open);
            _ = MazeGenerationUtils.MoveRight(fromCell, maze!.Object);
            Assert.AreEqual(WallStatus.Open, fromCell.GetWall(Direction.Down)!.Status);
        }

        [TestMethod]
        public void MoveUp_SetsWalls_CorrectlyOnBothCells()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new MazeCell((1, 1));
            var toCell = new MazeCell((1, 0));
            toCell.CreateWall(Direction.Down, new MazeCellWall { Status = WallStatus.Closed });
            toCell.CreateWall(Direction.Right, new MazeCellWall { Status = WallStatus.Open });
            maze.Setup(m => m.GetNeighbor(fromCell, Direction.Up)).Returns(toCell);

            MazeGenerationUtils.MoveUp(fromCell, maze.Object);

            Assert.AreEqual(WallStatus.Open, toCell.GetWall(Direction.Down)!.Status);
            Assert.AreEqual(WallStatus.Closed, toCell.GetWall(Direction.Right)!.Status);
        }

        [TestMethod]
        public void MoveDown_ExitCreationFails_Throws()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellBottomRow(fromCell.Object)).Returns(true);
            maze.Setup(m => m.ExitExists()).Returns(false);
            maze.Setup(m => m.CreateExit(fromCell.Object));
            maze.SetupSequence(m => m.ExitExists()).Returns(false).Returns(false);

            Assert.ThrowsException<ApplicationException>(() => MazeGenerationUtils.MoveDown(fromCell.Object, maze.Object));
        }

        [TestMethod]
        public void MoveRight_BothWallsAlreadyOpen_SetsNoAdditionalWalls()
        {
            var maze = new Mock<IMaze>();
            var fromCell = new Mock<IMazeCell>();
            var toCell = new Mock<IMazeCell>();
            maze.Setup(m => m.IsCellRightEdge(fromCell.Object)).Returns(false);
            maze.Setup(m => m.GetNeighbor(fromCell.Object, Direction.Right)).Returns(toCell.Object);

            var rightWall = new Mock<IMazeCellWall>();
            rightWall.SetupProperty(w => w.Status, WallStatus.Open);
            fromCell.Setup(c => c.GetRightWall()).Returns(rightWall.Object);

            var bottomWall = new Mock<IMazeCellWall>();
            bottomWall.SetupProperty(w => w.Status, WallStatus.Open);
            fromCell.Setup(c => c.GetBottomWall()).Returns(bottomWall.Object);

            MazeGenerationUtils.MoveRight(fromCell.Object, maze.Object);

            rightWall.VerifySet(w => w.Status = WallStatus.Open, Times.Never());
            bottomWall.VerifySet(w => w.Status = WallStatus.Open, Times.Never());
        }
    }
}