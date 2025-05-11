using System;

namespace NetChris.Core.Clock
{
    /// <summary>
    /// Implementation of <see cref="IClock"/> which provides the current
    /// value from <see cref="DateTimeOffset.UtcNow"/>.
    /// </summary>
    /// <seealso cref="IClock" />
    [Obsolete("Stop using this altogether. Use System.TimeProvider and adjust for UTC.", true)]
    public class UtcClock : IClock
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