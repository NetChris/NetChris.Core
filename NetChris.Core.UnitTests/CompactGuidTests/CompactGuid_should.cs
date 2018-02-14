using System;
using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests.CompactGuidTests
{
    public class CompactGuid_should
    {
        private const string SourceGuidAsString = "5D8DA2CF-4801-48F1-BE59-42FA5A986EB9";
        private const string SourceGuidAsCompactGuidString = "5d8da2cf480148f1be5942fa5a986eb9";
        private readonly Guid _sourceGuid;
        private readonly Values.CompactGuid _compactGuid;

        public CompactGuid_should()
        {
            // Arrange
            _sourceGuid = new Guid(SourceGuidAsString);
            _compactGuid = new Values.CompactGuid(_sourceGuid);
        }

        [Fact]
        public void Return_a_compact_Guid_string_from_ToString()
        {
            // Act
            string value = _compactGuid.ToString();

            // Assert
            value.Should().Be(SourceGuidAsCompactGuidString);
        }

        [Fact]
        public void Return_a_Guid_string_Guid()
        {
            // Act
            Guid value = _compactGuid.Guid;

            // Assert
            value.Should().Be(_sourceGuid);
        }

        [Fact]
        public void Be_implicitly_convertible_to_Guid()
        {
            // Act
            Guid implicitValue = _compactGuid;

            // Assert
            implicitValue.Should().Be(_sourceGuid);
        }

        [Fact]
        public void Be_implicitly_convertible_from_Guid()
        {
            // Act
            Values.CompactGuid implicitValue = _sourceGuid;

            // Assert
            implicitValue.Should().Be(_compactGuid);
        }

        [Fact]
        public void Be_implicitly_convertible_to_string()
        {
            // Act
            string implicitValue = _compactGuid;

            // Assert
            implicitValue.Should().Be(SourceGuidAsCompactGuidString);
        }

        [Fact]
        public void Be_createable_from_Guid()
        {
            var newGuid = Guid.NewGuid();
            Values.CompactGuid compactGuidFromGuid = new Values.CompactGuid(newGuid);
            compactGuidFromGuid.Guid.Should().Be(newGuid);
        }


        [Fact]
        public void Be_createable_from_Guid_string()
        {
            var compactGuidFromGuidString = new Values.CompactGuid(SourceGuidAsString);
            compactGuidFromGuidString.Guid.Should().Be(_sourceGuid);
        }
    }
}
