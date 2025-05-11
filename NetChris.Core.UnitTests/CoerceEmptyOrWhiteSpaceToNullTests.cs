using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests;

public class CoerceEmptyOrWhiteSpaceToNullTests
{
    [Fact]
    public void EmptyStringResultsInNull()
    {
        string.Empty.CoerceEmptyOrWhiteSpaceToNull().Should().BeNull();
    }
    
    [Fact]
    public void OnlySpacesResultInNull()
    {
        "  ".CoerceEmptyOrWhiteSpaceToNull().Should().BeNull();
    }
    
    [Fact]
    public void OnlyTabsResultInNull()
    {
        "\t\t".CoerceEmptyOrWhiteSpaceToNull().Should().BeNull();
    }
    
    [Fact]
    public void OnlyNewlinesResultInNull()
    {
        "\n\n".CoerceEmptyOrWhiteSpaceToNull().Should().BeNull();
    }
    
    [Fact]
    public void NonWhitespaceValueComesThroughUnmolested()
    {
        "Some non-whitespace value".CoerceEmptyOrWhiteSpaceToNull().Should().Be("Some non-whitespace value");
    }
    
    [Fact]
    public void UntrimmedNonWhitespaceValueComesThroughUnmolested()
    {
        " Untrimmed non-whitespace value   ".CoerceEmptyOrWhiteSpaceToNull(false)
            .Should().Be(" Untrimmed non-whitespace value   ");
    }
    
    [Fact]
    public void TrimmedNonWhitespaceValueComesThroughTrimmed()
    {
        " Untrimmed non-whitespace value   ".CoerceEmptyOrWhiteSpaceToNull(true)
            .Should().Be("Untrimmed non-whitespace value");
    }
}