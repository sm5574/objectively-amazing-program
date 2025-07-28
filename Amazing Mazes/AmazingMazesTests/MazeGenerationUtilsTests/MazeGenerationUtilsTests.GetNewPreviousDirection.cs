using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetNewPreviousDirection_BothNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(null, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousNull_NextUp_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(null, Direction.Up);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousNull_NextDown_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(null, Direction.Down);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousNull_NextLeft_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(null, Direction.Left);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousNull_NextRight_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(null, Direction.Right);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousUp_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Up, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousDown_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Down, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousLeft_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Left, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousRight_NextNull_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Right, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousUp_NextUp_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Up, Direction.Up);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousDown_NextDown_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Down, Direction.Down);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousLeft_NextLeft_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Left, Direction.Left);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousRight_NextRight_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Right, Direction.Right);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousDown_NextUp_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Down, Direction.Up);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousLeft_NextDown_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Left, Direction.Down);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousRight_NextLeft_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Right, Direction.Left);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetNewPreviousDirection_PreviousUp_NextRight_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetNewPreviousDirection(Direction.Up, Direction.Right);
            Assert.AreEqual(Direction.Right, result);
        }
    }
}