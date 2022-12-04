﻿namespace AdventOfCode;

public class Day_04 : BaseDay
{
    private readonly List<(string Name, int Id, string Checksum)> _input;

    public Day_04()
    {
        _input = ParseInput().ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        return new($"{ValidInput().Sum(entry => entry.Id)}");
    }

    public override ValueTask<string> Solve_2()
    {
        foreach (var (Name, Id, _) in ValidInput())
        {
            var newNameArray = new List<char>(Name.Length);

            foreach (var ch in Name)
            {
                newNameArray.Add((char)('a' + ((ch - 'a' + Id) % 26)));
            }

            var stringWithoutSpaces = string.Concat(newNameArray);

            if (stringWithoutSpaces.Contains("northpole"))
            {
                return new($"{Id}");
            }
        }

        throw new SolvingException("North Pole not found");
    }

    private List<(string Name, int Id, string Checksum)> ValidInput()
    {
        return _input
            .Where(entry => entry.Checksum ==
                string.Concat(
                    entry.Name
                        .GroupBy(ch => ch)
                        .OrderByDescending(g => g.Count())
                        .ThenBy(g => g.Key)
                        .Select(g => g.Key)
                        .Take(5)))
            .ToList();
    }

    private IEnumerable<(string Name, int Id, string Checksum)> ParseInput()
    {
        var file = new ParsedFile(InputFilePath, new[] { '-', '[' });
        while (!file.Empty)
        {

            var line = file.NextLine();
            List<string> name = new(line.Count - 2);

            while (!line.Empty)
            {
                var element = line.NextElement<string>();
                if (element.Last() == ']')
                {
                    yield return (string.Concat(name.Take(name.Count - 1)), int.Parse(name[^1]), element[..^1]);
                }
                else
                {
                    name.Add(element);
                }
            }
        }
    }
}
