using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeCellTests
    {
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SetWallStatus_Up_WhenWallIsNull_ShouldThrow()
        {
            _cell.SetWallStatus(Direction.Up, WallStatus.Open);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SetWallStatus_Down_WhenWallIsNull_ShouldThrow()
        {
            _cell.SetWallStatus(Direction.Down, WallStatus.Open);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SetWallStatus_Left_WhenWallIsNull_ShouldThrow()
        {
            _cell.SetWallStatus(Direction.Left, WallStatus.Open);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SetWallStatus_Right_WhenWallIsNull_ShouldThrow()
        {
            _cell.SetWallStatus(Direction.Right, WallStatus.Open);
        }

        [TestMethod]
        public void SetWallStatus_Up_ShouldChangeStatus()
        {
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Up, wall);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Up)!.Status);
            _cell.SetWallStatus(Direction.Up, WallStatus.Open);
            Assert.AreEqual(WallStatus.Open, _cell.GetWall(Direction.Up)!.Status);
            _cell.SetWallStatus(Direction.Up, WallStatus.Closed);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Up)!.Status);
        }

        [TestMethod]
        public void SetWallStatus_Down_ShouldChangeStatus()
        {
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Down, wall);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Down)!.Status);
            _cell.SetWallStatus(Direction.Down, WallStatus.Open);
            Assert.AreEqual(WallStatus.Open, _cell.GetWall(Direction.Down)!.Status);
            _cell.SetWallStatus(Direction.Down, WallStatus.Closed);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Down)!.Status);
        }

        [TestMethod]
        public void SetWallStatus_Left_ShouldChangeStatus()
        {
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Left, wall);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Left)!.Status);
            _cell.SetWallStatus(Direction.Left, WallStatus.Open);
            Assert.AreEqual(WallStatus.Open, _cell.GetWall(Direction.Left)!.Status);
            _cell.SetWallStatus(Direction.Left, WallStatus.Closed);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Left)!.Status);
        }

        [TestMethod]
        public void SetWallStatus_Right_ShouldChangeStatus()
        {
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Right, wall);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Right)!.Status);
            _cell.SetWallStatus(Direction.Right, WallStatus.Open);
            Assert.AreEqual(WallStatus.Open, _cell.GetWall(Direction.Right)!.Status);
            _cell.SetWallStatus(Direction.Right, WallStatus.Closed);
            Assert.AreEqual(WallStatus.Closed, _cell.GetWall(Direction.Right)!.Status);
        }
    }
}
