namespace AdventOfCode2021.Problems;

using System;
using System.Collections.Generic;

using AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/2">Day 2</a>.
/// </summary>
public class Problem2 : ProblemBase
{
    public Problem2(InputDownloader inputDownloader = null) : base(2, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    internal static int PartOne(ICollection<string> input)
    {
        var parsedInput = new Dictionary<string, int>();

        foreach (var line in input)
        {
            var tmp = line.Split(" ");

            if (!parsedInput.ContainsKey(tmp[0]))
            {
                parsedInput.Add(tmp[0], 0);
            }

            parsedInput[tmp[0]] += tmp[1].ToInt();
        }

        var horizontal = parsedInput["forward"];
        var vertical = parsedInput["down"] - parsedInput["up"];

        return horizontal * vertical;
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var aim = 0;
        var horizontal = 0;
        var depth = 0;

        foreach (var line in input)
        {
            var tmp = line.Split(" ");

            switch (tmp[0])
            {
                case "forward":
                    horizontal += tmp[1].ToInt();
                    depth += aim * tmp[1].ToInt();
                    break;
                case "up":
                    aim -= tmp[1].ToInt();
                    break;
                case "down":
                    aim += tmp[1].ToInt();
                    break;
                default:
                    throw new Exception("Oh no");
            }
        }

        return horizontal * depth;
    }
}