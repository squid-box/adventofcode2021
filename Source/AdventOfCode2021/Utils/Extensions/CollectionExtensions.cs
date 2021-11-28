namespace AdventOfCode2021.Utils.Extensions
{
	using System.Collections.Generic;
	using System.Linq;

    /// <summary>
    /// Extensions for the collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Converts the input from a collection of strings to a collection of integers.
        /// </summary>
        /// <param name="input">Input to convert.</param>
        /// <returns>An array of integers.</returns>
        public static IList<int> ConvertToInt(this ICollection<string> input)
        {
            return input.Select(int.Parse).ToList();
        }

        public static IList<long> ConvertToLong(this ICollection<string> input)
        {
            return input.Select(long.Parse).ToList();
        }

        public static IList<string> WithoutEmptyLines(this ICollection<string> input)
        {
            return input.Where(line => !string.IsNullOrEmpty(line)).ToList();
        }
    }
}
