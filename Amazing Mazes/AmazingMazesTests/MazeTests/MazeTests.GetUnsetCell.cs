using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeTests
    {
        [TestMethod]
        public void GetUnsetCell_WhenUnsetCellExists_ReturnsUnsetCell()
        {
            var cell = _unsetMaze!.GetUnsetCell();
            Assert.IsNotNull(cell);
            Assert.AreEqual(_unsetCellLowerRight.Object.Coordinates, cell!.Coordinates);
        }

        [TestMethod]
        public void GetUnsetCell_WhenAllCellsSet_ReturnsNull()
        {
            var cell = _setMaze!.GetUnsetCell();
            Assert.IsNull(cell);
        }
    }
}
