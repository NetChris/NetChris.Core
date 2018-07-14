using System;

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
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CompactGuid otherCompactGuid)
            {
                return Equals(otherCompactGuid);
            }

            return false;
        }

        /// <summary>
        /// Returns whether this <see cref="CompactGuid"/> equals another <see cref="CompactGuid"/>
        /// </summary>
        /// <param name="other">The other <see cref="CompactGuid"/>.</param>
        /// <returns><c>true</c> if this <see cref="CompactGuid"/> equals <paramref name="other"/>, <c>false</c> otherwise.</returns>
        public bool Equals(CompactGuid other)
        {
            return Guid.Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return Guid.GetHashCode();
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

        /// <summary>
        /// The character length of a <see cref="CompactGuid"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is useful for such purposes as setting
        /// length requirements on data transfer objects
        /// where the transfer format is a string.
        /// </para>
        /// </remarks>
        public const int CharacterLength = 32;
    }
}
