using NetChris.Core.CommandResult;

namespace NetChris.Core.UnitTests.CommandResult;

public class UntypedSuccessfulCommandResultTests : SuccessfulCommandResultTests
{
    protected override ICommandResult CommandResult => new SuccessfulCommandResult();
}