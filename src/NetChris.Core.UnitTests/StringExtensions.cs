using FluentAssertions;
using NetChris.Core.Extensions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class StringExtensions
    {
        [Fact]
        public void Guid_string_can_be_converted_to_CompactGuid()
        {
            string value = "5FEF5949-4BF9-4B6C-B746-AEB79594B386";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Bracketed_Guid_string_can_be_converted_to_CompactGuid()
        {
            string value = "{221DBD71-BC89-40E8-B6F3-A87219E9D844}";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Parentheses_Guid_string_can_be_converted_to_CompactGuid()
        {
            string value = "(221DBD71-BC89-40E8-B6F3-A87219E9D844)";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Guid_compact_string_can_be_converted_to_CompactGuid()
        {
            string value = "5fef59494bf94b6cb746aeb79594b386";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Guid_compact_string_mixed_case_can_be_converted_to_CompactGuid()
        {
            string value = "5FeF59494bF94b6Cb746AeB79594b386";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeTrue();
        }

        [Fact]
        public void Empty_string_cannot_be_converted_to_CompactGuid()
        {
            string value = "";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void White_space_cannot_be_converted_to_CompactGuid()
        {
            string value = "   ";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void Non_Guid_cannot_be_converted_to_CompactGuid()
        {
            string value = "ssfdfsdf9879879";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void Malformed_Guid_cannot_be_converted_to_CompactGuid()
        {
            // Note the x
            string value = "{0b54f259-67a2-45ef-8076-0ex42693eb84}";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void Mixed_Bracket_Parentheses_Guid_string_cannot_be_converted_to_CompactGuid()
        {
            string value = "(221DBD71-BC89-40E8-B6F3-A87219E9D844}";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void Parentheses_only_Guid_string_cannot_be_converted_to_CompactGuid()
        {
            string value = "(221DBD71-BC89-40E8-B6F3-A87219E9D844";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();

            value = "221DBD71-BC89-40E8-B6F3-A87219E9D844)";
            result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }

        [Fact]
        public void Bracket_only_Guid_string_cannot_be_converted_to_CompactGuid()
        {
            string value = "{221DBD71-BC89-40E8-B6F3-A87219E9D844";
            var result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();

            value = "221DBD71-BC89-40E8-B6F3-A87219E9D844}";
            result = value.CanBeConvertedToCompactGuid();
            result.Should().BeFalse();
        }
    }
}
