using DataAccess;
using Grpc.Core;
using Hive.Protocol;

namespace HiveVaultService.Services;

public class HiveNoSqlDataService : HiveNoSqlData.HiveNoSqlDataBase
{
    public override Task<NosqlDataResponse> GetNoSqlData(NosqlDataRequest request, ServerCallContext context)
    {
        return base.GetNoSqlData(request, context);
    }
}

