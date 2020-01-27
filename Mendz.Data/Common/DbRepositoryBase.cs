using System;

namespace Mendz.Data.Common
{
    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TDbDataContext">The database context.</typeparam>
    public abstract class DbRepositoryBase<TDbDataContext> : IDisposable
        where TDbDataContext : new()
    {
        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        protected TDbDataContext DbDataContext { get; set; }

        /// <summary>
        /// Gets or sets if the current instance is the owner of the database context.
        /// </summary>
        protected bool DbDataContextOwner { get; set; } = false;

        /// <summary>
        /// Creates a repository that owns a database context instance.
        /// </summary>
        protected DbRepositoryBase() => CreateDbDataContext();

        /// <summary>
        /// Creates a repository that shares a database context.
        /// </summary>
        /// <param name="dbDataContext">The database context to share.</param>
        protected DbRepositoryBase(TDbDataContext dbDataContext) => DbDataContext = dbDataContext;

        protected void CreateDbDataContext()
        {
            if (DbDataContext == null)
            {
                DbDataContext = new TDbDataContext();
                DbDataContextOwner = true;
            }
        }

        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DbDataContextOwner)
                    {
                        if (DbDataContext is IDisposable dbdc) dbdc.Dispose();
                    }
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
