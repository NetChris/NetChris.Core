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
    /// Gets the <see cref="Exception"/> causing or related to the command failure, if any.
    /// </summary>
    /// <remarks>
    /// </remarks>
    Exception? Exception { get; }
    
    /// <summary>
    /// The mode of failure for the command
    /// </summary>
    CommandResultFailureMode FailureMode { get; }
}

/// <summary>
/// Possible modes of failure for a <see cref="ICommandResult"/>
/// </summary>
public enum CommandResultFailureMode
{
    /// <summary>
    /// The command was successful
    /// </summary>
    NoFailure = 0,

    /// <summary>
    /// The command failed because the state of the command was invalid
    /// </summary>
    InvalidCommand = 400,

    /// <summary>
    /// The command failed because of a missing resource
    /// </summary>
    ResourceNotFound = 404,
    
    /// <summary>
    /// The command failed because of an internal error
    /// </summary>
    InternalError = 500,
}