namespace HiveVaultService.Handlers;

public static class HandshakeTokens
{
    private static Guid[] RequestIds = new Guid[1000];

    public static string GetToken()
    {
        var guid = Guid.NewGuid();
        RequestIds.Append(guid);
        return guid.ToString();
    }

    public static bool IsTokenValid(string requestId)
    {
        return RequestIds.Contains(Guid.Parse(requestId));
    }
}