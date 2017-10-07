using Mendz.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mendz.Data.Repository.Async
{
    /// <summary>
    /// Defines a database data that can be deleted asynchronously.
    /// </summary>
    /// <typeparam name="T">The model to delete.</typeparam>
    public interface IDbDataDeletableAsync<T>
    {
        /// <summary>
        /// Deletes the model asynchronously.
        /// </summary>
        /// <param name="model">The model to delete.</param>
        /// <param name="expansion">Additional data to use in the delete operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted model.</returns>
        Task<T> DeleteAsync(T model, dynamic expansion = null, List<ResultInfo> result = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
