using System;
using FluentAssertions;
using NetChris.Core.Time;
using Xunit;

namespace NetChris.Core.UnitTests.Time
{
    public class StoppedTimeProvider_created_with_default_constructor_should
    {
        private readonly DateTimeOffset _start;
        private readonly DateTimeOffset _end;
        private DateTimeOffset _result;

        public StoppedTimeProvider_created_with_default_constructor_should()
        {
            // Arrange
            _start = DateTimeOffset.Now;
            TimeProvider clock = new StoppedTimeProvider();
            _end = DateTimeOffset.Now;

            // Act
            _result = clock.GetUtcNow();
        }

        [Fact]
        public void Return_the_current_time()
        {
            // Assert
            _result.Should().BeOnOrAfter(_start);
            _result.Should().BeOnOrBefore(_end);
        }
    }
}