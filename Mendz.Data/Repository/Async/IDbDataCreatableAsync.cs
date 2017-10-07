using Mendz.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mendz.Data.Repository.Async
{
    /// <summary>
    /// Defines a database data that can be created asynchronously.
    /// </summary>
    /// <typeparam name="T">The model to create.</typeparam>
    public interface IDbDataCreatableAsync<T>
    {
        /// <summary>
        /// Creates the model asynchronously.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <param name="expansion">Additional data to use in the create operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created model.</returns>
        Task<T> CreateAsync(T model, dynamic expansion = null, List<ResultInfo> result = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
