using System.Data;

namespace Mendz.Data.Common
{
    /// <summary>
    /// The base implementation of IDbDataContext.
    /// </summary>
    public abstract class DbDataContextBase : IDbDataContext
    {
        /// <summary>
        /// Builds the context instance.
        /// </summary>
        /// <returns>The context instance.</returns>
        protected abstract IDbConnection BuildContext();

        #region IDbDataContext Support
        protected IDbConnection _context = null;
        public IDbConnection Context {
            get
            {
                CreateContext();
                return _context;
            }
        }

        protected IDbTransaction _transaction = null;
        public IDbTransaction Transaction
        {
            get => _transaction;
        }

        public virtual void CreateContext()
        {
            if (_context == null)
            {
                _context = BuildContext();
                _context.Open();
            }
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_transaction == null)
            {
                CreateContext();
                _transaction = _context.BeginTransaction(isolationLevel);
            }
        }

        public virtual void EndTransaction(EndTransactionMode mode = EndTransactionMode.Commit)
        {
            if (_transaction != null)
            {
                if (mode == EndTransactionMode.Commit)
                {
                    _transaction.Commit();
                }
                else
                {
                    _transaction.Rollback();
                }
                _transaction.Dispose();
                _transaction = null;
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
                    if (_transaction != null)
                    {
                    _transaction.Dispose();
                    }
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
                disposed = true;
            }
        }

        public void Dispose() => Dispose(true);
        #endregion
    }
}
