using DataAccess;
using DataAccess.Contracts;
using Grpc.Core;
using Hive.Protocol;

namespace HiveVaultService.Services;

public class HiveNoSqlDataService : HiveNoSqlData.HiveNoSqlDataBase
{
    private INoSqlQueryHandler _repo = new NoSqlQueryHandler();
    public override Task<NosqlDataResponse> GetNoSqlData(NosqlDataRequest request, ServerCallContext context)
    {
        
        var response = _repo.LoadDataAsync(request.CollectionName, request.SearchKeyParameter, request.SearchKey);
        return base.GetNoSqlData(request, context);
    }
}

