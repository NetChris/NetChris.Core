using FluentAssertions;
using NetChris.Core.Extensions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class StringExtensions
    {
        [Fact]
        public void Guid_string_CanBeConvertedToCompactGuid()
        {
            string value = "5FEF5949-4BF9-4B6C-B746-AEB79594B386";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Guid_compact_string_CanBeConvertedToCompactGuid()
        {
            string value = "5fef59494bf94b6cb746aeb79594b386";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Empty_string_cannot_CanBeConvertedToCompactGuid()
        {
            string value = "";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void White_space_cannot_CanBeConvertedToCompactGuid()
        {
            string value = "   ";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void Non_Guid_cannot_CanBeConvertedToCompactGuid()
        {
            string value = "ssfdfsdf9879879";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }
    }
}
