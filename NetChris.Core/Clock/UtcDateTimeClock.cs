using System;

namespace NetChris.Core.Clock
{
    /// <summary>
    /// Implementation of <see cref="IClock"/> which provides the current
    /// value from <see cref="DateTimeOffset.UtcNow"/>.
    /// </summary>
    /// <seealso cref="IClock" />
    public class UtcDateTimeClock : IClock
    {
        /// <summary>
        /// Gets the time according to the clock.
        /// </summary>
        /// <returns>The time according to the clock.</returns>
        public DateTimeOffset GetTime()
        {
            var result = DateTimeOffset.UtcNow;
            return result;
        }
    }
}