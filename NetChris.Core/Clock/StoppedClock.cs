using System;

namespace NetChris.Core.Clock
{
    /// <summary>
    /// Implementation of <see cref="IClock"/> which provides an unchanging <see cref="DateTimeOffset"/> value
    /// for <see cref="GetTime"/>, much like a stopped clock.
    /// </summary>
    /// <seealso cref="IClock" />
    public class StoppedClock : IClock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoppedClock"/> class, using
        /// <see cref="DateTimeOffset.Now"/> as the time when the clock has stopped.
        /// </summary>
        public StoppedClock()
            : this(DateTimeOffset.Now)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoppedClock"/> class.
        /// </summary>
        /// <param name="time">The time at which the clock has stopped.</param>
        public StoppedClock(DateTimeOffset time)
        {
            _stoppedTime = time;
        }

        private readonly DateTimeOffset _stoppedTime;

        /// <summary>
        /// Gets the time according to the clock.
        /// </summary>
        /// <returns>The time according to the clock.</returns>
        public DateTimeOffset GetTime()
        {
            return _stoppedTime;
        }
    }
}