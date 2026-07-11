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

## CanonicalApplicationName

Represents the application's [Canonical Application Name](https://github.com/NetChris/reference/wiki/Canonical-Application-Name): the application aggregate and application component, each with a long and short form. Values must adhere to the [name part normalization](https://github.com/NetChris/reference/wiki/Name-part-normalization) rules:

- Long form (`applicationAggregate`, `applicationComponent`): lower-case letters, numbers, and underscores only, beginning with a lower-case letter.
- Short form (`applicationAggregateShort`, `applicationComponentShort`): 1 to 4 lower-case letters and/or numbers only.

`CanonicalApplicationName.FromConfiguration(IConfiguration)` builds an instance from the following well-known configuration keys, failing fast with a clear error if any is missing or empty:

- `netchris:application:aggregate`
- `netchris:application:aggregateShort`
- `netchris:application:component`
- `netchris:application:componentShort`

## ApplicationMetadata

`IApplicationMetadata`/`ApplicationMetadata` capture basic metadata about the running application and its execution instance: `ApplicationName`, `CanonicalApplicationName`, `ApplicationVersion`, `InformationalVersion`, `EnvironmentName`, `MachineName`, `OSPlatform`, `OSVersion`, `UserName`, `ClrVersion`, and `StartTimestamp`.

- `ApplicationMetadata.GetApplicationMetadata(assembly, applicationAggregate, applicationAggregateShort, applicationComponent, applicationComponentShort, environmentName)` builds an instance, discerning `ApplicationName` from the given assembly's name.
- `ApplicationMetadata.GetApplicationMetadata(assembly, configuration, environmentName)` does the same, but builds its `CanonicalApplicationName` via `CanonicalApplicationName.FromConfiguration(configuration)` using the well-known configuration keys above.
