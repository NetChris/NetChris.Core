using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests;

public class DefaultIfNullOrWhiteSpaceTests
{
    [Fact]
    public void NullShouldReturnDefault()
    {
        string? nullString = null;
        nullString.DefaultIfNullOrWhiteSpace("default").Should().Be("default");
    }

    [Fact]
    public void EmptyStringShouldReturnDefault()
    {
        "".DefaultIfNullOrWhiteSpace("default").Should().Be("default");
    }

    [Fact]
    public void WhiteSpaceShouldReturnDefault()
    {
        "  \t\n".DefaultIfNullOrWhiteSpace("default").Should().Be("default");
    }

    [Fact]
    public void NonNullNonWhiteSpaceShouldReturnValue()
    {
        " Some string  \t".DefaultIfNullOrWhiteSpace("default").Should().Be(" Some string  \t");
    }
}