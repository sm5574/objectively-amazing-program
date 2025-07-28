using System.ComponentModel;

namespace ObjectivelyAmazingProgramCore
{
    /// <summary>
    /// Contains enumerations used throughout the maze generation library.
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Represents the four cardinal directions in the maze.
        /// </summary>
        public enum Direction
        {
            /// <summary>
            /// The upward (top) direction.
            /// </summary>
            [Description("Top")]
            Up = 1,
            /// <summary>
            /// The rightward direction.
            /// </summary>
            [Description("Right")]
            Right = 2,
            /// <summary>
            /// The downward (bottom) direction.
            /// </summary>
            [Description("Bottom")]
            Down = 4,
            /// <summary>
            /// The leftward direction.
            /// </summary>
            [Description("Left")]
            Left = 8
        }

        /// <summary>
        /// Represents the walls of a maze cell.
        /// </summary>
        public enum Wall
        {
            /// <summary>
            /// The top wall of the cell.
            /// </summary>
            Top = 1,
            /// <summary>
            /// The right wall of the cell.
            /// </summary>
            Right = 2,
            /// <summary>
            /// The bottom wall of the cell.
            /// </summary>
            Bottom = 4,
            /// <summary>
            /// The left wall of the cell.
            /// </summary>
            Left = 8
        }

        /// <summary>
        /// Represents the bit position for each wall in a bitmask.
        /// </summary>
        public enum WallBitPlace
        {
            /// <summary>
            /// The bit position for the top wall.
            /// </summary>
            Top = 0,
            /// <summary>
            /// The bit position for the right wall.
            /// </summary>
            Right = 1,
            /// <summary>
            /// The bit position for the bottom wall.
            /// </summary>
            Bottom = 2,
            /// <summary>
            /// The bit position for the left wall.
            /// </summary>
            Left = 3
        }

        /// <summary>
        /// Represents the status of a maze exit.
        /// </summary>
        public enum ExitStatus
        {
            /// <summary>
            /// No exit status.
            /// </summary>
            NoStatus,
            /// <summary>
            /// Indicates an exit should be created.
            /// </summary>
            CreateExit,
            /// <summary>
            /// Indicates an exit already exists.
            /// </summary>
            ExitExists
        }

        /// <summary>
        /// Represents the open or closed status of a wall.
        /// </summary>
        public enum WallStatus
        {
            /// <summary>
            /// The wall is open.
            /// </summary>
            Open,
            /// <summary>
            /// The wall is closed.
            /// </summary>
            Closed
        }
    }
}