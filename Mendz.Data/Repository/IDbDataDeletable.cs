using Mendz.Data;
using System.Collections.Generic;

namespace Mendz.Data.Repository
{
    /// <summary>
    /// Defines a database data that can be deleted.
    /// </summary>
    /// <typeparam name="T">The model to delete.</typeparam>
    public interface IDbDataDeletable<T>
    {
        /// <summary>
        /// Deletes the model.
        /// </summary>
        /// <param name="model">The model to delete.</param>
        /// <param name="expansion">Additional data to use in the delete operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <returns>The deleted model.</returns>
        T Delete(T model, dynamic expansion = null, List<ResultInfo> result = null);
    }
}
