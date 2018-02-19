﻿using System;
using FluentAssertions;
using NetChris.Core.Clock;
using Xunit;

namespace NetChris.Core.UnitTests.Clock
{
    public class DateTimeClock_should
    {
        private readonly TimeSpan _utcOffset;
        private readonly DateTime _start;
        private readonly DateTimeOffset _result;
        private readonly DateTime _end;

        public DateTimeClock_should()
        {
            // Arrange
            var clock = new DateTimeClock();

            _utcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now);

            // Act
            _start = DateTime.UtcNow;
            _result = clock.GetTime();
            _end = DateTime.UtcNow;
        }

        [Fact]
        public void Return_the_current_time()
        {
            // Assert
            _result.Should().BeOnOrAfter(_start);
            _result.Should().BeOnOrBefore(_end);
        }

        [Fact]
        public void Return_the_correct_Offset()
        {
            // Assert
            _result.Offset.Should().Be(_utcOffset);
        }
    }
}