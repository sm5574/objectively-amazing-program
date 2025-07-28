using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivelyAmazingProgramCore.Tests
{
    public partial class MazeTests
    {
        [TestMethod]
        public void SetCellPathStep_WhenCalled_SetsPathStepEqualToSetCellCount()
        {
            var cellVal1 = (WidthVal2 - 1, HeightVal2 - 1);
            var cellVal2 = (WidthVal2 - 2, HeightVal2 - 2);
            var maze = new Maze(_dimensions);

            maze.AddCell(cellVal1);
            var cell = maze.GetCell(cellVal1);
            Assert.IsNotNull(cell);

            maze.SetCellPathStep(cell!);
            Assert.AreEqual(maze.GetSetCellCount(), cell!.PathStep);

            maze.AddCell(cellVal2);
            var cell2 = maze.GetCell(cellVal2);
            Assert.IsNotNull(cell2);

            maze.SetCellPathStep(cell2!);
            Assert.AreEqual(maze.GetSetCellCount(), cell2!.PathStep);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SetCellPathStep_WhenCellIsAlreadySet_ThrowsApplicationException()
        {
            var cellVal1 = (WidthVal2 - 1, HeightVal2 - 1);
            var maze = new Maze(_dimensions);

            maze.AddCell(cellVal1);
            var cell = maze.GetCell(cellVal1);
            Assert.IsNotNull(cell);

            maze.SetCellPathStep(cell!);
            maze.SetCellPathStep(cell!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetCellPathStep_WhenCellIsNull_ThrowsArgumentNullException()
        {
            var cellVal1 = (WidthVal2 - 1, HeightVal2 - 1);
            var maze = new Maze(_dimensions);

            maze.AddCell(cellVal1);
            maze.SetCellPathStep(null);
        }
    }
}
