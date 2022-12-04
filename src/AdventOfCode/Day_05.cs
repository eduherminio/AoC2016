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
            var hash = MD5.HashData(encoder.GetBytes(str));

            if (hash[0] == 0 && hash[1] == 0)
            {
                var hashedString = hash[2].ToString("x2");

                if (hashedString[0] == '0')
                {
                    result += hashedString[1];
                    if (result.Length == 8)
                    {
                        return new(result);
                    }
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
            var hash = MD5.HashData(encoder.GetBytes(str));

            if (hash[0] == 0 && hash[1] == 0)
            {
                var hashedString = hash[2].ToString("x2") + hash[3].ToString("x2");

                if (hashedString[0] == '0')
                {
                    if (int.TryParse(hashedString[1].ToString(), out var position) && position < 8 && result[position] == default)
                    {
                        result[position] = hashedString[2];
                    }
                    if (result.All(ch => ch != default))
                    {
                        return new(string.Concat(result));
                    }
                }
            }
        }
    }

    private string ParseInput() => File.ReadAllText(InputFilePath).Trim();
}

