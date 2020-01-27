using System;
using System.Data;
using System.Data.Common;

namespace Mendz.Data.Common
{
    /// <summary>
    /// Provides extenstions to ResultInfo.
    /// </summary>
    public static class ResultInfoExtensions
    {
        /// <summary>
        /// Sets the input values.
        /// </summary>
        /// <param name="result">The ResultInfo instance.</param>
        /// <param name="parameters">The parameters to evaluate.</param>
        public static void SetInputValues(this ResultInfo result, DbParameterCollection parameters)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            foreach (DbParameter parameter in parameters)
            {
                if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
                {
                    if (!result.InputValues.ContainsKey(parameter.ParameterName)) result.InputValues.Add(parameter.ParameterName, parameter.Value);
                }
            }
        }

        /// <summary>
        /// Sets the output values.
        /// </summary>
        /// <param name="result">The ResultInfo instance.</param>
        /// <param name="parameters">The parameters to evaluate.</param>
        public static void SetOutputValues(this ResultInfo result, DbParameterCollection parameters, string affectedCountName = null, string totalCountName = null)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            string parameterName;
            object parameterValue;
            foreach (DbParameter parameter in parameters)
            {
                if (parameter.Direction != ParameterDirection.Input)
                {
                    parameterName = parameter.ParameterName;
                    parameterValue = parameter.Value;
                    if (!string.IsNullOrEmpty(affectedCountName) && parameterName == affectedCountName)
                    {
                        result.AffectedCount = (int)parameterValue;
                    }
                    else if (!string.IsNullOrEmpty(totalCountName) && parameterName == totalCountName)
                    {
                        result.TotalCount = (int)parameterValue;
                    }
                    else if (!result.OutputValues.ContainsKey(parameterName))
                    {
                        result.OutputValues.Add(parameterName, parameterValue);
                    }
                }
            }
        }
    }
}
