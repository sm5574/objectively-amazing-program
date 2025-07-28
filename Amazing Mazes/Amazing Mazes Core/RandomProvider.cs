using System;
using ObjectivelyAmazingProgramCore.Interfaces;

namespace ObjectivelyAmazingProgramCore
{
    /// <summary>
    /// Default implementation of IRandomProvider using System.Random.
    /// The seed is set via the constructor for reproducible random sequences.
    /// </summary>
    public class RandomProvider : IRandomProvider
    {
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomProvider"/> class.
        /// </summary>
        /// <param name="seed">Optional seed for the random number generator. If not provided, uses a time-dependent default seed.</param>
        public RandomProvider(int? seed = null)
        {
            _random = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        /// <inheritdoc/>
        public int Next()
        {
            return _random.Next();
        }

        /// <inheritdoc/>
        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        /// <inheritdoc/>
        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        /// <inheritdoc/>
        public double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}