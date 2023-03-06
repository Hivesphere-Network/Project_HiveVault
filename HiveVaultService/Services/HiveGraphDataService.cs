using DataAccess;
using Grpc.Core;
using Hive.Protocol;
using HiveVaultService.Handlers;
using Neo4j.Driver;

namespace HiveVaultService.Services;

public class HiveGraphDataService : HiveGraphData.HiveGraphDataBase
{
    public override async Task<GetGraphResponse> GetGraphData(GetGraphRequest request, ServerCallContext context)
    {
        var repo = new GraphRepo();

        List<IRecord> response = await repo.ExecuteAsync(request.Query);

        var re = response.First()["node"].As<INode>().Properties["name"].As<string>();
        
        return await Task.FromResult(new GetGraphResponse
        {
            Response = re
        });
    }
}