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
        public void SetPathStep_WithValidValue_UpdatesPathStep()
        {
            const uint pathStep = 100;
            _cell.SetPathStep(pathStep);
            Assert.AreEqual(pathStep, _cell.PathStep);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SetPathStep_WhenCalledTwice_ThrowsApplicationException()
        {
            const uint pathStep = 100;
            _cell.SetPathStep(pathStep);
            _cell.SetPathStep(pathStep);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetPathStep_WithZero_ThrowsArgumentOutOfRangeException()
        {
            _cell.SetPathStep(0);
        }
    }
}
