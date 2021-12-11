namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem9Tests
{
    private readonly string[] _testInput = new string[]
    {
        "2199943210",
        "3987894921",
        "9856789892",
        "8767896789",
        "9899965678"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(15, Problem9.PartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(1134, Problem9.PartTwo(_testInput));
    }
}