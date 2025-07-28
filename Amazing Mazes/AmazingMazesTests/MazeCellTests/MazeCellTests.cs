using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Tests
{
    [TestClass]
    public partial class MazeCellTests
    {
        private (uint column, uint row) _coordinates;
        private MazeCell _cell = null!;

        [TestInitialize]
        public void Initialize()
        {
            _coordinates = (1, 1);
            _cell = new MazeCell(_coordinates);
        }

    }
}
