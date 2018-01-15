using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class ApplicationMetadataTests
    {
        [Fact]
        public void Automatic_ApplicationName_discern_should_work()
        {
            // Arrange
            ApplicationMetadata<ApplicationMetadataTests> appMetadata =
                new ApplicationMetadata<ApplicationMetadataTests>(
                    "GroupNameDoesNotMatterForThisTest",
                    environmentName: "UnitTestEnvironment",
                    buildIdentifier: "Build12345");

            string expectedApplicationName = "NetChris.Core.UnitTests";

            // Act
            var applicationName = appMetadata.ApplicationName;

            // Assert
            applicationName.Should().Be(expectedApplicationName);
        }

        [Fact]
        public void ApplicationGroup_should_flow_through()
        {
            // Arrange
            string expectedApplicationGroup = "App.Group";
            ApplicationMetadata<ApplicationMetadataTests> appMetadata =
                new ApplicationMetadata<ApplicationMetadataTests>(
                    expectedApplicationGroup,
                    "AppNameDoesNotMatterForThisTest",
                    environmentName: "UnitTestEnvironment",
                    buildIdentifier: "Build12345");

            // Act
            var applicationGroup = appMetadata.ApplicationGroup;

            // Assert
            applicationGroup.Should().Be(expectedApplicationGroup);
        }

        [Fact]
        public void ApplicationVersion_is_formatted_correctly()
        {
            // Arrange
            var expectedVersion = "1.2.3.0";

            ApplicationMetadata<ApplicationMetadataTests> appMetadata =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter",
                    environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            // Act
            var applicationVersion = appMetadata.ApplicationVersion;

            // Assert
            applicationVersion.Should().Be(expectedVersion);
        }

        [Fact]
        public void InformationalVersion_is_formatted_correctly()
        {
            // Arrange
            // This is defined in the csproj properties
            var expectedVersion = "1.2.3-alpha informational version";

            ApplicationMetadata<ApplicationMetadataTests> appMetadata =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter",
                    environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            // Act
            var applicationVersion = appMetadata.InformationalVersion;

            // Assert
            applicationVersion.Should().Be(expectedVersion);
        }

        [Fact]
        public void ExecutionInstanceId_should_stay_constant_over_instances()
        {
            // Arrange
            ApplicationMetadata<ApplicationMetadataTests> appMetadata1 =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter1", environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            ApplicationMetadata<ApplicationMetadataTests> appMetadata2 =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter2", environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            // Act
            var executionInstanceId1 = appMetadata1.ExecutionInstanceId;
            var executionInstanceId2 = appMetadata2.ExecutionInstanceId;

            // Assert
            executionInstanceId1.Should().BeEquivalentTo(executionInstanceId2);
        }

        [Fact]
        public void ExecutionInstanceTimestamp_should_stay_constant_over_instances()
        {
            // Arrange
            ApplicationMetadata<ApplicationMetadataTests> appMetadata1 =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter1", environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            ApplicationMetadata<ApplicationMetadataTests> appMetadata2 =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter2", environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            // Act
            var executionInstanceTimestamp1 = appMetadata1.ExecutionInstanceTimestamp;
            var executionInstanceTimestamp2 = appMetadata2.ExecutionInstanceTimestamp;

            // Assert
            executionInstanceTimestamp1.ShouldBeEquivalentTo(executionInstanceTimestamp2);
        }

        [Fact]
        public void MachineLocalTimeZone_should_stay_constant_over_instances()
        {
            // Arrange
            ApplicationMetadata<ApplicationMetadataTests> appMetadata1 =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter1", environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            ApplicationMetadata<ApplicationMetadataTests> appMetadata2 =
                new ApplicationMetadata<ApplicationMetadataTests>("DoesNotMatter2", environmentName: "UnitTestEnvironment", buildIdentifier: "Build12345");

            // Act
            var timeZone1 = appMetadata1.MachineLocalTimeZone;
            var timeZone2 = appMetadata2.MachineLocalTimeZone;

            // Assert
            timeZone1.ShouldBeEquivalentTo(timeZone2);
        }
    }
}
