# Mendz.Data
Provides tools and guidance for creating data access contexts and repositories.
## Implementations
* [Mendz.Data.EntityFramework](https://github.com/etmendz/Mendz.Data.EntityFramework)
* [Mendz.Data.SqlServer](https://github.com/etmendz/Mendz.Data.SqlServer)
* Mendz.Data.MongoDB (coming soon...)
## Namespaces
### Mendz.Data
#### Contents
Name | Description
---- | -----------
DataSettings | Represents a DataSettings configuration.
DataSettingOptions | Provides the data setting options.
PagingInfo | Represents paging information.
ResultInfo | Represents a result information.
#### DataSettings and DataSettingOptions
Microsoft recommends the Options model/pattern to take advantage of dependency injection native to .Net Core applications. The DataSettings and DataSettingOptions are alternatives to initializing connection strings and data settings. By simply taking advantage of the simple fact that DataSettingOptions is a static class, its values are available anywhere in the application domain/runtime. Thus, given the assumption that DataSettingOptions will be initialized at application startup, you can write class libraries that consume DataSettingOptions for data connection and setting needs.

DataSettings and DataSettingOptions, therefore, assumes that appsettings.json contains an entry/section for DataSettings.
```JSON
{
    "DataSettings": {
        "ConnectionStrings": {
            "EntityFrameworkConnectionString" : "connection string for entity framework DbContext instance",
            "SqlServerConnectionString" : "connection string to Sql Server",
            "SqlServerExpressConnectionString" : "connection string to Sql Server express (LocalDB)",
            "OracleConnectionString" : "connection string to Oracle",
            "MongoDBClient" : "MongoDB client specification",
            "MongoDBContext" : "MongoDB context specification"
        }
    }
}
```
In the application startup or initialization routine, the DataSettings should be loaded into DataSettingOptions as follows:
```C#
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataSettingOptions.Initialize(Configuration.GetSection("DataSettings").Get<DataSettings>());
        }
```
From this point onwards, DataSettingOptions contains the collection of connection strings that may be needed by the application or by its Mendz.Data-aware class libraries.

Let's say for example that you have a DbContext class library project. To make it Mendz.Data-aware, just reference Mendz.Data and implement the OnConfiguring override as follows:
```C#
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DataSettingOptions.ConnectionStrings["EntityFrameworkConnectionString"]);
        }
```
This approach makes the DbContext instance semi-self-initializing. It also removes the need for the DbContext instance to be registered in the application's Startup.ConfigureServices -- usually done via call to IServiceCollection.AddDbContext(). Thus, the application does not even need to be aware of the DbContext instance itself. Using Mendz.Data, it is possible for the application to reference only the models and repositories libraries, shielding the application from being bound to specific data contexts.
### Mendz.Data.Common
#### Contents
Name | Description
---- | -----------
IDbDataContext | Defines a database context.
DbDataContextBase | The base implementation of IDbDataContext.
DbRepositoryBase | The base repository.
EndTransactionMode | Enumerates the modes to end a transaction: to commit or to rollback.
ResultInfoExtensions | Provides extenstions to ResultInfo.
#### DbRepositoryBase
Mendz.Data-aware repositories implement DbRepositoryBase. Note that this base class expects a Mendz.Data-aware data context. For example, using Mendz.Data.SqlServer.SqlServerDbDataContext, a generic Mendz.Data-aware context for ADO.Net-compatible access to SQL Server databases, a repository skeleton can look like the following:
```C#
    public class TestRepository : DbRepositoryBase<SqlServerDbDataContext>, IDbDataSearchable<Test>
    {
        public IEnumerable<Test> Search<F, S>(F filter, S sort, dynamic expansion = null, PagingInfo paging = null, List<ResultInfo> result = null)
        {
            ...
        }
    }
```
Which can be used, for example, in an ASP.NET MVC application's controller code as follows:
```C#
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(int id)
        {
            using (TestRepository testRepository = new TestRepository())
            {
                return View(testRepository.Search<int, object>(id, null));
            }
        }
    }
```
### Mendz.Data.Repository
#### Contents
Name | Description
---- | -----------
IDbDataCreatable | Defines a database data that can be created.
IDbDataReadable | Defines a database data that can be read.
IDbDataUpdatable | Defines a database data that can be updated.
IDbDataDeletable | Defines a database data that can be deleted.
IDbDataSearchable | Defines a database data that can be searched.
DbRepositoryException | Represents a repository exception.

Unlike other "repository pattern" implementations that put all CRUDS (Create, Read, Update, Delete and Search) methods in a single repository interface, Mendz.Data.Repository defines each CRUDS method as individual interfaces. This allows for greater flexibility when creating repositories that work on models that may not need full CRUDS scaffolding. For example, immutable models can be created, read, deleted or searched but cannot be updated. Another example, readonly models can only be read or searched but cannot be created, updated or deleted.
### Mendz.Data.Repository.Async
#### Contents
Name | Description
---- | -----------
IDbDataCreatableAsync | Defines a database data that can be created asynchronously.
IDbDataReadableAsync | Defines a database data that can be read asynchronously.
IDbDataUpdatableAsync | Defines a database data that can be updated asynchronously.
IDbDataDeletableAsync | Defines a database data that can be deleted asynchronously.
IDbDataSearchableAsync | Defines a database data that can be searched asynchronously.

The Mendz.Data.Repository CRUDS interfaces have async versions in Mendz.Data.Repository.Async namespace. They are very similar in many ways, with the async versions adding the ability/option to pass cancellation tokens.
## NuGet It...
https://www.nuget.org/packages/Mendz.Data/
