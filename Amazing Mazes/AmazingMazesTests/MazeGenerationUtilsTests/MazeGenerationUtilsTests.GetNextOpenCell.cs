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
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNextOpenCell_MazeNull_Throws()
        {
            var cell = new Mock<IMazeCell>().Object;
            MazeGenerationUtils.GetNextOpenCell(null, cell);
        }

        [TestMethod]
        public void GetNextOpenCell_CellIsSet_ReturnsSameCell()
        {
            var cell = new Mock<IMazeCell>();
            cell.Setup(c => c.IsSet()).Returns(true);
            cell.SetupGet(c => c.Coordinates).Returns((0u, 0u));

            var maze = new Mock<IMaze>();
            maze.Setup(m => m.GetCell(It.IsAny<(uint, uint)>())).Returns(cell.Object);
            maze.Setup(m => m.IsCellRightEdge(cell.Object)).Returns(false);
            maze.Setup(m => m.IsCellBottomRow(cell.Object)).Returns(false);

            var result = MazeGenerationUtils.GetNextOpenCell(maze.Object, cell.Object);

            Assert.AreEqual(cell.Object, result);
        }

        [TestMethod]
        public void GetNextOpenCell_NextCellIsSet_ReturnsNextCell()
        {
            var cell = new Mock<IMazeCell>();
            var nextCell = new Mock<IMazeCell>();

            cell.SetupGet(c => c.Coordinates).Returns((0u, 0u));
            cell.Setup(c => c.IsSet()).Returns(false);

            nextCell.SetupGet(c => c.Coordinates).Returns((1u, 0u));
            nextCell.Setup(c => c.IsSet()).Returns(true);

            var maze = new Mock<IMaze>();
            maze.Setup(m => m.IsCellRightEdge(cell.Object)).Returns(false);
            var coordinates = (1u, 0u);
            maze.Setup(m => m.GetCell(coordinates)).Returns(nextCell.Object);

            maze.Setup(m => m.IsCellRightEdge(nextCell.Object)).Returns(false);
            maze.Setup(m => m.IsCellBottomRow(nextCell.Object)).Returns(false);

            var result = MazeGenerationUtils.GetNextOpenCell(maze.Object, cell.Object);

            Assert.AreEqual(nextCell.Object, result);
        }

        [TestMethod]
        public void GetNextOpenCell_StartsWithNullCell_ReturnsFirstSetCell()
        {
            var setCell = new Mock<IMazeCell>();
            setCell.SetupGet(c => c.Coordinates).Returns((0u, 0u));
            setCell.Setup(c => c.IsSet()).Returns(true);

            var maze = new Mock<IMaze>();
            maze.Setup(m => m.GetCell(It.IsAny<(uint, uint)>())).Returns(setCell.Object);
            maze.Setup(m => m.IsCellRightEdge(setCell.Object)).Returns(false);
            maze.Setup(m => m.IsCellBottomRow(setCell.Object)).Returns(false);

            var result = MazeGenerationUtils.GetNextOpenCell(maze.Object, null);

            Assert.AreEqual(setCell.Object, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetNextOpenCell_NoSetCell_Throws()
        {
            var cell = new Mock<IMazeCell>();
            cell.SetupGet(c => c.Coordinates).Returns((0u, 0u));
            cell.Setup(c => c.IsSet()).Returns(false);

            var maze = new Mock<IMaze>();
            maze.Setup(m => m.IsCellRightEdge(It.IsAny<IMazeCell>())).Returns(false);
            maze.Setup(m => m.IsCellBottomRow(It.IsAny<IMazeCell>())).Returns(false);
            var coordinates = (0u, 0u);
            maze.Setup(m => m.GetCell(coordinates)).Returns(cell.Object);

            MazeGenerationUtils.GetNextOpenCell(maze.Object, cell.Object);
        }
    }
}