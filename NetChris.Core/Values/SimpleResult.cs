using System;

namespace NetChris.Core.Values;

/// <summary>
/// Lightweight object with a code and message.
/// A glorified key/value pair.
/// </summary>
/// <remarks>
/// <para>
/// Ideal use is in systems and APIs that, for example, return messages
/// or throw errors with unique-ish codes and an explanatory message.
/// </para>
/// </remarks>
public class SimpleResult
{
    /// <summary>
    /// The result type
    /// </summary>
    /// <remarks>
    /// This is implemented as a <see cref="Uri"/> to communicate that the result is of a unique type
    /// </remarks>
    public Uri ResultType
    {
        get;
    }

    /// <summary>
    /// The message
    /// </summary>
    public string Message
    {
        get;
    }

    /// <summary>
    /// Whether the message can be publicly displayed
    /// (e.g. in a RFC 9457 Problem Details from a web API).
    /// </summary>
    /// <remarks>
    /// It is implementation dependent how this is used.
    /// The default is <c>true</c>, meaning the message can be displayed publicly.
    /// </remarks>
    public bool IsPublic
    {
        get;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleResult" /> class.
    /// </summary>
    /// <param name="resultType">The result type</param>
    /// <param name="message">The message</param>
    /// <param name="isPublic">Whether the message can be publicly displayed</param>
    public SimpleResult(Uri resultType, string message, bool isPublic = true)
    {
        ResultType = resultType;
        Message = message;
        IsPublic = isPublic;
    }
}