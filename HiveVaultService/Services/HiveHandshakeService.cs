using Grpc.Core;
using Hive.Protocol;

namespace HiveVaultService.Services;

public class HiveHandshakeService : HiveHandshake.HiveHandshakeBase
{
    public override Task<HandshakeResponse> Handshake(HandshakeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HandshakeResponse
        {
            // Message = "Hello " + request.Name
        });
    }
}