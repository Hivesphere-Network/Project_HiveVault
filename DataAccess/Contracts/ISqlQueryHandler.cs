namespace DataAccess.Contracts;

public interface ISqlQueryHandler
{
    Task ExecuteAsync<T>(string query, T parameters, string connectionId = "Sql");
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Sql");
    Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Sql");
}
