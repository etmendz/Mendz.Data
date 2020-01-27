using System;
using System.Collections.Generic;

namespace Mendz.Data
{
    /// <summary>
    /// Provides the data setting options.
    /// </summary>
    /// <example>
    /// Given an appsettings.json entry as follows:
    /// 
    /// {
    ///     "DataSettings": {
    ///         "ConnectionStrings": {
    ///             "EntityFrameworkConnectionString" : "connection string for EF"
    ///             "SqlServerExpressConnectionString" : "connection string to Sql Server express (LocalDB)",
    ///             "SqlServerConnectionString" : "connection string to Sql Server",
    ///             "OracleConnectionString" : "connection string to Oracle",
    ///             "MongoDBClient" : "MongoDB client specification",
    ///             "MongoDBContext" : "MongoDB context specification"
    ///         }
    ///     }
    /// }
    /// 
    /// In StartUp.cs StartUp class constructor:
    /// 
    ///     public Startup(IConfiguration configuration)
    ///     {
    ///         Configuration = configuration;
    ///         DataSettingOptions.Initialize(Configuration.GetSection("DataSettings").Get<DataSettings>());
    ///     }
    /// </example>
    public static class DataSettingOptions
    {
        /// <summary>
        /// Gets the collection of named connection strings.
        /// </summary>
        public static Dictionary<string, string> ConnectionStrings { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Initializes from a DataSettings instance.
        /// </summary>
        /// <param name="dataSettings">The DataSettings instance.</param>
        public static void Initialize(DataSettings dataSettings)
        {
            if (dataSettings == null) throw new ArgumentNullException(nameof(dataSettings));
            foreach (var connectionString in dataSettings.ConnectionStrings)
            {
                ConnectionStrings.Add(connectionString.Key, connectionString.Value);
            }
        }
    }
}
