using NetChris.Core.Values;
using System;
using System.Collections.Generic;

namespace NetChris.Core.CommandResult;

/// <summary>
/// Simple implementation of an unsuccessful command result.
/// </summary>
public class UnsuccessfulCommandResult : ICommandResult
{
    // string resultCode, string message)

    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> with a single failure.
    /// </summary>
    public static UnsuccessfulCommandResult FromSingleFailure(SimpleResult primaryFailure)
    {
        return new UnsuccessfulCommandResult(new[] { primaryFailure }, primaryFailure);
    }

    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> with a single failure.
    /// </summary>
    public static UnsuccessfulCommandResult FromSingleFailure(string resultCode, string message)
    {
        return FromSingleFailure(new SimpleResult(resultCode, message));
    }
    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> with a single failure.
    /// </summary>
    public static UnsuccessfulCommandResult<TSingleFailureResult> FromSingleFailure<TSingleFailureResult>(SimpleResult primaryFailure)
    {
        return new UnsuccessfulCommandResult<TSingleFailureResult>(new[] { primaryFailure }, primaryFailure);
    }

    /// <summary>
    /// Get a new instance of <see cref="UnsuccessfulCommandResult"/> with a single failure.
    /// </summary>
    public static UnsuccessfulCommandResult<TSingleFailureResult> FromSingleFailure<TSingleFailureResult>(string resultCode, string message)
    {
        return FromSingleFailure<TSingleFailureResult>(new SimpleResult(resultCode, message));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnsuccessfulCommandResult" /> class.
    /// </summary>
    /// <param name="failureDetail">The command result failure reasons.</param>
    /// <param name="primaryFailure">The primary command result failure reason.</param>
    public UnsuccessfulCommandResult(IEnumerable<SimpleResult> failureDetail, SimpleResult primaryFailure)
    {
        FailureDetail = failureDetail;
        PrimaryFailure = primaryFailure;
    }

    /// <inheritdoc />
    public bool Successful => false;

    /// <inheritdoc />
    public IEnumerable<SimpleResult> FailureDetail { get; }

    /// <inheritdoc />
    public virtual Exception? Exception => null;

    /// <inheritdoc />
    public SimpleResult PrimaryFailure { get; }
}

/// <summary>
/// Simple implementation of an unsuccessful command result.
/// </summary>
public class UnsuccessfulCommandResult<TResult> : UnsuccessfulCommandResult, ICommandResult<TResult>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="UnsuccessfulCommandResult" /> class.
    /// </summary>
    /// <param name="failureDetail">The command result failure reasons.</param>
    /// <param name="primaryFailure">The primary command result failure reason.</param>
    public UnsuccessfulCommandResult(IEnumerable<SimpleResult> failureDetail, SimpleResult primaryFailure) : base(
        failureDetail, primaryFailure)
    {
    }

    /// <inheritdoc />
    public TResult? Result => default;
}