using System;
using System.IO;
using ObjectivelyAmazingProgramConsole;
using ObjectivelyAmazingProgramCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static ObjectivelyAmazingProgramCore.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AmazingMazesTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetDimensions_ValidInput_ReturnsDimensions()
        {
            // Arrange
            var input = new SequenceTextReader(new[] { "5", "6" });
            var output = new StringWriter();

            // Act
            var result = Program.GetDimensions(input, output);

            // Assert
            Assert.AreEqual((5u, 6u), result);
            StringAssert.Contains(output.ToString(), "WHAT IS YOUR WIDTH?");
            StringAssert.Contains(output.ToString(), "WHAT IS YOUR LENGTH?");
        }

        [TestMethod]
        public void GetDimensions_InvalidThenValidInput_ReturnsValidDimensions()
        {
            // Arrange: first width is invalid, then valid; then height is invalid, then valid; then always "5"
            var input = new SequenceTextReader(new[] { "2", "5", "2", "5", "6" }, "5");
            var output = new StringWriter();

            // Act
            var result = Program.GetDimensions(input, output);

            // Assert
            Assert.AreEqual((5u, 6u), result);
            var outputStr = output.ToString();
            StringAssert.Contains(outputStr, "MEANINGLESS DIMENSIONS.  TRY AGAIN.");
            StringAssert.Contains(outputStr, "WHAT IS YOUR WIDTH?");
            StringAssert.Contains(outputStr, "WHAT IS YOUR LENGTH?");
        }

        [TestMethod]
        public void PrintTitle_WritesExpectedHeader()
        {
            // Arrange
            var output = new StringWriter();

            // Act
            Program.PrintTitle(output);

            // Assert
            var text = output.ToString();
            StringAssert.Contains(text, "OBJECTIVELY AMAZING PROGRAM");
            StringAssert.Contains(text, "SCOTT MILLER");
            StringAssert.Contains(text, "BIBLEBYTE BOOKS");
        }

        [TestMethod]
        public void PrintBlankLines_WritesCorrectNumberOfLines()
        {
            // Arrange
            var output = new StringWriter();

            // Act
            Program.PrintBlankLines(3, output);

            // Assert
            var expected = string.Concat(Enumerable.Repeat(Environment.NewLine, 3));
            Assert.AreEqual(expected, output.ToString());
        }

        [TestMethod]
        public void PrintError_PrintsAllErrorInfo()
        {
            // Arrange
            var output = new StringWriter();
            var ex = new ApplicationException("Test error", new InvalidOperationException("Inner"));

            // Act
            Program.PrintError("A test error occurred.", ex, 12345, output);

            // Assert
            var text = output.ToString();
            StringAssert.Contains(text, "ERROR: A test error occurred.");
            StringAssert.Contains(text, "Details: Test error");
            StringAssert.Contains(text, "Inner Exception: Inner");
            StringAssert.Contains(text, "Seed: 12345");
            StringAssert.Contains(text, "Please try again or report this issue if it persists.");
        }

        [TestMethod]
        public void PrintMaze_PrintsMazeWithoutError()
        {
            // Arrange
            var output = new StringWriter();
            var mazeMock = new Mock<IMaze>();
            mazeMock.Setup(m => m.Dimensions).Returns((3u, 2u));
            mazeMock.Setup(m => m.GetOpeningCell()).Returns(() =>
            {
                var cell = new Mock<IMazeCell>();
                cell.Setup(c => c.Coordinates).Returns((1u, 0u));
                return cell.Object;
            });

            // Setup cells and walls
            var cells = new IMazeCell[3, 2];
            for (uint col = 0; col < 3; col++)
            for (uint row = 0; row < 2; row++)
            {
                var cell = new Mock<IMazeCell>();
                cell.Setup(c => c.Coordinates).Returns((col, row));
                cell.Setup(c => c.GetRightWall()).Returns((IMazeCellWall)null);
                cell.Setup(c => c.GetBottomWall()).Returns((IMazeCellWall)null);
                cells[col, row] = cell.Object;
            }
            // Add a right wall to (2,0)
            var rightWall = new Mock<IMazeCellWall>();
            rightWall.Setup(w => w.Status).Returns(WallStatus.Closed);
            Mock.Get(cells[2, 0]).Setup(c => c.GetRightWall()).Returns(rightWall.Object);

            // Add a bottom wall to (1,1)
            var bottomWall = new Mock<IMazeCellWall>();
            bottomWall.Setup(w => w.Status).Returns(WallStatus.Closed);
            Mock.Get(cells[1, 1]).Setup(c => c.GetBottomWall()).Returns(bottomWall.Object);

            mazeMock.Setup(m => m.GetCell(It.IsAny<(uint, uint)>()))
                .Returns<(uint, uint)>(coord => cells[coord.Item1, coord.Item2]);

            // Act
            Program.PrintMaze(mazeMock.Object, output);

            // Assert
            var text = output.ToString();
            StringAssert.Contains(text, ".  .--.");// Top edge
            StringAssert.Contains(text, "I        I");  // Right wall
            StringAssert.Contains(text, ":--");    // Bottom wall
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void PrintMazeBody_ThrowsIfCellIsMissing()
        {
            // Arrange
            var output = new StringWriter();
            var mazeMock = new Mock<IMaze>();
            mazeMock.Setup(m => m.Dimensions).Returns((2u, 1u));
            mazeMock.Setup(m => m.GetCell(It.IsAny<(uint, uint)>())).Returns((IMazeCell)null);

            // Act
            Program.PrintMazeBody(mazeMock.Object, output);
        }
    }

    public class SequenceTextReader : TextReader
    {
        private readonly Queue<string> _inputs;
        private readonly string _defaultValue;

        public SequenceTextReader(IEnumerable<string> inputs, string defaultValue = "5")
        {
            _inputs = new Queue<string>(inputs);
            _defaultValue = defaultValue;
        }

        public override string? ReadLine()
        {
            if (_inputs.Count > 0)
                return _inputs.Dequeue();
            return _defaultValue;
        }
    }
}