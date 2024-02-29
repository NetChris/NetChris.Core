using System;

namespace NetChris.Core;

/// <summary>
/// The application's Canonical Application Name
/// </summary>
/// <see href="https://gitlab.com/cssl/reference/-/wikis/canonical-application-name">Canonical Application Name</see>
public class CanonicalApplicationName
{
    /// <summary>
    /// Create a new <see cref="CanonicalApplicationName"/>
    /// </summary>
    /// <param name="applicationAggregate">The application aggregate</param>
    /// <param name="applicationAggregateShort">The short-form application aggregate</param>
    /// <param name="applicationComponent">The application component</param>
    /// <param name="applicationComponentShort">The short-form application component</param>
    public CanonicalApplicationName(string applicationAggregate, string applicationAggregateShort,
        string applicationComponent, string applicationComponentShort)
    {
        if (string.IsNullOrWhiteSpace(applicationAggregate))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationAggregate));
        }

        if (string.IsNullOrWhiteSpace(applicationComponent))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationComponent));
        }

        ApplicationAggregate = applicationAggregate;
        ApplicationAggregateShort = applicationAggregateShort;
        ApplicationComponent = applicationComponent;
        ApplicationComponentShort = applicationComponentShort;
    }

    /// <summary>
    /// Gets the application aggregate
    /// </summary>
    public string ApplicationAggregate { get; }

    /// <summary>
    /// Gets the short-form application aggregate
    /// </summary>
    public string ApplicationAggregateShort { get; }

    /// <summary>
    /// Gets the application component
    /// </summary>
    public string ApplicationComponent { get; }

    /// <summary>
    /// Gets the short-form application component
    /// </summary>
    public string ApplicationComponentShort { get; }
}