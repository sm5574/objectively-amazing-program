using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetProhibitedDirection_BothNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(null, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousNull_NextUp_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(null, Direction.Up);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousNull_NextDown_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(null, Direction.Down);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousNull_NextLeft_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(null, Direction.Left);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousNull_NextRight_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(null, Direction.Right);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousUp_NextDown_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Up, Direction.Down);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousUp_NextLeft_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Up, Direction.Left);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousUp_NextRight_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Up, Direction.Right);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousDown_NextUp_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Down, Direction.Up);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousDown_NextLeft_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Down, Direction.Left);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousDown_NextRight_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Down, Direction.Right);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousLeft_NextUp_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Left, Direction.Up);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousLeft_NextDown_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Left, Direction.Down);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousLeft_NextRight_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Left, Direction.Right);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousRight_NextUp_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Right, Direction.Up);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousRight_NextDown_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Right, Direction.Down);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousRight_NextLeft_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Right, Direction.Left);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousUp_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Up, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousDown_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Down, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousLeft_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Left, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_BothNull_ProbabilityNotMatch_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(null, null, mockRandom1.Object, RandomProbability3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousUp_NextUp_ProbabilityNotMatch_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Up, Direction.Up, mockRandom1.Object, RandomProbability3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousDown_NextDown_ProbabilityNotMatch_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Down, Direction.Down, mockRandom1.Object, RandomProbability3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousLeft_NextLeft_ProbabilityNotMatch_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Left, Direction.Left, mockRandom1.Object, RandomProbability3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousRight_NextRight_ProbabilityNotMatch_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Right, Direction.Right, mockRandom1.Object, RandomProbability3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousUp_NextUp_ProbabilityMatch_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Up, Direction.Up, mockRandom0.Object, RandomProbability3);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousDown_NextDown_ProbabilityMatch_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Down, Direction.Down, mockRandom0.Object, RandomProbability3);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousLeft_NextLeft_ProbabilityMatch_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Left, Direction.Left, mockRandom0.Object, RandomProbability3);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetProhibitedDirection_PreviousRight_NextRight_ProbabilityMatch_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetProhibitedDirection(Direction.Right, Direction.Right, mockRandom0.Object, RandomProbability3);
            Assert.AreEqual(Direction.Right, result);
        }
    }
}