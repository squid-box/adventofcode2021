namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem1Tests
{
    private readonly string[] _testInput = new[] 
    {   
        "199",
        "200",
        "208",
        "210",
        "200",
        "207",
        "240",
        "269",
        "260",
        "263"
    };

    [Test]
    public void TestPart1()
    {
        Assert.AreEqual(7, Problem1.PartOne(_testInput));
    }

    [Test]
    public void TestPart2()
    {
        Assert.AreEqual(5, Problem1.PartTwo(_testInput));
    }
}