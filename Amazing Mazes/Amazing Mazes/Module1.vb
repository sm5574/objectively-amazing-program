Module MazeGenerator
    Sub Main()
        ' Display the program title and creator information
        Console.WriteLine(vbTab & "AMAZING PROGRAM")
        Console.WriteLine(vbTab & "CREATIVE COMPUTING  MORRISTOWN, NEW JERSEY")
        Console.WriteLine()
        Console.WriteLine()

        ' Get user input for maze dimensions
        Console.Write("WHAT ARE YOUR WIDTH AND LENGTH? ")
        Dim width As Integer = Integer.Parse(Console.ReadLine())
        Dim height As Integer = Integer.Parse(Console.ReadLine())

        ' Validate the dimensions
        If width <= 1 Or height <= 1 Then
            Console.WriteLine("MEANINGLESS DIMENSIONS.  TRY AGAIN.")
            Main() ' Restart the program
            Return
        End If

        ' Initialize the maze arrays
        Dim mazeWidth As Integer = width
        Dim mazeHeight As Integer = height
        Dim mazePath(mazeWidth, mazeHeight) As Integer
        Dim mazeVisited(mazeWidth, mazeHeight) As Integer

        ' Initialize variables for maze generation
        Dim currentCell As Integer = 0
        Dim direction As Integer = 0
        Dim randomSeed As Integer = 0

        ' Start the maze generation process
        GenerateMaze(mazeWidth, mazeHeight, mazePath, mazeVisited, currentCell, direction, randomSeed)

        ' Print the generated maze
        PrintMaze(mazeWidth, mazeHeight, mazeVisited)
    End Sub

    Sub GenerateMaze(mazeWidth As Integer, mazeHeight As Integer, ByRef mazePath(,) As Integer, ByRef mazeVisited(,) As Integer, ByRef currentCell As Integer, ByRef direction As Integer, ByRef randomSeed As Integer)
        Randomize()
        Dim startX As Integer = CInt(Rnd() * mazeWidth) + 1
        Dim startY As Integer = 1
        Dim stack As New Stack(Of Tuple(Of Integer, Integer))

        ' Initialize the starting point
        mazePath(startX, startY) = 1
        mazeVisited(startX, startY) = 1
        stack.Push(Tuple.Create(startX, startY))

        While stack.Count > 0
            Dim current As Tuple(Of Integer, Integer) = stack.Pop()
            Dim currentX As Integer = current.Item1
            Dim currentY As Integer = current.Item2
            Dim directions As New List(Of Tuple(Of Integer, Integer)) From {
                Tuple.Create(0, -2), ' Up
                Tuple.Create(0, 2),  ' Down
                Tuple.Create(-2, 0), ' Left
                Tuple.Create(2, 0)   ' Right
            }

            ' Shuffle the directions randomly
            Randomize()
            directions = directions.OrderBy(Function(d) Rnd()).ToList()

            Dim validDirectionFound As Boolean = False
            For Each d In directions
                Dim newX As Integer = currentX + d.Item1
                Dim newY As Integer = currentY + d.Item2

                If newX > 0 And newX <= mazeWidth And newY > 0 And newY <= mazeHeight And mazeVisited(newX, newY) = 0 Then
                    ' Mark the new cell as visited and add it to the stack
                    mazeVisited(newX, newY) = 1
                    mazePath(newX, newY) = 1
                    stack.Push(Tuple.Create(newX, newY))
                    validDirectionFound = True
                    Exit For
                End If
            Next

            If Not validDirectionFound Then
                stack.Pop()
            End If
        End While
    End Sub

    Sub PrintMaze(mazeWidth As Integer, mazeHeight As Integer, ByRef mazeVisited(,) As Integer)
        For y As Integer = 1 To mazeHeight
            ' Print the top wall of each row
            For x As Integer = 1 To mazeWidth
                If x = 1 Then
                    Console.Write("+")
                ElseIf mazeVisited(x, y) = 0 Then
                    Console.Write("+--")
                Else
                    Console.Write("+  ")
                End If
            Next
            Console.WriteLine("+")

            ' Print the sides and paths of each row
            For x As Integer = 1 To mazeWidth
                If mazeVisited(x, y) = 0 Then
                    Console.Write("|  ")
                Else
                    Console.Write("|   ")
                End If
            Next
            Console.WriteLine("|")

            ' Print the bottom wall of each row
            For x As Integer = 1 To mazeWidth
                If x = 1 Then
                    Console.Write("+")
                ElseIf mazeVisited(x, y) = 0 Then
                    Console.Write("+--")
                Else
                    Console.Write("+  ")
                End If
            Next
            Console.WriteLine("+")
        Next
    End Sub
End Module