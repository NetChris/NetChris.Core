using NetChris.Core.Values;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetChris.Core.CommandResult;

/// <summary>
/// Simple implementation of a successful command result.
/// </summary>
[Obsolete("Use NetChris.Cqrs package for this functionality")]
public class SuccessfulCommandResult : ICommandResult
{
    /// <inheritdoc />
    public bool Successful => true;

    /// <inheritdoc />
    public IEnumerable<SimpleResult> FailureDetail => new ReadOnlyCollection<SimpleResult>(new List<SimpleResult>());

    /// <inheritdoc />
    public Exception? Exception => null;

    /// <inheritdoc />
    public CommandResultFailureMode FailureMode => CommandResultFailureMode.NoFailure;
}

/// <summary>
/// Simple implementation of a successful command result, with the typed result object.
/// </summary>
[Obsolete("Use NetChris.Cqrs package for this functionality")]
public class SuccessfulCommandResult<TResult> : SuccessfulCommandResult, ICommandResult<TResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SuccessfulCommandResult{T}" /> class.
    /// </summary>
    public SuccessfulCommandResult(TResult result)
    {
        Result = result;
    }

    /// <inheritdoc />
    public TResult Result { get; }
}