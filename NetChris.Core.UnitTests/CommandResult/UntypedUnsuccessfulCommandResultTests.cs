using NetChris.Core.CommandResult;

namespace NetChris.Core.UnitTests.CommandResult;

public class UntypedUnsuccessfulCommandResultTests : UnsuccessfulCommandResultTests
{
    protected override ICommandResult CommandResult => UnsuccessfulCommandResult.FromSingleFailure(
        "UntypedResourceNotFound", "Resource not found: UNTYPED");

}