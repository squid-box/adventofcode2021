namespace AdventOfCode2021.Problems;

using AdventOfCode2021.Utils;
using AdventOfCode2021.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/9">Day 9</a>.
/// </summary>
public class Problem9 : ProblemBase
{
    public Problem9(InputDownloader inputDownloader = null) : base(9, inputDownloader) { }

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
        var heatmap = ParseInput(input.ToList());

        var riskLevel = 0;

        for (var y = 0; y < heatmap.Height; y++)
        {
            for (var x = 0; x < heatmap.Width; x++)
            {
                var point = heatmap.GetElement(x, y);

                var smallestPoint = true;

                foreach (var neighbour in GetNeighbours(new Coordinate(x, y)))
                {
                    try
                    {
                        if (heatmap.GetElement(neighbour.X, neighbour.Y) <= point)
                        {
                            smallestPoint = false;
                        }
                    }
                    catch { }
                }

                if (smallestPoint)
                {
                    riskLevel += 1 + point;
                }
            }
        }

        return riskLevel;
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var heatmap = ParseInput(input.ToList());
        var visited = new HashSet<Coordinate>();

        var basins = new List<int>();

        for (var y = 0; y < heatmap.Height; y++)
        {
            for (var x = 0; x < heatmap.Width; x++)
            {
                var coord = new Coordinate(x, y);
                if (visited.Contains(coord))
                {
                    continue;
                }

                try
                {
                    var point = heatmap.GetElement(x, y);

                    if (point == 9)
                    {
                        continue;
                    }
                }
                catch { }

                var basin = 1;
                visited.Add(coord);

                var toVisit = new HashSet<Coordinate>(GetNeighbours(coord));
                toVisit.ExceptWith(visited);

                while (toVisit.Count > 0)
                {
                    var next = toVisit.First();
                    toVisit.Remove(next);

                    visited.Add(next);

                    try
                    {
                        if (heatmap.GetElement(next.X, next.Y) == 9)
                        {
                            continue;
                        }
                    }
                    catch { continue; }

                    basin++;

                    toVisit.UnionWith(GetNeighbours(next));
                    toVisit.ExceptWith(visited);
                }

                basins.Add(basin);
            }
        }

        var result = 1;

        foreach (var basin in basins.OrderByDescending(x => x).Take(3))
        {
            result *= basin;
        }

        return result;
    }

    private static List<Coordinate> GetNeighbours(Coordinate center)
    {
        return new List<Coordinate>
        {
            center + Vector.North,
            center + Vector.West,
            center + Vector.South,
            center + Vector.East
        };
    }

    private static Matrix<int> ParseInput(IList<string> input)
    {
        var matrix = new Matrix<int>(input[0].Length, input.Count);

        for (var y = 0; y < matrix.Height; y++)
        {
            var line = input[y].ToArray();

            for (var x = 0; x < matrix.Width; x++)
            {
                matrix.SetElement(x, y, line[x].ToString().ToInt());
            }
        }

        return matrix;
    }
}