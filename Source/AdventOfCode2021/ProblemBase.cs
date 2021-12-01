namespace AdventOfCode2021;

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Base class for Problems.
/// </summary>
public abstract class ProblemBase
{
    private readonly InputDownloader _inputDownloader;

    /// <summary>
    /// Creates a new <see cref="ProblemBase"/>.
    /// </summary>
    /// <param name="day">Day this problem belongs to.</param>
    protected ProblemBase(int day, InputDownloader inputDownloader = null)
    {
        _inputDownloader = inputDownloader;

        Day = day;
        Result = new Result(Day);
    }

    /// <summary>
    /// Day this problem belongs to.
    /// </summary>
    public int Day { get; }

    /// <summary>
    /// Gets the input for this problem.
    /// </summary>
    public ICollection<string> Input => File.ReadAllLines($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Inputs{Path.DirectorySeparatorChar}{Day}.input");

    /// <summary>
    /// The <see cref="Result"/> of solving this problem.
    /// </summary>
    public Result Result { get; }

    /// <summary>
    /// Calculate the solution(s) to this problem.
    /// </summary>
    public void CalculateSolution()
    {
        _inputDownloader?.DownloadDay(Day);

        var start = DateTime.Now;
        Result.AnswerPartOne = SolvePartOne().ToString();
        Result.TimePartOne = DateTime.Now - start;

        start = DateTime.Now;
        Result.AnswerPartTwo = SolvePartTwo().ToString();
        Result.TimePartTwo = DateTime.Now - start;
    }

    /// <summary>
    /// Calculates the first part of this problem.
    /// </summary>
    /// <returns>The answer for this part.</returns>
    protected abstract object SolvePartOne();

    /// <summary>
    /// Calculates the second part of this problem.
    /// </summary>
    /// <returns>The answer for this part.</returns>
    protected abstract object SolvePartTwo();
}