namespace AdventOfCode2021.Tests.Utils;

using System;

using AdventOfCode2021.Utils;

using NUnit.Framework;

[TestFixture]
public class MatrixTests
{
    [Test]
    public void ConstructorTests()
    {
        var squareMatrix = new Matrix<int>(10);

        Assert.AreEqual(10, squareMatrix.Width);
        Assert.AreEqual(10, squareMatrix.Height);

        var matrix = new Matrix<int>(5, 10);

        Assert.AreEqual(5, matrix.Width);
        Assert.AreEqual(10, matrix.Height);
    }

    [Test]
    public void GetElementTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.GetElement(-1, 5));
        Assert.IsFalse(matrix.GetElement(0, 0));
    }

    [Test]
    public void SetElementTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.SetElement(-1, 5, true));
        Assert.IsFalse(matrix.GetElement(0, 0));
        matrix.SetElement(0, 0, true);
        Assert.IsTrue(matrix.GetElement(0, 0));
    }

    [Test]
    public void GetRowTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.GetRow(-1));
        Assert.AreEqual(10, matrix.GetRow(0).Count);
    }

    [Test]
    public void GetColumnTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.GetColumn(-1));
        Assert.AreEqual(10, matrix.GetColumn(0).Count);
    }
}