namespace Mendz.Data.Common
{
    /// <summary>
    /// Defines a database context.
    /// </summary>
    /// <typeparam name="C">The context type.</typeparam>
    public interface IDbDataContext<C>
    {
        /// <summary>
        /// Gets the context instance.
        /// </summary>
        C Context { get; }

        /// <summary>
        /// Creates a context instance.
        /// </summary>
        void CreateContext();
    }
}
