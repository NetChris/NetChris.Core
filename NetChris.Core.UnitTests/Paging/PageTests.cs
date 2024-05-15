using System.Collections.Generic;
using FluentAssertions;
using NetChris.Core.Paging;
using Xunit;

namespace NetChris.Core.UnitTests.Paging;

public class PageTests
{
    private readonly Page<SomeThing> _typicalPage4;

    public PageTests()
    {
        _typicalPage4 = new Page<SomeThing>(new List<SomeThing>(),
            4, 50, 1372);
    }

    [Fact]
    public void TotalPagesShouldBeCorrect()
    {
        _typicalPage4.TotalPages.Should().Be(28);
    }

    private class SomeThing
    {
    }
}