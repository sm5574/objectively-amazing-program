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
        public void CreateWall_Up_ShouldSetAndReturnWall()
        {
            Assert.IsNull(_cell.GetWall(Direction.Up));
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Up, wall);
            Assert.AreSame(wall, _cell.GetWall(Direction.Up));
        }

        [TestMethod]
        public void CreateWall_Down_ShouldSetAndReturnWall()
        {
            Assert.IsNull(_cell.GetWall(Direction.Down));
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Down, wall);
            Assert.AreSame(wall, _cell.GetWall(Direction.Down));
        }

        [TestMethod]
        public void CreateWall_Left_ShouldSetAndReturnWall()
        {
            Assert.IsNull(_cell.GetWall(Direction.Left));
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Left, wall);
            Assert.AreSame(wall, _cell.GetWall(Direction.Left));
        }

        [TestMethod]
        public void CreateWall_Right_ShouldSetAndReturnWall()
        {
            Assert.IsNull(_cell.GetWall(Direction.Right));
            var wall = new MazeCellWall();
            _cell.CreateWall(Direction.Right, wall);
            Assert.AreSame(wall, _cell.GetWall(Direction.Right));
        }
    }
}
