using System.Threading;
using System.Threading.Tasks;

namespace NetChris.Core.Patterns;

/// <summary>
/// Presents a unit of work interface to coordinate a unit-of-work pattern operation against a data store.
/// </summary>
/// <remarks>
/// <para>
/// There is no prescribed implementation of this of course.  However the primary use of this will be to wrap the operations
/// of an Entity Framework DbContext.  And even though the DbContext's SaveChanges/Async operations constitute a unit
/// of work in and of themselves, it's important to have a separate handle on the over-arching unit of work for:
/// <list type="bullet">
/// <item>Having an abstraction to use for testing in concert with repository abstractions.</item>
/// <item>Handle the common exceptions that can occur when saving changes to the database, and then wrap them in well-known exceptions.</item>
/// <item>Allow the ability to save/commit the unit of work without needing to reference the DbContext</item>
/// </list>
/// </para>
/// </remarks>
public interface IUnitOfWork
{
    /// <summary>
    /// Commit the unit of work
    /// </summary>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}