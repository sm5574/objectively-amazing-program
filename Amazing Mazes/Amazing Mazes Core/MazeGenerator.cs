using ObjectivelyAmazingProgramCore.Interfaces;
using System.Runtime.CompilerServices;
using static ObjectivelyAmazingProgramCore.Enums;
[assembly: InternalsVisibleTo("ObjectivelyAmazingProgramTests")]

namespace ObjectivelyAmazingProgramCore
{
    public class MazeGenerator
    {
        private const int BaseForceChangeProbability = 3;

        private IMaze _maze;
        private IRandomProvider _rnd;

        internal IMazeCell Cell { get; set; }
        internal int ForceChangeVal { get; set; }
        internal Direction? NextDirection { get; set; }
        internal Direction? PreviousDirection { get; set; }
        internal Direction? ProhibitedDirection { get; set; }
        internal int AvailableDirections { get; set; }

        public MazeGenerator(IMaze maze, IMazeCell cell, IRandomProvider? rnd = null)
        {
            _maze = maze;
            Cell = cell;
            _rnd = rnd ?? new RandomProvider();

            ForceChangeVal = BaseForceChangeProbability;
        }

        public IMaze Generate()
        {
            do
            {
                DetermineAvailableDirections();
                DetermineNextDirection();
                DetermineProbabilityOfChange();
                DeterminePreviousDirection();
                DetermineProhibitedDirection();
                DetermineNextCell();

                if (!Cell.IsSet())
                    _maze.SetCellPathStep(Cell);
            } while (!_maze.IsComplete());

            return _maze;
        }

        internal bool MustCreateExit() => MazeGenerationUtils.CreateExit(_maze, Cell);
        internal bool ExitExists() => _maze.ExitExists();

        internal void DetermineAvailableDirections()
        {
            AvailableDirections = MazeGenerationUtils.GetAvailableDirections(
                MazeGenerationUtils.IsBlockedUp(_maze, Cell),
                MazeGenerationUtils.IsBlockedRight(_maze, Cell),
                MazeGenerationUtils.IsBlockedDown(_maze, Cell),
                MazeGenerationUtils.IsBlockedLeft(_maze, Cell),
                ProhibitedDirection);
        }

        internal void DetermineNextDirection()
        {
            NextDirection = MazeGenerationUtils.GetDirectionFromAvailableDirections(AvailableDirections, MustCreateExit(), ExitExists(), _rnd);
        }

        internal void DeterminePreviousDirection()
        {
            PreviousDirection = MazeGenerationUtils.GetNewPreviousDirection(PreviousDirection, NextDirection);
        }

        internal void DetermineProhibitedDirection()
        {
            ProhibitedDirection = MazeGenerationUtils.GetProhibitedDirection(PreviousDirection, NextDirection, _rnd, ForceChangeVal);
        }

        internal void DetermineProbabilityOfChange()
        {
            if (PreviousDirection == NextDirection && ForceChangeVal > 0)
                ForceChangeVal--;
            else
                ForceChangeVal = BaseForceChangeProbability;
        }

        internal void DetermineNextCell()
        {
            Cell = MazeGenerationUtils.GetNextCellToVisit(_maze, Cell, NextDirection);
        }
    }
}
