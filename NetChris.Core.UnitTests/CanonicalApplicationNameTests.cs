using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace NetChris.Core.UnitTests;

public class CanonicalApplicationNameTests
{
    [Fact]
    public void Conforming_values_should_flow_through()
    {
        // Arrange
        // Act
        var canonicalApplicationName = new CanonicalApplicationName(
            "app_aggregate", "aagg", "app_component", "acmp");

        // Assert
        canonicalApplicationName.ApplicationAggregate.Should().Be("app_aggregate");
        canonicalApplicationName.ApplicationAggregateShort.Should().Be("aagg");
        canonicalApplicationName.ApplicationComponent.Should().Be("app_component");
        canonicalApplicationName.ApplicationComponentShort.Should().Be("acmp");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("Aggregate")]
    [InlineData("1aggregate")]
    [InlineData("app-aggregate")]
    [InlineData("app aggregate")]
    public void Non_conforming_long_form_aggregate_should_throw(string? applicationAggregate)
    {
        // Arrange
        // Act
        var act = () => new CanonicalApplicationName(applicationAggregate!, "aagg", "app_component", "acmp");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("applicationAggregate");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("Component")]
    [InlineData("1component")]
    [InlineData("app-component")]
    public void Non_conforming_long_form_component_should_throw(string? applicationComponent)
    {
        // Arrange
        // Act
        var act = () => new CanonicalApplicationName("app_aggregate", "aagg", applicationComponent!, "acmp");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("applicationComponent");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("AAGG")]
    [InlineData("aagg5")]
    [InlineData("ag_g")]
    public void Non_conforming_short_form_aggregate_should_throw(string? applicationAggregateShort)
    {
        // Arrange
        // Act
        var act = () =>
            new CanonicalApplicationName("app_aggregate", applicationAggregateShort!, "app_component", "acmp");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("applicationAggregateShort");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("ACMP")]
    [InlineData("acmp5")]
    [InlineData("cm_p")]
    public void Non_conforming_short_form_component_should_throw(string? applicationComponentShort)
    {
        // Arrange
        // Act
        var act = () =>
            new CanonicalApplicationName("app_aggregate", "aagg", "app_component", applicationComponentShort!);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("applicationComponentShort");
    }

    [Fact]
    public void FromConfiguration_should_build_from_well_known_keys()
    {
        // Arrange
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["netchris:application:aggregate"] = "app_aggregate",
                ["netchris:application:aggregateShort"] = "aagg",
                ["netchris:application:component"] = "app_component",
                ["netchris:application:componentShort"] = "acmp",
            })
            .Build();

        // Act
        var canonicalApplicationName = CanonicalApplicationName.FromConfiguration(configuration);

        // Assert
        canonicalApplicationName.ApplicationAggregate.Should().Be("app_aggregate");
        canonicalApplicationName.ApplicationAggregateShort.Should().Be("aagg");
        canonicalApplicationName.ApplicationComponent.Should().Be("app_component");
        canonicalApplicationName.ApplicationComponentShort.Should().Be("acmp");
    }

    [Fact]
    public void FromConfiguration_with_null_configuration_should_throw()
    {
        // Arrange
        // Act
        var act = () => CanonicalApplicationName.FromConfiguration(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("configuration");
    }

    [Theory]
    [InlineData("netchris:application:aggregate")]
    [InlineData("netchris:application:aggregateShort")]
    [InlineData("netchris:application:component")]
    [InlineData("netchris:application:componentShort")]
    public void FromConfiguration_with_missing_key_should_throw_and_name_the_key(string missingKey)
    {
        // Arrange
        var values = new Dictionary<string, string?>
        {
            ["netchris:application:aggregate"] = "app_aggregate",
            ["netchris:application:aggregateShort"] = "aagg",
            ["netchris:application:component"] = "app_component",
            ["netchris:application:componentShort"] = "acmp",
        };
        values.Remove(missingKey);

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(values)
            .Build();

        // Act
        var act = () => CanonicalApplicationName.FromConfiguration(configuration);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage($"*{missingKey}*");
    }
}
