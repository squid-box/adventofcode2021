namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem7Tests
{
    private readonly string[] _testInput = new string[]
    {
        "16,1,2,0,4,2,7,1,2,14"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(37, Problem7.FindLowestFuelConsumption(_testInput, 1));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(168, Problem7.FindLowestFuelConsumption(_testInput, 2));
    }
}