namespace AdventOfCode2021.Problems;

using System;
using System.Linq;
using System.Collections.Generic;

using AdventOfCode2021.Utils;
using AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/5">Day 5</a>.
/// </summary>
public class Problem5 : ProblemBase
{
    public Problem5(InputDownloader inputDownloader = null) : base(5, inputDownloader) { }

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
        var lines = ParseInput(input);

        var locations = new Dictionary<Coordinate, int>();

        foreach (var line in lines.Where(Line => Line.IsVertical || Line.IsHorizontal))
        {
            foreach (var coord in line.GetCoordinates())
            {
                if (!locations.ContainsKey(coord))
                {
                    locations.Add(coord, 0);
                }

                locations[coord]++;
            }
        }

        return locations.Where(kvp => kvp.Value > 1).Count();
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var lines = ParseInput(input);

        var locations = new Dictionary<Coordinate, int>();

        foreach (var line in lines.Where(Line => Line.IsVertical || Line.IsHorizontal || Line.IsDiagonal))
        {
            foreach (var coord in line.GetCoordinates())
            {
                if (!locations.ContainsKey(coord))
                {
                    locations.Add(coord, 0);
                }

                locations[coord]++;
            }
        }

        return locations.Where(kvp => kvp.Value > 1).Count();
    }

    internal static IList<Line> ParseInput(ICollection<string> input)
    {
        var result = new List<Line>();

        foreach(var line in input)
        {
            result.Add(new Line(line));
        }

        return result;
    }

    internal class Line
    {
        public Line(string input)
        {
            var tmp = input.Split(" -> ");
            var originSplit = tmp[0].Split(',').ConvertToInt();
            var destinationSplit = tmp[1].Split(',').ConvertToInt();

            Origin = new Coordinate(originSplit[0], originSplit[1]);
            Destination = new Coordinate(destinationSplit[0], destinationSplit[1]);
        }

        public Coordinate Origin { get; }

        public Coordinate Destination { get; }

        public IList<Coordinate> GetCoordinates()
        {
            var result = new List<Coordinate>();
            var currentCoordinate = Origin;

            int xDirection = 0;
            int yDirection = 0;

            if (Destination.X > Origin.X)
            {
                xDirection = 1;
            }
            else if (Destination.X < Origin.X)
            {
                xDirection = -1;
            }

            if (Destination.Y > Origin.Y)
            {
                yDirection = 1;
            }
            else if (Destination.Y < Origin.Y)
            {
                yDirection = -1;
            }

            while (!currentCoordinate.Equals(Destination))
            {
                result.Add(currentCoordinate);

                currentCoordinate = new Coordinate(currentCoordinate.X + xDirection, currentCoordinate.Y + yDirection);
            }

            result.Add(Destination);

            return result;
        }

        public bool IsHorizontal => Origin.X == Destination.X;

        public bool IsVertical => Origin.Y == Destination.Y;

        public bool IsDiagonal => Math.Abs(Origin.X - Destination.X) == Math.Abs(Origin.Y - Destination.Y);
    }
}