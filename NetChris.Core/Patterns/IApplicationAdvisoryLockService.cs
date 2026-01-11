using System.Threading;
using System.Threading.Tasks;

namespace NetChris.Core.Patterns;

/// <summary>
/// Provides advisory lock services for a distributed application
/// </summary>
/// <remarks>
/// This is inspired by Postgres advisory locks.  See the links below for more information.
/// </remarks>
/// <see href="https://www.postgresql.org/docs/current/explicit-locking.html#ADVISORY-LOCKS"/>
/// <see href="https://www.postgresql.org/docs/current/functions-admin.html#FUNCTIONS-ADVISORY-LOCKS"/>
public interface IApplicationAdvisoryLockService
{
    /// <summary>
    /// Sets an advisory lock asynchronously for the specified value on the transaction
    /// </summary>
    /// <param name="lockId">The advisory lock ID</param>
    /// <param name="cancellationToken">The cancellation token used when first acquiring the lock</param>
    Task SetAdvisoryLockAsync(int lockId, CancellationToken cancellationToken);
}