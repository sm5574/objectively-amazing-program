using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void GetDirectionFromAvailableDirections_OnlyDown_ReturnsDown()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections((int)Direction.Down, false, false);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_OnlyRight_ReturnsRight()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections((int)Direction.Right, false, false);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_OnlyUp_ReturnsUp()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections((int)Direction.Up, false, false);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_OnlyLeft_ReturnsLeft()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections((int)Direction.Left, false, false);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_RightAndDown_CreateExitTrue_AlwaysDown()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Right + (int)Direction.Down, true, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Right + (int)Direction.Down, true, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_RightAndDown_CreateExitFalse_CoversBoth()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Right + (int)Direction.Down, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Right, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Right + (int)Direction.Down, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_UpAndDown_CoversBoth()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Down, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Down, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_UpAndRight_CoversBoth()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Right, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Right, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Right, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftAndDown_CoversBoth()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Down, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Down, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftAndRight_CoversBoth()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Right, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Right, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Right, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftAndUp_ExitExistsTrue_AlwaysLeft()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up, false, true, mockRandom0.Object);
            Assert.AreEqual(Direction.Left, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up, false, true, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftAndUp_ExitExistsFalse_CoversBoth()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Up, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_UpRightDown_CoversAll()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Right + (int)Direction.Down, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Right + (int)Direction.Down, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Up, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Up + (int)Direction.Right + (int)Direction.Down, false, false, mockRandom2.Object);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftRightDown_CoversAll()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Right + (int)Direction.Down, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Right + (int)Direction.Down, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Right + (int)Direction.Down, false, false, mockRandom2.Object);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftUpDown_ExitExists_CoversAll()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Down, false, true, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Down, false, true, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Down, false, true, mockRandom2.Object);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftUpDown_NoExitExists_CoversLeftAndDown()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Down, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Down, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Down, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_LeftUpRight_CoversAll()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Right, false, false, mockRandom0.Object);
            Assert.AreEqual(Direction.Right, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Right, false, false, mockRandom1.Object);
            Assert.AreEqual(Direction.Left, result);

            result = MazeGenerationUtils.GetDirectionFromAvailableDirections(
                (int)Direction.Left + (int)Direction.Up + (int)Direction.Right, false, false, mockRandom2.Object);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void GetDirectionFromAvailableDirections_None_ReturnsNull()
        {
            var result = MazeGenerationUtils.GetDirectionFromAvailableDirections(0, false, false);
            Assert.IsNull(result);
        }
    }
}