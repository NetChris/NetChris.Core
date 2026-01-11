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
    /// Sets a transaction-level advisory lock for specified value
    /// </summary>
    /// <remarks>
    /// As the name implies, the lock is help for the duration of a transaction.  There is no prescription where that
    /// transaction lives or how it is managed.  It is up to the application to ensure that the implementation uses some
    /// mechanism (usually a database transaction), to ensure that the transaction is resolved (committed or rolled back)
    /// in a timely manner.
    /// </remarks>
    /// <param name="lockId">The advisory lock ID</param>
    /// <param name="cancellationToken">The cancellation token used when first acquiring the lock</param>
    Task SetTransactionAdvisoryLockAsync(int lockId, CancellationToken cancellationToken);
}