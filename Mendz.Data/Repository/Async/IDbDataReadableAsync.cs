using Mendz.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mendz.Data.Repository.Async
{
    /// <summary>
    /// Defines a database data that can be read asynchronously.
    /// </summary>
    /// <typeparam name="T">The model to read.</typeparam>
    public interface IDbDataReadableAsync<T>
    {
        /// <summary>
        /// Reads the model asynchronously.
        /// </summary>
        /// <param name="model">The model to read.</param>
        /// <param name="expansion">Additional data to use in the read operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The read model.</returns>
        Task<T> ReadAsync(T model, dynamic expansion = null, List<ResultInfo> result = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
