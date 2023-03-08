namespace DataAccess.Contracts;


public interface INoSqlQueryHandler
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string collectionName, U parameters);
    Task SaveDataAsync<T>(string collectionName, T parameters);
}
