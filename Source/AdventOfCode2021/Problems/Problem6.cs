namespace AdventOfCode2021.Problems;

using System.Collections.Generic;
using System.Linq;

using AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/6">Day 6</a>.
/// </summary>
public class Problem6 : ProblemBase
{
    public Problem6(InputDownloader inputDownloader = null) : base(6, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return CalculatePopulation(Input, 80);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return CalculatePopulation(Input, 256);
    }

    internal static long CalculatePopulation(ICollection<string> input, int days)
    {
        var fishPond = new List<long>(new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });

        foreach (var seed in input.First().Split(',').ConvertToInt())
        {
            fishPond[seed]++;
        }

        for (var day = 0; day < days; day++)
        {
            // Remember number of fish ready to give birth.
            var ready = fishPond[0];

            // Shift list one step down.
            fishPond.RemoveAt(0);
            fishPond.Add(0);

            // Add parents back into their cycle.
            fishPond[6] += ready;

            // Add new-born fish.
            fishPond[8] = ready;
        }

        return fishPond.Sum();
    }
}