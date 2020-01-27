using System.Data;

namespace Mendz.Data.Common
{
    /// <summary>
    /// Defines a database transaction.
    /// </summary>
    /// <typeparam name="TTransaction">The transaction type.</typeparam>
    public interface IDbDataTransaction<TTransaction>
    {
        /// <summary>
        /// Gets the transaction.
        /// </summary>
        TTransaction Transaction { get; }

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
