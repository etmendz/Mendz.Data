using Mendz.Data;
using System.Collections.Generic;

namespace Mendz.Data.Repository
{
    /// <summary>
    /// Defines a database data that can be created.
    /// </summary>
    /// <typeparam name="T">The model to create.</typeparam>
    public interface IDbDataCreatable<T>
    {
        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <param name="expansion">Additional data to use in the create operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <returns>The created model.</returns>
        T Create(T model, dynamic expansion = null, List<ResultInfo> result = null);
    }
}
