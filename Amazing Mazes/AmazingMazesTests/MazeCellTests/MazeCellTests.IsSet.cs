using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeCellTests
    {
        [TestMethod]
        public void IsSet_ReturnsFalse_WhenPathStepIsZero()
        {
            Assert.IsFalse(_cell.IsSet());
        }

        [TestMethod]
        public void IsSet_ReturnsTrue_WhenPathStepIsGreaterThanZero()
        {
            _cell.SetPathStep(1);
            Assert.IsTrue(_cell.IsSet());
        }
    }
}
