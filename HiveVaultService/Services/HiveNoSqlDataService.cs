using DataAccess;
using DataAccess.Contracts;
using Grpc.Core;
using Hive.Protocol;
using MongoDB.Bson;

namespace HiveVaultService.Services;

public class HiveNoSqlDataService : HiveNoSqlData.HiveNoSqlDataBase
{
    private readonly INoSqlQueryHandler _repo = new NoSqlQueryHandler();
    public override async Task<SingleDataReadResponse> GetSingleData(SingleDataReadRequest request, ServerCallContext context)
    {
        var response = _repo.LoadDataAsync(request.Collection, request.Key, request.Value);
        return await Task.FromResult(new SingleDataReadResponse
        {
            Value = response.First().ToString()
        });
    }
    
    public override async Task<SingleDataWriteResponse> SetSingleData(SingleDataWriteRequest request, ServerCallContext context)
    {
        BsonDocument document = new();
        string[] keys = request.Key.ToArray();
        string[] values = request.Value.ToArray();
        foreach (string? key in keys)
        {
            document.Add(key, values[keys.ToList().IndexOf(key)]);
        }
        var response = _repo.SaveDataAsync(request.Collection, document);
        return await Task.FromResult(new SingleDataWriteResponse
        {
            Status = "Complete"
        });
    }
}

