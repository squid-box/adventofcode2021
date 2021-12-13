namespace AdventOfCode2021.Problems;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/12">Day 12</a>.
/// </summary>
public class Problem12 : ProblemBase
{
    public Problem12(InputDownloader inputDownloader = null) : base(12, inputDownloader) { }

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
        var graph = ParseInput(input);

        return graph.FindAllPaths(1);
    }

    internal static long PartTwo(ICollection<string> input)
    {
        var graph = ParseInput(input);

        return graph.FindAllPaths(2);
    }

    private static CaveGraph ParseInput(ICollection<string> input)
    {
        var graph = new CaveGraph();

        foreach (var line in input)
        {
            var tmp = line.Split('-');
            graph.AddEdge(tmp[0], tmp[1]);
        }

        return graph;
    }
}

internal class CaveGraph
{
    private readonly Dictionary<string, List<string>> _graph;
    private readonly HashSet<string> _smallCaves;

    public CaveGraph()
    {
        _graph = new Dictionary<string, List<string>>();
        _smallCaves = new HashSet<string>();
    }

    public int FindAllPaths(int part)
    {
        var sum = 0;

        var current = "start";
        var path = new List<string> { current };

        var queue = _graph[current];

        for (var i = 0; i < queue.Count; i++)
        {
            var next = queue[i];
            sum += Recurse(next, new List<string>(path), part);
        }

        return sum;
    }

    private int Recurse(string current, List<string> path, int part)
    {
        if (part.Equals(1))
        {
            if (_smallCaves.Contains(current) && path.Contains(current))
            {
                return 0;
            }
        }
        else
        {
            if (path.Contains(current) && _smallCaves.Contains(current))
            {
                if (path.Contains("!"))
                {
                    return 0;
                }

                if (path.Contains(current))
                {
                    path.Add("!");
                }
            }
        }

        path.Add(current);

        if (current.Equals("end"))
        {
            return 1;
        }

        var sum = 0;

        var stack = new Stack<string>(_graph[current]);

        while (stack.Count > 0)
        {
            var next = stack.Pop();

            if (next.Equals("start"))
            {
                continue;
            }

            var newPath = new List<string>(path);
            sum += Recurse(next, newPath, part);
        }

        return sum;
    }

    public void AddEdge(string sourceNode, string destinationNode)
    {
        if (!_graph.ContainsKey(sourceNode))
        {
            _graph.Add(sourceNode, new List<string>());
        }

        if (!_graph.ContainsKey(destinationNode))
        {
            _graph.Add(destinationNode, new List<string>());
        }

        _graph[sourceNode].Add(destinationNode);
        _graph[destinationNode].Add(sourceNode);

        if (sourceNode.All(char.IsLower))
        {
            _smallCaves.Add(sourceNode);
        }

        if (destinationNode.All(char.IsLower))
        {
            _smallCaves.Add(destinationNode);
        }
    }
}