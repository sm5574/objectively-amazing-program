using ObjectivelyAmazingProgramCore.Interfaces;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore
{
    /// <summary>
    /// Provides utility methods for maze generation, cell movement, wall creation, and direction logic.
    /// </summary>
    public static class MazeGenerationUtils
    {
        /// <summary>
        /// Generates a maze with the specified dimensions and returns the completed maze.
        /// </summary>
        /// <param name="dimensions">The width and height of the maze.</param>
        /// <param name="rnd">Optional random number provider for maze generation. If null, a default provider is used.</param>
        /// <returns>A fully generated maze.</returns>
        /// <exception cref="ApplicationException">Thrown if no opening cell is defined.</exception>
        public static IMaze GetGeneratedMaze((uint width, uint height) dimensions, IRandomProvider? rnd = null)
        {
            IMaze maze = MazeGenerationUtils.CreateMatrix(dimensions, rnd ?? new RandomProvider());
            var cell = maze.GetOpeningCell() ?? throw new ApplicationException("No opening cell defined.");

            var mazeGenerator = new MazeGenerator(maze, cell, rnd);
            return mazeGenerator.Generate();
        }

        /// <summary>
        /// Populates the maze with cells for the given dimensions.
        /// </summary>
        /// <param name="maze">The maze to populate. If null, a new maze is created.</param>
        /// <param name="dimensions">The width and height of the maze.</param>
        /// <returns>The maze with all cells added.</returns>
        public static IMaze GenerateCellsWithinMaze(IMaze maze, (uint width, uint height) dimensions)
        {
            maze ??= new Maze(dimensions);

            for (uint i = 0; i < dimensions.width; i++)
                for (uint j = 0; j < dimensions.height; j++)
                    maze.AddCell((i, j));

            return maze;
        }

        #region Move
        //--
        /// <summary>
        /// Moves up from the specified cell in the maze.
        /// </summary>
        /// <param name="fromCell">The cell to move from.</param>
        /// <param name="maze">The maze containing the cell.</param>
        /// <returns>The cell above, or null if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fromCell or maze is null.</exception>
        public static IMazeCell? MoveUp(IMazeCell fromCell, IMaze maze)
        {
            if (fromCell == null)
                throw new ArgumentNullException(nameof(fromCell));

            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            IMazeCell? toCell;

            toCell = maze.GetNeighbor(fromCell, Direction.Up);

            if (toCell != null)
            {
                toCell.SetWallStatus(Direction.Down, WallStatus.Open);
                toCell.SetWallStatus(Direction.Right, WallStatus.Closed);
            }

            return toCell;
        }

        /// <summary>
        /// Moves left from the specified cell in the maze.
        /// </summary>
        /// <param name="fromCell">The cell to move from.</param>
        /// <param name="maze">The maze containing the cell.</param>
        /// <returns>The cell to the left, or null if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fromCell or maze is null.</exception>
        public static IMazeCell? MoveLeft(IMazeCell fromCell, IMaze maze)
        {
            if (fromCell == null)
                throw new ArgumentNullException(nameof(fromCell));

            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            IMazeCell? toCell;

            toCell = maze.GetNeighbor(fromCell, Direction.Left);

            if (toCell != null)
            {
                toCell.SetWallStatus(Direction.Down, WallStatus.Closed);
                toCell.SetWallStatus(Direction.Right, WallStatus.Open);
            }

            return toCell;
        }

        /// <summary>
        /// Moves down from the specified cell in the maze.
        /// </summary>
        /// <param name="fromCell">The cell to move from.</param>
        /// <param name="maze">The maze containing the cell.</param>
        /// <returns>The cell below, or null if not available or if an exit is created.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fromCell or maze is null.</exception>
        /// <exception cref="ApplicationException">Thrown if exit creation fails.</exception>
        public static IMazeCell? MoveDown(IMazeCell fromCell, IMaze maze)
        {
            if (fromCell == null)
                throw new ArgumentNullException(nameof(fromCell));

            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            if (!maze.IsCellBottomRow(fromCell) || maze.ExitExists())
            {
                fromCell.SetWallStatus(Direction.Down, WallStatus.Open);
                return maze.GetNeighbor(fromCell, Direction.Down);
            }

            maze.CreateExit(fromCell);

            if (maze.ExitExists())
                return null;

            throw new ApplicationException("Create maze exit failed");
        }

        /// <summary>
        /// Moves right from the specified cell in the maze.
        /// </summary>
        /// <param name="fromCell">The cell to move from.</param>
        /// <param name="maze">The maze containing the cell.</param>
        /// <returns>The cell to the right, or null if not available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fromCell or maze is null.</exception>
        public static IMazeCell? MoveRight(IMazeCell fromCell, IMaze maze)
        {
            if (fromCell == null)
                throw new ArgumentNullException(nameof(fromCell));
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            var neighbor = maze.GetNeighbor(fromCell, Direction.Right);

            // I think this line should never be hit, because if fromCell is on the right edge
            // then Right would not be an available direction, so MoveRight() should not be called.
            // But if this line does actually get hit, neighbor will be null.
            //
            if (maze.IsCellRightEdge(fromCell))
                return neighbor;

            var bottomWall = fromCell.GetBottomWall();
            var rightWall = fromCell.GetRightWall();

            bool bottomClosed = (bottomWall?.Status == WallStatus.Closed);
            bool rightClosed = (rightWall?.Status == WallStatus.Closed);

            if (bottomClosed && rightClosed)
            {
                fromCell.SetWallStatus(Direction.Right, WallStatus.Open);
                return neighbor;
            }

            fromCell.SetWallStatus(Direction.Down, WallStatus.Open);
            fromCell.SetWallStatus(Direction.Right, WallStatus.Open);
            return neighbor;
        }
        //--
        #endregion

        #region Check if Blocked
        //--
        /// <summary>
        /// Determines if the cell is blocked to the right.
        /// </summary>
        /// <param name="maze">The maze containing the cell.</param>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if blocked, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if maze or cell is null.</exception>
        public static bool IsBlockedRight(IMaze maze, IMazeCell cell)
        {
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            var isRightEdge = maze.IsCellRightEdge(cell);
            var rightNeighborSet = maze.GetNeighbor(cell, Direction.Right)?.IsSet() ?? false;

            if (isRightEdge) return true;
            if (rightNeighborSet) return true;

            return false;
        }

        /// <summary>
        /// Determines if the cell is blocked to the left.
        /// </summary>
        /// <param name="maze">The maze containing the cell.</param>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if blocked, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if maze or cell is null.</exception>
        public static bool IsBlockedLeft(IMaze maze, IMazeCell cell)
        {
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            var isLeftEdge = maze.IsCellLeftEdge(cell);
            var leftNeighborSet = maze.GetNeighbor(cell, Direction.Left)?.IsSet() ?? false;

            if (isLeftEdge) return true;
            if (leftNeighborSet) return true;

            return false;
        }

        /// <summary>
        /// Determines if the cell is blocked above.
        /// </summary>
        /// <param name="maze">The maze containing the cell.</param>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if blocked, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if maze or cell is null.</exception>
        public static bool IsBlockedUp(IMaze maze, IMazeCell cell)
        {
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            var isTopRow = maze.IsCellTopRow(cell);
            var upperNeighborIsSet = maze.GetNeighbor(cell, Direction.Up)?.IsSet() ?? false;

            if (isTopRow) return true;
            if (upperNeighborIsSet) return true;

            return false;
        }

        /// <summary>
        /// Determines if the cell is blocked below.
        /// </summary>
        /// <param name="maze">The maze containing the cell.</param>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if blocked, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if maze or cell is null.</exception>
        public static bool IsBlockedDown(IMaze maze, IMazeCell cell)
        {
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            var isBottomRow = maze.IsCellBottomRow(cell);
            var lowerNeighborIsSet = maze.GetNeighbor(cell, Direction.Down)?.IsSet() ?? false;

            if (isBottomRow)
                return !MazeGenerationUtils.CreateExit(maze, cell);

            if (lowerNeighborIsSet)
                return true;

            return false;
        }

        /// <summary>
        /// Determines if an exit can be created at the specified cell.
        /// </summary>
        /// <param name="maze">The maze containing the cell.</param>
        /// <param name="cell">The cell to check for exit creation.</param>
        /// <returns>True if an exit can be created, otherwise false.</returns>
        public static bool CreateExit(IMaze maze, IMazeCell cell) => (maze.IsCellBottomRow(cell) && !maze.ExitExists());
        //--
        #endregion

        #region Get Direction
        //--
        /// <summary>
        /// Gets the previous direction used in maze generation.
        /// </summary>
        /// <param name="previousDirection">The previous direction.</param>
        /// <param name="nextDirection">The next direction.</param>
        /// <returns>The previous direction, or null if nextDirection is null.</returns>
        public static Direction? GetNewPreviousDirection(Direction? previousDirection, Direction? nextDirection)
        {
            if (nextDirection == null)
                return null;

            if (previousDirection != nextDirection)
                return nextDirection;

            return previousDirection;
        }

        /// <summary>
        /// Determines the prohibited direction for the next maze step. 
        /// This allows the program to force a turn or a dead end to prevent long, straight paths.
        /// </summary>
        /// <param name="previousDirection">The previous direction.</param>
        /// <param name="nextDirection">The next direction.</param>
        /// <param name="rnd">Optional random number provider. If null, a default provider is used.</param>
        /// <param name="rndProbability">Probability threshold for prohibiting direction.</param>
        /// <returns>The prohibited direction, or null if none.</returns>
        public static Direction? GetProhibitedDirection(Direction? previousDirection, Direction? nextDirection, IRandomProvider? rnd = null, int rndProbability = 3)
        {
            rnd ??= new RandomProvider();

            if (previousDirection == nextDirection && rnd.Next(rndProbability) == 0)
                return nextDirection;

            return null;
        }

        /// <summary>
        /// Gets the opposite direction of the specified direction.
        /// </summary>
        /// <param name="direction">The direction to get the opposite of.</param>
        /// <returns>The opposite direction.</returns>
        /// <exception cref="ApplicationException">Thrown if an invalid direction is specified.</exception>
        public static Direction GetOppositeDirection(Direction direction)
        {
            return (direction switch
            {
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                _ => throw new ApplicationException("Invalid direction specified."),
            });
        }

        /// <summary>
        /// Calculates the available directions for movement based on blocked and prohibited directions.
        /// </summary>
        /// <param name="isBlockedUp">Whether up is blocked.</param>
        /// <param name="isBlockedRight">Whether right is blocked.</param>
        /// <param name="isBlockedDown">Whether down is blocked.</param>
        /// <param name="isBlockedLeft">Whether left is blocked.</param>
        /// <param name="prohibitedDirection">Optional direction to prohibit.</param>
        /// <returns>An integer representing available directions (bitwise combination).</returns>
        public static int GetAvailableDirections(bool isBlockedUp, bool isBlockedRight, bool isBlockedDown, bool isBlockedLeft, Direction? prohibitedDirection) =>
            0
            + ((isBlockedUp || prohibitedDirection == Direction.Up) ? 0 : (int)Direction.Up)
            + ((isBlockedRight || prohibitedDirection == Direction.Right) ? 0 : (int)Direction.Right)
            + ((isBlockedDown || prohibitedDirection == Direction.Down) ? 0 : (int)Direction.Down)
            + ((isBlockedLeft || prohibitedDirection == Direction.Left) ? 0 : (int)Direction.Left);

        /// <summary>
        /// Randomly selects one of two directions.
        /// </summary>
        /// <param name="firstDirection">The first direction.</param>
        /// <param name="secondDirection">The second direction.</param>
        /// <param name="forceFirst">If true, always selects the first direction.</param>
        /// <param name="rnd">Optional random number provider. If null, a default provider is used.</param>
        /// <returns>The selected direction.</returns>
        /// <exception cref="ApplicationException">Thrown if an invalid random number is generated.</exception>
        public static Direction GetOneOfTwoDirections(Direction firstDirection, Direction secondDirection, bool forceFirst = false, IRandomProvider? rnd = null)
        {
            if (forceFirst)
                return firstDirection;

            rnd ??= new RandomProvider();
            var whichOfTwoOptions = rnd.Next(2);
            return (whichOfTwoOptions switch
            {
                1 => firstDirection,
                0 => secondDirection,
                _ => throw new ApplicationException("Invalid random number generated.")
            });
        }

        /// <summary>
        /// Randomly selects one of three directions.
        /// </summary>
        /// <param name="firstDirection">The first direction.</param>
        /// <param name="secondDirection">The second direction.</param>
        /// <param name="thirdDirection">The third direction.</param>
        /// <param name="rnd">Optional random number provider. If null, a default provider is used.</param>
        /// <returns>The selected direction.</returns>
        /// <exception cref="ApplicationException">Thrown if an invalid random number is generated.</exception>
        public static Direction GetOneOfThreeDirections(Direction firstDirection, Direction secondDirection, Direction thirdDirection, IRandomProvider? rnd = null)
        {
            rnd ??= new RandomProvider();
            var whichOfThreeOptions = rnd.Next(3);
            return (whichOfThreeOptions switch
            {
                1 => firstDirection,
                2 => secondDirection,
                0 => thirdDirection,
                _ => throw new ApplicationException("Invalid random number generated.")
            });
        }

        /// <summary>
        /// Determines the direction to move from the available directions.
        /// </summary>
        /// <param name="availableDirections">Integer representing available directions (bitwise combination).</param>
        /// <param name="createExit">Whether to create an exit.</param>
        /// <param name="exitExists">Whether an exit already exists.</param>
        /// <param name="rnd">Optional random number provider. If null, a default provider is used.</param>
        /// <returns>The selected direction, or null if none available.</returns>
        public static Direction? GetDirectionFromAvailableDirections(int availableDirections, bool createExit, bool exitExists, IRandomProvider? rnd = null)
        {
            rnd ??= new RandomProvider();

            if (availableDirections == (int)Direction.Down)
                return Direction.Down;

            if (availableDirections == (int)Direction.Right)
                return Direction.Right;

            if (availableDirections == (int)Direction.Up)
                return Direction.Up;

            if (availableDirections == (int)Direction.Left)
                return Direction.Left;

            if (availableDirections == (int)Direction.Right + (int)Direction.Down)
                return GetOneOfTwoDirections(Direction.Down, Direction.Right, createExit, rnd);

            if (availableDirections == (int)Direction.Up + (int)Direction.Down)
                return GetOneOfTwoDirections(Direction.Up, Direction.Down, false, rnd);

            if (availableDirections == (int)Direction.Up + (int)Direction.Right)
                return GetOneOfTwoDirections(Direction.Up, Direction.Right, false, rnd);

            if (availableDirections == (int)Direction.Left + (int)Direction.Down)
                return GetOneOfTwoDirections(Direction.Left, Direction.Down, false, rnd);

            if (availableDirections == (int)Direction.Left + (int)Direction.Right)
                return GetOneOfTwoDirections(Direction.Left, Direction.Right, false, rnd);

            if (availableDirections == (int)Direction.Left + (int)Direction.Up)
                return GetOneOfTwoDirections(Direction.Left, Direction.Up, exitExists, rnd);

            if (availableDirections == (int)Direction.Up + (int)Direction.Right + (int)Direction.Down)
                return GetOneOfThreeDirections(Direction.Up, Direction.Right, Direction.Down, rnd);

            if (availableDirections == (int)Direction.Left + (int)Direction.Right + (int)Direction.Down)
                return GetOneOfThreeDirections(Direction.Left, Direction.Right, Direction.Down, rnd);

            if (exitExists && availableDirections == (int)Direction.Left + (int)Direction.Up + (int)Direction.Down)
                return GetOneOfThreeDirections(Direction.Left, Direction.Up, Direction.Down, rnd);

            if (availableDirections == (int)Direction.Left + (int)Direction.Up + (int)Direction.Down)
                return GetOneOfTwoDirections(Direction.Left, Direction.Down, false, rnd);

            if (availableDirections == (int)Direction.Left + (int)Direction.Up + (int)Direction.Right)
                return GetOneOfThreeDirections(Direction.Left, Direction.Up, Direction.Right, rnd);

            return null;
        }
        //--
        #endregion

        /// <summary>
        /// Processes the current maze cell and moves to the next cell based on the direction, 
        /// or a new open cell if the path has reached an end.
        /// </summary>
        /// <param name="maze">The maze being generated.</param>
        /// <param name="cell">The current cell.</param>
        /// <param name="nextDirection">The direction to move, if any.</param>
        /// <returns>The next cell to process.</returns>
        public static IMazeCell GetNextCellToVisit(IMaze maze, IMazeCell cell, Direction? nextDirection = null)
        {
            if (maze.IsCellBottomRow(cell) && !maze.ExitExists() && nextDirection == Direction.Up)
            {
                maze.CreateExit(cell);
                return MazeGenerationUtils.GetNextOpenCell(maze, cell);
            }

            if (nextDirection.HasValue)
                return ((nextDirection.Value) switch
                {
                    Direction.Up => MazeGenerationUtils.MoveUp(cell, maze),
                    Direction.Left => MazeGenerationUtils.MoveLeft(cell, maze),
                    Direction.Down => MazeGenerationUtils.MoveDown(cell, maze),
                    Direction.Right => MazeGenerationUtils.MoveRight(cell, maze),
                    _ => null
                }) ?? MazeGenerationUtils.GetNextOpenCell(maze, null);

            return MazeGenerationUtils.GetNextOpenCell(maze, cell);
        }

        /// <summary>
        /// Finds the next open cell in the maze for path generation.
        /// </summary>
        /// <param name="maze">The maze being generated.</param>
        /// <param name="cell">The current cell, or null to start from (0,0).</param>
        /// <returns>The next open cell.</returns>
        /// <exception cref="ArgumentNullException">Thrown if maze is null.</exception>
        /// <exception cref="ApplicationException">Thrown if no next cell is found.</exception>
        public static IMazeCell GetNextOpenCell(IMaze maze, IMazeCell? cell)
        {
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            IMazeCell? nextCell = cell;
            var loop = true;
            var firstLoop = true;

            while (loop)
            {
                if (nextCell == cell && !firstLoop)
                    throw new ApplicationException("No next cell found.");

                firstLoop = false;

                if (nextCell == null)
                {
                    nextCell = maze.GetCell((0, 0));
                    continue;
                }

                if (!maze.IsCellRightEdge(nextCell))
                {
                    nextCell = maze.GetCell((nextCell.Coordinates.column + 1, nextCell.Coordinates.row));
                    loop = (nextCell?.IsSet() != true);
                    continue;
                }

                if (!maze.IsCellBottomRow(nextCell))
                {
                    nextCell = maze.GetCell((0, nextCell.Coordinates.row + 1));
                    loop = (nextCell?.IsSet() != true);
                    continue;
                }

                nextCell = maze.GetCell((0, 0));
                loop = true;
            }

            return nextCell;
        }

        /// <summary>
        /// Creates a new maze matrix with the specified dimensions and sets the top opening.
        /// </summary>
        /// <param name="dimensions">The width and height of the maze.</param>
        /// <param name="rnd">Optional random number provider for opening selection. If null, a default provider is used.</param>
        /// <returns>The initialized maze matrix.</returns>
        public static IMaze CreateMatrix((uint width, uint height) dimensions, IRandomProvider? rnd = null)
        {
            rnd ??= new RandomProvider();
            var maze = GenerateCellsWithinMaze(new Maze(dimensions), dimensions);
            MazeGenerationUtils.CreateAllCellWalls(maze);
            var column = (uint)rnd.Next(0, (int)dimensions.width);
            MazeGenerationUtils.SetTopOpening(maze, (column, 0));

            return maze;
        }

        /// <summary>
        /// Creates all walls for every cell in the maze.
        /// </summary>
        /// <param name="maze">The maze to process.</param>
        public static void CreateAllCellWalls(IMaze maze)
        {
            foreach (var cell in maze.MazeCells)
            {
                MazeGenerationUtils.CreateCellWall(cell, maze.GetNeighbor(cell, Direction.Up), Direction.Up);
                MazeGenerationUtils.CreateCellWall(cell, maze.GetNeighbor(cell, Direction.Down), Direction.Down);
                MazeGenerationUtils.CreateCellWall(cell, maze.GetNeighbor(cell, Direction.Right), Direction.Right);
                MazeGenerationUtils.CreateCellWall(cell, maze.GetNeighbor(cell, Direction.Left), Direction.Left);
            }
        }

        /// <summary>
        /// Creates a wall between the specified cell and its neighbor in the given direction.
        /// </summary>
        /// <param name="cell">The cell to create the wall for.</param>
        /// <param name="neighbor">The neighboring cell.</param>
        /// <param name="direction">The direction of the wall.</param>
        /// <exception cref="ApplicationException">Thrown if cell wall mismatch occurs.</exception>
        public static void CreateCellWall(IMazeCell cell, IMazeCell? neighbor, Direction direction)
        {
            var cellWall = cell.GetWall(direction);
            var oppositeDirection = GetOppositeDirection(direction);

            if (cellWall != null && neighbor == null)
                return;

            if (cellWall != null && neighbor!.GetWall(oppositeDirection) == null)
            {
                neighbor.CreateWall(oppositeDirection, cellWall);
                return;
            }

            if (cellWall != null && neighbor!.GetWall(oppositeDirection) != cellWall)
                throw new ApplicationException("Cell wall mismatch.");

            if (cellWall != null)
                return;

            if (neighbor?.GetWall(oppositeDirection) != null)
                throw new ApplicationException("Cell wall mismatch.");

            var wall = new MazeCellWall();

            cell.CreateWall(direction, wall);
            neighbor?.CreateWall(oppositeDirection, wall);
        }

        /// <summary>
        /// Sets the top opening for the maze at the specified coordinates.
        /// </summary>
        /// <param name="maze">The maze to modify.</param>
        /// <param name="coordinates">The coordinates of the opening cell.</param>
        /// <exception cref="ApplicationException">Thrown if no opening cell is created.</exception>
        public static void SetTopOpening(IMaze maze, (uint column, uint row) coordinates)
        {
            var openingCell = maze.MazeCells.Where(x => x.Coordinates == coordinates).FirstOrDefault() 
                ?? throw new ApplicationException("No opening cell created.");

            openingCell.SetWallStatus(Direction.Up, Enums.WallStatus.Open);
            maze.SetCellPathStep(openingCell);
        }
    }
}
