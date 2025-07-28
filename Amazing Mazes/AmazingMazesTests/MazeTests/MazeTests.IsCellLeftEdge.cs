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
        public void IsCellLeftEdge_WhenCellIsNull_ThrowsArgumentNullException()
        {
            _ = _mazeFromDimensions!.IsCellLeftEdge(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsCellLeftEdge_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
        {
            _ = _mazeFromDimensions!.IsCellLeftEdge(new MazeCell((0, 0)));
        }

        [TestMethod]
        public void IsCellLeftEdge_WhenCellColumnIsZero_ReturnsTrue()
        {
            (uint column, uint row) leftEdge = (0, HeightVal2 - 1);

            _mazeFromDimensions!.AddCell(leftEdge);
            var cell = _mazeFromDimensions.GetCell(leftEdge);
            Assert.IsNotNull(cell);
            Assert.IsTrue(_mazeFromDimensions.IsCellLeftEdge(cell!));
        }

        [TestMethod]
        public void IsCellLeftEdge_WhenCellColumnIsNotZero_ReturnsFalse()
        {
            (uint column, uint row) notLeftEdge = (WidthVal2 - 1, 0);

            _mazeFromDimensions!.AddCell(notLeftEdge);
            var cell = _mazeFromDimensions.GetCell(notLeftEdge);
            Assert.IsNotNull(cell);
            Assert.IsFalse(_mazeFromDimensions.IsCellLeftEdge(cell!));
        }
    }
}
