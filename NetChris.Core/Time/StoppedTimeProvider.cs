using System;
using NetChris.Core.Clock;

namespace NetChris.Core.Time;

/// <summary>
/// Implementation of <see cref="TimeProvider"/> which provides an unchanging <see cref="DateTimeOffset"/> value
/// for <see cref="TimeProvider.GetUtcNow"/>, much like a stopped clock.
/// </summary>
/// <seealso cref="IClock" />
public class StoppedTimeProvider : TimeProvider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StoppedClock"/> class, using
    /// <see cref="DateTimeOffset.UtcNow"/> as the time when the clock has stopped.
    /// </summary>
    public StoppedTimeProvider() : this(DateTimeOffset.UtcNow)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StoppedClock"/> class.
    /// </summary>
    /// <param name="time">The time at which the clock has stopped.</param>
    public StoppedTimeProvider(DateTimeOffset time)
    {
        _stoppedTime = time;
    }

    private readonly DateTimeOffset _stoppedTime;

    /// <inheritdoc />
    public override DateTimeOffset GetUtcNow()
    {
        return _stoppedTime.ToUniversalTime();
    }

    /// <inheritdoc />
    public override long GetTimestamp()
    {
        return _stoppedTime.Ticks;
    }
}