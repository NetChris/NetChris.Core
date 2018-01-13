using FluentAssertions;
using Xunit;

namespace NetChris.Core.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Class1 class1 = new Class1();
            class1.Should().NotBeNull();
        }
    }
}
