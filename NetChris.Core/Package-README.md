# NetChris.Core

Base metadata and operational classes for .NET Core development.

## CommandResult

Supports, in our own way, the Result pattern. Implementations of `ICommandResult` can be used to return the result of a command, successful or not.

These types can be used for simple success and failure results:

- `SuccessfulCommandResult` and its generic counterpart `SuccessfulCommandResult<T>`
- `UnsuccessfulCommandResult` and its generic counterpart `UnsuccessfulCommandResult<T>`

You can find other examples of this pattern in something like [`Ardalis.Result`](https://result.ardalis.com/).

### CommandResult References

- [Working with the result pattern](https://andrewlock.net/series/working-with-the-result-pattern/)
