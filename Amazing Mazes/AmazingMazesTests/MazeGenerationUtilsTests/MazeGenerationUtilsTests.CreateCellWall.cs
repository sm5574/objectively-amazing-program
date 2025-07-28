using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectivelyAmazingProgramCore;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeGenerationUtilsTests
    {
        [TestMethod]
        public void CreateCellWall_Up_WallsNotSet_CreatesSharedWall()
        {
            Assert.IsNull(cell!.GetWall(Direction.Up));
            Assert.IsNull(neighbor!.GetWall(Direction.Down));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Up);
            var cellWall = cell.GetWall(Direction.Up);
            var neighborWall = neighbor.GetWall(Direction.Down);
            Assert.IsNotNull(cellWall);
            Assert.IsNotNull(neighborWall);
            Assert.AreSame(cellWall, neighborWall);
        }

        [TestMethod]
        public void CreateCellWall_Up_NeighborNull_CreatesSingleWall()
        {
            Assert.IsNull(cell!.GetWall(Direction.Up));
            MazeGenerationUtils.CreateCellWall(cell, null, Direction.Up);
            Assert.IsNotNull(cell.GetWall(Direction.Up));
        }

        [TestMethod]
        public void CreateCellWall_Up_WallExistsAndNeighborNull_DoesNothing()
        {
            var wall = new MazeCellWall();
            cell!.CreateWall(Direction.Up, wall);
            MazeGenerationUtils.CreateCellWall(cell, null, Direction.Up);
            Assert.AreSame(wall, cell.GetWall(Direction.Up));
        }

        [TestMethod]
        public void CreateCellWall_Up_CellAndNeighborShareWall_DoesNothing()
        {
            var wall = new MazeCellWall();
            cell!.CreateWall(Direction.Up, wall);
            neighbor!.CreateWall(Direction.Down, wall);
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Up);
            Assert.AreSame(wall, cell.GetWall(Direction.Up));
            Assert.AreSame(wall, neighbor.GetWall(Direction.Down));
        }

        [TestMethod]
        public void CreateCellWall_Up_CellWallSetAndNeighborWallNotSet_SetsNeighborWall()
        {
            var wall = new MazeCellWall();
            cell!.CreateWall(Direction.Up, wall);
            Assert.IsNull(neighbor!.GetWall(Direction.Down));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Up);
            Assert.AreSame(wall, neighbor.GetWall(Direction.Down));
        }

        [TestMethod]
        public void CreateCellWall_Down_WallsNotSet_CreatesSharedWall()
        {
            Assert.IsNull(cell!.GetWall(Direction.Down));
            Assert.IsNull(neighbor!.GetWall(Direction.Up));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Down);
            var cellWall = cell.GetWall(Direction.Down);
            var neighborWall = neighbor.GetWall(Direction.Up);
            Assert.IsNotNull(cellWall);
            Assert.IsNotNull(neighborWall);
            Assert.AreSame(cellWall, neighborWall);
        }

        [TestMethod]
        public void CreateCellWall_Left_WallsNotSet_CreatesSharedWall()
        {
            Assert.IsNull(cell!.GetWall(Direction.Left));
            Assert.IsNull(neighbor!.GetWall(Direction.Right));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Left);
            var cellWall = cell.GetWall(Direction.Left);
            var neighborWall = neighbor.GetWall(Direction.Right);
            Assert.IsNotNull(cellWall);
            Assert.IsNotNull(neighborWall);
            Assert.AreSame(cellWall, neighborWall);
        }

        [TestMethod]
        public void CreateCellWall_Right_WallsNotSet_CreatesSharedWall()
        {
            Assert.IsNull(cell!.GetWall(Direction.Right));
            Assert.IsNull(neighbor!.GetWall(Direction.Left));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Right);
            var cellWall = cell.GetWall(Direction.Right);
            var neighborWall = neighbor.GetWall(Direction.Left);
            Assert.IsNotNull(cellWall);
            Assert.IsNotNull(neighborWall);
            Assert.AreSame(cellWall, neighborWall);
        }

        [TestMethod]
        public void CreateCellWall_Left_CellWallSetAndNeighborWallNotSet_SetsNeighborWall()
        {
            var wall = new MazeCellWall();
            cell!.CreateWall(Direction.Left, wall);
            Assert.IsNull(neighbor!.GetWall(Direction.Right));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Left);
            Assert.AreSame(wall, neighbor.GetWall(Direction.Right));
        }

        [TestMethod]
        public void CreateCellWall_Right_CellWallSetAndNeighborWallNotSet_SetsNeighborWall()
        {
            var wall = new MazeCellWall();
            cell!.CreateWall(Direction.Right, wall);
            Assert.IsNull(neighbor!.GetWall(Direction.Left));
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Right);
            Assert.AreSame(wall, neighbor.GetWall(Direction.Left));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Up_CellWallNotSetButNeighborIs_Throws()
        {
            neighbor!.CreateWall(Direction.Down, new MazeCellWall());
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Up);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Up_WallsDoNotMatch_Throws()
        {
            var wall1 = new MazeCellWall();
            var wall2 = new MazeCellWall();
            cell!.CreateWall(Direction.Up, wall1);
            neighbor!.CreateWall(Direction.Down, wall2);
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Up);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Down_CellWallNotSetButNeighborIs_Throws()
        {
            neighbor!.CreateWall(Direction.Up, new MazeCellWall());
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Down);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Down_WallsDoNotMatch_Throws()
        {
            var wall1 = new MazeCellWall();
            var wall2 = new MazeCellWall();
            cell!.CreateWall(Direction.Down, wall1);
            neighbor!.CreateWall(Direction.Up, wall2);
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Down);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Left_CellWallNotSetButNeighborIs_Throws()
        {
            neighbor!.CreateWall(Direction.Right, new MazeCellWall());
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Left);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Left_WallsDoNotMatch_Throws()
        {
            var wall1 = new MazeCellWall();
            var wall2 = new MazeCellWall();
            cell!.CreateWall(Direction.Left, wall1);
            neighbor!.CreateWall(Direction.Right, wall2);
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Left);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Right_CellWallNotSetButNeighborIs_Throws()
        {
            neighbor!.CreateWall(Direction.Left, new MazeCellWall());
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Right);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCellWall_Right_WallsDoNotMatch_Throws()
        {
            var wall1 = new MazeCellWall();
            var wall2 = new MazeCellWall();
            cell!.CreateWall(Direction.Right, wall1);
            neighbor!.CreateWall(Direction.Left, wall2);
            MazeGenerationUtils.CreateCellWall(cell, neighbor, Direction.Right);
        }
    }
}