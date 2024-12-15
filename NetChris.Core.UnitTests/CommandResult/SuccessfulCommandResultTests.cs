using FluentAssertions;
using NetChris.Core.CommandResult;
using Xunit;

namespace NetChris.Core.UnitTests.CommandResult;

public abstract class SuccessfulCommandResultTests
{
    protected abstract ICommandResult CommandResult { get; }

    [Fact]
    public void IsSuccessful()
    {
        CommandResult.Successful.Should().BeTrue();
    }

    [Fact]
    public void HasEmptyFailureDetail()
    {
        CommandResult.FailureDetail.Should().BeEmpty();
    }

    [Fact]
    public void FailureModeIsNoFailure()
    {
        CommandResult.FailureMode.Should().Be(CommandResultFailureMode.NoFailure);
    }
}