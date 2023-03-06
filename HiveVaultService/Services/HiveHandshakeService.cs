using Grpc.Core;
using Hive.Protocol;
using HiveVaultService.Handlers;

namespace HiveVaultService.Services;

public class HiveHandshakeService : HiveHandshake.HiveHandshakeBase
{
    private IConfiguration config;
    public HiveHandshakeService(IConfiguration configuration)
    {
        config = configuration;
    }
    public override Task<HandshakeResponse> Handshake(HandshakeRequest request, ServerCallContext context)
    {
        string requestId = HandshakeTokens.GetToken();
        return Task.FromResult(new HandshakeResponse
        {
            ServerName = "HiveVaultService",
            ServerVersion = "0.1.0",
            ServerID = config["serverID"],
            HandshakeToken = requestId
        });
    }
}