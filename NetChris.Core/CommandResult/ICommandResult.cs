using System;
using System.Collections.Generic;
using NetChris.Core.Values;

namespace NetChris.Core.CommandResult;

/// <summary>
/// Result of executing a command, with a typed result object
/// </summary>
public interface ICommandResult<TResult> : ICommandResult
{
    /// <summary>
    /// The result of the command
    /// </summary>
    TResult? Result { get; }
}

/// <summary>
/// Result of executing a command
/// </summary>
public interface ICommandResult
{
    /// <summary>
    /// Gets a value indicating whether the command was successful.
    /// </summary>
    bool Successful { get; }

    /// <summary>
    /// Gets the command result failure detail.
    /// </summary>
    IEnumerable<SimpleResult> FailureDetail { get; }

    /// <summary>
    /// Gets the <see cref="Exception"/> causing the command failure, if any.
    /// </summary>
    Exception? Exception { get; }

    /// <summary>
    /// The primary failure, if any
    /// </summary>
    SimpleResult? PrimaryFailure { get; }
}