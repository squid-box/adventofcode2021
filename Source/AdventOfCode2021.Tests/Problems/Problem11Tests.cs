namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem11Tests
{
    private readonly string[] _testInput = new string[]
    {
        "5483143223",
        "2745854711",
        "5264556173",
        "6141336146",
        "6357385478",
        "4167524645",
        "2176841721",
        "6882881134",
        "4846848554",
        "5283751526"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(204, Problem11.PartOne(_testInput, 10));
        Assert.AreEqual(1656, Problem11.PartOne(_testInput, 100));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(195, Problem11.PartTwo(_testInput));
    }
}