namespace AdventOfCode2021.Tests.Utils.Extensions;

using System;

using AdventOfCode2021.Utils.Extensions;

using NUnit.Framework;

[TestFixture]
public class StringExtensionsTests
{
    [TestCase("0", 0)]
    [TestCase("-10", -10)]
    [TestCase("666", 666)]
    public void Test(string source, int expectedResult)
    {
        Assert.AreEqual(expectedResult, source.ToInt());
    }

    [TestCase("0", 0)]
    [TestCase("-10", -10)]
    [TestCase("6000000000", 6000000000)]
    public void Test(string source, long expectedResult)
    {
        Assert.AreEqual(expectedResult, source.ToLong());
    }

    [Test]
    public void LongToInt_Throws()
    {
        Assert.Throws<OverflowException>(() => "6000000000".ToInt());
    }

    [Test]
    public void BadString_Throws()
    {
        Assert.Throws<FormatException>(() => "hello".ToInt());
    }
}