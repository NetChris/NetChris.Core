using System;
using FluentAssertions;
using NetChris.Core.Values;
using Xunit;

namespace NetChris.Core.UnitTests.IdentityBase32Tests
{
    public class IdentityBase32_Should
    {
        [Fact]
        public void Be_implicitly_representable_from_an_int()
        {
            const int x = 1;
#pragma warning disable 219
            IdentityBase32 identityBase32 = x;
#pragma warning restore 219
        }

        [Fact]
        public void Be_implicitly_representable_from_a_string()
        {
#pragma warning disable 219
            IdentityBase32 identityBase32 = "1s";
#pragma warning restore 219
        }

        [Fact]
        public void Throw_ArgumentOutOfRangeException_on_empty_string_initialization()
        {
            Action action = () =>
            {
#pragma warning disable 219
                IdentityBase32 identityBase32 = "";
#pragma warning restore 219
            };

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Throw_ArgumentOutOfRangeException_on_negative_initialization()
        {
            Action action = () =>
            {
#pragma warning disable 219
                IdentityBase32 identityBase32 = -1;
#pragma warning restore 219
            };

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Throw_ArgumentNullException_on_null_string_initialization()
        {
            Action action = () =>
            {
#pragma warning disable 219
                IdentityBase32 identityBase32 = null;
#pragma warning restore 219
            };

            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData('-')]
        [InlineData('u')]
        [InlineData('U')]
        [InlineData(';')]
        public void Throw_FormatException_on_disallowed_character(char disallowedCharacter)
        {
            Action action = () =>
            {
                // ReSharper disable once UnusedVariable
                IdentityBase32 identityBase32 = disallowedCharacter.ToString();
            };

            action.ShouldThrow<FormatException>();
        }

        [Theory]
        [InlineData('0')]
        [InlineData('1')]
        [InlineData('2')]
        [InlineData('3')]
        [InlineData('4')]
        [InlineData('5')]
        [InlineData('7')]
        [InlineData('8')]
        [InlineData('9')]
        [InlineData('A')]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('b')]
        [InlineData('C')]
        [InlineData('c')]
        [InlineData('D')]
        [InlineData('d')]
        [InlineData('E')]
        [InlineData('e')]
        [InlineData('F')]
        [InlineData('f')]
        [InlineData('G')]
        [InlineData('g')]
        [InlineData('H')]
        [InlineData('h')]
        [InlineData('I')]
        [InlineData('i')]
        [InlineData('J')]
        [InlineData('j')]
        [InlineData('K')]
        [InlineData('k')]
        [InlineData('L')]
        [InlineData('l')]
        [InlineData('M')]
        [InlineData('n')]
        [InlineData('O')]
        [InlineData('o')]
        [InlineData('P')]
        [InlineData('p')]
        [InlineData('Q')]
        [InlineData('q')]
        [InlineData('R')]
        [InlineData('r')]
        [InlineData('S')]
        [InlineData('s')]
        [InlineData('T')]
        [InlineData('t')]
        [InlineData('V')]
        [InlineData('v')]
        [InlineData('W')]
        [InlineData('w')]
        [InlineData('X')]
        [InlineData('x')]
        [InlineData('Y')]
        [InlineData('y')]
        [InlineData('Z')]
        [InlineData('z')]
        public void Accept_all_characters(char allowedCharacter)
        {
            // ReSharper disable once UnusedVariable
            IdentityBase32 identityBase32 = allowedCharacter.ToString();
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("o", 0)]
        [InlineData("1", 1)]
        [InlineData("i", 1)]
        [InlineData("I", 1)]
        [InlineData("l", 1)]
        [InlineData("L", 1)]
        public void Be_expected_integer_values_from_known_strings(string presentedString, ulong expectedNumber)
        {
            IdentityBase32 value = presentedString;
            var number = value.GetValue();
            number.Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "3")]
        [InlineData(4, "4")]
        [InlineData(5, "5")]
        [InlineData(6, "6")]
        [InlineData(7, "7")]
        [InlineData(8, "8")]
        [InlineData(9, "9")]
        [InlineData(10, "a")]
        [InlineData(11, "b")]
        [InlineData(12, "c")]
        [InlineData(13, "d")]
        [InlineData(14, "e")]
        [InlineData(15, "f")]
        [InlineData(16, "g")]
        [InlineData(17, "h")]
        [InlineData(18, "j")]
        [InlineData(19, "k")]
        [InlineData(20, "m")]
        [InlineData(21, "n")]
        [InlineData(22, "p")]
        [InlineData(23, "q")]
        [InlineData(24, "r")]
        [InlineData(25, "s")]
        [InlineData(26, "t")]
        [InlineData(27, "v")]
        [InlineData(28, "w")]
        [InlineData(29, "x")]
        [InlineData(30, "y")]
        [InlineData(31, "z")]
        [InlineData(32, "10")]
        [InlineData(320, "a0")]
        public void Be_expected_string_values_from_known_integers(ulong number, string expectedString)
        {
            IdentityBase32 value = number;
            value.ToString().Should().Be(expectedString);
        }
    }
}
