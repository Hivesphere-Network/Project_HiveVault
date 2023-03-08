using DataAccess;
using Grpc.Core;
using Hive.Protocol;
using Neo4j.Driver;

namespace HiveVaultService.Services;

public class HiveGraphDataService : HiveGraphData.HiveGraphDataBase
{
    private readonly GraphRepo _repo = new();

    public override async Task<GetGraphResponse> GetGraphData(GetGraphRequest request, ServerCallContext context)
    {
        string[] array = request.Parameter.ToArray();
        string query = string.Format(request.Query, array[0]);

        var response = await _repo.ExecuteAsync(query);

        string? node = response.First()["node"].As<INode>().Properties["name"].As<string>();

        return await Task.FromResult(new GetGraphResponse
        {
            Response = node
        });
    }

    public override async Task<WriteGraphResponse> WriteGraphData(WriteGraphRequest request, ServerCallContext context)
    {
        string[] array = request.Parameter.ToArray();
        string query = string.Format(request.Query, array[0]);

        var response = await _repo.ExecuteWriteAsync(query);

        return await Task.FromResult(new WriteGraphResponse
        {
            Response = response.ConsumeAsync().Result.ToString()
        });
    }
}