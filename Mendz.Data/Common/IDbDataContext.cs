namespace Mendz.Data.Common
{
    /// <summary>
    /// Defines a database context.
    /// </summary>
    /// <typeparam name="TContext">The context type.</typeparam>
    public interface IDbDataContext<TContext>
    {
        /// <summary>
        /// Gets the context instance.
        /// </summary>
        TContext Context { get; }

        /// <summary>
        /// Creates a context instance.
        /// </summary>
        void CreateContext();
    }
}
