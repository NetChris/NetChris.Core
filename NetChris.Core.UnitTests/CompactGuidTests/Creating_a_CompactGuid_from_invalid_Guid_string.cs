using System;
using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests.CompactGuidTests
{
    public class Creating_a_CompactGuid_from_invalid_Guid_string
    {
        private readonly Exception _exception;

        public Creating_a_CompactGuid_from_invalid_Guid_string()
        {
            var invalidGuid = "thisisnotaguid";

            try
            {
                new Values.CompactGuid(invalidGuid);
            }
            catch (Exception exc)
            {
                _exception = exc;
            }
        }

        [Fact]
        public void Should_throw()
        {

            _exception.Should().NotBeNull();
        }

        [Fact]
        public void Should_throw_FormatException()
        {

            _exception.Should().BeOfType<FormatException>();
        }
    }
}