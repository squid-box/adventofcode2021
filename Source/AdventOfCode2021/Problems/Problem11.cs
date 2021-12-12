namespace AdventOfCode2021.Problems;

using System.Collections.Generic;
using System.Linq;

using AdventOfCode2021.Utils;
using AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/11">Day 11</a>.
/// </summary>
public class Problem11 : ProblemBase
{
    public Problem11(InputDownloader inputDownloader = null) : base(11, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input.ToList(), 100);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input.ToList());
    }

    internal static int PartOne(IList<string> input, int steps)
    {
        var octopi = new Dictionary<Coordinate, int>();

        for (var y = 0; y < input.Count; y++)
        {
            var line = input[y];

            for (var x = 0; x < line.Length; x++)
            {
                octopi.Add(new Coordinate(x, y), line[x].ToString().ToInt());
            }
        }

        var flashes = 0;

        for (var step = 0; step < steps; step++)
        {
            var toFlash = new List<Coordinate>();

            // Increment all energy levels by one.
            foreach (var octopus in octopi)
            {
                octopi[octopus.Key]++;

                if (octopi[octopus.Key] > 9)
                {
                    toFlash.Add(octopus.Key);
                }
            }

            // Check state
            var flashed = new HashSet<Coordinate>();

            while (toFlash.Count > 0)
            {
                var current = toFlash.First();
                toFlash.Remove(current);

                if (flashed.Contains(current))
                {
                    continue;
                }

                if (octopi[current] > 9)
                {
                    flashes++;
                    octopi[current] = 0;

                    flashed.Add(current);

                    foreach (var neighbour in current.GetNeighbours())
                    {
                        if (!octopi.ContainsKey(neighbour) || flashed.Contains(neighbour))
                        {
                            continue;
                        }

                        octopi[neighbour]++;

                        if (octopi[neighbour] > 9)
                        {
                            toFlash.Add(neighbour);
                        }
                    }
                }
            }
        }

        return flashes;
    }

    internal static int PartTwo(IList<string> input)
    {
        var octopi = new Dictionary<Coordinate, int>();

        for (var y = 0; y < input.Count; y++)
        {
            var line = input[y];

            for (var x = 0; x < line.Length; x++)
            {
                octopi.Add(new Coordinate(x, y), line[x].ToString().ToInt());
            }
        }

        var flashes = 0;

        for (var step = 0; step < int.MaxValue; step++)
        {
            var toFlash = new List<Coordinate>();

            // Increment all energy levels by one.
            foreach (var octopus in octopi)
            {
                octopi[octopus.Key]++;

                if (octopi[octopus.Key] > 9)
                {
                    toFlash.Add(octopus.Key);
                }
            }

            // Check state
            var flashed = new HashSet<Coordinate>();

            while (toFlash.Count > 0)
            {
                var current = toFlash.First();
                toFlash.Remove(current);

                if (flashed.Contains(current))
                {
                    continue;
                }

                if (octopi[current] > 9)
                {
                    flashes++;
                    octopi[current] = 0;

                    flashed.Add(current);

                    foreach (var neighbour in current.GetNeighbours())
                    {
                        if (!octopi.ContainsKey(neighbour) || flashed.Contains(neighbour))
                        {
                            continue;
                        }

                        octopi[neighbour]++;

                        if (octopi[neighbour] > 9)
                        {
                            toFlash.Add(neighbour);
                        }
                    }
                }
            }

            if (flashed.Count == 100)
            {
                return step + 1;
            }
        }

        return int.MinValue;
    }
}