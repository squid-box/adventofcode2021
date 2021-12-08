namespace AdventOfCode2021.Problems;

using AdventOfCode2021.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/8">Day 8</a>.
/// </summary>
public class Problem8 : ProblemBase
{
    public Problem8(InputDownloader inputDownloader = null) : base(8, inputDownloader) { }

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
        var data = ParseInput(input);

        var total = 0;

        foreach (var (_, digits) in data)
        {
            foreach (var digit in digits)
            {
                if (digit.Length == 2 ||
                    digit.Length == 4 ||
                    digit.Length == 3 ||
                    digit.Length == 7)
                {
                    total++;
                }
            }
        }

        return total;
    }

    internal static long PartTwo(ICollection<string> input)
    {
        var data = ParseInput(input);
        var results = new List<long>();

        foreach (var (signals, digits) in data)
        {
            var one = signals[0];
            var seven = signals[1];
            var four = signals[2];
            var eight = signals[9];

            var frequencies = GetLetterFrequencies(signals);

            var signalA = seven.ToArray().Except(one.ToArray()).First().ToString();
            var signalB = frequencies.Where(kvp => kvp.Value == 6).First().Key.ToString();
            var signalE = frequencies.Where(kvp => kvp.Value == 4).First().Key.ToString();
            var signalF = frequencies.Where(kvp => kvp.Value == 9).First().Key.ToString();
            var signalC = one.Replace(signalF.ToString(), string.Empty)[0].ToString();
            var signalD = four
                .Replace(signalB, string.Empty)
                .Replace(signalC, string.Empty)
                .Replace(signalF, string.Empty)[0].ToString();
            var signalG = eight
                .Replace(signalA, string.Empty)
                .Replace(signalB, string.Empty)
                .Replace(signalC, string.Empty)
                .Replace(signalD, string.Empty)
                .Replace(signalE, string.Empty)
                .Replace(signalF, string.Empty)[0].ToString();

            var learned = new Dictionary<string, long>
            {
                { one.SortAlphabetically(), 1L },
                { four.SortAlphabetically(), 4L },
                { seven.SortAlphabetically(), 7L },
                { eight.SortAlphabetically(), 8L },
                { eight.Replace(signalE, string.Empty).SortAlphabetically(), 9L }
            };

            learned.Add(eight.Replace(signalC, string.Empty).Replace(signalE, string.Empty).SortAlphabetically(), 5L);
            learned.Add(eight.Replace(signalC, string.Empty).SortAlphabetically(), 6L);
            learned.Add(eight.Replace(signalB, string.Empty).Replace(signalE, string.Empty).SortAlphabetically(), 3L);
            learned.Add(eight.Replace(signalB, string.Empty).Replace(signalF, string.Empty).SortAlphabetically(), 2L);
            learned.Add(eight.Replace(signalD, string.Empty).SortAlphabetically(), 0L);

            results.Add(
                learned[digits[0].SortAlphabetically()] * 1000 +
                learned[digits[1].SortAlphabetically()] * 100 +
                learned[digits[2].SortAlphabetically()] * 10 +
                learned[digits[3].SortAlphabetically()]);
        }

        return results.Sum();
    }

    private static Dictionary<char, int> GetLetterFrequencies(IList<string> signals)
    {
        var result = new Dictionary<char, int>();

        foreach (var signal in signals)
        {
            foreach (var c in signal)
            {
                if (!result.ContainsKey(c))
                {
                    result.Add(c, 0);
                }

                result[c]++;
            }
        }

        return result;
    }

    private static IList<(IList<string> signals, IList<string> digits)> ParseInput(ICollection<string> input)
    {
        var results = new List<(IList<string>, IList<string>)>();

        foreach (var line in input)
        {
            var split = line.Split(" | ");

            results.Add((split[0].Split(' ').OrderBy(x => x.Length).ToList(), split[1].Split(' ')));
        }

        return results;
    }
}