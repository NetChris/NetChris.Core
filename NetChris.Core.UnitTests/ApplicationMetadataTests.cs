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
            _appMetadata =
                new ApplicationMetadata(
                    "AggregateNameDoesNotMatterForThisTest",
                     "NetChris.Core.UnitTests","UnitTestEnvironment");
            
            _appMetadataWithJustAggregateAndEnvironment =
                new ApplicationMetadata("AggregateNameDoesNotMatterForThisTest","UnitTestEnvironment"); 
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
            string expectedApplicationAggregate = "AggregateNameDoesNotMatterForThisTest";

            // Act
            var applicationAggregate = _appMetadata.ApplicationAggregate;

            // Assert
            applicationAggregate.Should().Be(expectedApplicationAggregate);
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
            // Arrange
            // This is defined in the csproj properties
            var expectedVersion = "1.2.3-alpha informational version";

            // Act
            var applicationVersion = _appMetadata.InformationalVersion;

            // Assert
            applicationVersion.Should().Be(expectedVersion);
        }

        [Fact]
        public void StartTimestamp_should_stay_constant_over_instances()
        {
            // Arrange
            var appMetadata1 =
                new ApplicationMetadata("DoesNotMatter1", environmentName: "UnitTestEnvironment",
                    assembly: Assembly.GetEntryAssembly());

            var appMetadata2 =
                new ApplicationMetadata("DoesNotMatter2", environmentName: "UnitTestEnvironment",
                    assembly: Assembly.GetEntryAssembly());

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
        public void Auto_Assembly_detection_detects_something()
        {
            _appMetadataWithJustAggregateAndEnvironment.ApplicationName.Should()
                .NotBeNullOrWhiteSpace();
        }
    }
}