using System.Collections.Generic;

namespace Mendz.Data
{
    /// <summary>
    /// Represents a result information.
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// Gets or sets the source name.
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// Gets or sets the input values.
        /// </summary>
        public Dictionary<string, object> InputValues { get; set; }

        /// <summary>
        /// Gets or sets the output values.
        /// </summary>
        public Dictionary<string, object> OutputValues { get; set; }

        /// <summary>
        /// Gets or sets a count of affected data.
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// Gets or sets a count of total data read/passed.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets a list of result information.
        /// </summary>
        /// <remarks> This is useful in sequential, transactional and/or nested operations.</remarks>
        public List<List<ResultInfo>> ResultInfos { get; set; } = new List<List<ResultInfo>>();

        /// <summary>
        /// Initializes a ResultInfo.
        /// </summary>
        /// <param name="sourceName">The source name.</param>
        /// <param name="inputValues">The input values.</param>
        /// <param name="outputValues">The output values.</param>
        /// <param name="affectedCount">The count of affected data.</param>
        /// <param name="totalCount">The total count of data read/passed.</param>
        public ResultInfo(string sourceName, Dictionary<string, object> inputValues, Dictionary<string, object> outputValues, int affectedCount = 0, int totalCount = 0)
        {
            SourceName = sourceName;
            InputValues = inputValues;
            OutputValues = outputValues;
            AffectedCount = affectedCount;
        }

        /// <summary>
        /// Initializes a ResultInfo.
        /// </summary>
        /// <param name="sourceName">The source name.</param>
        /// <param name="outputValues">The output values.</param>
        /// <param name="affectedCount">The count of affected data.</param>
        /// <param name="totalCount">The total count of data read/passed.</param>
        public ResultInfo(string sourceName, Dictionary<string, object> outputValues, int affectedCount = 0, int totalCount = 0)
            : this(sourceName, null, outputValues, affectedCount, totalCount)
        {
        }

        /// <summary>
        /// Initializes a ResultInfo.
        /// </summary>
        /// <param name="sourceName">The source name.</param>
        /// <param name="affectedCount">The count of affected data.</param>
        /// <param name="totalCount">The total count of data read/passed.</param>
        public ResultInfo(string sourceName, int affectedCount, int totalCount = 0)
            : this(sourceName, null, null, affectedCount, totalCount)
        {
        }
    }
}
