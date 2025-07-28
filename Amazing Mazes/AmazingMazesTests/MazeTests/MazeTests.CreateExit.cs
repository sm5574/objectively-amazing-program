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
        [ExpectedException(typeof(ApplicationException))]
        public void CreateExit_WhenExitExists_ThrowsApplicationException()
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

            var cell = new MazeCell(_lowerRight);
            maze.CreateExit(cell);
        }

        [TestMethod]
        public void CreateExit_WhenCellOnBottomRowAndNoExit_SetsBottomWallToOpen()
        {
            var dimensions = (2u, 2u);
            var maze = new Maze(dimensions);
            var cell = new MazeCell((2, 1));
            cell.CreateWall(Direction.Down, new MazeCellWall());

            Assert.AreEqual(WallStatus.Closed, cell.GetWall(Direction.Down)!.Status);

            maze.CreateExit(cell);

            Assert.AreEqual(WallStatus.Open, cell.GetWall(Direction.Down)!.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateExit_WhenCellNotOnBottomRow_ThrowsArgumentOutOfRangeException()
        {
            var dimensions = (2u, 2u);
            var maze = new Maze(dimensions);
            var cell = new MazeCell((1, 0));
            maze.CreateExit(cell);
        }
    }
}
