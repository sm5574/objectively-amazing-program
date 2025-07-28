using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Interfaces
{
    /// <summary>
    /// Represents a cell within a maze, including its coordinates, path step, and wall management operations.
    /// </summary>
    public interface IMazeCell
    {
        /// <summary>
        /// Gets or sets the coordinates of the cell within the maze.
        /// </summary>
        (uint column, uint row) Coordinates { get; set; }

        /// <summary>
        /// Gets the path step value for the cell. Zero indicates unset.
        /// </summary>
        uint PathStep { get; }

        /// <summary>
        /// Determines whether the cell has been set in the maze path.
        /// </summary>
        /// <returns>True if the cell is set; otherwise, false.</returns>
        bool IsSet();

        // /// <summary>
        // /// Returns an integer representation of the cell's wall configuration.
        // /// </summary>
        // /// <returns>An integer encoding the wall states.</returns>
        // int GetWallsAsInt();

        /// <summary>
        /// Sets the path step value for the cell.
        /// </summary>
        /// <param name="step">The path step value to set. Must be greater than zero.</param>
        void SetPathStep(uint step);

        /// <summary>
        /// Assigns a wall to the cell in the specified direction.
        /// </summary>
        /// <param name="direction">The direction of the wall.</param>
        /// <param name="wall">The wall object to assign.</param>
        void CreateWall(Direction direction, IMazeCellWall wall);

        /// <summary>
        /// Gets the wall object for the specified direction.
        /// </summary>
        /// <param name="direction">The direction of the wall.</param>
        /// <returns>The wall object, or null if not present.</returns>
        IMazeCellWall? GetWall(Direction direction);

        /// <summary>
        /// Gets the top wall of the cell.
        /// </summary>
        /// <returns>The top wall object, or null if not present.</returns>
        IMazeCellWall? GetTopWall();

        /// <summary>
        /// Gets the bottom wall of the cell.
        /// </summary>
        /// <returns>The bottom wall object, or null if not present.</returns>
        IMazeCellWall? GetBottomWall();

        /// <summary>
        /// Gets the left wall of the cell.
        /// </summary>
        /// <returns>The left wall object, or null if not present.</returns>
        IMazeCellWall? GetLeftWall();

        /// <summary>
        /// Gets the right wall of the cell.
        /// </summary>
        /// <returns>The right wall object, or null if not present.</returns>
        IMazeCellWall? GetRightWall();

        /// <summary>
        /// Sets the status of the wall in the specified direction.
        /// </summary>
        /// <param name="direction">The direction of the wall.</param>
        /// <param name="wallStatus">The status to set (open or closed).</param>
        void SetWallStatus(Direction direction, WallStatus wallStatus);

        /// <summary>
        /// Sets the status of the bottom wall.
        /// </summary>
        /// <param name="status">The status to set (open or closed).</param>
        void SetBottomWallStatus(WallStatus status);
    }
}