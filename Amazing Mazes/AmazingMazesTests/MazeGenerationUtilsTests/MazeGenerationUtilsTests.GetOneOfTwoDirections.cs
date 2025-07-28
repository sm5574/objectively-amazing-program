using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetOneOfTwoDirections_ForceFirst_ReturnsFirstDirection()
        {
            var result = MazeGenerationUtils.GetOneOfTwoDirections(
                Direction.Left, Direction.Right, true, mockRandom0.Object);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetOneOfTwoDirections_CoversBoth()
        {
            var result = MazeGenerationUtils.GetOneOfTwoDirections(
                Direction.Left, Direction.Right, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);

            result = MazeGenerationUtils.GetOneOfTwoDirections(
                Direction.Left, Direction.Right, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Right, result);
        }
    }
}