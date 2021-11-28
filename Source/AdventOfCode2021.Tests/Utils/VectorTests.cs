namespace AdventOfCode2021.Tests.Utils
{
    using AdventOfCode2021.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void VectorAddition()
        {
            var vectorOne = new Vector(0, 0, 0);
            var vectorTwo = new Vector(5, 6, 7);
            var vectorThree = new Vector(1, 2, 3);

            var resultOne = new Vector(6, 8, 10);

            Assert.AreEqual(vectorTwo, vectorOne + vectorTwo);
            Assert.AreEqual(resultOne, vectorTwo + vectorThree);
        }
        
        [Test]
        public void VectorSubtraction()
        {
            var vectorOne = new Vector(0, 0, 0);
            var vectorTwo = new Vector(5, 6, 7);
            var vectorThree = new Vector(1, 2, 3);

            var resultOne = new Vector(4, 4, 4);

            Assert.AreEqual(vectorTwo, vectorTwo - vectorOne);
            Assert.AreEqual(resultOne, vectorTwo - vectorThree);
        }
    }
}
