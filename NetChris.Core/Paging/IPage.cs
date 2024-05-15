using System.Collections.Generic;

namespace NetChris.Core.Paging;

/// <summary>
/// A page of <typeparam name="T" />, with associated position and size information
/// </summary>
public interface IPage<T> : IPage
{
    /// <summary>
    /// The items on the page
    /// </summary>
    IEnumerable<T> Items { get; }
}

/// <summary>
/// Represents a page of items, with associated position and size information
/// </summary>
public interface IPage
{
    /// <summary>
    /// The count of total items in the source dataset
    /// </summary>
    ulong TotalItems { get; }

    /// <summary>
    /// The page size
    /// </summary>
    ulong PageSize { get; }

    /// <summary>
    /// The current page number
    /// </summary>
    ulong CurrentPage { get; }

    /// <summary>
    /// Gets the total pages
    /// </summary>
    /// <remarks>
    /// This will never return 0 as there is always conceptually a 'page 1', even if empty.
    /// </remarks>
    ulong TotalPages { get; }
}