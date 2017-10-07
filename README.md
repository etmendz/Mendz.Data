# Mendz.Data
Provides tools and guidance for creating data access contexts and repositories.
## Namespaces
Mendz.Data
### Contents
Name | Description
---- | -----------
DataSettings | Represents a DataSettings configuration.
DataSettingOptions | Provides the data setting options.
PagingInfo | Represents paging information.
ResultInfo | Represents a result information.
Mendz.Data.Common
Name | Description
---- | -----------
IDbDataContext | Defines a database context.
DbDataContextBase | The base implementation of IDbDataContext.
DbRepositoryBase | The base repository.
EndTransactionMode | Enumerates the modes to end a transaction: to commit or to rollback.
ResultInfoExtensions | Provides extenstions to ResultInfo.
Mendz.Data.Repository
Name | Description
---- | -----------
IDbDataCreatable | Defines a database data that can be created.
IDbDataReadable | Defines a database data that can be read.
IDbDataUpdatable | Defines a database data that can be updated.
IDbDataDeletable | Defines a database data that can be deleted.
IDbDataSearchable | Defines a database data that can be searched.
DbRepositoryException | Represents a repository exception.
Mendz.Data.Repository.Async
Name | Description
---- | -----------
IDbDataCreatableAsync | Defines a database data that can be created asynchronously.
IDbDataReadableAsync | Defines a database data that can be read asynchronously.
IDbDataUpdatableAsync | Defines a database data that can be updated asynchronously.
IDbDataDeletableAsync | Defines a database data that can be deleted asynchronously.
IDbDataSearchableAsync | Defines a database data that can be searched asynchronously.
## NuGet It...
https://www.nuget.org/packages/Mendz.Data/
