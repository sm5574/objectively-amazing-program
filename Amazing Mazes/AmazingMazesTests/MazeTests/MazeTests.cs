using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    [TestClass]
    public partial class MazeTests
    {
        private const uint WidthVal2 = 2;
        private const uint HeightVal2 = 2;
        private (uint column, uint row) _dimensions;
        private List<IMazeCell> _cells = null!;

        private (uint column, uint row) _validCell;
        private (uint column, uint row) _colZero;
        private (uint column, uint row) _rowZero;
        private (uint column, uint row) _colOutOfBounds;
        private (uint column, uint row) _rowOutOfBounds;

        private (uint column, uint row) _upperLeft;
        private (uint column, uint row) _upperRight;
        private (uint column, uint row) _lowerLeft;
        private (uint column, uint row) _lowerRight;

        private Mock<IMazeCell> _cellUpperLeft = null!;
        private Mock<IMazeCell> _cellUpperRight = null!;
        private Mock<IMazeCell> _cellLowerLeft = null!;
        private Mock<IMazeCell> _cellLowerRight = null!;

        private Maze? _mazeFromDimensions = null!;

        private const uint WidthVal1 = 1;
        private const uint HeightVal1 = 1;
        private Maze? _mazeGetNeighbor = null!;
        private List<IMazeCell> _cellsGetNeighbor = null!;

        private Maze? _setMaze = null!;
        private Maze? _unsetMaze = null!;
        private List<IMazeCell> _setCells = null!;
        private List<IMazeCell> _unsetCells = null!;
        private Mock<IMazeCell> _setCellLowerRight = null!;
        private Mock<IMazeCell> _unsetCellLowerRight = null!;

        private Maze? _completeMaze = null!;
        private List<IMazeCell> _completeCells = null!;
        private Mock<IMazeCell> _openCellLowerRight = null!;
        private Mock<IMazeCellWall> _closedWall = null!;
        private Mock<IMazeCellWall> _openWall = null!;

        [TestInitialize]
        public void Initialize()
        {
            _dimensions = (WidthVal2, HeightVal2);
            _cells = [];

            _validCell = (WidthVal2 - 1, HeightVal2 - 1);
            _colZero = (0, HeightVal2);
            _rowZero = (WidthVal2, 0);
            _colOutOfBounds = (WidthVal2 + 1, HeightVal2);
            _rowOutOfBounds = (WidthVal2, HeightVal2 + 1);
            _mazeFromDimensions = new Maze(_dimensions);

            _upperLeft = (0, 0);
            _upperRight = (WidthVal1, 0);
            _lowerLeft = (0, HeightVal1);
            _lowerRight = (WidthVal1, HeightVal1);
            _cellsGetNeighbor = [];
            _setCells = [];
            _unsetCells = [];
            _completeCells = [];

            _cellUpperLeft = new Mock<IMazeCell>();
            _cellUpperRight = new Mock<IMazeCell>();
            _cellLowerLeft = new Mock<IMazeCell>();
            _cellLowerRight = new Mock<IMazeCell>();
            _setCellLowerRight = new Mock<IMazeCell>();
            _unsetCellLowerRight = new Mock<IMazeCell>();
            _openCellLowerRight = new Mock<IMazeCell>();
            _closedWall = new Mock<IMazeCellWall>();
            _openWall = new Mock<IMazeCellWall>();

            _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
            _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
            _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
            _cellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);

            _cellsGetNeighbor.Add(_cellUpperLeft.Object);
            _cellsGetNeighbor.Add(_cellUpperRight.Object);
            _cellsGetNeighbor.Add(_cellLowerLeft.Object);
            _cellsGetNeighbor.Add(_cellLowerRight.Object);
            _mazeGetNeighbor = new Maze(_cellsGetNeighbor);

            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _setCellLowerRight.Setup(x => x.IsSet()).Returns(true);
            _unsetCellLowerRight.Setup(x => x.IsSet()).Returns(false);
            _setCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
            _unsetCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
            _setCells.Add(_cellUpperLeft.Object);
            _setCells.Add(_cellUpperRight.Object);
            _setCells.Add(_cellLowerLeft.Object);
            _setCells.Add(_setCellLowerRight.Object);
            _unsetCells.Add(_cellUpperLeft.Object);
            _unsetCells.Add(_cellUpperRight.Object);
            _unsetCells.Add(_cellLowerLeft.Object);
            _unsetCells.Add(_unsetCellLowerRight.Object);
            _setMaze = new Maze(_setCells);
            _unsetMaze = new Maze(_unsetCells);

            _closedWall.Setup(x => x.Status).Returns(WallStatus.Closed);
            _openWall.Setup(x => x.Status).Returns(WallStatus.Open);
            _openCellLowerRight.Setup(x => x.IsSet()).Returns(true);
            _openCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _setCellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _openCellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
            _unsetCellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _completeCells.Add(_cellUpperLeft.Object);
            _completeCells.Add(_cellUpperRight.Object);
            _completeCells.Add(_cellLowerLeft.Object);
            _completeCells.Add(_openCellLowerRight.Object);
            _completeMaze = new Maze(_completeCells);
        }

        [TestMethod]
        public void Constructor_WithDimensions_SetsDimensions()
        {
            var maze = new Maze(_dimensions);
            Assert.AreEqual(_dimensions, maze.Dimensions);
        }

        [TestMethod]
        public void Constructor_WithDimensions_InitializesMazeCells()
        {
            var maze = new Maze(_dimensions);
            Assert.IsNotNull(maze.MazeCells);
            Assert.IsTrue(maze.MazeCells.Count == 0);
        }

        [TestMethod]
        public void Constructor_WithCells_SetsDimensionsFromCells()
        {
            for (uint col = 0; col < WidthVal2; col++)
                for (uint row = 0; row < HeightVal2; row++)
                    _cells.Add(new MazeCell((col, row)));

            var maze = new Maze(_cells);
            Assert.AreEqual(WidthVal2, maze.Dimensions.width);
            Assert.AreEqual(HeightVal2, maze.Dimensions.height);
        }

        [TestMethod]
        public void Constructor_WithCells_SetsMazeCellsReference()
        {
            for (uint col = 0; col < WidthVal2; col++)
                for (uint row = 0; row < HeightVal2; row++)
                    _cells.Add(new MazeCell((col, row)));

            var maze = new Maze(_cells);
            Assert.AreSame(_cells, maze.MazeCells);
        }
    }
}
