using FluentAssertions;
using NetChris.Core.CommandResult;
using Xunit;

namespace NetChris.Core.UnitTests.CommandResult;

public class TypedUnsuccessfulCommandResultTests : UnsuccessfulCommandResultTests
{
    private readonly ICommandResult<TypedUnsuccessfulCommandResultTests> _typedResult =
        UnsuccessfulCommandResult.FromSingleFailure<TypedUnsuccessfulCommandResultTests>(
            "TypedResourceNotFound", "Resource not found: TYPED");

    [Fact]
    public void ThereIsNoResult()
    {
        _typedResult.Result.Should().BeNull();
    }

    protected override ICommandResult CommandResult => _typedResult;
}