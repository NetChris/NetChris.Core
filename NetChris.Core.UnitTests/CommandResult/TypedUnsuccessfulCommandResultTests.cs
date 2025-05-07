using System;
using FluentAssertions;
using NetChris.Core.CommandResult;
using Xunit;

namespace NetChris.Core.UnitTests.CommandResult;

[Obsolete("ICommandResult is obsolete")]
public class TypedUnsuccessfulCommandResultTests : UnsuccessfulCommandResultTests
{
    private readonly ICommandResult<TypedUnsuccessfulCommandResultTests> _typedResult =
        UnsuccessfulCommandResult.ResourceNotFound<TypedUnsuccessfulCommandResultTests>(
            "TypedResourceNotFound", "Resource not found: TYPED");

    public TypedUnsuccessfulCommandResultTests() : base(CommandResultFailureMode.ResourceNotFound)
    {
    }

    [Fact]
    public void GettingResultThrows()
    {
        Action act = () => _ = _typedResult.Result;
        act.Should().Throw<InvalidOperationException>();
    }

    protected override ICommandResult CommandResult => _typedResult;
}