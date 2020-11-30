using AoCHelper;
using SheepTools.Model;
using SheepTools.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_01 : BaseDay
    {
        private readonly List<Instruction> _input;

        public Day_01()
        {
            _input = ParseInput().ToList();
        }

        public override string Solve_1()
        {
            var position = new Point(0, 0);
            var direction = _input[0].Direction;

            position = position.Move(direction, _input[0].Distance);

            foreach (var instruction in _input.Skip(1))
            {
                direction = instruction.Direction switch
                {
                    Direction.Left => direction.TurnLeft(),
                    Direction.Right => direction.TurnRight(),
                    _ => throw new SolvingException()
                };

                position = position.Move(direction, instruction.Distance);
            }

            return position.ManhattanDistance(new Point(0, 0)).ToString();
        }

        public override string Solve_2()
        {
            var visitedPositions = new HashSet<Point>();

            var position = new Point(0, 0);
            var direction = _input[0].Direction;

            visitedPositions.Add(position);

            for (int _ = 0; _ < _input[0].Distance; ++_)
            {
                position = position.Move(direction);
                visitedPositions.Add(position);
            }

            foreach (var instruction in _input.Skip(1))
            {
                direction = instruction.Direction switch
                {
                    Direction.Left => direction.TurnLeft(),
                    Direction.Right => direction.TurnRight(),
                    _ => throw new SolvingException()
                };

                bool shouldBreak = false;
                for (int _ = 0; _ < instruction.Distance; ++_)
                {
                    position = position.Move(direction);
                    if (!visitedPositions.Add(position))
                    {
                        shouldBreak = true;
                        break;
                    }
                }

                if (shouldBreak) break;
            }

            return position.ManhattanDistance(new Point(0, 0)).ToString();
        }

        private IEnumerable<Instruction> ParseInput()
        {
            var input = File.ReadAllText(InputFilePath);

            foreach (var instruction in input.Split(','))
            {
                var trimmed = instruction.Trim();
                yield return new Instruction(
                    trimmed[0] == 'R' ? Direction.Right : Direction.Left,
                    int.Parse(trimmed[1..]));
            }
        }

        private record Instruction(Direction Direction, int Distance);
    }
}
