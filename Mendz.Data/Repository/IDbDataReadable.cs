using Mendz.Data;
using System.Collections.Generic;

namespace Mendz.Data.Repository
{
    /// <summary>
    /// Defines a database data that can be read.
    /// </summary>
    /// <typeparam name="T">The model to read.</typeparam>
    public interface IDbDataReadable<T>
    {
        /// <summary>
        /// Reads the model.
        /// </summary>
        /// <param name="model">The model to read.</param>
        /// <param name="expansion">Additional data to use in the read operation.</param>
        /// <param name="result">The list of ResultInfo.</param>
        /// <returns>The read model.</returns>
        T Read(T model, dynamic expansion = null, List<ResultInfo> result = null);
    }
}
