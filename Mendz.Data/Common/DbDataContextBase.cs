using System;
using System.Data;

namespace Mendz.Data.Common
{
    /// <summary>
    /// The base implementation of a database context.
    /// </summary>
    public abstract class DbDataContextBase : GenericDbDataContextBase<IDbConnection>, IDbDataTransaction<IDbTransaction>, IDisposable
    {
        public override void CreateContext()
        {
            if (Context == null)
            {
                base.CreateContext();
                Context.Open();
            }
        }

        #region IDbDataTransaction Support
        public IDbTransaction Transaction { get; protected set; }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (Transaction == null)
            {
                CreateContext();
                Transaction = Context.BeginTransaction(isolationLevel);
            }
        }

        public virtual void EndTransaction(EndTransactionMode mode = EndTransactionMode.Commit)
        {
            if (Transaction != null)
            {
                if (mode == EndTransactionMode.Commit)
                {
                    Transaction.Commit();
                }
                else
                {
                    Transaction.Rollback();
                }
                Transaction.Dispose();
                Transaction = null;
            }
        }
        #endregion

        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Transaction != null) Transaction.Dispose();
                    if (Context != null) Context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
