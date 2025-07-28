using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    //[TestClass]
    //public class MazeTests_Constructor
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;
    //    private (uint column, uint row) _dimensions;
    //    private List<IMazeCell> _cells = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _cells = new List<IMazeCell>();
    //        for (uint col = 0; col < Width; col++)
    //            for (uint row = 0; row < Height; row++)
    //                _cells.Add(new MazeCell((col, row)));
    //    }

    //    [TestMethod]
    //    public void Constructor_WithDimensions_SetsDimensions()
    //    {
    //        var maze = new Maze(_dimensions);
    //        Assert.AreEqual(_dimensions, maze.Dimensions);
    //    }

    //    [TestMethod]
    //    public void Constructor_WithDimensions_InitializesMazeCells()
    //    {
    //        var maze = new Maze(_dimensions);
    //        Assert.IsNotNull(maze.MazeCells);
    //        Assert.IsTrue(maze.MazeCells.Count == 0);
    //    }

    //    [TestMethod]
    //    public void Constructor_WithCells_SetsDimensionsFromCells()
    //    {
    //        var maze = new Maze(_cells);
    //        Assert.AreEqual(Width, maze.Dimensions.width);
    //        Assert.AreEqual(Height, maze.Dimensions.height);
    //    }

    //    [TestMethod]
    //    public void Constructor_WithCells_SetsMazeCellsReference()
    //    {
    //        var maze = new Maze(_cells);
    //        Assert.AreSame(_cells, maze.MazeCells);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_AddCell_GetCell
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;
    //    private (uint column, uint row) _dimensions;
    //    private (uint column, uint row) _validCell;
    //    private (uint column, uint row) _colZero;
    //    private (uint column, uint row) _rowZero;
    //    private (uint column, uint row) _colOutOfBounds;
    //    private (uint column, uint row) _rowOutOfBounds;
    //    private IMaze _maze = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _validCell = (Width - 1, Height - 1);
    //        _colZero = (0, Height);
    //        _rowZero = (Width, 0);
    //        _colOutOfBounds = (Width + 1, Height);
    //        _rowOutOfBounds = (Width, Height + 1);
    //        _maze = new Maze(_dimensions);
    //    }

    //    [TestMethod]
    //    public void AddCell_ThenGetCell_ReturnsCellWithMatchingCoordinates()
    //    {
    //        _maze.AddCell(_validCell);
    //        var cell = _maze.GetCell(_validCell);
    //        Assert.IsNotNull(cell);
    //        Assert.AreEqual(_validCell, cell!.Coordinates);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ApplicationException))]
    //    public void AddCell_WhenCellAlreadyExists_ThrowsApplicationException()
    //    {
    //        _maze.AddCell(_validCell);
    //        _maze.AddCell(_validCell);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void AddCell_WhenColumnIsZero_ThrowsArgumentOutOfRangeException()
    //    {
    //        _maze.AddCell(_colZero);
    //        _maze.AddCell(_colZero);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void AddCell_WhenColumnExceedsBoundary_ThrowsArgumentOutOfRangeException()
    //    {
    //        _maze.AddCell(_colOutOfBounds);
    //        _maze.AddCell(_colOutOfBounds);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void AddCell_WhenRowIsZero_ThrowsArgumentOutOfRangeException()
    //    {
    //        _maze.AddCell(_rowZero);
    //        _maze.AddCell(_rowZero);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void AddCell_WhenRowExceedsBoundary_ThrowsArgumentOutOfRangeException()
    //    {
    //        _maze.AddCell(_rowOutOfBounds);
    //        _maze.AddCell(_rowOutOfBounds);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_GetNeighbor
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _maze = null!;
    //    private List<IMazeCell> _cells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _cellLowerRight = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _cells = new List<IMazeCell>();

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _cellLowerRight = new Mock<IMazeCell>();

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _cellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);
    //    }

    //    [TestMethod]
    //    public void GetNeighbor_Up_ReturnsUpperNeighbor()
    //    {
    //        var cell = _maze.GetCell(_lowerLeft);
    //        Assert.IsNotNull(cell);
    //        var neighbor = _maze.GetNeighbor(cell, Direction.Up);
    //        Assert.IsNotNull(neighbor);
    //        Assert.AreEqual(_cellUpperLeft.Object.Coordinates, neighbor!.Coordinates);
    //    }

    //    [TestMethod]
    //    public void GetNeighbor_Down_ReturnsLowerNeighbor()
    //    {
    //        var cell = _maze.GetCell(_upperLeft);
    //        Assert.IsNotNull(cell);
    //        var neighbor = _maze.GetNeighbor(cell, Direction.Down);
    //        Assert.IsNotNull(neighbor);
    //        Assert.AreEqual(_cellLowerLeft.Object.Coordinates, neighbor!.Coordinates);
    //    }

    //    [TestMethod]
    //    public void GetNeighbor_Left_ReturnsLeftNeighbor()
    //    {
    //        var cell = _maze.GetCell(_lowerRight);
    //        Assert.IsNotNull(cell);
    //        var neighbor = _maze.GetNeighbor(cell, Direction.Left);
    //        Assert.IsNotNull(neighbor);
    //        Assert.AreEqual(_cellLowerLeft.Object.Coordinates, neighbor!.Coordinates);
    //    }

    //    [TestMethod]
    //    public void GetNeighbor_Right_ReturnsRightNeighbor()
    //    {
    //        var cell = _maze.GetCell(_lowerLeft);
    //        Assert.IsNotNull(cell);
    //        var neighbor = _maze.GetNeighbor(cell, Direction.Right);
    //        Assert.IsNotNull(neighbor);
    //        Assert.AreEqual(_cellLowerRight.Object.Coordinates, neighbor!.Coordinates);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void GetNeighbor_CellIsNull_ThrowsArgumentNullException()
    //    {
    //        _ = _maze.GetNeighbor(null, Direction.Up);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_GetUnsetCell
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _setMaze = null!;
    //    private IMaze _unsetMaze = null!;
    //    private List<IMazeCell> _setCells = null!;
    //    private List<IMazeCell> _unsetCells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _setCellLowerRight = null!;
    //    private Mock<IMazeCell> _unsetCellLowerRight = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _setCells = new List<IMazeCell>();
    //        _unsetCells = new List<IMazeCell>();

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _setCellLowerRight = new Mock<IMazeCell>();
    //        _unsetCellLowerRight = new Mock<IMazeCell>();

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _setCellLowerRight.Setup(x => x.IsSet()).Returns(true);
    //        _unsetCellLowerRight.Setup(x => x.IsSet()).Returns(false);

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _setCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
    //        _unsetCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);

    //        _setCells.Add(_cellUpperLeft.Object);
    //        _setCells.Add(_cellUpperRight.Object);
    //        _setCells.Add(_cellLowerLeft.Object);
    //        _setCells.Add(_setCellLowerRight.Object);

    //        _unsetCells.Add(_cellUpperLeft.Object);
    //        _unsetCells.Add(_cellUpperRight.Object);
    //        _unsetCells.Add(_cellLowerLeft.Object);
    //        _unsetCells.Add(_unsetCellLowerRight.Object);

    //        _setMaze = new Maze(_setCells);
    //        _unsetMaze = new Maze(_unsetCells);
    //    }

    //    [TestMethod]
    //    public void GetUnsetCell_WhenUnsetCellExists_ReturnsUnsetCell()
    //    {
    //        var cell = _unsetMaze.GetUnsetCell();
    //        Assert.IsNotNull(cell);
    //        Assert.AreEqual(_unsetCellLowerRight.Object.Coordinates, cell!.Coordinates);
    //    }

    //    [TestMethod]
    //    public void GetUnsetCell_WhenAllCellsSet_ReturnsNull()
    //    {
    //        var cell = _setMaze.GetUnsetCell();
    //        Assert.IsNull(cell);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_IsComplete
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _setMaze = null!;
    //    private IMaze _unsetMaze = null!;
    //    private IMaze _completeMaze = null!;
    //    private List<IMazeCell> _setCells = null!;
    //    private List<IMazeCell> _unsetCells = null!;
    //    private List<IMazeCell> _completeCells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _setCellLowerRight = null!;
    //    private Mock<IMazeCell> _unsetCellLowerRight = null!;
    //    private Mock<IMazeCell> _openCellLowerRight = null!;
    //    private Mock<IMazeCellWall> _closedWall = null!;
    //    private Mock<IMazeCellWall> _openWall = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _setCells = new List<IMazeCell>();
    //        _unsetCells = new List<IMazeCell>();
    //        _completeCells = new List<IMazeCell>();

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _setCellLowerRight = new Mock<IMazeCell>();
    //        _unsetCellLowerRight = new Mock<IMazeCell>();
    //        _openCellLowerRight = new Mock<IMazeCell>();

    //        _closedWall = new Mock<IMazeCellWall>();
    //        _openWall = new Mock<IMazeCellWall>();

    //        _closedWall.Setup(x => x.Status).Returns(WallStatus.Closed);
    //        _openWall.Setup(x => x.Status).Returns(WallStatus.Open);

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _setCellLowerRight.Setup(x => x.IsSet()).Returns(true);
    //        _openCellLowerRight.Setup(x => x.IsSet()).Returns(true);
    //        _unsetCellLowerRight.Setup(x => x.IsSet()).Returns(false);

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _setCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
    //        _unsetCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
    //        _openCellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);

    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _setCellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _openCellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _unsetCellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);

    //        _setCells.Add(_cellUpperLeft.Object);
    //        _setCells.Add(_cellUpperRight.Object);
    //        _setCells.Add(_cellLowerLeft.Object);
    //        _setCells.Add(_setCellLowerRight.Object);

    //        _unsetCells.Add(_cellUpperLeft.Object);
    //        _unsetCells.Add(_cellUpperRight.Object);
    //        _unsetCells.Add(_cellLowerLeft.Object);
    //        _unsetCells.Add(_unsetCellLowerRight.Object);

    //        _completeCells.Add(_cellUpperLeft.Object);
    //        _completeCells.Add(_cellUpperRight.Object);
    //        _completeCells.Add(_cellLowerLeft.Object);
    //        _completeCells.Add(_openCellLowerRight.Object);

    //        _setMaze = new Maze(_setCells);
    //        _unsetMaze = new Maze(_unsetCells);
    //        _completeMaze = new Maze(_completeCells);
    //    }

    //    [TestMethod]
    //    public void IsComplete_WhenAllCellsSetAndExitExists_ReturnsTrue()
    //    {
    //        Assert.IsTrue(_completeMaze.IsComplete());
    //    }

    //    [TestMethod]
    //    public void IsComplete_WhenUnsetCellsExist_ReturnsFalse()
    //    {
    //        Assert.IsFalse(_unsetMaze.IsComplete());
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ApplicationException))]
    //    public void IsComplete_WhenAllCellsSetButNoExit_ThrowsApplicationException()
    //    {
    //        _ = _setMaze.IsComplete();
    //    }
    //}

    //[TestClass]
    //public class MazeTests_GetOpeningCell
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _maze = null!;
    //    private List<IMazeCell> _cells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _cellLowerRight = null!;
    //    private Mock<IMazeCellWall> _closedWall = null!;
    //    private Mock<IMazeCellWall> _openWall = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _cells = new List<IMazeCell>();

    //        _closedWall = new Mock<IMazeCellWall>();
    //        _openWall = new Mock<IMazeCellWall>();
    //        _closedWall.Setup(x => x.Status).Returns(WallStatus.Closed);
    //        _openWall.Setup(x => x.Status).Returns(WallStatus.Open);

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _cellLowerRight = new Mock<IMazeCell>();

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _cellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
    //    }

    //    [TestMethod]
    //    public void GetOpeningCell_WhenCellIsOpenAndSet_ReturnsCell()
    //    {
    //        // Setup: Only upper right cell has open top wall and is set
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        var cell = _maze.GetOpeningCell();
    //        Assert.IsNotNull(cell);
    //        Assert.AreEqual(_cellUpperRight.Object.Coordinates, cell!.Coordinates);
    //    }

    //    [TestMethod]
    //    public void GetOpeningCell_WhenCellIsOpenAndNotSet_ReturnsNull()
    //    {
    //        // Setup: Only upper right cell has open top wall and is not set
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(false);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        var cell = _maze.GetOpeningCell();
    //        Assert.IsNull(cell);
    //    }

    //    [TestMethod]
    //    public void GetOpeningCell_WhenNoCellIsOpenAndSet_ReturnsNull()
    //    {
    //        // Setup: No cell has open top wall, all are set
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        var cell = _maze.GetOpeningCell();
    //        Assert.IsNull(cell);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_ExitExists
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _maze = null!;
    //    private List<IMazeCell> _cells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _cellLowerRight = null!;
    //    private Mock<IMazeCellWall> _closedWall = null!;
    //    private Mock<IMazeCellWall> _openWall = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _cells = new List<IMazeCell>();

    //        _closedWall = new Mock<IMazeCellWall>();
    //        _openWall = new Mock<IMazeCellWall>();
    //        _closedWall.Setup(x => x.Status).Returns(WallStatus.Closed);
    //        _openWall.Setup(x => x.Status).Returns(WallStatus.Open);

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _cellLowerRight = new Mock<IMazeCell>();

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _cellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
    //    }

    //    [TestMethod]
    //    public void ExitExists_WhenCellIsOpenAndSet_ReturnsTrue()
    //    {
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        Assert.IsTrue(_maze.ExitExists());
    //    }

    //    [TestMethod]
    //    public void ExitExists_WhenCellIsOpenAndNotSet_ReturnsFalse()
    //    {
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(false);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        Assert.IsFalse(_maze.ExitExists());
    //    }

    //    [TestMethod]
    //    public void ExitExists_WhenCellIsNotOpenAndSet_ReturnsFalse()
    //    {
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_openWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_openWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_openWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_openWall.Object);
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        Assert.IsFalse(_maze.ExitExists());
    //    }
    //}

    //[TestClass]
    //public class MazeTests_GetSetCellCount
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _maze = null!;
    //    private List<IMazeCell> _cells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _cellLowerRight = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _cells = new List<IMazeCell>();

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _cellLowerRight = new Mock<IMazeCell>();

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _cellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(false);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);
    //    }

    //    [TestMethod]
    //    public void ReturnsNumberOfSetCells()
    //    {
    //        Assert.IsTrue(_maze.GetSetCellCount() == 3);
    //    }

    //    [TestMethod]
    //    public void GetSetCellCount_WhenSomeCellsSet_ReturnsCorrectCount()
    //    {
    //        var count = _maze.GetSetCellCount();
    //        Assert.AreEqual(3u, count);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_SetCellPathStep
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;

    //    private (uint column, uint row) _dimensions;
    //    private (uint column, uint row) _cell1;
    //    private (uint column, uint row) _cell2;
    //    private (uint column, uint row) _cell3;
    //    private IMaze _maze = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _cell1 = (Width, Height);
    //        _cell2 = (Width - 1, Height - 1);
    //        _cell3 = (Width - 2, Height - 2);
    //        _maze = new Maze(_dimensions);
    //    }

    //    [TestMethod]
    //    public void SetCellPathStep_WhenCalled_SetsPathStepEqualToSetCellCount()
    //    {
    //        _maze.AddCell(_cell2);
    //        var cell = _maze.GetCell(_cell2);
    //        Assert.IsNotNull(cell);

    //        _maze.SetCellPathStep(cell!);
    //        Assert.AreEqual(_maze.GetSetCellCount(), cell!.PathStep);

    //        _maze.AddCell(_cell3);
    //        var cell2 = _maze.GetCell(_cell3);
    //        Assert.IsNotNull(cell2);

    //        _maze.SetCellPathStep(cell2!);
    //        Assert.AreEqual(_maze.GetSetCellCount(), cell2!.PathStep);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ApplicationException))]
    //    public void SetCellPathStep_WhenCellIsAlreadySet_ThrowsApplicationException()
    //    {
    //        _maze.AddCell(_cell2);
    //        var cell = _maze.GetCell(_cell2);
    //        Assert.IsNotNull(cell);

    //        _maze.SetCellPathStep(cell!);
    //        _maze.SetCellPathStep(cell!);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void SetCellPathStep_WhenCellIsNull_ThrowsArgumentNullException()
    //    {
    //        _maze.AddCell(_cell2);
    //        _maze.SetCellPathStep(null);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_CreateExit
    //{
    //    private const uint Width = 1;
    //    private const uint Height = 1;

    //    private (uint column, uint row) _upperLeft;
    //    private (uint column, uint row) _upperRight;
    //    private (uint column, uint row) _lowerLeft;
    //    private (uint column, uint row) _lowerRight;

    //    private IMaze _maze = null!;
    //    private List<IMazeCell> _cells = null!;
    //    private Mock<IMazeCell> _cellUpperLeft = null!;
    //    private Mock<IMazeCell> _cellUpperRight = null!;
    //    private Mock<IMazeCell> _cellLowerLeft = null!;
    //    private Mock<IMazeCell> _cellLowerRight = null!;
    //    private Mock<IMazeCellWall> _closedWall = null!;
    //    private Mock<IMazeCellWall> _openWall = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _upperLeft = (0, 0);
    //        _upperRight = (Width, 0);
    //        _lowerLeft = (0, Height);
    //        _lowerRight = (Width, Height);

    //        _cells = new List<IMazeCell>();

    //        _closedWall = new Mock<IMazeCellWall>();
    //        _openWall = new Mock<IMazeCellWall>();
    //        _closedWall.Setup(x => x.Status).Returns(WallStatus.Closed);
    //        _openWall.Setup(x => x.Status).Returns(WallStatus.Open);

    //        _cellUpperLeft = new Mock<IMazeCell>();
    //        _cellUpperRight = new Mock<IMazeCell>();
    //        _cellLowerLeft = new Mock<IMazeCell>();
    //        _cellLowerRight = new Mock<IMazeCell>();

    //        _cellUpperLeft.Setup(x => x.Coordinates).Returns(_upperLeft);
    //        _cellUpperRight.Setup(x => x.Coordinates).Returns(_upperRight);
    //        _cellLowerLeft.Setup(x => x.Coordinates).Returns(_lowerLeft);
    //        _cellLowerRight.Setup(x => x.Coordinates).Returns(_lowerRight);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ApplicationException))]
    //    public void CreateExit_WhenExitExists_ThrowsApplicationException()
    //    {
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
    //        _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
    //        _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
    //        _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
    //        _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);

    //        _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
    //        _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

    //        _cells.Add(_cellUpperLeft.Object);
    //        _cells.Add(_cellUpperRight.Object);
    //        _cells.Add(_cellLowerLeft.Object);
    //        _cells.Add(_cellLowerRight.Object);

    //        _maze = new Maze(_cells);

    //        var cell = new MazeCell(_lowerRight);
    //        _maze.CreateExit(cell);
    //    }

    //    [TestMethod]
    //    public void CreateExit_WhenCellOnBottomRowAndNoExit_SetsBottomWallToOpen()
    //    {
    //        var dimensions = (2u, 2u);
    //        _maze = new Maze(dimensions);
    //        var cell = new MazeCell((2, 1));
    //        cell.CreateWall(Direction.Down, new MazeCellWall());

    //        Assert.AreEqual(WallStatus.Closed, cell.GetWall(Direction.Down)!.Status);

    //        _maze.CreateExit(cell);

    //        Assert.AreEqual(WallStatus.Open, cell.GetWall(Direction.Down)!.Status);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void CreateExit_WhenCellNotOnBottomRow_ThrowsArgumentOutOfRangeException()
    //    {
    //        var dimensions = (2u, 2u);
    //        _maze = new Maze(dimensions);
    //        var cell = new MazeCell((1, 0));
    //        _maze.CreateExit(cell);
    //    }
    //}

    //[TestClass]
    //public class MazeTests_IsCellTopRow
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;

    //    private (uint column, uint row) _dimensions;
    //    private (uint column, uint row) _topRow;
    //    private (uint column, uint row) _notTopRow;
    //    private IMaze _maze = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _topRow = (Width - 1, 0);
    //        _notTopRow = (0, Height - 1);
    //        _maze = new Maze(_dimensions);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void IsCellTopRow_WhenCellIsNull_ThrowsArgumentNullException()
    //    {
    //        _ = _maze.IsCellTopRow(null);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void IsCellTopRow_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
    //    {
    //        _ = _maze.IsCellTopRow(new MazeCell((0, 0)));
    //    }

    //    [TestMethod]
    //    public void IsCellTopRow_WhenCellRowIsZero_ReturnsTrue()
    //    {
    //        _maze.AddCell(_topRow);
    //        var cell = _maze.GetCell(_topRow);
    //        Assert.IsNotNull(cell);
    //        Assert.IsTrue(_maze.IsCellTopRow(cell!));
    //    }

    //    [TestMethod]
    //    public void IsCellTopRow_WhenCellRowIsNotZero_ReturnsFalse()
    //    {
    //        _maze.AddCell(_notTopRow);
    //        var cell = _maze.GetCell(_notTopRow);
    //        Assert.IsNotNull(cell);
    //        Assert.IsFalse(_maze.IsCellTopRow(cell!));
    //    }
    //}

    //[TestClass]
    //public class MazeTests_IsCellLeftEdge
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;

    //    private (uint column, uint row) _dimensions;
    //    private (uint column, uint row) _leftEdge;
    //    private (uint column, uint row) _notLeftEdge;
    //    private IMaze _maze = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _leftEdge = (0, Height - 1);
    //        _notLeftEdge = (Width - 1, 0);
    //        _maze = new Maze(_dimensions);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void IsCellLeftEdge_WhenCellIsNull_ThrowsArgumentNullException()
    //    {
    //        _ = _maze.IsCellLeftEdge(null);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void IsCellLeftEdge_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
    //    {
    //        _ = _maze.IsCellLeftEdge(new MazeCell((0, 0)));
    //    }

    //    [TestMethod]
    //    public void IsCellLeftEdge_WhenCellColumnIsZero_ReturnsTrue()
    //    {
    //        _maze.AddCell(_leftEdge);
    //        var cell = _maze.GetCell(_leftEdge);
    //        Assert.IsNotNull(cell);
    //        Assert.IsTrue(_maze.IsCellLeftEdge(cell!));
    //    }

    //    [TestMethod]
    //    public void IsCellLeftEdge_WhenCellColumnIsNotZero_ReturnsFalse()
    //    {
    //        _maze.AddCell(_notLeftEdge);
    //        var cell = _maze.GetCell(_notLeftEdge);
    //        Assert.IsNotNull(cell);
    //        Assert.IsFalse(_maze.IsCellLeftEdge(cell!));
    //    }
    //}

    //[TestClass]
    //public class MazeTests_IsCellBottomRow
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;

    //    private (uint column, uint row) _dimensions;
    //    private (uint column, uint row) _bottomRow;
    //    private (uint column, uint row) _notBottomRow;
    //    private IMaze _maze = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _bottomRow = (0, Height - 1);
    //        _notBottomRow = (Width - 1, 0);
    //        _maze = new Maze(_dimensions);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void IsCellBottomRow_WhenCellIsNull_ThrowsArgumentNullException()
    //    {
    //        _ = _maze.IsCellBottomRow(null);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void IsCellBottomRow_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
    //    {
    //        _ = _maze.IsCellBottomRow(new MazeCell((0, 0)));
    //    }

    //    [TestMethod]
    //    public void IsCellBottomRow_WhenCellRowIsBottom_ReturnsTrue()
    //    {
    //        _maze.AddCell(_bottomRow);
    //        var cell = _maze.GetCell(_bottomRow);
    //        Assert.IsNotNull(cell);
    //        Assert.IsTrue(_maze.IsCellBottomRow(cell!));
    //    }

    //    [TestMethod]
    //    public void IsCellBottomRow_WhenCellRowIsNotBottom_ReturnsFalse()
    //    {
    //        _maze.AddCell(_notBottomRow);
    //        var cell = _maze.GetCell(_notBottomRow);
    //        Assert.IsNotNull(cell);
    //        Assert.IsFalse(_maze.IsCellBottomRow(cell!));
    //    }
    //}

    //[TestClass]
    //public class MazeTests_IsCellRightEdge
    //{
    //    private const uint Width = 2;
    //    private const uint Height = 2;

    //    private (uint column, uint row) _dimensions;
    //    private (uint column, uint row) _rightEdge;
    //    private (uint column, uint row) _notRightEdge;
    //    private IMaze _maze = null!;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _dimensions = (Width, Height);
    //        _rightEdge = (Width - 1, 0);
    //        _notRightEdge = (0, Height - 1);
    //        _maze = new Maze(_dimensions);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void IsCellRightEdge_WhenCellIsNull_ThrowsArgumentNullException()
    //    {
    //        _ = _maze.IsCellRightEdge(null);
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void IsCellRightEdge_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
    //    {
    //        _ = _maze.IsCellRightEdge(new MazeCell((0, 0)));
    //    }

    //    [TestMethod]
    //    public void IsCellRightEdge_WhenCellColumnIsZero_ReturnsTrue()
    //    {
    //        _maze.AddCell(_rightEdge);
    //        var cell = _maze.GetCell(_rightEdge);
    //        Assert.IsNotNull(cell);
    //        Assert.IsTrue(_maze.IsCellRightEdge(cell!));
    //    }

    //    [TestMethod]
    //    public void IsCellRightEdge_WhenCellColumnIsNotZero_ReturnsFalse()
    //    {
    //        _maze.AddCell(_notRightEdge);
    //        var cell = _maze.GetCell(_notRightEdge);
    //        Assert.IsNotNull(cell);
    //        Assert.IsFalse(_maze.IsCellRightEdge(cell!));
    //    }
    //}
}