using System;
using FluentAssertions;
using NetChris.Core.Time;
using Xunit;

namespace NetChris.Core.UnitTests.Time;

public class AmbientTimeProvider_GetUtcNow
{
    [Fact]
    public void Should_be_a_reasonable_time()
    {
        // Arrange
        // Act
        var timespan = DateTimeOffset.UtcNow - AmbientTimeProvider.Current.GetUtcNow();

        // Assert
        timespan.Should().BeLessThan(TimeSpan.FromSeconds(1));
    }
}