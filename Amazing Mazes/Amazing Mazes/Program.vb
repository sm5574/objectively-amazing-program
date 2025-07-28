Imports System

Module Program
    Const DEAD_END = 0
    Const RIGHT_WALL = 1
    Const BOTTOM_WALL = 2
    Const NO_WALLS = 3

    Enum Direction
        Left = 0
        Right = 1
        Up = 2
        Down = 3
        Reset = 4
    End Enum

    Dim Height As Integer = 0
    Dim Width As Integer = 0
    Dim Paths(Width, Height) As Integer 'This array contains the paths
    Dim Walls(Width, Height) As Integer 'This array contains the walls

    Dim CreateExit As Boolean
    Dim ExitExists As Boolean
    Dim CellCount As Integer
    Dim EntranceColumn As Integer
    Dim Col As Integer
    Dim Row As Integer

    Sub PrintBlankLines(Optional Lines As Integer = 1)
        For i = 1 To Lines
            Console.WriteLine("")
        Next i
    End Sub

    Sub PrintTitle()
        Console.CursorLeft = 28
        Console.WriteLine("AMAZING PROGRAM")
        Console.CursorLeft = 15
        Console.WriteLine("BIBLEBYTE BOOKS, MAPLE VALLEY, WASHINGTON")
        PrintBlankLines(4)
    End Sub

    Private Sub Initialize()
        CreateExit = False
        ExitExists = False
        CellCount = 1
        EntranceColumn = 0
        Col = 0
        Row = 1
    End Sub

    Sub GetDimensions()
        Try
            Console.Write("WHAT IS YOUR WIDTH? ")
            Width = Console.ReadLine()
            Console.Write("WHAT IS YOUR LENGTH? ")
            Height = Console.ReadLine()

            If Width < 3 Or Height < 3 Then
                Console.WriteLine("MEANINGLESS DIMENSIONS.  TRY AGAIN.")
                GetDimensions()
            End If
        Catch ex As Exception
            End
        End Try
    End Sub

    Sub CreateArrays()
        'Paths snakes through the dimensions, placing walls as needed
        'Then it backtracks to an unblocked pathway
        'It stops when the array is full
        'It apparently makes sure each spot has at least one open side
        ReDim Paths(Width, Height)
        ReDim Walls(Width, Height)

        For I = 1 To Width
            For J = 1 To Height
                Paths(I, J) = 0
                Walls(I, J) = DEAD_END
            Next
        Next
    End Sub

    Sub PrintTopEdge()
        'Randomly choose where the top opening is
        EntranceColumn = Math.Floor(Rnd() * Width + 1)

        Console.Write("  ")

        For I = 1 To Width
            If I = EntranceColumn Then
                Console.Write(".  ") '".  "
            Else
                Console.Write(".--") '".--"
            End If
        Next

        Console.WriteLine(".") '"."
    End Sub

    Sub PrintMaze()
        For J = 1 To Height
            Console.Write("  ")

            Console.Write("I") '"I"

            For I = 1 To Width
                Select Case Walls(I, J)
                    Case DEAD_END
                        Console.Write("  I") '"  I"
                    Case RIGHT_WALL
                        Console.Write("  I") '"  I"
                    Case BOTTOM_WALL
                        Console.Write("    ")
                    Case NO_WALLS
                        Console.Write("    ")
                End Select
            Next

            PrintBlankLines(1)
            Console.Write("  ")

            For I = 1 To Width
                Select Case Walls(I, J)
                    Case DEAD_END
                        Console.Write(":--") '":--"
                    Case RIGHT_WALL
                        Console.Write(":  ") '":  "
                    Case BOTTOM_WALL
                        Console.Write(":--") '":--"
                    Case NO_WALLS
                        Console.Write(":  ") '":  "
                End Select
            Next

            Console.WriteLine(".") '"."
        Next

        Console.ReadKey()
    End Sub

    Function Random(ByVal Options As Integer)
        Return Math.Floor(Rnd() * Options + 1)
    End Function

    Function IsEmpty(ByVal i As Integer) As Boolean
        Return (i = 0)
    End Function

    Function IsDeadEnd() As Boolean
        Return IsEmpty(WallsThisCell())
    End Function

    Function WeAreDone() As Boolean
        Return (CellCount = Width * Height + 1)
    End Function

#Region "Shift to another cell"
    '--
    Function WallsLeftCell() As Integer
        Return Walls(Col - 1, Row)
    End Function

    Function WallsRightCell() As Integer
        Return Walls(Col + 1, Row)
    End Function

    Function WallsUpCell() As Integer
        Return Walls(Col, Row - 1)
    End Function

    Function WallsDownCell() As Integer
        Return Walls(Col, Row + 1)
    End Function

    Function WallsThisCell() As Integer
        Return Walls(Col, Row)
    End Function

    Function PathsLeftCell() As Integer
        Return Paths(Col - 1, Row)
    End Function

    Function PathsRightCell() As Integer
        Return Paths(Col + 1, Row)
    End Function

    Function PathsUpCell() As Integer
        Return Paths(Col, Row - 1)
    End Function

    Function PathsDownCell() As Integer
        Return Paths(Col, Row + 1)
    End Function

    Function PathsThisCell() As Integer
        Return Paths(Col, Row)
    End Function
    '--
#End Region

#Region "At the edges?"
    '--
    Function AtBottomRow() As Boolean
        Return (Row = Height)
    End Function

    Function AtTopRow() As Boolean
        Return (Row = 1)
    End Function

    Function AtRightEdge() As Boolean
        Return (Col = Width)
    End Function

    Function AtLeftEdge() As Boolean
        Return (Col = 1)
    End Function
    '--
#End Region

#Region "Simple moves"
    '--
    Sub MoveLeft()
        Paths(Col - 1, Row) = CellCount
        CellCount += 1
        Col -= 1
        SetBottomWallOnly()
    End Sub

    Sub MoveRight()
        Col += 1
    End Sub

    Sub MoveUp()
        Paths(Col, Row - 1) = CellCount
        CellCount += 1
        Row -= 1
        SetRightWallOnly()
    End Sub

    Sub MoveDown()
        Row += 1
    End Sub
    '--
#End Region

#Region "Blocked?"
    '--
    Function RightBlocked() As Boolean
        If AtRightEdge() Then Return True
        If Not IsEmpty(PathsRightCell()) Then Return True
        Return False
    End Function

    Function LeftBlocked() As Boolean
        If AtLeftEdge() Then Return True
        If Not IsEmpty(PathsLeftCell()) Then Return True
        Return False
    End Function

    Function UpBlocked() As Boolean
        If AtTopRow() Then Return True
        If Not IsEmpty(PathsUpCell()) Then Return True
        Return False
    End Function
    '--
#End Region

#Region "Set walls"
    '--
    Sub SetRightWallOnly()
        Walls(Col, Row) = RIGHT_WALL
    End Sub

    Sub SetBottomWallOnly()
        Walls(Col, Row) = BOTTOM_WALL
    End Sub

    Sub SetNoWalls()
        Walls(Col, Row) = NO_WALLS
    End Sub
    '--
#End Region

#Region "Which direction?"
    '--
    Function WhichRandomDirection(x As Direction, y As Direction)
        Select Case Random(2)
            Case 1
                Return x
            Case 2
                Return y
        End Select
    End Function

    Function WhichRandomDirection(x As Direction, y As Direction, z As Direction)
        Select Case Random(3)
            Case 1
                Return x
            Case 2
                Return y
            Case 3
                Return z
        End Select
    End Function
    '--
#End Region

    Sub Reset()
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
    End Sub

    Function DownBlocked() As Boolean
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
    End Function

    Function FromThisCell() As Direction
        Dim NoLeft As Boolean = LeftBlocked()
        Dim NoUp As Boolean = UpBlocked()
        Dim NoRight As Boolean = RightBlocked()
        Dim NoDown As Boolean = DownBlocked()

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
    End Function

    Sub ProcessCurrentCell()
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
    End Sub

    Sub MainLoop()
        PrintBlankLines(1)
        Initialize()

        GetDimensions()
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
        Dim Again = (Console.ReadLine().ToString().ToUpper() = "Y")

        If Again Then MainLoop()
    End Sub

    Sub Main()
        Randomize()
        PrintTitle()
        MainLoop()
    End Sub
End Module