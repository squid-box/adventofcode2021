namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem6Tests
{
    private readonly string[] _testInput = new[]
    {
        "3,4,3,1,2"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(26, Problem6.CalculatePopulation(_testInput, 18));
        Assert.AreEqual(5934, Problem6.CalculatePopulation(_testInput, 80));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(26984457539, Problem6.CalculatePopulation(_testInput, 256));
    }
}