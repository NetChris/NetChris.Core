using NetChris.Core.CommandResult;

namespace NetChris.Core.UnitTests.CommandResult;

[System.Obsolete("ICommandResult is obsolete")]
public class UntypedSuccessfulCommandResultTests : SuccessfulCommandResultTests
{
    protected override ICommandResult CommandResult => new SuccessfulCommandResult();
}