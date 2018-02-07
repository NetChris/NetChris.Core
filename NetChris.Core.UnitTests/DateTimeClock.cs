using System;
using FluentAssertions;
using NetChris.Core.Clock;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class DateTimeClock_should
    {
        [Fact]
        public void Return_the_current_time()
        {
            // Arrange
            IClock clock = new DateTimeClock();

            // Act
            DateTime start = DateTime.UtcNow;
            var result = clock.GetTime();
            DateTime end = DateTime.UtcNow;

            // Assert
            Assert.True(result >= start);
            Assert.True(result <= end);
        }
    }

    public class UtcDateTimeClock_should
    {
        [Fact]
        public void Return_the_current_time()
        {
            // Arrange
            IClock clock = new UtcDateTimeClock();

            // Act
            DateTime start = DateTime.UtcNow;
            var result = clock.GetTime();
            DateTime end = DateTime.UtcNow;

            // Assert
            Assert.True(result >= start);
            Assert.True(result <= end);
        }

        [Fact]
        public void Return_the_time_with_no_Offset()
        {
            // Arrange
            IClock clock = new UtcDateTimeClock();

            // Act
            var result = clock.GetTime();

            // Assert
            result.Offset.Should().Be(TimeSpan.Zero);
        }
    }
}
