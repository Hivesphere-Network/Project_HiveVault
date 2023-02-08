namespace DataAccessLayer.Sql;

public interface ISqlQueryHandler {
  Task ExecuteAsync<T>(string query, T parameters,
                       string connectionId = "Default");
  Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters,
                                           string connectionId = "Default");
  Task SaveDataAsync<T>(string storedProcedure, T parameters,
                        string connectionId = "Default");
}