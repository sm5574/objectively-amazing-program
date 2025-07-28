using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetAvailableDirections_OnlyUpAvailable_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, Blocked, Blocked, Blocked, null);
            Assert.AreEqual(Up, result);
        }

        [TestMethod]
        public void GetAvailableDirections_OnlyDownAvailable_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, Blocked, NotBlocked, Blocked, null);
            Assert.AreEqual(Down, result);
        }

        [TestMethod]
        public void GetAvailableDirections_OnlyLeftAvailable_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, Blocked, Blocked, NotBlocked, null);
            Assert.AreEqual(Left, result);
        }

        [TestMethod]
        public void GetAvailableDirections_OnlyRightAvailable_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, NotBlocked, Blocked, Blocked, null);
            Assert.AreEqual(Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_UpAndDownAvailable_ReturnsUpPlusDown()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, Blocked, NotBlocked, Blocked, null);
            Assert.AreEqual(Up + Down, result);
        }

        [TestMethod]
        public void GetAvailableDirections_UpAndLeftAvailable_ReturnsUpPlusLeft()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, Blocked, Blocked, NotBlocked, null);
            Assert.AreEqual(Up + Left, result);
        }

        [TestMethod]
        public void GetAvailableDirections_UpAndRightAvailable_ReturnsUpPlusRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, NotBlocked, Blocked, Blocked, null);
            Assert.AreEqual(Up + Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_DownAndLeftAvailable_ReturnsDownPlusLeft()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, Blocked, NotBlocked, NotBlocked, null);
            Assert.AreEqual(Down + Left, result);
        }

        [TestMethod]
        public void GetAvailableDirections_DownAndRightAvailable_ReturnsDownPlusRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, NotBlocked, NotBlocked, Blocked, null);
            Assert.AreEqual(Down + Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_LeftAndRightAvailable_ReturnsLeftPlusRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, NotBlocked, Blocked, NotBlocked, null);
            Assert.AreEqual(Left + Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_UpDownLeftAvailable_ReturnsUpPlusDownPlusLeft()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, Blocked, NotBlocked, NotBlocked, null);
            Assert.AreEqual(Up + Down + Left, result);
        }

        [TestMethod]
        public void GetAvailableDirections_UpDownRightAvailable_ReturnsUpPlusDownPlusRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, NotBlocked, NotBlocked, Blocked, null);
            Assert.AreEqual(Up + Down + Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_UpLeftRightAvailable_ReturnsUpPlusLeftPlusRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, NotBlocked, Blocked, NotBlocked, null);
            Assert.AreEqual(Up + Left + Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_DownLeftRightAvailable_ReturnsDownPlusLeftPlusRight()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(Blocked, NotBlocked, NotBlocked, NotBlocked, null);
            Assert.AreEqual(Down + Left + Right, result);
        }

        [TestMethod]
        public void GetAvailableDirections_AllDirectionsAvailable_ReturnsSumOfAll()
        {
            var result = MazeGenerationUtils.GetAvailableDirections(NotBlocked, NotBlocked, NotBlocked, NotBlocked, null);
            Assert.AreEqual(Up + Down + Left + Right, result);
        }
    }
}