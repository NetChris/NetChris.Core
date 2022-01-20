using System;

namespace NetChris.Core;

/// <summary>
/// The application's <see href="https://gitlab.com/cssl/reference/-/wikis/canonical-application-name">Canonical Application Name</see>
/// </summary>
public class CanonicalApplicationName
{
    /// <summary>
    /// Create a new <see cref="CanonicalApplicationName"/>
    /// </summary>
    /// <param name="applicationAggregate">The application aggregate.</param>
    /// <param name="applicationComponent">The application component.</param>
    public CanonicalApplicationName(string applicationAggregate, string applicationComponent)
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
        ApplicationComponent = applicationComponent;
    }

    /// <summary>
    /// Gets the application aggregate.
    /// </summary>
    public string ApplicationAggregate { get; }

    /// <summary>
    /// Gets the application component.
    /// </summary>
    public string ApplicationComponent { get; }
}