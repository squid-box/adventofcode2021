namespace AdventOfCode2021.Tests.Utils;

using AdventOfCode2021.Utils;

using NUnit.Framework;

[TestFixture]
public class CoordinateTests
{
    [Test]
    public void CoordinateVectorInteraction()
    {
        var coordinate = new Coordinate(1, 2, 3);

        Assert.AreEqual(new Coordinate(1, 2, 4), coordinate + Vector.Up);
        Assert.AreEqual(new Coordinate(1, 2, 2), coordinate - Vector.Up);
    }

    [Test]
    public void ManhattanDistanceTest()
    {
        var start = Coordinate.Zero;

        var end = new Coordinate(10, 10);

        Assert.AreEqual(0, Coordinate.ManhattanDistance(start, start));
        Assert.AreEqual(20, Coordinate.ManhattanDistance(start, end));
        Assert.AreEqual(20, Coordinate.ManhattanDistance(end, start));
    }
}