using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void CreateExit_BottomRowAndNoExit_ReturnsTrue()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(mockCell.Object)).Returns(true);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);

            var result = MazeGenerationUtils.CreateExit(mockMaze.Object, mockCell.Object);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateExit_BottomRowAndExitExists_ReturnsFalse()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(mockCell.Object)).Returns(true);
            mockMaze.Setup(m => m.ExitExists()).Returns(true);

            var result = MazeGenerationUtils.CreateExit(mockMaze.Object, mockCell.Object);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateExit_NotBottomRowAndNoExit_ReturnsFalse()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(mockCell.Object)).Returns(false);
            mockMaze.Setup(m => m.ExitExists()).Returns(false);

            var result = MazeGenerationUtils.CreateExit(mockMaze.Object, mockCell.Object);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateExit_NotBottomRowAndExitExists_ReturnsFalse()
        {
            var mockMaze = new Mock<IMaze>();
            var mockCell = new Mock<IMazeCell>();

            mockMaze.Setup(m => m.IsCellBottomRow(mockCell.Object)).Returns(false);
            mockMaze.Setup(m => m.ExitExists()).Returns(true);

            var result = MazeGenerationUtils.CreateExit(mockMaze.Object, mockCell.Object);

            Assert.IsFalse(result);
        }
    }
}