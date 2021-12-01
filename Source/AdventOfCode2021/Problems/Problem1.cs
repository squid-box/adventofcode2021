namespace AdventOfCode2021.Problems;

using System.Collections.Generic;

using Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/1">Day 1</a>.
/// </summary>
public class Problem1 : ProblemBase
{
    public Problem1(InputDownloader inputDownloader = null) : base(1, inputDownloader) { }

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
        var measurements = input.ConvertToInt();

        var count = 0;

        for (var i = 0; i < measurements.Count - 1; i++)
        {
            if (measurements[i] < measurements[i + 1])
            {
                count++;
            }
        }

        return count;
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var measurements = input.ConvertToInt();

        var count = 0;

        for (var i = 0; i < measurements.Count - 3; i++)
        {
            var groupOne = measurements[i] + measurements[i + 1] + measurements[i + 2];
            var groupTwo = measurements[i+1] + measurements[i + 2] + measurements[i + 3];

            if (groupTwo > groupOne)
            {
                count++;
            }
        }

        return count;
    }
}