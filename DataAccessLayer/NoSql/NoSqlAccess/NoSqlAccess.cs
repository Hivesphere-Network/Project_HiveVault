namespace DataAccessLayer.NoSql.NoSqlAccess;

public class NoSqlAccess : INoSqlAccess
{
    public Task<IEnumerable<T>> LoadDataAsync<T, U>(string collectionName, U parameters)
    {
        throw new NotImplementedException();
    }

    public Task SaveDataAsync<T>(string collectionName, T parameters)
    {
        throw new NotImplementedException();
    }
}