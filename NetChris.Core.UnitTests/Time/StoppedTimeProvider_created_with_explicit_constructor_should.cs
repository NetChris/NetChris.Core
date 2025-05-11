using System;
using FluentAssertions;
using NetChris.Core.Time;
using Xunit;

namespace NetChris.Core.UnitTests.Time;

public class StoppedTimeProvider_created_with_explicit_constructor_should
{
    private readonly DateTimeOffset _start;
    private readonly DateTimeOffset _result;

    public StoppedTimeProvider_created_with_explicit_constructor_should()
    {
        // Arrange
        _start = new DateTimeOffset(2018, 1, 2, 3, 4, 5, 6, TimeSpan.FromHours(-4));
        var clock = new StoppedTimeProvider(_start);

        // Act
        _result = clock.GetUtcNow();
    }

    [Fact]
    public void Return_the_exact_time_dictated()
    {
        // Assert
        _result.Should().Be(_start);
    }
}