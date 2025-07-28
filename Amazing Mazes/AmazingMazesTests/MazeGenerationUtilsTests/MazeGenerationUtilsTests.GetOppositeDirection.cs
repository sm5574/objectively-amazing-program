using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetOppositeDirection_Up_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetOppositeDirection(Direction.Up);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetOppositeDirection_Down_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetOppositeDirection(Direction.Down);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetOppositeDirection_Left_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetOppositeDirection(Direction.Left);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void GetOppositeDirection_Right_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetOppositeDirection(Direction.Right);
            Assert.AreEqual(Direction.Left, result);
        }
    }
}