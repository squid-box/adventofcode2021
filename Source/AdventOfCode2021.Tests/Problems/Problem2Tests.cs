namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem2Tests
{
    private string[] _testInput = new string[]
    {
        "forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(150, Problem2.PartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(900, Problem2.PartTwo(_testInput));
    }
}