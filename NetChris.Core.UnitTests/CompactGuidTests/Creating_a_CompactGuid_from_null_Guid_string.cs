using System;
using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests.CompactGuidTests
{
    public class Creating_a_CompactGuid_from_null_Guid_string
    {
        private readonly Exception _exception;

        public Creating_a_CompactGuid_from_null_Guid_string()
        {
            try
            {
                new Values.CompactGuid((string)null);
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

            _exception.Should().BeOfType<ArgumentNullException>();
        }
    }
}