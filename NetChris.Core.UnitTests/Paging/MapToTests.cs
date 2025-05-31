using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NetChris.Core.Paging;
using Xunit;

namespace NetChris.Core.UnitTests.Paging;

public class MapToTests
{
    private class FromType
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }

    private class ToType
    {
        public string PersonName { get; set; } = null!;
        public TimeSpan Age { get; set; }
    }


    private readonly List<FromType> _fromTypes = new()
    {
        new FromType { Name = "Alice", Age = 30 },
        new FromType { Name = "Bob", Age = 25 },
        new FromType { Name = "Charlie", Age = 35 },
        new FromType { Name = "Diana", Age = 28 }
    };


    private readonly Page<FromType> _sourcePage;
    private readonly Page<ToType> _targetPage;

    private static ToType MappingFunction(FromType from)
    {
        return new ToType
        {
            PersonName = from.Name,
            Age = TimeSpan.FromDays(from.Age * 365.25),
        };
    }

    public MapToTests()
    {
        _sourcePage = new Page<FromType>(_fromTypes, 2, 4, 500);
        _targetPage = _sourcePage.MapTo(MappingFunction);
    }

    [Fact]
    public void TotalPagesShouldBeCorrect()
    {
        _targetPage.TotalPages.Should().Be(_sourcePage.TotalPages);
    }

    [Fact]
    public void CurrentPageShouldBeCorrect()
    {
        _targetPage.CurrentPage.Should().Be(_sourcePage.CurrentPage);
    }

    [Fact]
    public void PageSizeShouldBeCorrect()
    {
        _targetPage.PageSize.Should().Be(_sourcePage.PageSize);
    }

    [Fact]
    public void MappedItemShouldMatch()
    {
        var charlieFromSourcePage = _sourcePage.Items.ElementAt(2);
        var charlieFromTargetPage = _targetPage.Items.ElementAt(2);

        charlieFromTargetPage.PersonName.Should().Be(charlieFromSourcePage.Name);
        charlieFromTargetPage.Age.Should().Be(
            TimeSpan.FromDays(charlieFromSourcePage.Age * 365.25));
    }
}