﻿using System;

namespace NetChris.Core.Values
{
    /// <summary>
    /// Represents a 'compact' <see cref="Guid"/>, primarily for simple alphanumeric string representation.
    /// </summary>
    /// <remarks>
    /// This is primarily a way to communicate a <see cref="string"/> representation of a <see cref="Guid"/>
    /// that is as compact as possible and, assuming the concept of <see cref="CompactGuid"/> is used commonly,
    /// can be consistent across systems.
    /// </remarks>
    public struct CompactGuid
    {
        private readonly string _compactGuidString;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompactGuid"/> struct.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        public CompactGuid(Guid guid)
        {
            Guid = guid;
            _compactGuidString = GetCompactGuidString(Guid);
        }

        /// <summary>
        /// Creates a new <see cref="CompactGuid"/> with a new <see cref="Guid"/>
        /// </summary>
        public static CompactGuid New()
        {
            return new CompactGuid(Guid.NewGuid());
        }

        private static string GetCompactGuidString(Guid guid)
        {
            var result = guid
                .ToString() // String representation of the Guid
                .Replace("-", "") // Remove the dashes
                .ToLower(); // Force to lowercase

            return result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompactGuid"/> struct.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringValue"/> is null</exception>
        /// <exception cref="FormatException"><paramref name="stringValue"/> is not a correctly-formatted string representation of a <see cref="Guid"/></exception>
        /// <exception cref="OverflowException"><paramref name="stringValue"/> is not a correctly-formatted string representation of a <see cref="Guid"/></exception>
        public CompactGuid(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }

            // TODO 0000 - Ensure FormatException is thrown
            // TODO 0000 - Ensure OverflowException is thrown

            Guid = new Guid(stringValue);
            _compactGuidString = GetCompactGuidString(Guid);
        }

        /// <summary>
        /// Gets the <see cref="Guid"/> underlying the <see cref="CompactGuid"/>.
        /// </summary>
        /// <value>The <see cref="Guid"/> underlying the <see cref="CompactGuid"/>.</value>
        public Guid Guid
        {
            get;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return _compactGuidString;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CompactGuid"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="compactGuid">The compact unique identifier.</param>
        /// <returns>The resultant <see cref="string"/>.</returns>
        public static implicit operator string(CompactGuid compactGuid)
        {
            return compactGuid._compactGuidString;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string" /> to <see cref="CompactGuid" />.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <returns>The resultant <see cref="CompactGuid" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stringValue"/> is null</exception>
        /// <exception cref="FormatException"><paramref name="stringValue"/> is not a correctly-formatted string representation of a <see cref="Guid"/></exception>
        /// <exception cref="OverflowException"><paramref name="stringValue"/> is not a correctly-formatted string representation of a <see cref="Guid"/></exception>
        public static implicit operator CompactGuid(string stringValue)
        {
            // TODO 0000 - Test this to make sure that, should a bad value be used, that a _descriptive_ exception is thrown:
            // "The string value used in place of CompactGuid, {stringValue}, was invalid: null, empty, or otherwise unparseable as a Guid"
            return new CompactGuid(stringValue);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CompactGuid"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="compactGuid">The compact unique identifier.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Guid(CompactGuid compactGuid)
        {
            return compactGuid.Guid;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Guid"/> to <see cref="CompactGuid"/>.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CompactGuid(Guid guid)
        {
            return new CompactGuid(guid);
        }
    }
}