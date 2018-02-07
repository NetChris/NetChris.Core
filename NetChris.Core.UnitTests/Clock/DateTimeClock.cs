using System;
using NetChris.Core.Clock;
using Xunit;

namespace NetChris.Core.UnitTests.Clock.DateTimeClock
{
    public class GetTime
    {
        [Fact]
        public void Returns_the_current_time()
        {
            // Arrange
            IClock dateTimeClock = new Core.Clock.DateTimeClock();

            // Act
            DateTime start = DateTime.UtcNow;
            var result = dateTimeClock.GetTime();
            DateTime end = DateTime.UtcNow;

            // Assert
            Assert.True(result >= start);
            Assert.True(result <= end);
        }
    }
}
