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
        public void ExitExists_WhenCellIsOpenAndSet_ReturnsTrue()
        {
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);

            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

            _cells.Add(_cellUpperLeft.Object);
            _cells.Add(_cellUpperRight.Object);
            _cells.Add(_cellLowerLeft.Object);
            _cells.Add(_cellLowerRight.Object);

            var maze = new Maze(_cells);

            Assert.IsTrue(maze.ExitExists());
        }

        [TestMethod]
        public void ExitExists_WhenCellIsOpenAndNotSet_ReturnsFalse()
        {
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_closedWall.Object);
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_openWall.Object);

            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _cellLowerRight.Setup(x => x.IsSet()).Returns(false);

            _cells.Add(_cellUpperLeft.Object);
            _cells.Add(_cellUpperRight.Object);
            _cells.Add(_cellLowerLeft.Object);
            _cells.Add(_cellLowerRight.Object);

            var maze = new Maze(_cells);

            Assert.IsFalse(maze.ExitExists());
        }

        [TestMethod]
        public void ExitExists_WhenCellIsNotOpenAndIsSet_ReturnsFalse()
        {
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Left)).Returns(_openWall.Object);
            _cellLowerLeft.Setup(x => x.GetWall(Direction.Right)).Returns(_openWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Up)).Returns(_openWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Left)).Returns(_openWall.Object);
            _cellLowerRight.Setup(x => x.GetWall(Direction.Right)).Returns(_openWall.Object);
            _cellUpperLeft.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);
            _cellUpperRight.Setup(x => x.GetWall(Direction.Down)).Returns(_closedWall.Object);

            _cellUpperLeft.Setup(x => x.IsSet()).Returns(true);
            _cellUpperRight.Setup(x => x.IsSet()).Returns(true);
            _cellLowerLeft.Setup(x => x.IsSet()).Returns(true);
            _cellLowerRight.Setup(x => x.IsSet()).Returns(true);

            _cells.Add(_cellUpperLeft.Object);
            _cells.Add(_cellUpperRight.Object);
            _cells.Add(_cellLowerLeft.Object);
            _cells.Add(_cellLowerRight.Object);

            var maze = new Maze(_cells);

            Assert.IsFalse(maze.ExitExists());
        }
    }
}
