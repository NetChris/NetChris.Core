using System;
using NetChris.Core.Values;

namespace NetChris.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether a string can be represented as a <see cref="Values.CompactGuid"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if a string can be represented as a <see cref="Values.CompactGuid"/>; otherwise, <c>false</c>.</returns>
        public static bool CanBeConvertedToCompactGuid(this string value)
        {
            bool result = Guid.TryParse(value, out var outGuid);
            return result;
        }

        /// <summary>
        /// Creates a <see cref="CompactGuid"/> from a string.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is a simple pipe through to <see cref="Guid.Parse(string)"/> so <paramref name="value"/> 
        /// must be parseable as a <see cref="Guid"/>.
        /// </para>
        /// </remarks>
        /// <param name="value">The value.</param>
        public static CompactGuid ToCompactGuid(this string value)
        {
            var guid = Guid.Parse(value);
            var result = new CompactGuid(guid);
            return result;
        }
    }
}
