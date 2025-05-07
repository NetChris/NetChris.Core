using FluentAssertions;
using NetChris.Core.CommandResult;
using Xunit;

namespace NetChris.Core.UnitTests.CommandResult;

[System.Obsolete("ICommandResult is obsolete")]
public class TypedSuccessfulCommandResultTests : SuccessfulCommandResultTests
{
    private readonly ICommandResult<TypedSuccessfulCommandResultTests> _typedResult;

    public TypedSuccessfulCommandResultTests()
    {
        _typedResult =
            new SuccessfulCommandResult<TypedSuccessfulCommandResultTests>(this);
    }

    protected override ICommandResult CommandResult => _typedResult;

    [Fact]
    public void ThereIsAResult()
    {
        _typedResult.Result.Should().Be(this);
    }
}