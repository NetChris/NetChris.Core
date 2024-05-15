using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NetChris.Core.Paging;
using Xunit;

namespace NetChris.Core.UnitTests.Paging;

public class PageTests
{
    private readonly Page<SomeThing> _typicalPage4;

    public PageTests()
    {
        _typicalPage4 = new Page<SomeThing>(new List<SomeThing> { new(), new(), new(), new() },
            4, 50, 1372);
    }

    [Fact]
    public void TotalPagesShouldBeCorrect()
    {
        _typicalPage4.TotalPages.Should().Be(28);
    }

    [Fact]
    public void ItemCountShouldBeCorrect()
    {
        _typicalPage4.Items.Count().Should().Be(4);
    }

    private class SomeThing
    {
    }
}