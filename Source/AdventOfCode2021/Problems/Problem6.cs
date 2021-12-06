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
        return PartOne(Input, 80);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartOne(Input, 256);
    }

    internal static long PartOne(ICollection<string> input, int days)
    {
        var fishPond = input.First().Split(',').ConvertToInt();

        for (var day = 0; day < days; day++)
        {
            for (var i = 0; i < fishPond.Count; i++)
            {
                if (fishPond[i] == 0)
                {
                    fishPond.Add(9);
                }
                if (fishPond[i] == -1)
                {
                    fishPond[i] = 6;
                }
            }

            for (var i = 0; i < fishPond.Count; i++)
            {
                fishPond[i]--;
            }
        }

        return fishPond.Count;
    }
}