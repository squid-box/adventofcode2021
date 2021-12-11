namespace AdventOfCode2021.Problems;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/10">Day 10</a>.
/// </summary>
public class Problem10 : ProblemBase
{
    public Problem10(InputDownloader inputDownloader = null) : base(10, inputDownloader) { }

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

    internal static long PartOne(ICollection<string> input)
    {
        var score = 0L;

        foreach (var line in input)
        {
            score += EvaluateLine(line);
        }

        return score;
    }

    internal static long PartTwo(ICollection<string> input)
    {
        var scores = new List<long>();

        var validLines = new List<string>();

        foreach (var line in input)
        {
            if (EvaluateLine(line) == 0)
            {
                validLines.Add(line);
            }
        }

        var scoring = new Dictionary<char, int>
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 }
        };

        var expectedClosings = new Dictionary<char, char>
        {
            { '<', '>' },
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        foreach (var line in validLines)
        {
            var openedStack = new Stack<char>();

            foreach (var c in line)
            {
                if (expectedClosings.Keys.Contains(c))
                {
                    openedStack.Push(expectedClosings[c]);
                }
                else
                {
                    var expected = openedStack.Pop();
                }
            }

            var score = 0L;

            foreach (var c in openedStack)
            {
                score = score * 5 + scoring[c];
            }

            scores.Add(score);
        }

        return scores.OrderBy(x => x).Skip(scores.Count/2).Take(1).First();
    }

    private static long EvaluateLine(string line)
    {
        var scoring = new Dictionary<char, int>
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 }
        };

        var expectedClosings = new Dictionary<char, char>
        {
            { '<', '>' },
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        var openedStack = new Stack<char>();

        foreach (var c in line)
        {
            if (expectedClosings.Keys.Contains(c))
            {
                openedStack.Push(expectedClosings[c]);
            }
            else
            {
                var expected = openedStack.Pop();

                if (!c.Equals(expected))
                {
                    return scoring[c];
                }
            }
        }

        return 0;
    }
}