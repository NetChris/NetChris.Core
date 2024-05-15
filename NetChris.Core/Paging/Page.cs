using System;
using System.Collections.Generic;

namespace NetChris.Core.Paging;

/// <inheritdoc />
public class Page<T> : IPage<T>
{
    /// <summary>
    /// Create a new page
    /// </summary>
    /// <param name="items">The items on the page</param>
    /// <param name="currentPage">The current page number</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="totalItems">The count of total items in the source dataset</param>
    public Page(IEnumerable<T> items, ulong currentPage, ulong pageSize, ulong totalItems)
    {
        Items = items;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
    }

    /// <inheritdoc />
    public IEnumerable<T> Items { get; }

    /// <inheritdoc />
    public ulong TotalItems { get; }

    /// <inheritdoc />
    public ulong PageSize { get; }

    /// <inheritdoc />
    public ulong CurrentPage { get; }

    /// <inheritdoc />
    public ulong TotalPages
    {
        get
        {
            ulong result = 1;
            if (PageSize != 0)
            {
                result = (ulong)Math.Ceiling((decimal)TotalItems / PageSize);
            }

            return Math.Max(1, result);
        }
    }
}