using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;


namespace AmazingMazesDirectPort
{
    public class Port
    {
        /*
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }



        private const int DEAD_END = 0;
        private const int RIGHT_WALL = 1;
        private const int BOTTOM_WALL = 2;
        private const int NO_WALLS = 3;

        public enum Direction
        {
            Left = 0,
            Right = 1,
            Up = 2,
            Down = 3,
            Reset = 4
        }

        private int MazeHeight = 0;
        private int MazeWidth = 0;

        private int[,] Paths = new int[0, 0]; // Paths(Width, MazeHeight) As Integer 'This array contains the paths
        private int[,] Walls = new int[0, 0]; //(Width, MazeHeight) As Integer 'This array contains the walls

        private bool CreateExit;
        private bool ExitExists;
        private int CellCount;
        private int EntranceColumn;
        private int Col;
        private int Row;

        private Random random = new Random();

        public float Rnd()
        {
            return random.Next();
        }


        public void PrintBlankLines(int Lines = 1)
        {
            for (var i = 1; i <= Lines; i++)
                Console.WriteLine("");
        }

        public void PrintTitle()
        {
            Console.CursorLeft = 28;
            Console.WriteLine("AMAZING PROGRAM");
            Console.CursorLeft = 15;
            Console.WriteLine("BIBLEBYTE BOOKS, MAPLE VALLEY, WASHINGTON");
            PrintBlankLines(4);
        }

        public void Initialize()
        {
            CreateExit = false;
            ExitExists = false;
            CellCount = 1;
            EntranceColumn = 0;
            Col = 0;
            Row = 1;
        }

        public void GetDimensions()
        {
            try
            {
                Console.Write("WHAT IS YOUR WIDTH? ");
                MazeWidth = int.Parse(Console.ReadLine());
                Console.Write("WHAT IS YOUR LENGTH? ");
                MazeHeight = int.Parse(Console.ReadLine());

                if (MazeWidth < 3 || MazeHeight < 3)
                {
                    Console.WriteLine("MEANINGLESS DIMENSIONS.  TRY AGAIN.");
                    GetDimensions();
                }
            }
            catch (Exception ex)
            {
                Environment.Exit(0);

            }
        }

        public void CreateArrays()
        {
            // Paths snakes through the dimensions, placing walls as needed
            // Then it backtracks to an unblocked pathway
            // It stops when the array is full
            // It apparently makes sure each spot has at least one open side
            Paths = new int[MazeWidth, MazeHeight];
            Walls = new int[MazeWidth, MazeHeight];

            for (var i = 1; i <= MazeWidth; i++)
            {
                for (var j = 1; j <= MazeHeight; j++)
                {
                    Paths[i, j] = 0;
                    Walls[i, j] = DEAD_END;
                }
            }
        }

        public void PrintTopEdge()
        {
            //Randomly choose where the top opening is
            EntranceColumn = (int)Math.Floor(Rnd() * MazeWidth + 1);

            Console.Write("  ");

            for (var I = 1; I <= MazeWidth; I++)
                if (I == EntranceColumn)
                    Console.Write("██  "); // '".  "
                else
                    Console.Write("████"); // '".--"

            Console.WriteLine("██"); // '"."
        }

    public void PrintMaze()
        { 
        For J = 1 To MazeHeight
            Console.Write("  ")

            Console.Write("██") '"I"

            For I = 1 To MazeWidth
                Select Case Port(I, J)
                    Case DEAD_END
                        Console.Write("  ██") '"  I"
                    Case RIGHT_WALL
                        Console.Write("  ██") '"  I"
                    Case BOTTOM_WALL
                        Console.Write("    ")
                    Case NO_WALLS
                        Console.Write("    ")
                End Select
            Next

            PrintBlankLines(1)
            Console.Write("  ")

            For I = 1 To MazeWidth
                Select Case Port(I, J)
                    Case DEAD_END
                        Console.Write("████") '":--"
                    Case RIGHT_WALL
                        Console.Write("██  ") '":  "
                    Case BOTTOM_WALL
                        Console.Write("████") '":--"
                    Case NO_WALLS
                        Console.Write("██  ") '":  "
                End Select
            Next

            Console.WriteLine("██") '"."
        Next

        Console.ReadKey()
    }

        public int Random(int Options)
        {
            return (int)Math.Floor(Rnd() * Options + 1);
        }

    Function IsEmpty(ByVal i As Integer) As Boolean
        { 
        Return(i = 0)
    }

    Function IsDeadEnd() As Boolean
    { 
        Return IsEmpty(WallsThisCell())
    }

    Function WeAreDone() As Boolean
    { 
        Return(CellCount = MazeWidth * MazeHeight + 1)
    }

#region "Shift to another cell"
    '--
    Function WallsLeftCell() As Integer
    { 
        Return Walls(Col - 1, Row)
    }

    Function WallsRightCell() As Integer
    { 
        Return Walls(Col + 1, Row)
    }

    Function WallsUpCell() As Integer
    { 
        Return Walls(Col, Row - 1)
    }

    Function WallsDownCell() As Integer
    { 
        Return Walls(Col, Row + 1)
    }

    Function WallsThisCell() As Integer
    { 
        Return Walls(Col, Row)
    }

    Function PathsLeftCell() As Integer
    { 
        Return Paths(Col - 1, Row)
    }

    Function PathsRightCell() As Integer
    { 
        Return Paths(Col + 1, Row)
    }

    Function PathsUpCell() As Integer
    { 
        Return Paths(Col, Row - 1)
    }

    Function PathsDownCell() As Integer
    {
        Return Paths(Col, Row + 1)
    }

    Function PathsThisCell() As Integer
    {
        Return Paths(Col, Row)
    }
    '--
#endregion

#region "At the edges?"
    '--
    Function AtBottomRow() As Boolean
    {
        Return(Row = MazeHeight)
    }

    Function AtTopRow() As Boolean
    {
        Return(Row = 1)
    }

    Function AtRightEdge() As Boolean
    {
        Return(Col = MazeWidth)
    }

    Function AtLeftEdge() As Boolean
    {
        Return(Col = 1)
    }
    '--
#endregion

#region "Simple moves"
    '--
    public void MoveLeft()
    {
        Paths(Col - 1, Row) = CellCount
        CellCount += 1
        Col -= 1
        SetBottomWallOnly()
    }

    public void MoveRight()
    {
        Col += 1
    }

    public void MoveUp()
    {
        Paths(Col, Row - 1) = CellCount
        CellCount += 1
        Row -= 1
        SetRightWallOnly()
    }

    public void MoveDown()
    {
        Row += 1
    }
    '--
#endregion

#region "Blocked?"
    '--
    Function RightBlocked() As Boolean
    {
        If AtRightEdge() Then Return True
        If Not IsEmpty(PathsRightCell()) Then Return True
        Return False
    }

    Function LeftBlocked() As Boolean
    {
        If AtLeftEdge() Then Return True
        If Not IsEmpty(PathsLeftCell()) Then Return True
        Return False
    }

    Function UpBlocked() As Boolean
    {
        If AtTopRow() Then Return True
        If Not IsEmpty(PathsUpCell()) Then Return True
        Return False
    }
    '--
#endregion

#region "Set walls"
    '--
    public void SetRightWallOnly()
    {
        Walls(Col, Row) = RIGHT_WALL
    }

    public void SetBottomWallOnly()
    {
        Walls(Col, Row) = BOTTOM_WALL
    }

    public void SetNoWalls()
    {
        Walls(Col, Row) = NO_WALLS
    }
    '--
#endregion

#region "Which direction?"
    '--
    Function WhichRandomDirection(x As Direction, y As Direction)
    {
        Select Case Random(2)
            Case 1
                Return x
            Case 2
                Return y
        End Select
    }

    Function WhichRandomDirection(x As Direction, y As Direction, z As Direction)
    {
        Select Case Random(3)
            Case 1
                Return x
            Case 2
                Return y
            Case 3
                Return z
        End Select
    }
    '--
#endregion

    public void Reset()
    {
        If Not AtRightEdge() Then
            MoveRight()
        ElseIf Not AtBottomRow() Then
            Col = 1
            MoveDown()
        Else
            Col = 1
            Row = 1
        End If

        If IsEmpty(PathsThisCell()) Then Reset()
    }

    Function DownBlocked() As Boolean
    {
        If AtBottomRow() Then
            If ExitExists Then
                Return True
            Else
                CreateExit = True
                Return False
            End If
        End If

        If IsEmpty(PathsDownCell()) Then Return False

        Return True
    }

    Function FromThisCell() As Direction
    {
        var NoLeft As Boolean = LeftBlocked()
        var NoUp As Boolean = UpBlocked()
        var NoRight As Boolean = RightBlocked()
        var NoDown As Boolean = DownBlocked()

        Select Case True
            Case NoLeft And NoUp And NoRight And NoDown
                Return Direction.Reset
            Case NoLeft And NoUp And NoRight
                Return Direction.Down
            Case NoLeft And NoUp And NoDown
                Return Direction.Right
            Case NoLeft And NoRight And NoDown
                Return Direction.Up
            Case NoUp And NoRight And NoDown
                Return Direction.Left
            Case NoLeft And NoUp
                If CreateExit Then
                    Return Direction.Down
                Else
                    Return WhichRandomDirection(Direction.Right, Direction.Down)
                End If
            Case NoLeft And NoRight
                Return WhichRandomDirection(Direction.Up, Direction.Down)
            Case NoLeft And NoDown
                Return WhichRandomDirection(Direction.Up, Direction.Right)
            Case NoUp And NoRight
                Return WhichRandomDirection(Direction.Left, Direction.Down)
            Case NoUp And NoDown
                Return WhichRandomDirection(Direction.Left, Direction.Right)
            Case NoRight And NoDown
                If ExitExists Then
                    Return Direction.Left
                Else
                    Return WhichRandomDirection(Direction.Left, Direction.Up)
                End If
            Case NoLeft
                Return WhichRandomDirection(Direction.Up, Direction.Right, Direction.Down)
            Case NoUp
                Return WhichRandomDirection(Direction.Left, Direction.Right, Direction.Down)
            Case NoRight
                If CreateExit Then
                    Return WhichRandomDirection(Direction.Left, Direction.Down)
                Else
                    Return WhichRandomDirection(Direction.Left, Direction.Up, Direction.Down)
                End If
            Case Else 'NoDown
                Return WhichRandomDirection(Direction.Left, Direction.Up, Direction.Right)
        End Select
    }

    public void ProcessCurrentCell()
    {
        Select Case FromThisCell()
            Case Direction.Left
                MoveLeft()
                CreateExit = False
            Case Direction.Right
                Paths(Col + 1, Row) = CellCount
                CellCount += 1

                If IsDeadEnd() Then
                    SetBottomWallOnly()
                Else
                    SetNoWalls()
                End If

                MoveRight()
            Case Direction.Up
                MoveUp()
                CreateExit = False
            Case Direction.Down
                If CreateExit Then
                    ExitExists = True

                    If IsDeadEnd() Then
                        SetRightWallOnly()
                        CreateExit = False
                        Col = 1
                        Row = 1

                        If IsEmpty(PathsThisCell()) Then Reset()
                    Else
                        SetNoWalls()
                        CreateExit = False
                        Reset()
                    End If
                Else
                    Paths(Col, Row + 1) = CellCount
                    CellCount += 1

                    If IsDeadEnd() Then
                        SetRightWallOnly()
                    Else
                        SetNoWalls()
                    End If

                    MoveDown()
                End If
            Case Direction.Reset
                Reset()
        End Select

        If Not WeAreDone() Then ProcessCurrentCell()
    }

    public void MainLoop()
    {
        PrintBlankLines(1)
        Initialize()

        Getvarensions()
        CreateArrays()

        'Print some breathing room
        PrintBlankLines(4)

        PrintTopEdge()

        Paths(EntranceColumn, 1) = CellCount
        CellCount += 1
        Col = EntranceColumn

        ProcessCurrentCell()
        PrintMaze()

        PrintBlankLines(1)
        Console.Write("Would you like to print another maze (Y/N)? ")
        var Again = (Console.ReadLine().ToString().ToUpper() = "Y")

        If Again Then MainLoop()
    }

    public void Main()
    {
        Randomize()
        PrintTitle()
        MainLoop()
    }
        */

        public static void Main()
        {
        }
    }
}