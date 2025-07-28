using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Interfaces
{
    /// <summary>
    /// Provides random number generation services for maze generation, with seed set via constructor.
    /// </summary>
    public interface IRandomProvider
    {
        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>A non-negative random integer.</returns>
        int Next();

        /// <summary>
        /// Returns a non-negative random integer less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound.</param>
        /// <returns>A non-negative random integer less than maxValue.</returns>
        int Next(int maxValue);

        /// <summary>
        /// Returns a random integer within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound.</param>
        /// <param name="maxValue">The exclusive upper bound.</param>
        /// <returns>A random integer greater than or equal to minValue and less than maxValue.</returns>
        int Next(int minValue, int maxValue);

        /// <summary>
        /// Returns a random floating-point number between 0.0 and 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number between 0.0 and 1.0.</returns>
        double NextDouble();
    }
}