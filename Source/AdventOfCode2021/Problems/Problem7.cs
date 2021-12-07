namespace AdventOfCode2021.Problems;

using AdventOfCode2021.Utils.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/7">Day 7</a>.
/// </summary>
public class Problem7 : ProblemBase
{
    public Problem7(InputDownloader inputDownloader = null) : base(7, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return FindLowestFuelConsumption(Input, 1);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return FindLowestFuelConsumption(Input, 2);
    }

    internal static long FindLowestFuelConsumption(ICollection<string> input, int part)
    {
        var crabs = input.First().Split(',').ConvertToInt();

        // Fuel cost: (position, cost)
        var fuelCostSummary = new List<(int, long)>();

        // Test all positions and evaluate fuel cost.
        for (var pos = crabs.Min(); pos <= crabs.Max(); pos++)
        {
            var cost = 0L;

            foreach (var crab in crabs)
            {
                if (crab == pos)
                {
                    continue;
                }

                if (part == 1)
                {
                    cost += Math.Abs(crab - pos);
                }
                else
                {
                    for (var i = 0; i < Math.Abs(crab - pos); i++)
                    {
                        cost += 1 + i;
                    }
                }                
            }

            fuelCostSummary.Add((pos, cost));
        }

        return fuelCostSummary.Min(x => x.Item2);
    }
}