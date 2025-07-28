using ObjectivelyAmazingProgramCore;
using ObjectivelyAmazingProgramCore.Interfaces;
using static ObjectivelyAmazingProgramCore.Enums;

namespace ObjectivelyAmazingProgramConsole
{
    /// <summary>
    /// Entry point and console interface for the Amazing Mazes application.
    /// Handles maze generation, user input, and maze display.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for the console application.
        /// Prompts the user for maze dimensions, generates the maze, and displays it.
        /// </summary>
        public static void Main()
        {
            var seed = new RandomProvider().Next();
            var rnd = new RandomProvider(seed);
            PrintTitle(Console.Out);

            var dimensions = GetDimensions(Console.In, Console.Out);

            try
            {
                IMaze maze = MazeGenerationUtils.GetGeneratedMaze(dimensions, rnd);
                PrintMaze(maze, Console.Out);
                PrintBlankLines(4, Console.Out);
            }
            catch (ApplicationException ex)
            {
                PrintError("A maze generation error occurred.", ex, seed, Console.Out);
            }
            catch (Exception ex)
            {
                PrintError("An unexpected error occurred.", ex, seed, Console.Out);
            }
        }

        /// <summary>
        /// Prints an error message and details to the specified output.
        /// </summary>
        /// <param name="message">A short description of the error.</param>
        /// <param name="ex">The exception that was thrown.</param>
        /// <param name="seed">The random seed used for maze generation.</param>
        /// <param name="output">The output stream to write to.</param>
        public static void PrintError(string message, Exception ex, int seed, TextWriter output)
        {
            output.WriteLine();
            output.WriteLine("ERROR: " + message);
            output.WriteLine("Details: " + ex.Message);

            if (ex.InnerException != null)
                output.WriteLine("Inner Exception: " + ex.InnerException.Message);
            
            output.WriteLine($"Seed: {seed}");
            output.WriteLine("Please try again or report this issue if it persists.");
        }

        /// <summary>
        /// Prompts the user for maze dimensions and validates the input.
        /// </summary>
        /// <param name="input">The input stream to read from.</param>
        /// <param name="output">The output stream to write to.</param>
        /// <returns>A tuple containing the width and height of the maze.</returns>
        public static (uint width, uint height) GetDimensions(TextReader input, TextWriter output)
        {
            while (true)
            {
                output.Write("WHAT IS YOUR WIDTH? ");

                if (!uint.TryParse(input.ReadLine(), out var x) || x < 3)
                {
                    output.WriteLine("MEANINGLESS DIMENSIONS.  TRY AGAIN.");
                    PrintBlankLines(1, output);
                    continue;
                }

                output.Write("WHAT IS YOUR LENGTH? ");
                
                if (!uint.TryParse(input.ReadLine(), out var y) || y < 3)
                {
                    output.WriteLine("MEANINGLESS DIMENSIONS.  TRY AGAIN.");
                    PrintBlankLines(1, output);
                    continue;
                }

                return (x, y);
            }
        }

        /// <summary>
        /// Prints the program title and credits to the specified output.
        /// </summary>
        /// <param name="output">The output stream to write to.</param>
        public static void PrintTitle(TextWriter output)
        {
            output.WriteLine("OBJECTIVELY AMAZING PROGRAM");
            output.WriteLine("SCOTT MILLER");
            output.WriteLine("REFACTORED FROM 'AMAZING' PROGRAM BY BIBLEBYTE BOOKS, MAPLE VALLEY, WASHINGTON");
            PrintBlankLines(4, output);
        }

        /// <summary>
        /// Prints the specified number of blank lines to the output.
        /// </summary>
        /// <param name="howMany">The number of blank lines to print.</param>
        /// <param name="output">The output stream to write to.</param>
        public static void PrintBlankLines(int howMany, TextWriter output)
        {
            for (var i = 0; i < howMany; i++)
                output.WriteLine("");
        }

        /// <summary>
        /// Prints the maze to the specified output, including the top edge and body.
        /// </summary>
        /// <param name="maze">The maze to print.</param>
        /// <param name="output">The output stream to write to.</param>
        public static void PrintMaze(IMaze maze, TextWriter output)
        {
            PrintTopEdge(maze, output);
            PrintMazeBody(maze, output);
        }

        /// <summary>
        /// Prints the top edge of the maze, including the opening.
        /// </summary>
        /// <param name="maze">The maze to print.</param>
        /// <param name="output">The output stream to write to.</param>
        public static void PrintTopEdge(IMaze maze, TextWriter output)
        {
            var width = maze.Dimensions.width;
            var topOpening = maze.GetOpeningCell()?.Coordinates.column
                ?? throw new ApplicationException("No opening cell defined.");

            output.Write("  ");

            for (var col = 0; col < width; col++)
                output.Write(col == topOpening ? ".  " : ".--");
            
            output.WriteLine(".");
        }

        /// <summary>
        /// Prints the body of the maze, including cell walls and paths.
        /// </summary>
        /// <param name="maze">The maze to print.</param>
        /// <param name="output">The output stream to write to.</param>
        public static void PrintMazeBody(IMaze maze, TextWriter output)
        {
            var height = maze.Dimensions.height;
            var width = maze.Dimensions.width;

            for (uint row = 0; row < height; row++)
            {
                output.Write("  I");

                for (uint col = 0; col < width; col++)
                {
                    var cell = maze.GetCell((col, row))
                        ?? throw new ApplicationException($"Maze cell at ({col}, {row}) is missing.");
                    output.Write(cell.GetRightWall()?.Status == WallStatus.Closed ? "  I" : "   ");
                }
                
                PrintBlankLines(1, output);
                output.Write("  ");
                
                for (uint col = 0; col < width; col++)
                {
                    var cell = maze.GetCell((col, row))
                        ?? throw new ApplicationException($"Maze cell at ({col}, {row}) is missing.");
                    output.Write(cell.GetBottomWall()?.Status == WallStatus.Closed ? ":--" : ":  ");
                }
                
                output.WriteLine(".");
            }
        }
    }
}