using System;

namespace Mendz.Data.Common
{
    /// <summary>
    /// The base implementation of a generic database context.
    /// </summary>
    public abstract class GenericDbDataContextBase<C> : IDbDataContext<C>
    {
        /// <summary>
        /// Builds the context instance.
        /// </summary>
        /// <returns>The context instance.</returns>
        protected abstract C BuildContext();

        #region IDbDataContext Support
        protected C _context = default(C);
        public C Context {
            get
            {
                CreateContext();
                return _context;
            }
        }

        public virtual void CreateContext()
        {
            if (_context == null)
            {
                _context = BuildContext();
            }
        }
        #endregion
    }
}
