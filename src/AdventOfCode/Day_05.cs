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
        var result = new char[8];

        var encoder = new UTF8Encoding();
        long index = 0;
        while (true)
        {
            var str = _input + index++;
            var hash = string.Concat(MD5.HashData(encoder.GetBytes(str)).Select(by => by.ToString("x2")));

            if (hash.StartsWith("00000"))
            {
                if (int.TryParse(hash[5].ToString(), out var position) && position < 8 && result[position] == default)
                {
                    result[position] = hash[6];
                }
                if (result.All(ch => ch != default))
                {
                    return new(string.Concat(result));
                }
            }
        }
    }

    private string ParseInput() => File.ReadAllText(InputFilePath).Trim();
}

