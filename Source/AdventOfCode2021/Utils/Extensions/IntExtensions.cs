namespace AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Extensions for integers.
/// </summary>
public static class IntExtensions
{
    /// <summary>
    /// Determines if the integer is within a given (inclusive) range.
    /// </summary>
    /// <param name="val">Value to check.</param>
    /// <param name="lowerBound">Lower bound (inclusive).</param>
    /// <param name="upperBound">Upper bound (inclusive).</param>
    /// <returns>True if the integer is within the given range, otherwise false.</returns>
    public static bool IsWithin(this int val, int lowerBound, int upperBound)
    {
        return lowerBound <= val && val <= upperBound;
    }
}