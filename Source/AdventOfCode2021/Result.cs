namespace AdventOfCode2021;

using System;
using System.Linq;

using Spectre.Console;

/// <summary>
/// Represents the results from calculating a days problem(s).
/// </summary>
public class Result
{
    /// <summary>
    /// Creates a new <see cref="Result"/>.
    /// </summary>
    /// <param name="day">The day this <see cref="Result"/> belongs to.</param>
    public Result(int day)
    {
        Day = day;
        AnswerPartOne = AnswerPartTwo = "Unsolved";
    }

    /// <summary>
    /// Gets the day this <see cref="Result"/> belongs to.
    /// </summary>
    public int Day { get; }

    /// <summary>
    /// Gets the answer to part one of this <see cref="Result"/>.
    /// </summary>
    public string AnswerPartOne { get; set; }

    /// <summary>
    /// Gets the answer to part two of this <see cref="Result"/>.
    /// </summary>
    public string AnswerPartTwo { get; set; }

    /// <summary>
    /// Gets the full answer of this <see cref="Result"/>.
    /// </summary>
    public string FullAnswer => string.Join(" | ", new[] { AnswerPartOne, AnswerPartTwo }.Where(str => !str.Equals("Unsolved", StringComparison.OrdinalIgnoreCase)));

    /// <summary>
    /// Gets the time it took to calculate part one of this <see cref="Result"/>.
    /// </summary>
    public TimeSpan TimePartOne { get; set; }

    /// <summary>
    /// Gets the time it took to calculate part two of this <see cref="Result"/>.
    /// </summary>
    public TimeSpan TimePartTwo { get; set; }

    /// <summary>
    /// Gets the time it took to calculate both parts of this <see cref="Result"/>.
    /// </summary>
    public TimeSpan FullTime => TimePartOne + TimePartTwo;

    public override string ToString()
    {
        var answerPartOneFormat = AnswerPartOne.Equals("Unsolved") ? Color.Grey : Color.Yellow;
        var answerPartTwoFormat = AnswerPartTwo.Equals("Unsolved") ? Color.Grey : Color.Yellow;

        return $"[green]{Day}:1[/]| Answer: \"[{answerPartOneFormat}]{AnswerPartOne}[/]\" found in [{TimeBasedColor(TimePartOne)}]{TimePartOne}[/]" + Environment.NewLine +
               $"[green]{Day}:2[/]| Answer: \"[{answerPartTwoFormat}]{AnswerPartTwo}[/]\" found in [{TimeBasedColor(TimePartTwo)}]{TimePartTwo}[/]";
    }

    private static Color TimeBasedColor(TimeSpan time)
    {
        if (time < TimeSpan.FromMilliseconds(250))
        {
            return Color.Lime;
        }

        return time < TimeSpan.FromMilliseconds(500) ? Color.Orange1 : Color.Red3;
    }
}