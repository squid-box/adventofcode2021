namespace AdventOfCode2021.Utils;

using System;
using System.Collections.Generic;

using AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Simple matrix wrapper.
/// </summary>
/// <typeparam name="T">Type used within the <see cref="Matrix"/>.</typeparam>
public class Matrix<T>
{
    private readonly T[,] _matrix;

    /// <summary>
    /// Creates a new <see cref="Matrix"/> with the given dimensions.
    /// </summary>
    /// <param name="width">Width of the matrix.</param>
    /// <param name="height">Height of the matrix.</param>
    public Matrix(int width, int height)
    {
        Width = width;
        Height = height;

        _matrix = new T[Width, Height];
    }

    /// <summary>
    /// Creates a new square <see cref="Matrix"/> with the given size.
    /// </summary>
    /// <param name="size">Width and height of the matrix.</param>
    public Matrix(int size)
    {
        Width = size;
        Height = size;

        _matrix = new T[size, size];
    }

    /// <summary>
    /// Width of the <see cref="Matrix"/>.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Height of the <see cref="Matrix"/>.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the element stored at (<paramref name="x"/>,<paramref name="y"/>).
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public T GetElement(int x, int y)
    {
        EvaluateGivenIndices(x, y);

        return _matrix[x, y];
    }

    /// <summary>
    /// Sets the given element at (<paramref name="x"/>,<paramref name="y"/>).
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public void SetElement(int x, int y, T value)
    {
        EvaluateGivenIndices(x, y);

        _matrix[x, y] = value;
    }

    /// <summary>
    /// Gets all elements on the given row.
    /// </summary>
    /// <param name="y">Zero-indexed row number.</param>
    /// <returns>All elements from given row.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public IList<T> GetRow(int y)
    {
        EvaluateGivenIndices(0, y);

        var result = new List<T>();

        for (int x = 0; x < Width; x++)
        {
            result.Add(_matrix[x, y]);
        }

        return result;
    }

    /// <summary>
    /// Gets all elements in the given column.
    /// </summary>
    /// <param name="x">Zero-indexed column number.</param>
    /// <returns>All elements from given column.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public IList<T> GetColumn(int x)
    {
        EvaluateGivenIndices(x, 0);

        var result = new List<T>();

        for (int y = 0; y < Height; y++)
        {
            result.Add(_matrix[x, y]);
        }

        return result;
    }

    private void EvaluateGivenIndices(int x, int y)
    {
        if (!x.IsWithin(0, Width))
        {
            throw new IndexOutOfRangeException($"Given index (x = {x}) not within matrix bounds.");
        }
        if (!y.IsWithin(0, Height))
        {
            throw new IndexOutOfRangeException($"Given index (y = {y}) not within matrix bounds.");
        }
    }
}