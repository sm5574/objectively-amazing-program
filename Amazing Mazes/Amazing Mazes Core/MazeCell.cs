using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectivelyAmazingProgramCore.Interfaces;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore
{
    /// <summary>
    /// Represents a cell within a maze, including its coordinates, path step, and walls.
    /// </summary>
    public class MazeCell : IMazeCell
    {
        private IMazeCellWall? _topWall = null;
        private IMazeCellWall? _bottomWall = null;
        private IMazeCellWall? _leftWall = null;
        private IMazeCellWall? _rightWall = null;

        /// <summary>
        /// Gets or sets the coordinates of the cell within the maze.
        /// </summary>
        public (uint column, uint row) Coordinates { get; set; }

        /// <summary>
        /// Gets the path step value for the cell. Zero indicates unset.
        /// </summary>
        public uint PathStep { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeCell"/> class with the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The column and row coordinates of the cell.</param>
        public MazeCell((uint column, uint row) coordinates)
        {
            Coordinates = coordinates;
            PathStep = 0;
        }

        /// <summary>
        /// Determines whether the cell has been set in the maze path.
        /// </summary>
        /// <returns>True if the cell is set; otherwise, false.</returns>
        public bool IsSet() => (PathStep > 0);

        // /// <summary>
        // /// Returns an integer representation of the cell's wall configuration.
        // /// </summary>
        // /// <returns>An integer encoding the wall states.</returns>
        // public int GetWallsAsInt()
        // {
        //     throw new NotImplementedException();
        // }

        /// <summary>
        /// Assigns a wall to the cell in the specified direction.
        /// </summary>
        /// <param name="direction">The direction of the wall.</param>
        /// <param name="wall">The wall object to assign.</param>
        /// <exception cref="ApplicationException">Thrown if the direction is invalid.</exception>
        public void CreateWall(Direction direction, IMazeCellWall wall)
        {
            switch (direction)
            {
                case Direction.Left: 
                    _leftWall = wall; 
                    break;
                case Direction.Right: 
                    _rightWall = wall; 
                    break;
                case Direction.Up: 
                    _topWall = wall; 
                    break;
                case Direction.Down: 
                    _bottomWall = wall; 
                    break;
                default: 
                    throw new ApplicationException("Invalid direction specified.");
            }
        }

        /// <summary>
        /// Gets the wall object for the specified direction.
        /// </summary>
        /// <param name="direction">The direction of the wall.</param>
        /// <returns>The wall object, or null if not present.</returns>
        /// <exception cref="ApplicationException">Thrown if the direction is invalid.</exception>
        public IMazeCellWall? GetWall(Direction direction)
        {
            return (direction switch
            {
                Direction.Left => _leftWall,
                Direction.Right => _rightWall,
                Direction.Up => _topWall,
                Direction.Down => _bottomWall,
                _ => throw new ApplicationException("Invalid direction specified."),
            });
        }

        /// <summary>
        /// Gets the top wall of the cell.
        /// </summary>
        /// <returns>The top wall object, or null if not present.</returns>
        public IMazeCellWall? GetTopWall() => _topWall;

        /// <summary>
        /// Gets the bottom wall of the cell.
        /// </summary>
        /// <returns>The bottom wall object, or null if not present.</returns>
        public IMazeCellWall? GetBottomWall() => _bottomWall;

        /// <summary>
        /// Gets the left wall of the cell.
        /// </summary>
        /// <returns>The left wall object, or null if not present.</returns>
        public IMazeCellWall? GetLeftWall() => _leftWall;

        /// <summary>
        /// Gets the right wall of the cell.
        /// </summary>
        /// <returns>The right wall object, or null if not present.</returns>
        public IMazeCellWall? GetRightWall() => _rightWall;

        /// <summary>
        /// Sets the status of the wall in the specified direction.
        /// </summary>
        /// <param name="direction">The direction of the wall.</param>
        /// <param name="wallStatus">The status to set (open or closed).</param>
        /// <exception cref="ApplicationException">Thrown if the wall is null or direction is invalid.</exception>
        public void SetWallStatus(Direction direction, WallStatus wallStatus)
        {
            IMazeCellWall? wall = (direction) switch
            {
                Direction.Left => _leftWall,
                Direction.Right => _rightWall,
                Direction.Up => _topWall,
                Direction.Down => _bottomWall,
                _ => throw new ApplicationException("Invalid direction specified."),
            } 
            ?? throw new ApplicationException($"{direction.GetDescription()} wall is null. Status cannot be set.");
            
            wall.Status = wallStatus;
        }

        /// <summary>
        /// Sets the status of the bottom wall.
        /// </summary>
        /// <param name="status">The status to set (open or closed).</param>
        /// <exception cref="ApplicationException">Thrown if the bottom wall is null.</exception>
        public void SetBottomWallStatus(WallStatus status)
        {
            if (_bottomWall is null)
                throw new ApplicationException("Bottom wall is null. Status cannot be set.");

            _bottomWall.Status = status;
        }

        /// <summary>
        /// Sets the path step value for the cell.
        /// </summary>
        /// <param name="step">The path step value to set. Must be greater than zero.</param>
        /// <exception cref="ApplicationException">Thrown if the path step is already set.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the step value is zero or negative.</exception>
        public void SetPathStep(uint step)
        {
            if (IsSet())
                throw new ApplicationException("PathStep already has a value.");

            if (step <= 0)
                throw new ArgumentOutOfRangeException(nameof(step));

            PathStep = step;
        }
    }
}
