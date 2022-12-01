using SheepTools.Model;

namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly List<List<Direction>> _input;

    public Day_02()
    {
        _input = ParseInput().ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        string solution = string.Empty;

        var currentPoint = new Point(0, 0);
        foreach (var line in _input)
        {
            foreach (var direction in line)
            {
                var newPoint = currentPoint.Move(direction);
                if (Math.Abs(newPoint.X) <= 1 && Math.Abs(newPoint.Y) <= 1)
                {
                    currentPoint = newPoint;
                }
            }

            var number = currentPoint switch
            {
                { X: -1, Y: 1 } => 1,
                { X: 0, Y: 1 } => 2,
                { X: 1, Y: 1 } => 3,
                { X: -1, Y: 0 } => 4,
                { X: 0, Y: 0 } => 5,
                { X: 1, Y: 0 } => 6,
                { X: -1, Y: -1 } => 7,
                { X: 0, Y: -1 } => 8,
                { X: 1, Y: -1 } => 9,
                _ => throw new()
            };

            solution += number;
        }

        return new(solution);
    }

    public override ValueTask<string> Solve_2()
    {
        string solution = string.Empty;

        var origin = new Point(0, 0);
        var currentPoint = new Point(-2, 0);

        foreach (var line in _input)
        {
            foreach (var direction in line)
            {
                var newPoint = currentPoint.Move(direction);
                if (newPoint.ManhattanDistance(origin) <= 2)
                {
                    currentPoint = newPoint;
                }
            }

            var number = currentPoint switch
            {
                { X: 0, Y: 2 } => "1",
                { X: -1, Y: 1 } => "2",
                { X: 0, Y: 1 } => "3",
                { X: 1, Y: 1 } => "4",
                { X: -2, Y: 0 } => "5",
                { X: -1, Y: 0 } => "6",
                { X: 0, Y: 0 } => "7",
                { X: 1, Y: 0 } => "8",
                { X: 2, Y: 0 } => "9",
                { X: -1, Y: -1 } => "A",
                { X: 0, Y: -1 } => "B",
                { X: 1, Y: -1 } => "C",
                { X: 0, Y: -2 } => "D",
                _ => throw new()
            };

            solution += number;
        }

        return new(solution);
    }

    private List<List<Direction>> ParseInput()
    {
        return File.ReadAllLines(InputFilePath)
            .Select(line => line
                .Select(ch => ch switch
                {
                    'D' => Direction.Down,
                    'R' => Direction.Right,
                    'U' => Direction.Up,
                    'L' => Direction.Left,
                    _ => throw new()
                })
                .ToList()
            ).ToList();
    }

    private sealed record Instruction(Direction Direction, int Distance);
}
