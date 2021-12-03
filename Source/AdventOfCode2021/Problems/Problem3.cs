namespace AdventOfCode2021.Problems;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/3">Day 3</a>.
/// </summary>
public class Problem3 : ProblemBase
{
    public Problem3(InputDownloader inputDownloader = null) : base(3, inputDownloader) { }

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

    private static Dictionary<int, (int, int)> ParseInput(ICollection<string> input)
    {
        var positions = new Dictionary<int, (int, int)>();

        foreach (var line in input)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (!positions.ContainsKey(i))
                {
                    positions.Add(i, (0, 0));
                }

                if (line[i].Equals('0'))
                {
                    var current = positions[i];
                    positions[i] = (++current.Item1, current.Item2);
                }
                else
                {
                    var current = positions[i];
                    positions[i] = (current.Item1, ++current.Item2);
                }
            }
        }

        return positions;
    }

    internal static int PartOne(ICollection<string> input)
    {
        var positions = ParseInput(input);

        var mostCommon = string.Empty;
        var leastCommon = string.Empty;
 
        foreach (var kvp in positions)
        {
            if (kvp.Value.Item1 > kvp.Value.Item2)
            {
                mostCommon += '0';
                leastCommon += '1';
            }
            else
            {
                mostCommon += '1';
                leastCommon += '0';
            }
        }

        var mostCommonInDec = Convert.ToInt32(mostCommon, 2);
        var leastCommonInDec = Convert.ToInt32(leastCommon, 2);

        return mostCommonInDec * leastCommonInDec;
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var oxygenPositions = ParseInput(input);
        var potentialOxygenValues = input.ToList();

        for (var i = 0; i < potentialOxygenValues[0].Length; i++)
        {
            var mostCommonBit = FindMostCommonBit(oxygenPositions, i);
            potentialOxygenValues = potentialOxygenValues.Where(line => line[i] == mostCommonBit).ToList();
            oxygenPositions = ParseInput(potentialOxygenValues);

            if (potentialOxygenValues.Count <= 1)
            {
                break;
            }
        }

        var oxyGenRating = Convert.ToInt32(potentialOxygenValues.FirstOrDefault(), 2);

        var co2Positions = ParseInput(input);
        var potentialCo2Values = input.ToList();

        for (var i = 0; i < potentialCo2Values[0].Length; i++)
        {
            var leastCommonBit = FindLeastCommonBit(co2Positions, i);
            potentialCo2Values = potentialCo2Values.Where(line => line[i] == leastCommonBit).ToList();
            co2Positions = ParseInput(potentialCo2Values);

            if (potentialCo2Values.Count <= 1)
            { 
                break;
            }
        }

        var co2ScrubberRating = Convert.ToInt32(potentialCo2Values.FirstOrDefault(), 2);

        return oxyGenRating * co2ScrubberRating;
    }

    private static char FindMostCommonBit(Dictionary<int, (int, int)> positions, int position)
    {
        if (positions[position].Item1 == positions[position].Item2)
        {
            return '1';
        }
        else if (positions[position].Item1 > positions[position].Item2)
        {
            return '0';
        }
        else
        {
            return '1';
        }
    }

    private static char FindLeastCommonBit(Dictionary<int, (int, int)> positions, int position)
    {
        if (positions[position].Item1 == positions[position].Item2)
        {
            return '0';
        }
        else
        if (positions[position].Item1 > positions[position].Item2)
        {
            return '1';
        }
        else
        {
            return '0';
        }
    }
}