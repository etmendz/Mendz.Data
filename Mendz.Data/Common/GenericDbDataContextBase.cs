using System;

namespace Mendz.Data.Common
{
    /// <summary>
    /// The base implementation of a generic database context.
    /// </summary>
    public abstract class GenericDbDataContextBase<TContext> : IDbDataContext<TContext>
    {
        /// <summary>
        /// Builds the context instance.
        /// </summary>
        /// <returns>The context instance.</returns>
        protected abstract TContext BuildContext();

        #region IDbDataContext Support
        private TContext _context = default;
        public TContext Context {
            get
            {
                CreateContext();
                return _context;
            }
            protected set => _context = value;
        }

        public virtual void CreateContext()
        {
            if (_context == null) _context = BuildContext();
        }
        #endregion
    }
}
