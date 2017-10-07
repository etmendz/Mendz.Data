using Mendz.Data;
using System.Collections.Generic;

namespace Mendz.Data.Repository
{
    /// <summary>
    /// Defines a database data that can be updated.
    /// </summary>
    /// <typeparam name="T">The model to update.</typeparam>
    public interface IDbDataUpdatable<T>
    {
        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="model">The model to update.</param>
        /// <param name="expansion">Additional data to use in the update operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <returns>The updated model.</returns>
        T Update(T model, dynamic expansion = null, List<ResultInfo> result = null);
    }
}
