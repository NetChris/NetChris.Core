using System;

namespace NetChris.Core.Clock
{
    /// <summary>
    /// Provides the interface for a clock.
    /// </summary>
    /// <remarks>
    /// This is primarily used to discourage the common use
    /// of <see cref="DateTimeOffset.Now"/> or <see cref="DateTimeOffset.UtcNow"/>.
    /// While in typical use these nondeterministic results are indeed
    /// desired they are hard to test.
    /// </remarks>
    [Obsolete("Use System.TimeProvider", true)]
    public interface IClock
    {
        /// <summary>
        /// Gets the time according to the clock.
        /// </summary>
        /// <returns>The time according to the clock.</returns>
        DateTimeOffset GetTime();
    }
}
