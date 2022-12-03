namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly List<int[]> _input;

    public Day_03()
    {
        _input = ParseInput().ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int counter = 0;
        foreach (var triangle in _input)
        {
            counter += IsTriangle(triangle);
        }

        return new(counter.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int counter = 0;

        for (int i = 0; i < _input.Count - 2; i += 3)
        {
            var t1 = new int[] { _input[i][0], _input[i + 1][0], _input[i + 2][0] };
            var t2 = new int[] { _input[i][1], _input[i + 1][1], _input[i + 2][1] };
            var t3 = new int[] { _input[i][2], _input[i + 1][2], _input[i + 2][2] };

            counter += IsTriangle(t1) + IsTriangle(t2) + IsTriangle(t3);
        }
        return new(counter.ToString());
    }

    private static int IsTriangle(int[] triangle)
    {
        if (triangle[0] + triangle[1] > triangle[2]
            && triangle[0] + triangle[2] > triangle[1]
            && triangle[1] + triangle[2] > triangle[0])
        {
            return 1;
        }

        return 0;
    }

    private IEnumerable<int[]> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);
        while (!file.Empty)
        {
            var line = file.NextLine();
            yield return new[] { line.NextElement<int>(), line.NextElement<int>(), line.NextElement<int>() };
        }
    }
}
