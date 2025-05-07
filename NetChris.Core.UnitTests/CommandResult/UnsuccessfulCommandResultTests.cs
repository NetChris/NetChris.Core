using FluentAssertions;
using NetChris.Core.CommandResult;
using Xunit;

namespace NetChris.Core.UnitTests.CommandResult;

[System.Obsolete("ICommandResult is obsolete")]
public abstract class UnsuccessfulCommandResultTests
{
    private readonly CommandResultFailureMode _commandResultFailureMode;
    protected abstract ICommandResult CommandResult { get; }

    protected UnsuccessfulCommandResultTests(CommandResultFailureMode commandResultFailureMode)
    {
        _commandResultFailureMode = commandResultFailureMode;
    }

    [Fact]
    public void IsNotSuccessful()
    {
        CommandResult.Successful.Should().BeFalse();
    }

    [Fact]
    public void HasNonEmptyFailureDetail()
    {
        CommandResult.FailureDetail.Should().NotBeEmpty();
    }
    
    [Fact]
    public void FailureModeIsCorrect()
    {
        CommandResult.FailureMode.Should().Be(_commandResultFailureMode);
    }
}