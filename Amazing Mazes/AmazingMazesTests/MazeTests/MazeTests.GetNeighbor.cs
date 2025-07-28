using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeTests
    {
        [TestMethod]
        public void GetNeighbor_Up_ReturnsUpperNeighbor()
        {
            var cell = _mazeGetNeighbor!.GetCell(_lowerLeft);
            Assert.IsNotNull(cell);
            var neighbor = _mazeGetNeighbor.GetNeighbor(cell, Direction.Up);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(_cellUpperLeft.Object.Coordinates, neighbor!.Coordinates);
        }

        [TestMethod]
        public void GetNeighbor_Down_ReturnsLowerNeighbor()
        {
            var cell = _mazeGetNeighbor!.GetCell(_upperLeft);
            Assert.IsNotNull(cell);
            var neighbor = _mazeGetNeighbor.GetNeighbor(cell, Direction.Down);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(_cellLowerLeft.Object.Coordinates, neighbor!.Coordinates);
        }

        [TestMethod]
        public void GetNeighbor_Left_ReturnsLeftNeighbor()
        {
            var cell = _mazeGetNeighbor!.GetCell(_lowerRight);
            Assert.IsNotNull(cell);
            var neighbor = _mazeGetNeighbor.GetNeighbor(cell, Direction.Left);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(_cellLowerLeft.Object.Coordinates, neighbor!.Coordinates);
        }

        [TestMethod]
        public void GetNeighbor_Right_ReturnsRightNeighbor()
        {
            var cell = _mazeGetNeighbor!.GetCell(_lowerLeft);
            Assert.IsNotNull(cell);
            var neighbor = _mazeGetNeighbor.GetNeighbor(cell, Direction.Right);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(_cellLowerRight.Object.Coordinates, neighbor!.Coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNeighbor_CellIsNull_ThrowsArgumentNullException()
        {
            _ = _mazeGetNeighbor!.GetNeighbor(null, Direction.Up);
        }
    }
}
