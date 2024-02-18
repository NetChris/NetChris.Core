using System;
using System.Collections.Generic;
using System.Text;

namespace NetChris.Core.Values
{
    /// <summary>
    /// An variation on Douglas Crockford's
    /// <see href="https://www.crockford.com/wrmg/base32.html">Base32 Encoding</see>
    /// used for non-negative identity integers only.
    /// </summary>
    public struct IdentityBase32
    {
        private readonly ulong _internalNumber;

        private static readonly CaseInsensitiveCharsToIntMap CaseInsensitiveCharsToIntMap =
            new CaseInsensitiveCharsToIntMap();

        static IdentityBase32()
        {
            // 0 == o == O
            CaseInsensitiveCharsToIntMap.Register(0, '0', 'o');

            // 1 == i == I == l == L
            CaseInsensitiveCharsToIntMap.Register(1, '1', 'l', 'i');

            CaseInsensitiveCharsToIntMap.Register(2, '2');
            CaseInsensitiveCharsToIntMap.Register(3, '3');
            CaseInsensitiveCharsToIntMap.Register(4, '4');
            CaseInsensitiveCharsToIntMap.Register(5, '5');
            CaseInsensitiveCharsToIntMap.Register(6, '6');
            CaseInsensitiveCharsToIntMap.Register(7, '7');
            CaseInsensitiveCharsToIntMap.Register(8, '8');
            CaseInsensitiveCharsToIntMap.Register(9, '9');
            CaseInsensitiveCharsToIntMap.Register(10, 'a');
            CaseInsensitiveCharsToIntMap.Register(11, 'b');
            CaseInsensitiveCharsToIntMap.Register(12, 'c');
            CaseInsensitiveCharsToIntMap.Register(13, 'd');
            CaseInsensitiveCharsToIntMap.Register(14, 'e');
            CaseInsensitiveCharsToIntMap.Register(15, 'f');
            CaseInsensitiveCharsToIntMap.Register(16, 'g');
            CaseInsensitiveCharsToIntMap.Register(17, 'h');
            CaseInsensitiveCharsToIntMap.Register(18, 'j');
            CaseInsensitiveCharsToIntMap.Register(19, 'k');
            CaseInsensitiveCharsToIntMap.Register(20, 'm');
            CaseInsensitiveCharsToIntMap.Register(21, 'n');
            CaseInsensitiveCharsToIntMap.Register(22, 'p');
            CaseInsensitiveCharsToIntMap.Register(23, 'q');
            CaseInsensitiveCharsToIntMap.Register(24, 'r');
            CaseInsensitiveCharsToIntMap.Register(25, 's');
            CaseInsensitiveCharsToIntMap.Register(26, 't');
            // no "u" to avoid obscenity
            CaseInsensitiveCharsToIntMap.Register(27, 'v');
            CaseInsensitiveCharsToIntMap.Register(28, 'w');
            CaseInsensitiveCharsToIntMap.Register(29, 'x');
            CaseInsensitiveCharsToIntMap.Register(30, 'y');
            CaseInsensitiveCharsToIntMap.Register(31, 'z');
        }

        private IdentityBase32(ulong number)
        {
            _internalNumber = number;
        }

        private static ulong IntPositivePow(ulong x, uint power)
        {
            ulong result = 1;
            while (power != 0)
            {
                if ((power & 1) == 1)
                {
                    result *= x;
                }

                x *= x;
                power >>= 1;
            }

            return result;
        }

        private static IdentityBase32 FromString(string identityBase32AsString)
        {
            if (identityBase32AsString == null)
            {
                throw new ArgumentNullException(nameof(identityBase32AsString));
            }

            if (string.IsNullOrWhiteSpace(identityBase32AsString))
            {
                throw new ArgumentOutOfRangeException(nameof(identityBase32AsString));
            }

            foreach (var character in identityBase32AsString)
            {
                if (!CaseInsensitiveCharsToIntMap.IsMapped(character))
                {
                    throw new FormatException();
                }
            }

            ulong result = 0;
            int power = 0;

            for (int i = identityBase32AsString.Length - 1; i >= 0; i--)
            {
                ulong number = CaseInsensitiveCharsToIntMap.GetInt(identityBase32AsString[i]);
                ulong base32 = IntPositivePow(32, (uint) power);
                ulong addition = number * base32;
                result += addition;
                power++;
            }

            return result;
        }

        /// <summary>
        /// Implicit conversion from <see cref="UInt64"/>
        /// </summary>
        public static implicit operator IdentityBase32(ulong value)
        {
            return new IdentityBase32(value);
        }

        /// <summary>
        /// Implicit conversion from <see cref="Int32"/>
        /// </summary>
        public static implicit operator IdentityBase32(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} may not be negative");
            }

            return new IdentityBase32((ulong) value);
        }

        /// <summary>
        /// Implicit conversion from <see cref="Int64"/>
        /// </summary>
        public static implicit operator IdentityBase32(long value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} may not be negative");
            }

            return new IdentityBase32((ulong) value);
        }

        /// <summary>
        /// Implicit conversion from a string
        /// </summary>
        public static implicit operator IdentityBase32(string encodedValue)
        {
            return FromString(encodedValue);
        }

        /// <summary>
        /// Get the <see cref="UInt64"/> value which the <see cref="IdentityBase32"/> represents. 
        /// </summary>
        public ulong GetValue()
        {
            return _internalNumber;
        }

        /// <summary>
        /// Returns the string representation of the <see cref="IdentityBase32"/>, with
        /// alpha characters are lower-case.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The 'minimum' value of this is '0'.  The 'maximum' value is 'fzzzzzzzzzzzz'.
        /// </para>
        /// </remarks>
        public override string ToString()
        {
            var value = _internalNumber;
            bool continueCalculating;

            var charRepresentationFromSmallestToLargest = new List<char>();

            do
            {
                var remainder = value % 32;
                var quotient = value / 32;
                continueCalculating = remainder != 0 || quotient != 0;
                if (continueCalculating)
                {
                    var character = CaseInsensitiveCharsToIntMap.GetChar(remainder);
                    charRepresentationFromSmallestToLargest.Add(character);
                }

                value = quotient;
            } while (continueCalculating);

            var result = "0";

            if (charRepresentationFromSmallestToLargest.Count > 0)
            {
                var sb = new StringBuilder();
                for (int index = charRepresentationFromSmallestToLargest.Count - 1; index >= 0; index--)
                {
                    sb.Append(charRepresentationFromSmallestToLargest[index]);
                }

                result = sb.ToString().TrimStart('0');
            }

            return result;
        }
    }
}