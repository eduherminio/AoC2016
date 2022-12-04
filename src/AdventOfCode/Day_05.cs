using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode;

public class Day_05 : BaseDay
{
    private readonly string _input;

    public Day_05()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        string result = string.Empty;

        var encoder = new UTF8Encoding();
        long index = 0;
        while (true)
        {
            var str = _input + index++;
            var hash = string.Concat(MD5.HashData(encoder.GetBytes(str)).Select(by => by.ToString("x2")));

            if (hash.StartsWith("00000"))
            {
                result += hash[5];
                if (result.Length == 8)
                {
                    return new(result);
                }
            }
        }
    }

    public override ValueTask<string> Solve_2()
    {
        int result = 0;

        return new($"{result}");
    }

    private string ParseInput() => File.ReadAllText(InputFilePath).Trim();
}

