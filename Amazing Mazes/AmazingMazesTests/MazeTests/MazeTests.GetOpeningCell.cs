using ObjectivelyAmazingProgramCore;
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
    public partial class MazeTests
    {
        [TestMethod]
        public void GetOpeningCell_WhenCellIsOpenAndSet_ReturnsCell()
        {
            // Setup: Only upper right cell has open top wall and is set  
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

            _cells.Add(_cellUpperLeft.Object);
            _cells.Add(_cellUpperRight.Object);
            _cells.Add(_cellLowerLeft.Object);
            _cells.Add(_cellLowerRight.Object);

            var maze = new Maze(_cells);

            var cell = maze.GetOpeningCell();
            Assert.IsNotNull(cell);
            Assert.AreEqual(_cellUpperRight.Object.Coordinates, cell!.Coordinates);
        }

        [TestMethod]
        public void GetOpeningCell_WhenCellIsOpenAndNotSet_ReturnsNull()
        {
            // Setup: Only upper right cell has open top wall and is not set  
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(false);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

            _cells.Add(_cellUpperLeft.Object);
            _cells.Add(_cellUpperRight.Object);
            _cells.Add(_cellLowerLeft.Object);
            _cells.Add(_cellLowerRight.Object);

            var maze = new Maze(_cells);

            var cell = maze.GetOpeningCell();
            Assert.IsNull(cell);
        }

        [TestMethod]
        public void GetOpeningCell_WhenNoCellIsOpenAndSet_ReturnsNull()
        {
            // Setup: No cell has open top wall, all are set  
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

            _cells.Add(_cellUpperLeft.Object);
            _cells.Add(_cellUpperRight.Object);
            _cells.Add(_cellLowerLeft.Object);
            _cells.Add(_cellLowerRight.Object);

            var maze = new Maze(_cells);

            var cell = maze.GetOpeningCell();
            Assert.IsNull(cell);
        }
    }
}
