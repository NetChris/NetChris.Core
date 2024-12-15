using NetChris.Core.Values;
using System;
using System.Collections.Generic;

namespace NetChris.Core.CommandResult;

/// <summary>
/// Simple implementation of an unsuccessful command result.
/// </summary>
public class UnsuccessfulCommandResult : ICommandResult
{
    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> for a resource-not-found failure.
    /// </summary>
    public static UnsuccessfulCommandResult ResourceNotFound(string resultCode = "ResourceNotFound",
        string message = "Resource not found")
    {
        return new UnsuccessfulCommandResult(CommandResultFailureMode.ResourceNotFound,
            new[] { new SimpleResult(resultCode, message) });
    }

    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> with a single failure.
    /// </summary>
    public static UnsuccessfulCommandResult FromSingleFailure(CommandResultFailureMode failureMode,
        SimpleResult primaryFailure)
    {
        return new UnsuccessfulCommandResult(failureMode, new[] { primaryFailure });
    }

    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> for a resource-not-found failure.
    /// </summary>
    public static UnsuccessfulCommandResult<TSingleFailureResult> ResourceNotFound<TSingleFailureResult>(
        string resultCode = "ResourceNotFound", string message = "Resource not found")
    {
        return new UnsuccessfulCommandResult<TSingleFailureResult>(CommandResultFailureMode.ResourceNotFound,
            new[] { new SimpleResult(resultCode, message) });
    }

    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> with a single failure.
    /// </summary>
    public static UnsuccessfulCommandResult<TSingleFailureResult> FromSingleFailure<TSingleFailureResult>(
        CommandResultFailureMode failureMode, SimpleResult primaryFailure)
    {
        return new UnsuccessfulCommandResult<TSingleFailureResult>(failureMode, new[] { primaryFailure });
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnsuccessfulCommandResult" /> class.
    /// </summary>
    /// <param name="failureMode">The failure mode</param>
    /// <param name="failureDetail">The command result failure reasons</param>
    public UnsuccessfulCommandResult(CommandResultFailureMode failureMode, IEnumerable<SimpleResult> failureDetail)
    {
        FailureMode = failureMode;
        FailureDetail = failureDetail;
    }

    /// <inheritdoc />
    public bool Successful => false;

    /// <inheritdoc />
    public IEnumerable<SimpleResult> FailureDetail { get; }

    /// <inheritdoc />
    public virtual Exception? Exception => null;

    /// <inheritdoc />
    public CommandResultFailureMode FailureMode { get; }
}

/// <summary>
/// Simple implementation of an unsuccessful command result.
/// </summary>
public class UnsuccessfulCommandResult<TResult> : UnsuccessfulCommandResult, ICommandResult<TResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnsuccessfulCommandResult{TResult}" /> class.
    /// </summary>
    /// <param name="failureMode">The failure mode</param>
    /// <param name="failureDetail">The command result failure reasons</param>
    public UnsuccessfulCommandResult(CommandResultFailureMode failureMode, IEnumerable<SimpleResult> failureDetail) :
        base(
            failureMode, failureDetail)
    {
    }

    /// <inheritdoc />
    public TResult? Result => default;
}