using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System;
using System.Linq;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void CreateMatrix_CreatesMazeWithCorrectDimensions()
        {
            var dimensions = (width: 5u, height: 7u);
            var maze = MazeGenerationUtils.CreateMatrix(dimensions, new RandomProvider(42));
            Assert.IsNotNull(maze);
            Assert.AreEqual(dimensions, maze.Dimensions);
        }

        [TestMethod]
        public void CreateMatrix_CreatesAllCells()
        {
            var dimensions = (width: 4u, height: 3u);
            var maze = MazeGenerationUtils.CreateMatrix(dimensions, new RandomProvider(1));
            Assert.IsTrue(maze.MazeCells.Count == (int)(dimensions.width * dimensions.height));
            foreach (var cell in maze.MazeCells)
            {
                Assert.IsTrue(cell.Coordinates.column < dimensions.width);
                Assert.IsTrue(cell.Coordinates.row < dimensions.height);
            }
        }

        [TestMethod]
        public void CreateMatrix_CreatesWallsForAllCells()
        {
            var dimensions = (width: 3u, height: 3u);
            var maze = MazeGenerationUtils.CreateMatrix(dimensions, new RandomProvider(2));
            foreach (var cell in maze.MazeCells)
            {
                foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    var wall = cell.GetWall(dir);
                    // Each wall should be either null (on edge) or a valid wall object
                    if (wall != null)
                    {
                        Assert.IsTrue(wall.Status == WallStatus.Open || wall.Status == WallStatus.Closed);
                    }
                }
            }
        }

        [TestMethod]
        public void CreateMatrix_SetsTopOpening()
        {
            var dimensions = (width: 5u, height: 5u);
            var rnd = new RandomProvider(42);
            var maze = MazeGenerationUtils.CreateMatrix(dimensions, rnd);

            Assert.IsTrue(maze.MazeCells.Where(c => c.GetTopWall()?.Status == WallStatus.Open).Count() == 1);

            var openingCell = maze.MazeCells.FirstOrDefault(c => c.GetTopWall()?.Status == WallStatus.Open);
            Assert.IsNotNull(openingCell);
            Assert.AreEqual(0u, openingCell.Coordinates.row);
        }

        [TestMethod]
        public void CreateMatrix_RandomnessAffectsTopOpening()
        {
            var dimensions = (width: 10u, height: 10u);
            var maze1 = MazeGenerationUtils.CreateMatrix(dimensions, mockRandom0.Object);
            var maze2 = MazeGenerationUtils.CreateMatrix(dimensions, mockRandom1.Object);

            // With different seeds, the top opening column should differ
            var openingCell1 = maze1.MazeCells.FirstOrDefault(c => c.GetTopWall()?.Status == WallStatus.Open)
                ?? throw new Exception();
            var openingCell2 = maze2.MazeCells.FirstOrDefault(c => c.GetTopWall()?.Status == WallStatus.Open)
                ?? throw new Exception();
            Assert.AreNotEqual(openingCell1.Coordinates.column, openingCell2.Coordinates.column);
        }
    }
}