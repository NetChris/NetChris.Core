using System;

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
    }
}
