using System;
using System.Collections.Generic;

namespace NetChris.Core.Paging;

/// <summary>
/// A page of <typeparam name="T" />, with associated position and size information
/// </summary>
public class Page<T> : Page
{
    /// <summary>
    /// Create a new page
    /// </summary>
    /// <param name="items">The items on the page</param>
    /// <param name="currentPage">The current page number</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="totalItems">The count of total items in the source dataset</param>
    public Page(IEnumerable<T> items, ulong currentPage, ulong pageSize, ulong totalItems)
        : base(currentPage, pageSize, totalItems)
    {
        Items = items;
    }

    /// <summary>
    /// The items on the page
    /// </summary>
    public IEnumerable<T> Items { get; }
}

/// <summary>
/// A page, with associated position and size information
/// </summary>
public class Page
{
    /// <summary>
    /// Create a new page
    /// </summary>
    /// <param name="currentPage">The current page number</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="totalItems">The count of total items in the source dataset</param>
    protected Page(ulong currentPage, ulong pageSize, ulong totalItems)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
    }

    /// <summary>
    /// The count of total items in the source dataset
    /// </summary>
    public ulong TotalItems { get; }

    /// <summary>
    /// The page size
    /// </summary>
    public ulong PageSize { get; }
    
    /// <summary>
    /// The current page number
    /// </summary>
    public ulong CurrentPage { get; }

    /// <summary>
    /// Gets the total pages
    /// </summary>
    /// <remarks>
    /// This will never return 0 as there is always conceptually a 'page 1', even if empty.
    /// </remarks>
    public ulong TotalPages
    {
        get
        {
            ulong result = 1;
            if (PageSize != 0)
            {
                result = (ulong) Math.Ceiling((decimal) TotalItems / PageSize);
            }

            return Math.Max(1, result);
        }
    }
}