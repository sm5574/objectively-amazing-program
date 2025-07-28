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
    /// Represents a wall between maze cells, with an open or closed status.
    /// </summary>
    public class MazeCellWall : IMazeCellWall
    {
        /// <summary>
        /// Gets or sets the status of the wall (open or closed).
        /// </summary>
        public WallStatus Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeCellWall"/> class with the wall status set to closed.
        /// </summary>
        public MazeCellWall()
        {
            Status = WallStatus.Closed;
        }
    }
}
