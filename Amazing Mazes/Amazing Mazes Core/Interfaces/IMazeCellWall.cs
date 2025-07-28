using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramCore.Interfaces
{
    /// <summary>
    /// Represents a wall between maze cells, with an open or closed status.
    /// </summary>
    public interface IMazeCellWall
    {
        /// <summary>
        /// Gets or sets the status of the wall (open or closed).
        /// </summary>
        WallStatus Status { get; set; }
    }
}
