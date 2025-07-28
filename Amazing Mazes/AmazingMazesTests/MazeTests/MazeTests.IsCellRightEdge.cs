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
        public void IsCellRightEdge_WhenCellIsNull_ThrowsArgumentNullException()
        {
            _ = _mazeFromDimensions!.IsCellRightEdge(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsCellRightEdge_WhenCellNotInMaze_ThrowsArgumentOutOfRangeException()
        {
            _ = _mazeFromDimensions!.IsCellRightEdge(new MazeCell((0, 0)));
        }

        [TestMethod]
        public void IsCellRightEdge_WhenCellColumnIsZero_ReturnsTrue()
        {
            (uint column, uint row) rightEdge = (WidthVal2 - 1, 0);

            _mazeFromDimensions!.AddCell(rightEdge);
            var cell = _mazeFromDimensions.GetCell(rightEdge);
            Assert.IsNotNull(cell);
            Assert.IsTrue(_mazeFromDimensions.IsCellRightEdge(cell!));
        }

        [TestMethod]
        public void IsCellRightEdge_WhenCellColumnIsNotZero_ReturnsFalse()
        {
            (uint column, uint row) notRightEdge = (0, HeightVal2 - 1);

            _mazeFromDimensions!.AddCell(notRightEdge);
            var cell = _mazeFromDimensions.GetCell(notRightEdge);
            Assert.IsNotNull(cell);
            Assert.IsFalse(_mazeFromDimensions.IsCellRightEdge(cell!));
        }
    }
}
