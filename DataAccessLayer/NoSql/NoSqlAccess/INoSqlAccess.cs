namespace DataAccessLayer.NoSql.NoSqlAccess;

// MongoDB Access

public interface INoSqlAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string collectionName, U parameters);
    Task SaveDataAsync<T>(string collectionName, T parameters);
    
}