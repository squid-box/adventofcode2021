namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem5Tests
{
    private readonly string[] _testInput = new[]
    {
        "0,9 -> 5,9",
        "8,0 -> 0,8",
        "9,4 -> 3,4",
        "2,2 -> 2,1",
        "7,0 -> 7,4",
        "6,4 -> 2,0",
        "0,9 -> 2,9",
        "3,4 -> 1,4",
        "0,0 -> 8,8",
        "5,5 -> 8,2"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(5, Problem5.PartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(12, Problem5.PartTwo(_testInput));
    }
}