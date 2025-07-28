using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetOneOfThreeDirections_CoversAll()
        {
            var result = MazeGenerationUtils.GetOneOfThreeDirections(
                Direction.Left, Direction.Up, Direction.Right, mockRandom0.Object);
            Assert.AreEqual(Direction.Right, result);

            result = MazeGenerationUtils.GetOneOfThreeDirections(
                Direction.Left, Direction.Up, Direction.Right, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);

            result = MazeGenerationUtils.GetOneOfThreeDirections(
                Direction.Left, Direction.Up, Direction.Right, mockRandom2.Object);
            Assert.AreEqual(Direction.Up, result);
        }
    }
}