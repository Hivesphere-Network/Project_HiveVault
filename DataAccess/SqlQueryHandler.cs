﻿using System.Data;
using Dapper;
using DataAccess.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class SqlQueryHandler : ISqlQueryHandler
{
    private readonly IConfiguration _config;

    public SqlQueryHandler(IConfiguration config)
    {
        this._config = config;
    }

    public Task ExecuteAsync<T>(string query, T parameters, string connectionId = "Sql")
    {
        using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString(connectionId));

        var result = dbConnection.QueryAsync(query, parameters);
        return result;
    }

    public async Task<IEnumerable<T>>
    LoadDataAsync<T, TU>(string storedProcedure, TU parameters, string connectionId = "Sql")
    {
        using IDbConnection connection =
            new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(
            storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Sql")
    {
        using IDbConnection connection =
            new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
