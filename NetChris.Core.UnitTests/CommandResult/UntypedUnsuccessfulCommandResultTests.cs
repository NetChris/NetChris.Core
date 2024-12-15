using NetChris.Core.CommandResult;

namespace NetChris.Core.UnitTests.CommandResult;

public class UntypedUnsuccessfulCommandResultTests : UnsuccessfulCommandResultTests
{
    public UntypedUnsuccessfulCommandResultTests() : base(CommandResultFailureMode.ResourceNotFound)
    {
    }

    protected override ICommandResult CommandResult => UnsuccessfulCommandResult.ResourceNotFound(
        "UntypedResourceNotFound", "Resource not found: UNTYPED");

}