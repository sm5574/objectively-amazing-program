using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;
using System;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        // Right
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedRight_MazeIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedRight(null, mockSetCell.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedRight_CellIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedRight(mockMazeIsEdge.Object, null);
        }

        [TestMethod]
        public void IsBlockedRight_IsRightEdgeAndRightNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedRight(mockMazeIsEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedRight_IsRightEdgeAndRightNeighborNotSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedRight(mockMazeIsEdge.Object, mockUnsetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedRight_NotRightEdgeAndRightNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedRight(mockMazeNotEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedRight_NotRightEdgeAndRightNeighborNotSet_ReturnsFalse()
        {
            var result = MazeGenerationUtils.IsBlockedRight(mockMazeNotEdge.Object, mockUnsetCell.Object);
            Assert.IsFalse(result);
        }

        // Left
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedLeft_MazeIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedLeft(null, mockSetCell.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedLeft_CellIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedLeft(mockMazeIsEdge.Object, null);
        }

        [TestMethod]
        public void IsBlockedLeft_IsLeftEdgeAndLeftNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedLeft(mockMazeIsEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedLeft_IsLeftEdgeAndLeftNeighborNotSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedLeft(mockMazeIsEdge.Object, mockUnsetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedLeft_NotLeftEdgeAndLeftNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedLeft(mockMazeNotEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedLeft_NotLeftEdgeAndLeftNeighborNotSet_ReturnsFalse()
        {
            var result = MazeGenerationUtils.IsBlockedLeft(mockMazeNotEdge.Object, mockUnsetCell.Object);
            Assert.IsFalse(result);
        }

        // Up
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedUp_MazeIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedUp(null, mockSetCell.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedUp_CellIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedUp(mockMazeIsEdge.Object, null);
        }

        [TestMethod]
        public void IsBlockedUp_IsTopRowAndUpperNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedUp(mockMazeIsEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedUp_IsTopRowAndUpperNeighborNotSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedUp(mockMazeIsEdge.Object, mockUnsetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedUp_NotTopRowAndUpperNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedUp(mockMazeNotEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedUp_NotTopRowAndUpperNeighborNotSet_ReturnsFalse()
        {
            var result = MazeGenerationUtils.IsBlockedUp(mockMazeNotEdge.Object, mockUnsetCell.Object);
            Assert.IsFalse(result);
        }

        // Down
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedDown_MazeIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedDown(null, mockSetCell.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsBlockedDown_CellIsNull_ThrowsArgumentNullException()
        {
            _ = MazeGenerationUtils.IsBlockedDown(mockMazeIsEdge.Object, null);
        }

        [TestMethod]
        public void IsBlockedDown_IsBottomRowAndLowerNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedDown(mockMazeIsEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedDown_IsBottomRowAndLowerNeighborNotSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedDown(mockMazeIsEdge.Object, mockUnsetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedDown_NotBottomRowAndLowerNeighborSet_ReturnsTrue()
        {
            var result = MazeGenerationUtils.IsBlockedDown(mockMazeNotEdge.Object, mockSetCell.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBlockedDown_NotBottomRowAndLowerNeighborNotSet_ReturnsFalse()
        {
            var result = MazeGenerationUtils.IsBlockedDown(mockMazeNotEdge.Object, mockUnsetCell.Object);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBlockedDown_BottomRowCreateExitAndLowerNeighborNotSet_ReturnsFalse()
        {
            var result = MazeGenerationUtils.IsBlockedDown(mockMazeCreateExit.Object, mockUnsetCell.Object);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBlockedDown_BottomRowCreateExitAndLowerNeighborSet_ReturnsFalse()
        {
            var result = MazeGenerationUtils.IsBlockedDown(mockMazeCreateExit.Object, mockSetCell.Object);
            Assert.IsFalse(result);
        }
    }
}