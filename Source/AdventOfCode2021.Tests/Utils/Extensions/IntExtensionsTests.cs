namespace AdventOfCode2021.Tests.Utils.Extensions
{
    using AdventOfCode2021.Utils.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class IntExtensionsTests
    {
        [TestCase(0, 0, 0, true)]
        [TestCase(5, 0, 10, true)]
        [TestCase(5, 6, 10, false)]
        [TestCase(5, 0, 4, false)]
        public void Test(int value, int lowerRange, int upperRange, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsWithin(lowerRange, upperRange));
        }
    }
}
