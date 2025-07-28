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
        public void GetNextCellToVisit_NextDirection_Up_CallsMoveUp()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var mockResultCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);
            mockMaze.Setup(m => m.GetNeighbor(mockCell.Object, Direction.Up)).Returns(mockResultCell.Object);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, Direction.Up);

            Assert.AreEqual(mockResultCell.Object, result);
        }

        [TestMethod]
        public void GetNextCellToVisit_NextDirection_Left_CallsMoveLeft()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var mockResultCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);
            mockMaze.Setup(m => m.GetNeighbor(mockCell.Object, Direction.Left)).Returns(mockResultCell.Object);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, Direction.Left);

            Assert.AreEqual(mockResultCell.Object, result);
        }

        [TestMethod]
        public void GetNextCellToVisit_NextDirection_Down_CallsMoveDown()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var mockResultCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);
            mockMaze.Setup(m => m.GetNeighbor(mockCell.Object, Direction.Down)).Returns(mockResultCell.Object);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, Direction.Down);

            Assert.AreEqual(mockResultCell.Object, result);
        }

        [TestMethod]
        public void GetNextCellToVisit_NextDirection_Right_CallsMoveRight()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var mockResultCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);
            mockMaze.Setup(m => m.IsCellRightEdge(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.GetNeighbor(mockCell.Object, Direction.Right)).Returns(mockResultCell.Object);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, Direction.Right);

            Assert.AreEqual(mockResultCell.Object, result);
        }

        [TestMethod]
        public void GetNextCellToVisit_NextDirection_Null_CallsGetNextOpenCell()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var mockNextOpenCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.GetCell(It.IsAny<(uint, uint)>())).Returns(mockNextOpenCell.Object);
            mockMaze.Setup(m => m.IsCellRightEdge(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);

            // This is required to break the loop in GetNextOpenCell
            mockNextOpenCell.Setup(c => c.IsSet()).Returns(true);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, null);

            Assert.AreEqual(mockNextOpenCell.Object, result);
        }

        [TestMethod]
        public void GetNextCellToVisit_MoveReturnsNull_CallsGetNextOpenCell()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var unsetCell = new Mock<IMazeCell>();
            var setCell = new Mock<IMazeCell>();

            // Setup coordinates for the test
            unsetCell.SetupGet(c => c.Coordinates).Returns((0u, 0u));
            unsetCell.Setup(c => c.IsSet()).Returns(false);

            setCell.SetupGet(c => c.Coordinates).Returns((1u, 0u));
            setCell.Setup(c => c.IsSet()).Returns(true);

            // First call to GetCell returns unsetCell, second call returns setCell
            var callCount = 0;
            mockMaze.Setup(m => m.GetCell(It.IsAny<(uint, uint)>()))
                .Returns(() =>
                {
                    callCount++;
                    return callCount == 1 ? unsetCell.Object : setCell.Object;
                });

            mockMaze.Setup(m => m.IsCellRightEdge(It.IsAny<IMazeCell>())).Returns(false);
            mockMaze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);

            // Setup MoveUp to return null, so GetNextCellToVisit will call GetNextOpenCell
            mockMaze.Setup(m => m.GetNeighbor(mockCell.Object, Direction.Up)).Returns((IMazeCell?)null);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, Direction.Up);

            Assert.AreEqual(setCell.Object, result);
        }

        [TestMethod]
        public void GetNextCellToVisit_BottomRow_NoExit_NextDirectionUp_CreatesExitAndReturnsNextOpenCell()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();
            var mockNextOpenCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(mockCell.Object)).Returns(true);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);
            mockMaze.Setup(m => m.CreateExit(mockCell.Object));
            mockMaze.Setup(m => m.GetCell(It.IsAny<(uint, uint)>())).Returns(mockNextOpenCell.Object);
            mockMaze.Setup(m => m.IsCellRightEdge(It.IsAny<IMazeCell>())).Returns(false);

            // This is required to break the loop in GetNextOpenCell
            mockNextOpenCell.Setup(c => c.IsSet()).Returns(true);

            var result = MazeGenerationUtils.GetNextCellToVisit(mockMaze.Object, mockCell.Object, Direction.Up);

            mockMaze.Verify(m => m.CreateExit(mockCell.Object), Times.Once);
            Assert.AreEqual(mockNextOpenCell.Object, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNextCellToVisit_NullCell_Throws()
        {
            var mockMaze = new Mock<IMaze>().Object;
            MazeGenerationUtils.GetNextCellToVisit(mockMaze, null, Direction.Up);
        }
    }
}