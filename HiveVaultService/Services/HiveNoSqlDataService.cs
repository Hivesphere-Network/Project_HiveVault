using DataAccess;
using DataAccess.Contracts;
using Grpc.Core;
using Hive.Protocol;

namespace HiveVaultService.Services;

public class HiveNoSqlDataService : HiveNoSqlData.HiveNoSqlDataBase
{
    private INoSqlQueryHandler _repo = new NoSqlQueryHandler();
    public override async Task<NosqlDataResponse> GetNoSqlData(NosqlDataRequest request, ServerCallContext context)
    {
        var response = _repo.LoadDataAsync(request.Collection, request.Key, request.Value);
        return await Task.FromResult(new NosqlDataResponse
        {
            Value = response.First().ToString()
        });
    }
}

