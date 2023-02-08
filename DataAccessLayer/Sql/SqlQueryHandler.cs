using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Sql;

public class SqlQueryHandler : ISqlQueryHandler {
  private readonly IConfiguration _config;

  public SqlQueryHandler(IConfiguration _config) { this._config = _config; }

  public Task ExecuteAsync<T>(string query, T parameters,
                              string connectionId = "Sql") {
    using IDbConnection dbConnection =
        new SqlConnection(_config.GetConnectionString(connectionId));

    var Result = dbConnection.QueryAsync(query, parameters);
    return Result;
  }

  public async Task<IEnumerable<T>>
  LoadDataAsync<T, TU>(string storedProcedure, TU parameters,
                       string connectionId = "Default") {
    using IDbConnection connection =
        new SqlConnection(_config.GetConnectionString(connectionId));

    return await connection.QueryAsync<T>(
        storedProcedure, parameters, commandType: CommandType.StoredProcedure);
  }

  public async Task SaveDataAsync<T>(string storedProcedure, T parameters,
                                     string connectionId = "Default") {
    using IDbConnection connection =
        new SqlConnection(_config.GetConnectionString(connectionId));

    await connection.ExecuteAsync(storedProcedure, parameters,
                                  commandType: CommandType.StoredProcedure);
  }
}