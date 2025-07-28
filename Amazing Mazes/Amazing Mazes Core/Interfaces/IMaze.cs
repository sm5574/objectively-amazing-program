using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Interfaces
{
    /// <summary>
    /// Represents a maze structure, including its dimensions, cells, openings, and operations for maze generation and querying.
    /// </summary>
    public interface IMaze
    {
        /// <summary>
        /// Gets the dimensions of the maze (width and height).
        /// </summary>
        (uint width, uint height) Dimensions { get; }

        /// <summary>
        /// Gets the coordinates of the top opening of the maze.
        /// </summary>
        (uint column, uint row) TopOpening { get; }

        /// <summary>
        /// Gets the coordinates of the bottom opening of the maze.
        /// </summary>
        (uint column, uint row) BottomOpening { get; }

        /// <summary>
        /// Gets the list of cells in the maze.
        /// </summary>
        List<IMazeCell> MazeCells { get; }

        /// <summary>
        /// Creates an exit at the specified cell in the bottom row.
        /// </summary>
        /// <param name="cell">The cell to create the exit at.</param>
        void CreateExit(IMazeCell cell);

        /// <summary>
        /// Determines whether an exit exists in the bottom row of the maze.
        /// </summary>
        /// <returns>True if an exit exists; otherwise, false.</returns>
        bool ExitExists();

        /// <summary>
        /// Gets the cell at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates of the cell.</param>
        /// <returns>The cell at the coordinates, or null if not found.</returns>
        IMazeCell? GetCell((uint column, uint row) coordinates);

        /// <summary>
        /// Determines if the specified cell is in the top row of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is in the top row; otherwise, false.</returns>
        bool IsCellTopRow(IMazeCell cell);

        /// <summary>
        /// Determines if the specified cell is on the left edge of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is on the left edge; otherwise, false.</returns>
        bool IsCellLeftEdge(IMazeCell cell);

        /// <summary>
        /// Determines if the specified cell is in the bottom row of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is in the bottom row; otherwise, false.</returns>
        bool IsCellBottomRow(IMazeCell cell);

        /// <summary>
        /// Determines if the specified cell is on the right edge of the maze.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is on the right edge; otherwise, false.</returns>
        bool IsCellRightEdge(IMazeCell cell);

        /// <summary>
        /// Gets the neighboring cell in the specified direction.
        /// </summary>
        /// <param name="cell">The cell to find the neighbor for.</param>
        /// <param name="direction">The direction of the neighbor.</param>
        /// <returns>The neighboring cell, or null if not found.</returns>
        IMazeCell? GetNeighbor(IMazeCell cell, Direction direction);

        /// <summary>
        /// Gets the first unset cell in the maze.
        /// </summary>
        /// <returns>The first unset cell, or null if all are set.</returns>
        IMazeCell? GetUnsetCell();

        /// <summary>
        /// Gets the count of cells that have been set in the maze path.
        /// </summary>
        /// <returns>The number of set cells.</returns>
        uint GetSetCellCount();

        /// <summary>
        /// Determines whether the maze is completely generated.
        /// </summary>
        /// <returns>True if the maze is complete; otherwise, false.</returns>
        bool IsComplete();

        /// <summary>
        /// Sets the path step for the specified cell.
        /// </summary>
        /// <param name="cell">The cell to set the path step for.</param>
        void SetCellPathStep(IMazeCell cell);

        /// <summary>
        /// Adds a cell to the maze at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates of the cell to add.</param>
        void AddCell((uint column, uint row) coordinates);

        /// <summary>
        /// Gets the opening cell at the top row with an open top wall.
        /// </summary>
        /// <returns>The opening cell, or null if not found.</returns>
        IMazeCell? GetOpeningCell();
    }
}
