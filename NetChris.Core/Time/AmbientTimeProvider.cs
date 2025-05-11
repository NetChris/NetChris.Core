using System;

namespace NetChris.Core.Time;

/// <summary>
/// A time provider allowing ambient context access to a 'now' that allows for easy test mocking
/// </summary>
/// <see href="https://stackoverflow.com/a/2425739/208990"/>
public static class AmbientTimeProvider
{
    private static TimeProvider _current = TimeProvider.System;

    /// <summary>
    /// The current time provider
    /// </summary>
    public static TimeProvider Current => _current;

    /// <summary>
    /// Set the time provider
    /// </summary>
    public static void Set(TimeProvider value)
    {
        _current = value;
    }

    /// <summary>
    /// Reset the time provider to the default
    /// </summary>
    public static void ResetToDefault()
    {
        _current = TimeProvider.System;
    }
}