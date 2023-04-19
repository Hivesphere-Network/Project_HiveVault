using DataAccess;
using DataAccess.Contracts;
using Grpc.Core;
using Hive.Protocol;
using MongoDB.Bson;

namespace HiveVaultService.Services;

public class HiveNoSqlDataService : HiveNoSqlData.HiveNoSqlDataBase
{
    private readonly INoSqlQueryHandler _repo = new NoSqlQueryHandler();
    public override async Task<SingleDataReadResponse> GetSingleData(DataReadRequest request, ServerCallContext context)
    {
        Dictionary<string, string> searchParameters = request.Key.ToList().ToDictionary(key => key, key => request.Value.ToArray()[request.Key.ToList().IndexOf(key)]);
        var response = _repo.LoadDataAsync(request.Collection, searchParameters);
        return await Task.FromResult(new SingleDataReadResponse
        {
            Value = response.First().ToString()
        });
    }
    
    public override async Task<MultiDataReadResponse> GetMultiData(DataReadRequest request, ServerCallContext context)
    {
        Dictionary<string, string> searchParameters = request.Key.ToList().ToDictionary(key => key, key => request.Value.ToArray()[request.Key.ToList().IndexOf(key)]);
        var response = _repo.LoadDataAsync(request.Collection, searchParameters);
        return await Task.FromResult(new MultiDataReadResponse
        {
            Value = { response.Select(x => x.ToString()) }
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

