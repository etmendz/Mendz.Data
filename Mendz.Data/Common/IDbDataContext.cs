using System;
using System.Data;

namespace Mendz.Data.Common
{
    /// <summary>
    /// Defines a database context.
    /// </summary>
    public interface IDbDataContext : IDisposable
    {
        /// <summary>
        /// Gets the context instance.
        /// </summary>
        IDbConnection Context { get; }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        IDbTransaction Transaction { get; }

        /// <summary>
        /// Creates a context instance.
        /// </summary>
        void CreateContext();

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
