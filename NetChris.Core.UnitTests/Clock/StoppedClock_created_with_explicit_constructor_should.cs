using System;
using FluentAssertions;
using NetChris.Core.Clock;
using Xunit;

namespace NetChris.Core.UnitTests.Clock
{
    public class StoppedClock_created_with_explicit_constructor_should
    {
        private readonly DateTimeOffset _start;
        private DateTimeOffset _result;

        public StoppedClock_created_with_explicit_constructor_should()
        {
            // Arrange
            _start = new DateTimeOffset(2018, 1, 2, 3, 4, 5, 6, TimeSpan.FromHours(-4));
            var clock = new StoppedClock(_start);

            // Act
            _result = clock.GetTime();
        }

        [Fact]
        public void Return_the_exact_time_dictated()
        {
            // Assert
            _result.Should().Be(_start);
        }
    }
}