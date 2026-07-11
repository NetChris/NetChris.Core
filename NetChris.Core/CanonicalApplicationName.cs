using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace NetChris.Core;

/// <summary>
/// The application's Canonical Application Name
/// </summary>
/// <see href="https://github.com/NetChris/reference/wiki/Canonical-Application-Name">Canonical Application Name</see>
public class CanonicalApplicationName
{
    private static readonly Regex LongFormPattern = new("^[a-z][a-z0-9_]*$", RegexOptions.Compiled);
    private static readonly Regex ShortFormPattern = new("^[a-z0-9]{1,4}$", RegexOptions.Compiled);

    private const string NetChrisApplicationConfigurationSectionKey = "netchris:application";

    /// <summary>
    /// Create a new <see cref="CanonicalApplicationName"/>
    /// </summary>
    /// <param name="applicationAggregate">The application aggregate</param>
    /// <param name="applicationAggregateShort">The short-form application aggregate</param>
    /// <param name="applicationComponent">The application component</param>
    /// <param name="applicationComponentShort">The short-form application component</param>
    /// <see href="https://github.com/NetChris/reference/wiki/Name-part-normalization">Name part normalization</see>
    public CanonicalApplicationName(string applicationAggregate, string applicationAggregateShort,
        string applicationComponent, string applicationComponentShort)
    {
        ValidateLongForm(applicationAggregate, nameof(applicationAggregate));
        ValidateShortForm(applicationAggregateShort, nameof(applicationAggregateShort));
        ValidateLongForm(applicationComponent, nameof(applicationComponent));
        ValidateShortForm(applicationComponentShort, nameof(applicationComponentShort));

        ApplicationAggregate = applicationAggregate;
        ApplicationAggregateShort = applicationAggregateShort;
        ApplicationComponent = applicationComponent;
        ApplicationComponentShort = applicationComponentShort;
    }

    private static void ValidateLongForm(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value) || !LongFormPattern.IsMatch(value))
        {
            throw new ArgumentException(
                "Value must consist of lower-case letters, numbers, and underscores only, and must begin with a lower-case letter.",
                paramName);
        }
    }

    private static void ValidateShortForm(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value) || !ShortFormPattern.IsMatch(value))
        {
            throw new ArgumentException(
                "Value must be 1 to 4 characters long and consist of lower-case letters and numbers only.",
                paramName);
        }
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

    /// <summary>
    /// Creates a new <see cref="CanonicalApplicationName"/> from well-known keys in <paramref name="configuration"/>:
    /// <c>netchris:application:aggregate</c>, <c>netchris:application:aggregateShort</c>,
    /// <c>netchris:application:component</c>, and <c>netchris:application:componentShort</c>.
    /// </summary>
    /// <param name="configuration">The configuration from which to read the Canonical Application Name.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="configuration"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown if any of the required configuration keys are missing or empty.</exception>
    public static CanonicalApplicationName FromConfiguration(IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        var applicationAggregate = GetRequiredValue(configuration, "aggregate");
        var applicationAggregateShort = GetRequiredValue(configuration, "aggregateShort");
        var applicationComponent = GetRequiredValue(configuration, "component");
        var applicationComponentShort = GetRequiredValue(configuration, "componentShort");

        return new CanonicalApplicationName(applicationAggregate, applicationAggregateShort,
            applicationComponent, applicationComponentShort);
    }

    private static string GetRequiredValue(IConfiguration configuration, string keyName)
    {
        var fullKey = $"{NetChrisApplicationConfigurationSectionKey}:{keyName}";
        var value = configuration[fullKey];

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException(
                $"The configuration key '{fullKey}' is required to create a {nameof(CanonicalApplicationName)} but was missing or empty.");
        }

        return value!;
    }
}