using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class ApplicationMetadataTests
    {
        private readonly ApplicationMetadata<ApplicationMetadataTests> _appMetadata;

        public ApplicationMetadataTests()
        {
            // Arrange
            _appMetadata =
                new ApplicationMetadata<ApplicationMetadataTests>(
                    "GroupNameDoesNotMatterForThisTest",
                    environmentName: "UnitTestEnvironment",
                    buildIdentifier: "Build12345");
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
        public void ApplicationGroup_should_flow_through()
        {
            // Arrange
            string expectedApplicationGroup = "GroupNameDoesNotMatterForThisTest";

            // Act
            var applicationGroup = _appMetadata.ApplicationGroup;

            // Assert
            applicationGroup.Should().Be(expectedApplicationGroup);
        }

        [Fact]
        public void ApplicationVersion_is_formatted_correctly()
        {
            // Arrange
            var expectedVersion = "1.2.3.0";

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

        [Fact]
        public void ProcessorCount_should_be_non_zero()
        {
            _appMetadata.ProcessorCount.Should().BeGreaterThan(0);
        }

        [Fact]
        public void SystemPageSize_should_be_non_zero()
        {
            _appMetadata.SystemPageSize.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WorkingSet_should_be_non_zero()
        {
            _appMetadata.WorkingSet.Should().BeGreaterThan(0);
        }
    }
}
