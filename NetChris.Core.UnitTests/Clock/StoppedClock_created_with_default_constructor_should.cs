using System;
using FluentAssertions;
using NetChris.Core.Clock;
using Xunit;

namespace NetChris.Core.UnitTests.Clock
{
    public class StoppedClock_created_with_default_constructor_should
    {
        private readonly DateTimeOffset _start;
        private readonly DateTimeOffset _end;
        private DateTimeOffset _result;

        public StoppedClock_created_with_default_constructor_should()
        {
            // Arrange
            _start = DateTimeOffset.Now;
            IClock clock = new StoppedClock();
            _end = DateTimeOffset.Now;

            // Act
            _result = clock.GetTime();
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
