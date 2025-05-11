using System;
using FluentAssertions;
using NetChris.Core.Values;
using Xunit;

namespace NetChris.Core.UnitTests.IdentityBase32Tests;

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
        var action = () =>
        {
#pragma warning disable 219
            IdentityBase32 identityBase32 = "";
#pragma warning restore 219
        };

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Throw_ArgumentOutOfRangeException_on_negative_initialization()
    {
        var action = () =>
        {
#pragma warning disable 219
            IdentityBase32 identityBase32 = -1;
#pragma warning restore 219
        };

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Throw_ArgumentNullException_on_null_string_initialization()
    {
        var action = () =>
        {
#pragma warning disable 219
#pragma warning disable CS8604
            IdentityBase32 identityBase32 = null;
#pragma warning restore CS8604
#pragma warning restore 219
        };

        action.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData('-')]
    [InlineData('u')]
    [InlineData('U')]
    [InlineData(';')]
    public void Throw_FormatException_on_disallowed_character(char disallowedCharacter)
    {
        var action = () =>
        {
            // ReSharper disable once UnusedVariable
            IdentityBase32 identityBase32 = disallowedCharacter.ToString();
        };

        action.Should().Throw<FormatException>();
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
    [InlineData("6cp2", 209602)]
    [InlineData("6CP2", 209602)]
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
    [InlineData(10, "A")]
    [InlineData(11, "B")]
    [InlineData(12, "C")]
    [InlineData(13, "D")]
    [InlineData(14, "E")]
    [InlineData(15, "F")]
    [InlineData(16, "G")]
    [InlineData(17, "H")]
    [InlineData(18, "J")]
    [InlineData(19, "K")]
    [InlineData(20, "M")]
    [InlineData(21, "N")]
    [InlineData(22, "P")]
    [InlineData(23, "Q")]
    [InlineData(24, "R")]
    [InlineData(25, "S")]
    [InlineData(26, "T")]
    [InlineData(27, "V")]
    [InlineData(28, "W")]
    [InlineData(29, "X")]
    [InlineData(30, "Y")]
    [InlineData(31, "Z")]
    [InlineData(32, "10")]
    [InlineData(320, "A0")]
    [InlineData(ulong.MaxValue, "FZZZZZZZZZZZZ")]
    public void Be_expected_string_values_from_known_integers(ulong number, string expectedString)
    {
        IdentityBase32 value = number;
        value.ToString().Should().Be(expectedString);
    }
}