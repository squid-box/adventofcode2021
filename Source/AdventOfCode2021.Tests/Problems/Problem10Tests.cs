namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem10Tests
{
    private readonly string[] _testInput = new string[]
    {
        "[({(<(())[]>[[{[]{<()<>>",
        "[(()[<>])]({[<{<<[]>>(",
        "{([(<{}[<>[]}>{[]{[(<()>",
        "(((({<>}<{<{<>}{[]{[]{}",
        "[[<[([]))<([[{}[[()]]]",
        "[{[{({}]{}}([{[{{{}}([]",
        "{<[[]]>}<{[{[{[]{()[[[]",
        "[<(<(<(<{}))><([]([]()",
        "<{([([[(<>()){}]>(<<{{",
        "<{([{{}}[<[[[<>{}]]]>[]]"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(26397, Problem10.PartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(288957, Problem10.PartTwo(_testInput));
    }
}