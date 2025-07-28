using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    [TestClass]
    public class MazeGeneratorTests
    {
        private class DummyMaze : IMaze
        {
            public (uint width, uint height) Dimensions => (1, 1);
            public (uint column, uint row) TopOpening => (0, 0);
            public (uint column, uint row) BottomOpening => (0, 0);
            public List<IMazeCell> MazeCells => new();
            public void CreateExit(IMazeCell cell) { }
            public bool ExitExists() => false;
            public IMazeCell? GetCell((uint column, uint row) coordinates) => null;
            public bool IsCellTopRow(IMazeCell cell) => false;
            public bool IsCellLeftEdge(IMazeCell cell) => false;
            public bool IsCellBottomRow(IMazeCell cell) => false;
            public bool IsCellRightEdge(IMazeCell cell) => false;
            public IMazeCell? GetNeighbor(IMazeCell cell, Direction direction) => null;
            public IMazeCell? GetUnsetCell() => null;
            public uint GetSetCellCount() => 0;
            public bool IsComplete() => true;
            public void SetCellPathStep(IMazeCell cell) { }
            public void AddCell((uint column, uint row) coordinates) { }
            public IMazeCell? GetOpeningCell() => null;
        }

        private class DummyCell : IMazeCell
        {
            public (uint column, uint row) Coordinates { get; set; }
            public uint PathStep => 0;
            public bool IsSet() => false;
            public void SetPathStep(uint step) { }
            public void CreateWall(Direction direction, IMazeCellWall wall) { }
            public IMazeCellWall? GetWall(Direction direction) => null;
            public IMazeCellWall? GetTopWall() => null;
            public IMazeCellWall? GetBottomWall() => null;
            public IMazeCellWall? GetLeftWall() => null;
            public IMazeCellWall? GetRightWall() => null;
            public void SetWallStatus(Direction direction, WallStatus wallStatus) { }
            public void SetBottomWallStatus(WallStatus status) { }
        }

        private class DummyRandomProvider : IRandomProvider
        {
            public int Next() => 0;
            public int Next(int maxValue) => 0;
            public int Next(int minValue, int maxValue) => minValue;
            public double NextDouble() => 0.0;
        }

        [TestMethod]
        public void Decrements_ForceChangeVal_When_DirectionsEqual_And_ForceChangeVal_GreaterThanZero()
        {
            var maze = new DummyMaze();
            var cell = new DummyCell();
            var generator = new MazeGenerator(maze, cell, new DummyRandomProvider());

            generator.ForceChangeVal = 2;
            generator.PreviousDirection = Direction.Up;
            generator.NextDirection = Direction.Up;

            generator.DetermineProbabilityOfChange();

            Assert.AreEqual(1, generator.ForceChangeVal);
        }

        [TestMethod]
        public void Resets_ForceChangeVal_When_DirectionsEqual_And_ForceChangeVal_Zero()
        {
            var maze = new DummyMaze();
            var cell = new DummyCell();
            var generator = new MazeGenerator(maze, cell, new DummyRandomProvider());

            generator.ForceChangeVal = 0;
            generator.PreviousDirection = Direction.Up;
            generator.NextDirection = Direction.Up;

            generator.DetermineProbabilityOfChange();

            Assert.AreEqual(3, generator.ForceChangeVal);
        }

        [TestMethod]
        public void Resets_ForceChangeVal_When_DirectionsNotEqual()
        {
            var maze = new DummyMaze();
            var cell = new DummyCell();
            var generator = new MazeGenerator(maze, cell, new DummyRandomProvider());

            generator.ForceChangeVal = 2;
            generator.PreviousDirection = Direction.Up;
            generator.NextDirection = Direction.Right;

            generator.DetermineProbabilityOfChange();

            Assert.AreEqual(3, generator.ForceChangeVal);
        }

        [TestMethod]
        public void Resets_ForceChangeVal_When_PreviousDirectionIsNull()
        {
            var maze = new DummyMaze();
            var cell = new DummyCell();
            var generator = new MazeGenerator(maze, cell, new DummyRandomProvider());

            generator.ForceChangeVal = 2;
            generator.PreviousDirection = null;
            generator.NextDirection = Direction.Right;

            generator.DetermineProbabilityOfChange();

            Assert.AreEqual(3, generator.ForceChangeVal);
        }

        [TestMethod]
        public void Resets_ForceChangeVal_When_NextDirectionIsNull()
        {
            var maze = new DummyMaze();
            var cell = new DummyCell();
            var generator = new MazeGenerator(maze, cell, new DummyRandomProvider());

            generator.ForceChangeVal = 2;
            generator.PreviousDirection = Direction.Right;
            generator.NextDirection = null;

            generator.DetermineProbabilityOfChange();

            Assert.AreEqual(3, generator.ForceChangeVal);
        }
    }
}