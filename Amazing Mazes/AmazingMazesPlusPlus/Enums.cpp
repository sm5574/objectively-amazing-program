namespace AmazingMazesPlusPlus
{
    enum class Direction
    {
        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8
    };

    enum class Wall
    {
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    };

    enum class WallBitPlace
    {
        Top = 0,
        Right = 1,
        Bottom = 2,
        Left = 3
    };

    enum class ExitStatus
    {
        NoStatus,
        CreateExit,
        ExitExists
    };

    enum class WallStatus
    {
        Open,
        Closed
    };
}