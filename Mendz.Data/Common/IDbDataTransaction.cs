using System.Data;

namespace Mendz.Data.Common
{
    /// <summary>
    /// Defines a database transaction.
    /// </summary>
    /// <typeparam name="T">The transaction type.</typeparam>
    public interface IDbDataTransaction<T>
    {
        /// <summary>
        /// Gets the transaction.
        /// </summary>
        T Transaction { get; }

        /// <summary>
        /// Begins a transaction.
        /// </summary>
        /// <param name="isolationLevel">The transaction's isolation level.</param>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Ends a transaction.
        /// </summary>
        /// <param name="mode">The transaction mode to commit or rollback.</param>
        void EndTransaction(EndTransactionMode mode = EndTransactionMode.Commit);
    }
}
