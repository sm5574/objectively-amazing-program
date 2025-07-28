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
        public void IsCellBottomRow_WhenCellIsNull_ThrowsArgumentNullException()
        {
            _ = _mazeFromDimensions!.IsCellBottomRow(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsCellBottomRow_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
        {
            _ = _mazeFromDimensions!.IsCellBottomRow(new MazeCell((0, 0)));
        }

        [TestMethod]
        public void IsCellBottomRow_WhenCellRowIsBottom_ReturnsTrue()
        {
            (uint column, uint row) bottomRow = (0, HeightVal2 - 1);

            _mazeFromDimensions!.AddCell(bottomRow);
            var cell = _mazeFromDimensions.GetCell(bottomRow);
            Assert.IsNotNull(cell);
            Assert.IsTrue(_mazeFromDimensions.IsCellBottomRow(cell!));
        }

        [TestMethod]
        public void IsCellBottomRow_WhenCellRowIsNotBottom_ReturnsFalse()
        {
            (uint column, uint row) notBottomRow = (WidthVal2 - 1, 0);

            _mazeFromDimensions!.AddCell(notBottomRow);
            var cell = _mazeFromDimensions.GetCell(notBottomRow);
            Assert.IsNotNull(cell);
            Assert.IsFalse(_mazeFromDimensions.IsCellBottomRow(cell!));
        }
    }
}
