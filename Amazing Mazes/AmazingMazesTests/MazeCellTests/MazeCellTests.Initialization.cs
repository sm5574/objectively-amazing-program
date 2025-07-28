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
        public void Constructor_SetsCoordinates()
        {
            Assert.AreEqual(_coordinates, _cell.Coordinates);
        }

        [TestMethod]
        public void Constructor_SetsPathStepToZero()
        {
            Assert.AreEqual(0u, _cell.PathStep);
        }

        [TestMethod]
        public void Constructor_InitializesAllWallsToNull()
        {
            Assert.IsNull(_cell.GetWall(Direction.Up));
            Assert.IsNull(_cell.GetWall(Direction.Right));
            Assert.IsNull(_cell.GetWall(Direction.Down));
            Assert.IsNull(_cell.GetWall(Direction.Left));
        }
    }
}
