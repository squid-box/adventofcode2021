namespace AdventOfCode2021.Problems;

using System.Collections.Generic;
using System.Linq;

using AdventOfCode2021.Utils.Extensions;

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

    private static List<(int Zeroes, int Ones)> ParseInput(ICollection<string> input)
    {
        var positions = new List<(int Zeroes, int Ones)>();

        for (var i = 0; i < input.First().Length; i++)
        {
            positions.Add((0, 0));
        }

        foreach (var line in input)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i].Equals('0'))
                {
                    var (Zeroes, Ones) = positions[i];
                    positions[i] = (++Zeroes, Ones);
                }
                else
                {
                    var (Zeroes, Ones) = positions[i];
                    positions[i] = (Zeroes, ++Ones);
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
 
        foreach (var (Zeroes, Ones) in positions)
        {
            if (Zeroes > Ones)
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

        return mostCommon.ToIntFromBinary() * leastCommon.ToIntFromBinary();
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var oxygenStatistics = ParseInput(input);
        var potentialOxygenValues = input.ToList();

        for (var i = 0; i < potentialOxygenValues[0].Length; i++)
        {
            var mostCommonBit = FindMostCommonBit(oxygenStatistics, i);
            potentialOxygenValues = potentialOxygenValues.Where(line => line[i] == mostCommonBit).ToList();
            oxygenStatistics = ParseInput(potentialOxygenValues);

            if (potentialOxygenValues.Count <= 1)
            {
                break;
            }
        }

        var co2Statistics = ParseInput(input);
        var potentialCo2Values = input.ToList();

        for (var i = 0; i < potentialCo2Values[0].Length; i++)
        {
            var mostCommonBit = FindMostCommonBit(co2Statistics, i);
            potentialCo2Values = potentialCo2Values.Where(line => line[i] != mostCommonBit).ToList();
            co2Statistics = ParseInput(potentialCo2Values);

            if (potentialCo2Values.Count <= 1)
            { 
                break;
            }
        }

        return potentialOxygenValues.First().ToIntFromBinary() * potentialCo2Values.First().ToIntFromBinary();
    }

    private static char FindMostCommonBit(List<(int Zeroes, int Ones)> positions, int position)
    {
        if (positions[position].Zeroes == positions[position].Ones)
        {
            return '1';
        }
        else if (positions[position].Zeroes > positions[position].Ones)
        {
            return '0';
        }
        else
        {
            return '1';
        }
    }
}