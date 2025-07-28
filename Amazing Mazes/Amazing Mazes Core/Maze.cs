using ObjectivelyAmazingProgramCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore
{
    /// <summary>
    /// Represents a maze consisting of cells, dimensions, and openings, and provides methods for maze manipulation and querying.
    /// </summary>
    public class Maze : IMaze
    {
        private readonly List<IMazeCell> _mazeCells;

        /// <summary>
        /// Gets the dimensions of the maze (width and height).
        /// </summary>
        public (uint width, uint height) Dimensions { get; private set; }

        /// <summary>
        /// Gets the coordinates of the top opening of the maze.
        /// </summary>
        public (uint column, uint row) TopOpening { get; private set; }

        /// <summary>
        /// Gets the coordinates of the bottom opening of the maze.
        /// </summary>
        public (uint column, uint row) BottomOpening { get; private set; }

        /// <summary>
        /// Gets the list of cells in the maze.
        /// </summary>
        public List<IMazeCell> MazeCells => _mazeCells;

        /// <summary>
        /// Initializes a new maze with the specified dimensions.
        /// </summary>
        /// <param name="dimensions">The width and height of the maze.</param>
        public Maze((uint width, uint height) dimensions)
        {
            Dimensions = dimensions;
            _mazeCells = new List<IMazeCell>();
        }

        /// <summary>
        /// Calculates the width of the maze from the provided cells.
        /// </summary>
        /// <param name="mazeCells">The list of maze cells.</param>
        /// <returns>The width of the maze.</returns>
        private static uint GetMazeWidth(List<IMazeCell> mazeCells) => 
            (mazeCells?.OrderByDescending(x => x.Coordinates.column).FirstOrDefault()?.Coordinates.column ?? 0) + 1;

        /// <summary>
        /// Calculates the height of the maze from the provided cells.
        /// </summary>
        /// <param name="mazeCells">The list of maze cells.</param>
        /// <returns>The height of the maze.</returns>
        private static uint GetMazeHeight(List<IMazeCell> mazeCells) =>
            (mazeCells?.OrderByDescending(x => x.Coordinates.row).FirstOrDefault()?.Coordinates.row ?? 0) + 1;

        /// <summary>
        /// Initializes a new maze from a list of cells, inferring dimensions.
        /// </summary>
        /// <param name="mazeCells">The list of maze cells.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the cells do not match the expected dimensions.</exception>
        public Maze(List<IMazeCell> mazeCells)
        {
            var width = GetMazeWidth(mazeCells);
            var height = GetMazeHeight(mazeCells);

            if (width * height <= 1)
                throw new ArgumentOutOfRangeException(nameof(mazeCells), "Maze cells must be in final form to use this constructor.");

            if (mazeCells?.Count != width * height)
                throw new ArgumentOutOfRangeException(nameof(mazeCells), "Maze cells height/width mismatch.");

            _mazeCells = mazeCells;

            (uint width, uint height) dimensions;
            dimensions.width = width;
            dimensions.height = height;

            Dimensions = dimensions;
        }

        /// <summary>
        /// Validates the provided maze cells. (Currently not implemented.)
        /// </summary>
        /// <param name="mazeCells">The list of maze cells to validate.</param>
        private void ValidateMazeCells(List<IMazeCell> mazeCells)
        {

        }

        /// <summary>
        /// Adds a cell to the maze at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates of the cell to add.</param>
        /// <exception cref="ApplicationException">Thrown if a cell already exists at the coordinates or the maze is full.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the coordinates are out of bounds.</exception>
        public void AddCell((uint column, uint row) coordinates)
        {
            if (GetCell(coordinates) != null)
                throw new ApplicationException($"A cell already exists at coordinates {coordinates.column}, {coordinates.row}.");

            if (coordinates.column < 0 || coordinates.column >= Dimensions.width || coordinates.row < 0 || coordinates.row >= Dimensions.height)
                throw new ArgumentOutOfRangeException(nameof(coordinates));

            if (_mazeCells.Count >= Dimensions.width * Dimensions.height)
                throw new ApplicationException("Cannot add any more cells to maze.");

            _mazeCells.Add(new MazeCell(coordinates));
        }

        /// <summary>
        /// Gets the cell at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates of the cell.</param>
        /// <returns>The cell at the coordinates, or null if not found.</returns>
        public IMazeCell? GetCell((uint column, uint row) coordinates) => _mazeCells?.Where(x => x.Coordinates == coordinates).FirstOrDefault();

        /// <summary>
        /// Determines if the specified cell is in the top row of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is in the top row; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the cell is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the cell is not in the maze.</exception>
        public bool IsCellTopRow(IMazeCell cell)
        {
            if (cell == null) 
                throw new ArgumentNullException(nameof(cell));

            if (!_mazeCells.Contains(cell))
                throw new ArgumentOutOfRangeException(nameof(cell));

            return (cell.Coordinates.row == 0);
        }

        /// <summary>
        /// Determines if the specified cell is on the left edge of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is on the left edge; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the cell is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the cell is not in the maze.</exception>
        public bool IsCellLeftEdge(IMazeCell cell)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            if (!_mazeCells.Contains(cell))
                throw new ArgumentOutOfRangeException(nameof(cell));

            return (cell.Coordinates.column == 0);
        }

        /// <summary>
        /// Determines if the specified cell is in the bottom row of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is in the bottom row; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the cell is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the cell is not in the maze.</exception>
        public bool IsCellBottomRow(IMazeCell cell)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            if (!_mazeCells.Contains(cell))
                throw new ArgumentOutOfRangeException(nameof(cell));

            return (cell.Coordinates.row == Dimensions.height - 1);
        }

        /// <summary>
        /// Determines if the specified cell is on the right edge of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is on the right edge; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the cell is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the cell is not in the maze.</exception>
        public bool IsCellRightEdge(IMazeCell cell)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            if (!_mazeCells.Contains(cell))
                throw new ArgumentOutOfRangeException(nameof(cell));

            return (cell.Coordinates.column == Dimensions.width - 1);
        }

        /// <summary>
        /// Gets the neighboring cell in the specified direction.
        /// </summary>
        /// <param name="cell">The cell to find the neighbor for.</param>
        /// <param name="direction">The direction of the neighbor.</param>
        /// <returns>The neighboring cell, or null if not found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the cell is null.</exception>
        /// <exception cref="ApplicationException">Thrown if the direction is invalid.</exception>
        public IMazeCell? GetNeighbor(IMazeCell cell, Direction direction)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            return (direction switch
            {
                Direction.Up => GetCell((cell.Coordinates.column, cell.Coordinates.row - 1)),
                Direction.Down => GetCell((cell.Coordinates.column, cell.Coordinates.row + 1)),
                Direction.Left => GetCell((cell.Coordinates.column - 1, cell.Coordinates.row)),
                Direction.Right => GetCell((cell.Coordinates.column + 1, cell.Coordinates.row)),
                _ => throw new ApplicationException("Invalid direction specified."),
            });
        }

        /// <summary>
        /// Gets the first unset cell in the maze.
        /// </summary>
        /// <returns>The first unset cell, or null if all are set.</returns>
        public IMazeCell? GetUnsetCell() => _mazeCells.Where(x => !x.IsSet()).FirstOrDefault();

        /// <summary>
        /// Determines whether the maze is completely generated.
        /// </summary>
        /// <returns>True if the maze is complete; otherwise, false.</returns>
        /// <exception cref="ApplicationException">Thrown if the maze is complete but no exit exists.</exception>
        public bool IsComplete()
        {
            var emptyCells = _mazeCells.Where(x => !x.IsSet()).Any();

            if (emptyCells)
                return false;

            if (!emptyCells && !ExitExists())
                throw new ApplicationException("Maze is complete, but no exit exists.");

            return true;
        }

        /// <summary>
        /// Gets the opening cell at the top row with an open top wall.
        /// </summary>
        /// <returns>The opening cell, or null if not found.</returns>
        public IMazeCell? GetOpeningCell() => 
            _mazeCells.Where(x => IsCellTopRow(x) && x.IsSet() && x.GetWall(Direction.Up)?.Status == WallStatus.Open).FirstOrDefault();

        /// <summary>
        /// Determines whether an exit exists in the bottom row of the maze.
        /// </summary>
        /// <returns>True if an exit exists; otherwise, false.</returns>
        public bool ExitExists() => 
            _mazeCells.Where(x => IsCellBottomRow(x) && x.IsSet() && x.GetWall(Direction.Down)?.Status == WallStatus.Open).Any();

        /// <summary>
        /// Gets the count of cells that have been set in the maze path.
        /// </summary>
        /// <returns>The number of set cells.</returns>
        public uint GetSetCellCount() => (uint)_mazeCells.Where(x => x.IsSet()).Count();

        /// <summary>
        /// Sets the path step for the specified cell.
        /// </summary>
        /// <param name="cell">The cell to set the path step for.</param>
        /// <exception cref="ArgumentNullException">Thrown if the cell is null.</exception>
        /// <exception cref="ApplicationException">Thrown if the cell is already set.</exception>
        public void SetCellPathStep(IMazeCell cell)
        {
            if (cell == null) 
                throw new ArgumentNullException(nameof(cell));

            if (cell.IsSet())
                throw new ApplicationException("Cell already set.");

            cell.SetPathStep(GetSetCellCount() + 1);
        }

        /// <summary>
        /// Creates an exit at the specified cell in the bottom row.
        /// </summary>
        /// <param name="cell">The cell to create the exit at.</param>
        /// <exception cref="ApplicationException">Thrown if an exit already exists.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the cell is not in the bottom row.</exception>
        public void CreateExit(IMazeCell cell)
        {
            if (ExitExists()) 
                throw new ApplicationException("Exit already exists.");

            if (cell.Coordinates.row != Dimensions.height - 1)
                throw new ArgumentOutOfRangeException(nameof(cell), "An attempt was made to create an exit on a cell that is not on the bottom row.");

            cell.SetBottomWallStatus(WallStatus.Open);
        }

        // /// <summary>
        // /// Gets the integer representation of the walls for the cell at the specified coordinates.
        // /// </summary>
        // /// <param name="column">The column of the cell.</param>
        // /// <param name="row">The row of the cell.</param>
        // /// <returns>The integer encoding of the cell's walls.</returns>
        // /// <exception cref="ApplicationException">Thrown if no cell is found at the specified coordinates.</exception>
        // public int GetCellWalls(int column, int row)
        // {
        //     var walls = _mazeCells.Where(o => o.Coordinates.column == column && o.Coordinates.row == row).FirstOrDefault()?.GetWallsAsInt();

        //     if (walls.HasValue)
        //         return walls.Value;

        //     throw new ApplicationException($"No cell walls were found matching column {column}, row {row}.");
        // }
    }
}
