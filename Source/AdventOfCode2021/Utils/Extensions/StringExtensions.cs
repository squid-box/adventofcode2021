namespace AdventOfCode2021.Utils.Extensions;

using System;

/// <summary>
/// Extensions for strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string into an int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as an integer.</returns>
    public static int ToInt(this string source)
    {
        return Convert.ToInt32(source);
    }

    /// <summary>
    /// Converts a string into a long.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as a long.</returns>
    public static long ToLong(this string source)
    {
        return Convert.ToInt64(source);
    }

    /// <summary>
    /// Converts a string into a nullable int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as an integer, or null.</returns>
    public static int? ToNullableInt(this string source)
    {
        try
        {
            return Convert.ToInt32(source);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Converts a string from binary to a decimal int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as a decimal integer.</returns>
    public static int ToIntFromBinary(this string source)
    {
        return Convert.ToInt32(source, 2);
    }
}