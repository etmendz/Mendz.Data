namespace Mendz.Data.Common
{
    /// <summary>
    /// Enumerates the modes to end a transaction: to commit or to rollback.
    /// </summary>
    public enum EndTransactionMode
    {
        /// <summary>
        /// Ends a transaction by rolling back all changes.
        /// </summary>
        Rollback,
        /// <summary>
        /// Ends a transaction by commiting all changes.
        /// </summary>
        Commit
    }
}
