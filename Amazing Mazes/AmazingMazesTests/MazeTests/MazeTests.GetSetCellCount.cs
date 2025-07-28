using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetSetCellCount_EmptyMaze_ThrowsArgumentOutOfRange()
        {
            _cells.Clear();
            var maze = new Maze(_cells);

            // Should throw ArgumentOutOfRangeException
            maze.GetSetCellCount();
        }

        [TestMethod]
        public void GetSetCellCount_AllCellsUnset_ReturnsZero()
        {
            _cells.Clear();

            for (uint col = 0; col < WidthVal2; col++)
                for (uint row = 0; row < HeightVal2; row++)
                {
                    var tempCell = new Mock<IMazeCell>();
                    tempCell.Setup(x => x.Coordinates).Returns((col, row));
                    tempCell.Setup(c => c.IsSet()).Returns(false);
                    _cells.Add(tempCell.Object);
                }

            var maze = new Maze(_cells);

            Assert.AreEqual(0u, maze.GetSetCellCount());
        }

        [TestMethod]
        public void GetSetCellCount_AllCellsSet_ReturnsTotalCount()
        {
            var mazeWidth = WidthVal2;
            var mazeHeight = HeightVal2;

            _cells.Clear();

            for (uint col = 0; col < mazeWidth; col++)
                for (uint row = 0; row < mazeHeight; row++)
                {
                    var tempCell = new Mock<IMazeCell>();
                    tempCell.Setup(x => x.Coordinates).Returns((col, row));
                    tempCell.Setup(c => c.IsSet()).Returns(true);
                    _cells.Add(tempCell.Object);
                }

            var maze = new Maze(_cells);

            Assert.AreEqual(mazeWidth * mazeHeight, maze.GetSetCellCount());
        }

        [TestMethod]
        public void GetSetCellCount_SomeCellsSet_ReturnsCorrectCount()
        {
            uint setCells = 0; ;
            _cells.Clear();

            for (uint col = 0; col < WidthVal2; col++)
                for (uint row = 0; row < HeightVal2; row++)
                {
                    var tempCell = new Mock<IMazeCell>();
                    tempCell.Setup(x => x.Coordinates).Returns((col, row));

                    if (col == 0 && row == 0)
                    {
                        tempCell.Setup(c => c.IsSet()).Returns(false);
                        _cells.Add(tempCell.Object);
                        continue;
                    }

                    tempCell.Setup(c => c.IsSet()).Returns(true);
                    setCells++;
                    _cells.Add(tempCell.Object);
                }

            var maze = new Maze(_cells);

            Assert.AreEqual(setCells, maze.GetSetCellCount());
        }
    }
}