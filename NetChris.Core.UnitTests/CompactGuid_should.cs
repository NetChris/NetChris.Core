using System;
using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class CompactGuid_should
    {
        private const string SourceGuidAsString = "5D8DA2CF-4801-48F1-BE59-42FA5A986EB9";
        private const string SourceGuidAsCompactGuidString = "5d8da2cf480148f1be5942fa5a986eb9";
        private readonly Guid _sourceGuid;
        private readonly Core.Values.CompactGuid _compactGuid;

        public CompactGuid_should()
        {
            // Arrange
            _sourceGuid = new Guid(SourceGuidAsString);
            _compactGuid = new Core.Values.CompactGuid(_sourceGuid);
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
            Core.Values.CompactGuid implicitValue = _sourceGuid;

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
        public void Be_implicitly_convertible_from_compact_Guid_string()
        {
            // Act
            Core.Values.CompactGuid implicitValue = SourceGuidAsString;

            // Assert
            implicitValue.ToString().Should().Be(SourceGuidAsCompactGuidString);
        }

        [Fact]
        public void Be_implicitly_convertible_from_normal_Guid_string()
        {
            // Act
            Core.Values.CompactGuid implicitValue = SourceGuidAsCompactGuidString;

            // Assert
            implicitValue.ToString().Should().Be(SourceGuidAsCompactGuidString);
        }

        [Fact]
        public void Be_createable_from_full_Guid_string()
        {
            string guidAsString = "D7F20447-26B4-4C4D-8BEA-B86879A52B0D";
            Guid guidFromString = new Guid(guidAsString);
            Core.Values.CompactGuid compactIdFromGuid = guidAsString;
            compactIdFromGuid.Guid.Should().Be(guidFromString);
        }

        [Fact]
        public void Be_createable_from_minimized_Guid_string()
        {
            string guidAsMinimizedString = "f2b713e5c473461487e43d1cdb8b1f05";
            var guidFromString = new Guid(guidAsMinimizedString);
            Core.Values.CompactGuid compactGuidFromGuid = guidAsMinimizedString;
            compactGuidFromGuid.Guid.Should().Be(guidFromString);
            compactGuidFromGuid.ToString().Should().Be(guidAsMinimizedString);
        }

        [Fact]
        public void Be_createable_from_Guid()
        {
            var newGuid = Guid.NewGuid();
            Core.Values.CompactGuid compactGuidFromGuid = new Core.Values.CompactGuid(newGuid);
            compactGuidFromGuid.Guid.Should().Be(newGuid);
        }
    }
}
