using System.Collections.Generic;

namespace Mendz.Data
{
    /// <summary>
    /// Represents a DataSettings configuration.
    /// </summary>
    /// <remarks>
    /// Use as POCO when deserializing a configuration's DataSettings section.
    /// Can be used to initialize DataSettingOptions.
    /// Can be used in Options model/pattern.
    /// </remarks>
    /// <example>
    /// Given an appsettings.json entry as follows:
    /// 
    /// {
    ///     "DataSettings": {
    ///         "ConnectionStrings": {
    ///             "SqlServerExpressConnectionString" : "connection string to Sql Server express (LocalDB)",
    ///             "SqlServerConnectionString" : "connection string to Sql Server",
    ///             "OracleConnectionString" : "connection string to Oracle",
    ///             "MongoDBClient" : "MongoDB client specification"
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
    public class DataSettings
    {
        /// <summary>
        /// The collection of named connection strings.
        /// </summary>
        public Dictionary<string, string> ConnectionStrings { get; set; }
    }
}
