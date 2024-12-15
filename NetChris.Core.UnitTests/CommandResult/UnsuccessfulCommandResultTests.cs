using FluentAssertions;
using NetChris.Core.CommandResult;
using Xunit;

namespace NetChris.Core.UnitTests.CommandResult;

public abstract class UnsuccessfulCommandResultTests
{
    protected abstract ICommandResult CommandResult { get; }

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
    public void HasPrimaryFailure()
    {
        CommandResult.PrimaryFailure.Should().NotBeNull();
    }
}