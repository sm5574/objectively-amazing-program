using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsCellTopRow_WhenCellIsNull_ThrowsArgumentNullException()
        {
            _ = _mazeFromDimensions!.IsCellTopRow(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsCellTopRow_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
        {
            _ = _mazeFromDimensions!.IsCellTopRow(new MazeCell((0, 0)));
        }

        [TestMethod]
        public void IsCellTopRow_WhenCellRowIsZero_ReturnsTrue()
        {
            (uint column, uint row) topRow = (WidthVal2 - 1, 0);

            _mazeFromDimensions!.AddCell(topRow);
            var cell = _mazeFromDimensions.GetCell(topRow);
            Assert.IsNotNull(cell);
            Assert.IsTrue(_mazeFromDimensions.IsCellTopRow(cell!));
        }

        [TestMethod]
        public void IsCellTopRow_WhenCellRowIsNotZero_ReturnsFalse()
        {
            (uint column, uint row) notTopRow = (0, HeightVal2 - 1);

            _mazeFromDimensions!.AddCell(notTopRow);
            var cell = _mazeFromDimensions.GetCell(notTopRow);
            Assert.IsNotNull(cell);
            Assert.IsFalse(_mazeFromDimensions.IsCellTopRow(cell!));
        }
    }
}
