using System;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class ApplicationMetadataTests
    {
        private readonly ApplicationMetadata _appMetadata;
        private readonly ApplicationMetadata _appMetadataWithJustAggregateAndEnvironment;

        public ApplicationMetadataTests()
        {
            // Arrange
            var thisAssembly = typeof(ApplicationMetadataTests).Assembly;
            _appMetadata =
                new ApplicationMetadata(
                    thisAssembly,
                    "ExpectedAppAggregate",
                    "ExpectedAppComponent",
                    thisAssembly.GetName().Name!,
                    "12345",
                    "UnitTestEnvironment");

            _appMetadataWithJustAggregateAndEnvironment =
                ApplicationMetadata.GetApplicationMetadataFromEntryAssembly(
                    "ExpectedAppAggregate",
                    "ExpectedAppComponent",
                    "12345",
                    "UnitTestEnvironment");
        }

        [Fact]
        public void Automatic_ApplicationName_discern_should_work()
        {
            // Arrange
            string expectedApplicationName = "NetChris.Core.UnitTests";

            // Act
            var applicationName = _appMetadata.ApplicationName;

            // Assert
            applicationName.Should().Be(expectedApplicationName);
        }

        [Fact]
        public void ApplicationAggregate_should_flow_through()
        {
            // Arrange
            string expectedApplicationAggregate = "ExpectedAppAggregate";

            // Act
            var applicationAggregate = _appMetadata.CanonicalApplicationName.ApplicationAggregate;

            // Assert
            applicationAggregate.Should().Be(expectedApplicationAggregate);
        }

        [Fact]
        public void ApplicationComponent_should_flow_through()
        {
            // Arrange
            string expectedApplicationComponent = "ExpectedAppComponent";

            // Act
            var applicationAggregate = _appMetadata.CanonicalApplicationName.ApplicationComponent;

            // Assert
            applicationAggregate.Should().Be(expectedApplicationComponent);
        }

        [Fact]
        public void ApplicationVersion_is_formatted_correctly()
        {
            // Arrange
            var expectedVersion = new Version("1.2.3.0");

            // Act
            var applicationVersion = _appMetadata.ApplicationVersion;

            // Assert
            applicationVersion.Should().Be(expectedVersion);
        }

        [Fact]
        public void InformationalVersion_is_formatted_correctly()
        {
            // With later versions of dotnet, the git sha will be appended to the informational version, so
            // just check for whether is starts with the expected value.
            _appMetadata.InformationalVersion.Should().StartWith("1.2.3-alpha informational version");
        }

        [Fact]
        public void StartTimestamp_should_stay_constant_over_instances()
        {
            // Arrange
            var entryAssembly = Assembly.GetEntryAssembly();
            var entryAssemblyName = entryAssembly?.GetName().Name;

            var appMetadata1 =
                new ApplicationMetadata(
                    entryAssembly!,
                    "DoesNotMatter1",
                    "DoesNotMatter1",
                    entryAssemblyName!,
                    "12345",
                    "UnitTestEnvironment");

            var appMetadata2 =
                new ApplicationMetadata(
                    entryAssembly!,
                    "DoesNotMatter2",
                    "DoesNotMatter2",
                    entryAssemblyName!,
                    "12345",
                    "UnitTestEnvironment");

            // Act
            var executionInstanceTimestamp1 = appMetadata1.StartTimestamp;
            var executionInstanceTimestamp2 = appMetadata2.StartTimestamp;

            // Assert
            executionInstanceTimestamp1.Should().Be(executionInstanceTimestamp2);
        }

        [Fact]
        public void EnvironmentName_should_flow_through()
        {
            _appMetadata.EnvironmentName.Should().Be("UnitTestEnvironment");
        }

        [Fact]
        public void MachineName_should_have_a_value()
        {
            _appMetadata.MachineName.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void OSPlatform_should_have_a_value()
        {
            _appMetadata.OSPlatform.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void OSVersion_should_have_a_value()
        {
            _appMetadata.OSVersion.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void UserName_should_have_a_value()
        {
            _appMetadata.UserName.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ClrVersion_should_have_a_value()
        {
            _appMetadata.ClrVersion.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void BuildIdentifier_should_flow_through()
        {
            _appMetadata.BuildIdentifier.Should().Be("12345");
        }
        
        [Fact]
        public void Auto_Assembly_detection_detects_something()
        {
            _appMetadataWithJustAggregateAndEnvironment.ApplicationName.Should()
                .NotBeNullOrWhiteSpace();
        }
    }
}