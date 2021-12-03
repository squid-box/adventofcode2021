namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem3Tests
{
    private readonly string[] _testInput = new string[]
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(198, Problem3.PartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(230, Problem3.PartTwo(_testInput));
    }
}