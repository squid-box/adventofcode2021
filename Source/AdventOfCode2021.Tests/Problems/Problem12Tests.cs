namespace AdventOfCode2021.Tests.Problems;

using AdventOfCode2021.Problems;

using NUnit.Framework;

[TestFixture]
public class Problem12Tests
{
    private readonly string[] _testInput1 = new string[]
    {
        "start-A",
        "start-b",
        "A-c",
        "A-b",
        "b-d",
        "A-end",
        "b-end"
    };

    private readonly string[] _testInput2 = new string[]
    {
        "dc-end",
        "HN-start",
        "start-kj",
        "dc-start",
        "dc-HN",
        "LN-dc",
        "HN-end",
        "kj-sa",
        "kj-HN",
        "kj-dc"
    };

    private readonly string[] _testInput3 = new string[]
    {
        "fs-end",
        "he-DX",
        "fs-he",
        "start-DX",
        "pj-DX",
        "end-zg",
        "zg-sl",
        "zg-pj",
        "pj-he",
        "RW-he",
        "fs-DX",
        "pj-RW",
        "zg-RW",
        "start-pj",
        "he-WI",
        "zg-he",
        "pj-fs",
        "start-RW"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(10, Problem12.PartOne(_testInput1));
        Assert.AreEqual(19, Problem12.PartOne(_testInput2));
        Assert.AreEqual(226, Problem12.PartOne(_testInput3));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(36, Problem12.PartTwo(_testInput1));
        Assert.AreEqual(103, Problem12.PartTwo(_testInput2));
        Assert.AreEqual(3509, Problem12.PartTwo(_testInput3));
    }
}