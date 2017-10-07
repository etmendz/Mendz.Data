using Mendz.Data;
using System.Collections.Generic;

namespace Mendz.Data.Repository
{
    /// <summary>
    /// Defines a database data that can be searched.
    /// </summary>
    /// <typeparam name="T">The model to search.</typeparam>
    public interface IDbDataSearchable<T>
    {
        /// <summary>
        /// Searches the model.
        /// </summary>
        /// <typeparam name="F">The filter type.</typeparam>
        /// <typeparam name="S">The sort type.</typeparam>
        /// <param name="filter">The filter keys.</param>
        /// <param name="sort">The sort keys.</param>
        /// <param name="expansion">Additional data to use in the search operation.</param>
        /// <param name="paging">The PagingInfo.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <returns>The enumerable result of models found.</returns>
        IEnumerable<T> Search<F, S>(F filter, S sort, dynamic expansion = null, 
            PagingInfo paging = null, List<ResultInfo> result = null);
    }
}
