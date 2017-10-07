using Mendz.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mendz.Data.Repository.Async
{
    /// <summary>
    /// Defines a database data that can be searched asynchronously.
    /// </summary>
    /// <typeparam name="T">The model to search.</typeparam>
    public interface IDbDataSearchableAsync<T>
    {
        /// <summary>
        /// Searches the model asynchronously.
        /// </summary>
        /// <typeparam name="F">The filter type.</typeparam>
        /// <typeparam name="S">The sort type.</typeparam>
        /// <param name="filter">The filter keys.</param>
        /// <param name="sort">The sort keys.</param>
        /// <param name="expansion">Additional data to use in the search operation.</param>
        /// <param name="paging">The PagingInfo.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The enumerable result of models found.</returns>
        Task<IEnumerable<T>> SearchAsync<F, S>(F filter, S sort, dynamic expansion = null,
            PagingInfo paging = null, List<ResultInfo> result = null, 
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
