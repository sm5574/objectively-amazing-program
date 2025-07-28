using ObjectivelyAmazingProgramCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Tests
{
    [TestClass]
    public partial class MazeGenerationUtilsTests
    {
        // Tests are grouped into partial class files for each method in MazeGenerationUtilsTests

        private const bool Blocked = true;
        private const bool NotBlocked = false;

        private const int Up = (int)Direction.Up;
        private const int Down = (int)Direction.Down;
        private const int Left = (int)Direction.Left;
        private const int Right = (int)Direction.Right;

        private const int RandomProbability2 = 2;
        private const int RandomProbability3 = 3;

        private Mock<IRandomProvider> mockRandom0 = null!;
        private Mock<IRandomProvider> mockRandom1 = null!;
        private Mock<IRandomProvider> mockRandom2 = null!;

        private Mock<IMazeCell> mockSetCell = null!;
        private Mock<IMazeCell> mockUnsetCell = null!;
        private Mock<IMaze> mockMazeIsEdge = null!;
        private Mock<IMaze> mockMazeCreateExit = null!;
        private Mock<IMaze> mockMazeNotEdge = null!;

        private MazeCell? cell;
        private MazeCell? neighbor;

        private MazeCell? unsetCell;
        private MazeCell? fromCell;
        private MazeCell? fromCellTopRow;
        private MazeCell? fromCellBottomRow;
        private MazeCell? fromCellLeftEdge;
        private MazeCell? fromCellRightEdge;
        private MazeCell? upperNeighbor;
        private MazeCell? lowerNeighbor;
        private MazeCell? leftNeighbor;
        private MazeCell? rightNeighbor;
        private Mock<IMaze>? maze;

        private MazeCell cell1 = null!;
        private MazeCell cell2 = null!;
        private MazeCell cell3 = null!;
        private MazeCell cell4 = null!;
        private List<IMazeCell> cells = null!;
        private Mock<IMaze> mockMaze = null!;

        [TestInitialize]
        public void MazeGenerationUtilsTestInitialize()
        {
            mockRandom0 = new Mock<IRandomProvider>();
            mockRandom1 = new Mock<IRandomProvider>();
            mockRandom2 = new Mock<IRandomProvider>();

            mockRandom0.SetupSequence(m => m.Next(RandomProbability2)).Returns(0);
            mockRandom1.SetupSequence(m => m.Next(RandomProbability2)).Returns(1);
            mockRandom0.SetupSequence(m => m.Next(RandomProbability3)).Returns(0);
            mockRandom1.SetupSequence(m => m.Next(RandomProbability3)).Returns(1);
            mockRandom2.SetupSequence(m => m.Next(RandomProbability3)).Returns(2);
            mockRandom0.SetupSequence(m => m.Next()).Returns(0);
            mockRandom1.SetupSequence(m => m.Next()).Returns(1);
            mockRandom2.SetupSequence(m => m.Next()).Returns(2);
            mockRandom0.SetupSequence(m => m.Next(0, It.IsAny<int>())).Returns(0);
            mockRandom1.SetupSequence(m => m.Next(0, It.IsAny<int>())).Returns(1);

            cell = new MazeCell((1, 1));
            neighbor = new MazeCell((2, 2));

            mockSetCell = new Mock<IMazeCell>();
            mockUnsetCell = new Mock<IMazeCell>();
            mockMazeIsEdge = new Mock<IMaze>();
            mockMazeCreateExit = new Mock<IMaze>();
            mockMazeNotEdge = new Mock<IMaze>();

            mockSetCell.Setup(x => x.IsSet()).Returns(true);
            mockUnsetCell.Setup(x => x.IsSet()).Returns(false);

            mockMazeIsEdge.Setup(x => x.IsCellRightEdge(mockSetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellRightEdge(mockUnsetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellLeftEdge(mockSetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellLeftEdge(mockUnsetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellTopRow(mockSetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellTopRow(mockUnsetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellBottomRow(mockSetCell.Object)).Returns(true);
            mockMazeIsEdge.Setup(x => x.IsCellBottomRow(mockUnsetCell.Object)).Returns(true);
            mockMazeCreateExit.Setup(x => x.IsCellBottomRow(mockSetCell.Object)).Returns(true);
            mockMazeCreateExit.Setup(x => x.IsCellBottomRow(mockUnsetCell.Object)).Returns(true);

            mockMazeIsEdge.Setup(x => x.ExitExists()).Returns(true);
            mockMazeCreateExit.Setup(x => x.ExitExists()).Returns(false);

            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Right)).Returns(mockSetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Left)).Returns(mockSetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Up)).Returns(mockSetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Down)).Returns(mockSetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Right)).Returns(mockUnsetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Left)).Returns(mockUnsetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Up)).Returns(mockUnsetCell.Object);
            mockMazeIsEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Down)).Returns(mockUnsetCell.Object);

            mockMazeNotEdge.Setup(x => x.IsCellRightEdge(mockSetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellRightEdge(mockUnsetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellLeftEdge(mockSetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellLeftEdge(mockUnsetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellTopRow(mockSetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellTopRow(mockUnsetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellBottomRow(mockSetCell.Object)).Returns(false);
            mockMazeNotEdge.Setup(x => x.IsCellBottomRow(mockUnsetCell.Object)).Returns(false);

            mockMazeNotEdge.Setup(x => x.ExitExists()).Returns(true);

            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Right)).Returns(mockSetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Left)).Returns(mockSetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Up)).Returns(mockSetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockSetCell.Object, Direction.Down)).Returns(mockSetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Right)).Returns(mockUnsetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Left)).Returns(mockUnsetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Up)).Returns(mockUnsetCell.Object);
            mockMazeNotEdge.Setup(x => x.GetNeighbor(mockUnsetCell.Object, Direction.Down)).Returns(mockUnsetCell.Object);

            unsetCell = new MazeCell((1, 1));
            fromCell = new MazeCell((1, 1));
            fromCellTopRow = new MazeCell((1, 0));
            fromCellBottomRow = new MazeCell((1, 2));
            fromCellLeftEdge = new MazeCell((0, 1));
            fromCellRightEdge = new MazeCell((2, 1));
            upperNeighbor = new MazeCell((1, 0));
            lowerNeighbor = new MazeCell((1, 2));
            leftNeighbor = new MazeCell((0, 1));
            rightNeighbor = new MazeCell((2, 1));

            foreach (var cell in new[] { fromCell, fromCellTopRow, fromCellBottomRow, fromCellLeftEdge, fromCellRightEdge, upperNeighbor, lowerNeighbor, leftNeighbor, rightNeighbor })
            {
                if (cell == null) continue;
                cell.CreateWall(Direction.Up, new MazeCellWall());
                cell.CreateWall(Direction.Down, new MazeCellWall());
                cell.CreateWall(Direction.Left, new MazeCellWall());
                cell.CreateWall(Direction.Right, new MazeCellWall());
            }

            maze = new Mock<IMaze>();
            maze.Setup(x => x.GetNeighbor(fromCell, Direction.Up)).Returns(upperNeighbor);
            maze.Setup(x => x.GetNeighbor(fromCell, Direction.Down)).Returns(lowerNeighbor);
            maze.Setup(x => x.GetNeighbor(fromCell, Direction.Left)).Returns(leftNeighbor);
            maze.Setup(x => x.GetNeighbor(fromCell, Direction.Right)).Returns(rightNeighbor);
            maze.Setup(x => x.GetNeighbor(fromCellTopRow, Direction.Up)).Returns((IMazeCell?)null);
            maze.Setup(x => x.GetNeighbor(fromCellBottomRow, Direction.Down)).Returns((IMazeCell?)null);
            maze.Setup(x => x.GetNeighbor(fromCellLeftEdge, Direction.Left)).Returns((IMazeCell?)null);
            maze.Setup(x => x.GetNeighbor(fromCellRightEdge, Direction.Right)).Returns((IMazeCell?)null);
            maze.Setup(x => x.IsCellRightEdge(fromCellRightEdge)).Returns(true);
            maze.Setup(x => x.IsCellRightEdge(fromCell)).Returns(false);
            maze.Setup(x => x.IsCellBottomRow(fromCellBottomRow)).Returns(true);
            maze.Setup(x => x.IsCellBottomRow(fromCell)).Returns(false);
            maze.Setup(x => x.GetUnsetCell()).Returns(unsetCell);
            maze.Setup(x => x.ExitExists()).Returns(true);

            // Create real cells
            cell1 = new MazeCell((0, 0));
            cell2 = new MazeCell((1, 0));
            cell3 = new MazeCell((0, 1));
            cell4 = new MazeCell((1, 1));
            cells = new List<IMazeCell> { cell1, cell2, cell3, cell4 };

            // Setup mock maze
            mockMaze = new Mock<IMaze>();
            mockMaze.Setup(m => m.MazeCells).Returns(cells);

            // Setup neighbor relationships
            mockMaze.Setup(m => m.GetNeighbor(cell1, Direction.Up)).Returns((IMazeCell?)null);
            mockMaze.Setup(m => m.GetNeighbor(cell1, Direction.Right)).Returns(cell2);
            mockMaze.Setup(m => m.GetNeighbor(cell1, Direction.Down)).Returns(cell3);
            mockMaze.Setup(m => m.GetNeighbor(cell1, Direction.Left)).Returns((IMazeCell?)null);

            mockMaze.Setup(m => m.GetNeighbor(cell2, Direction.Up)).Returns((IMazeCell?)null);
            mockMaze.Setup(m => m.GetNeighbor(cell2, Direction.Right)).Returns((IMazeCell?)null);
            mockMaze.Setup(m => m.GetNeighbor(cell2, Direction.Down)).Returns(cell4);
            mockMaze.Setup(m => m.GetNeighbor(cell2, Direction.Left)).Returns(cell1);

            mockMaze.Setup(m => m.GetNeighbor(cell3, Direction.Up)).Returns(cell1);
            mockMaze.Setup(m => m.GetNeighbor(cell3, Direction.Right)).Returns(cell4);
            mockMaze.Setup(m => m.GetNeighbor(cell3, Direction.Down)).Returns((IMazeCell?)null);
            mockMaze.Setup(m => m.GetNeighbor(cell3, Direction.Left)).Returns((IMazeCell?)null);

            mockMaze.Setup(m => m.GetNeighbor(cell4, Direction.Up)).Returns(cell2);
            mockMaze.Setup(m => m.GetNeighbor(cell4, Direction.Right)).Returns((IMazeCell?)null);
            mockMaze.Setup(m => m.GetNeighbor(cell4, Direction.Down)).Returns((IMazeCell?)null);
            mockMaze.Setup(m => m.GetNeighbor(cell4, Direction.Left)).Returns(cell3);
        }
    }
}
