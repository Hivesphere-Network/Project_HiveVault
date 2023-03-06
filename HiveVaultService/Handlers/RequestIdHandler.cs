namespace HiveVaultService.Handlers;

public static class RequestIdHandler
{
    private static readonly Guid[] RequestIds = new Guid[1000];
    
    public static string GetRequestId()
    {
        var guid = Guid.NewGuid();
        RequestIds.Append(guid);
        return guid.ToString();
    }
    
    public static bool IsRequestIdValid(string requestId)
    {
        return RequestIds.Contains(Guid.Parse(requestId));
    }
}