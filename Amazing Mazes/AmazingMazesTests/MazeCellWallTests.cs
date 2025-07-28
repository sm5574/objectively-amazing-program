using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Tests
{
    [TestClass()]
    public class MazeCellWallTests
    {
        [TestMethod()]
        public void ShouldInitializeClosed_Test()
        {
            var mazeCellWall = new MazeCellWall();

            Assert.IsTrue(mazeCellWall?.Status == Enums.WallStatus.Closed);
        }
    }
}