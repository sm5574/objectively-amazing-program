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
        public void IsComplete_WhenAllCellsSetAndExitExists_ReturnsTrue()
        {
            Assert.IsTrue(_completeMaze!.IsComplete());
        }

        [TestMethod]
        public void IsComplete_WhenUnsetCellsExist_ReturnsFalse()
        {
            Assert.IsFalse(_unsetMaze!.IsComplete());
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void IsComplete_WhenAllCellsSetButNoExit_ThrowsApplicationException()
        {
            _ = _setMaze!.IsComplete();
        }
    }
}
