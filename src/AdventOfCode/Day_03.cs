namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly List<(int A, int B, int C)> _input;

    public Day_03()
    {
        _input = ParseInput().ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int counter = 0;
        foreach (var (A, B, C) in _input)
        {
            counter += IsTriangle(A, B, C);
        }

        return new(counter.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int counter = 0;

        for (int i = 0; i < _input.Count - 2; i += 3)
        {
            counter += IsTriangle(_input[i].A, _input[i + 1].A, _input[i + 2].A)
                     + IsTriangle(_input[i].B, _input[i + 1].B, _input[i + 2].B)
                     + IsTriangle(_input[i].C, _input[i + 1].C, _input[i + 2].C);
        }
        return new(counter.ToString());
    }

    private static int IsTriangle(int A, int B, int C)
    {
        if (A + B > C
            && A + C > B
            && B + C > A)
        {
            return 1;
        }

        return 0;
    }

    private IEnumerable<(int, int, int)> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);
        while (!file.Empty)
        {
            var line = file.NextLine();
            yield return (line.NextElement<int>(), line.NextElement<int>(), line.NextElement<int>());
        }
    }
}
