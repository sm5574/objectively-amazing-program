using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using System.Collections.Generic;
using static ObjectivelyAmazingProgramCore.Enums;
using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void CreateAllCellWalls_CreatesWallsAndSharesCorrectly_Cell1()
        {
            MazeGenerationUtils.CreateAllCellWalls(mockMaze.Object);

            Assert.IsNotNull(cell1.GetWall(Direction.Up));
            Assert.IsNotNull(cell1.GetWall(Direction.Right));
            Assert.IsNotNull(cell1.GetWall(Direction.Down));
            Assert.IsNotNull(cell1.GetWall(Direction.Left));

            Assert.AreSame(cell1.GetWall(Direction.Right), cell2.GetWall(Direction.Left));
            Assert.AreSame(cell1.GetWall(Direction.Down), cell3.GetWall(Direction.Up));
        }

        [TestMethod]
        public void CreateAllCellWalls_CreatesWallsAndSharesCorrectly_Cell2()
        {
            MazeGenerationUtils.CreateAllCellWalls(mockMaze.Object);

            Assert.IsNotNull(cell2.GetWall(Direction.Up));
            Assert.IsNotNull(cell2.GetWall(Direction.Left));
            Assert.IsNotNull(cell2.GetWall(Direction.Down));
            Assert.IsNotNull(cell2.GetWall(Direction.Right));

            Assert.AreSame(cell2.GetWall(Direction.Left), cell1.GetWall(Direction.Right));
            Assert.AreSame(cell2.GetWall(Direction.Down), cell4.GetWall(Direction.Up));
        }

        [TestMethod]
        public void CreateAllCellWalls_CreatesWallsAndSharesCorrectly_Cell3()
        {
            MazeGenerationUtils.CreateAllCellWalls(mockMaze.Object);

            Assert.IsNotNull(cell3.GetWall(Direction.Up));
            Assert.IsNotNull(cell3.GetWall(Direction.Right));
            Assert.IsNotNull(cell3.GetWall(Direction.Down));
            Assert.IsNotNull(cell3.GetWall(Direction.Left));

            Assert.AreSame(cell3.GetWall(Direction.Up), cell1.GetWall(Direction.Down));
            Assert.AreSame(cell3.GetWall(Direction.Right), cell4.GetWall(Direction.Left));
        }

        [TestMethod]
        public void CreateAllCellWalls_CreatesWallsAndSharesCorrectly_Cell4()
        {
            MazeGenerationUtils.CreateAllCellWalls(mockMaze.Object);

            Assert.IsNotNull(cell4.GetWall(Direction.Up));
            Assert.IsNotNull(cell4.GetWall(Direction.Left));
            Assert.IsNotNull(cell4.GetWall(Direction.Down));
            Assert.IsNotNull(cell4.GetWall(Direction.Right));

            Assert.AreSame(cell4.GetWall(Direction.Up), cell2.GetWall(Direction.Down));
            Assert.AreSame(cell4.GetWall(Direction.Left), cell3.GetWall(Direction.Right));
        }

        [TestMethod]
        public void CreateAllCellWalls_DoesNotDuplicateWalls()
        {
            MazeGenerationUtils.CreateAllCellWalls(mockMaze.Object);

            Assert.AreSame(cell1.GetWall(Direction.Right), cell2.GetWall(Direction.Left));
            Assert.AreSame(cell1.GetWall(Direction.Down), cell3.GetWall(Direction.Up));
            Assert.AreSame(cell2.GetWall(Direction.Down), cell4.GetWall(Direction.Up));
            Assert.AreSame(cell3.GetWall(Direction.Right), cell4.GetWall(Direction.Left));
        }
    }
}