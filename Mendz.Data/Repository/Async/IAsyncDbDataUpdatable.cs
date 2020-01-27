using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mendz.Data.Repository.Async
{
    /// <summary>
    /// Defines a database data that can be updated asynchronously.
    /// </summary>
    /// <typeparam name="T">The model to update.</typeparam>
    public interface IAsyncDbDataUpdatable<T>
    {
        /// <summary>
        /// Updates the model asynchronously.
        /// </summary>
        /// <param name="model">The model to update.</param>
        /// <param name="expansion">Additional data to use in the update operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model.</returns>
        Task<T> UpdateAsync(T model, dynamic expansion = null, List<ResultInfo> result = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
