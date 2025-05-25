using System;
using System.Linq;

namespace NetChris.Core.Paging;

/// <summary>
/// Extension methods for paging
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Get a page of items of type <typeparamref name="TTo"/>
    /// mapped from a page of items of type <typeparamref name="T"/>
    /// </summary>
    /// <param name="sourcePage">The source page</param>
    /// <param name="mappingFunction">The mapping function from <typeparamref name="T"/> to <typeparamref name="TTo"/></param>
    public static Page<TTo> MapTo<T, TTo>(this Page<T> sourcePage, Func<T, TTo> mappingFunction)
    {
        var resultItems = sourcePage.Items.Select(mappingFunction).ToList();

        return new Page<TTo>(
            resultItems,
            sourcePage.CurrentPage,
            sourcePage.PageSize,
            sourcePage.TotalItems);
    }
}