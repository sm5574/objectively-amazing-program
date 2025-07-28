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
        public void AddCell_ThenGetCell_ReturnsCellWithMatchingCoordinates()
        {
            _mazeFromDimensions.AddCell(_validCell);
            var cell = _mazeFromDimensions.GetCell(_validCell);
            Assert.IsNotNull(cell);
            Assert.AreEqual(_validCell, cell!.Coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddCell_WhenCellAlreadyExists_ThrowsApplicationException()
        {
            _mazeFromDimensions.AddCell(_validCell);
            _mazeFromDimensions.AddCell(_validCell);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCell_WhenColumnIsZero_ThrowsArgumentOutOfRangeException()
        {
            _mazeFromDimensions.AddCell(_colZero);
            _mazeFromDimensions.AddCell(_colZero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCell_WhenColumnExceedsBoundary_ThrowsArgumentOutOfRangeException()
        {
            _mazeFromDimensions.AddCell(_colOutOfBounds);
            _mazeFromDimensions.AddCell(_colOutOfBounds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCell_WhenRowIsZero_ThrowsArgumentOutOfRangeException()
        {
            _mazeFromDimensions.AddCell(_rowZero);
            _mazeFromDimensions.AddCell(_rowZero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCell_WhenRowExceedsBoundary_ThrowsArgumentOutOfRangeException()
        {
            _mazeFromDimensions.AddCell(_rowOutOfBounds);
            _mazeFromDimensions.AddCell(_rowOutOfBounds);
        }
    }
}
