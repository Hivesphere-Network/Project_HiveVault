namespace HiveVault_API.API;

public static class HealthApi
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/api/health", HealthCheckAsync).WithName("HealthCheck");
    }

    private static async Task<IResult> HealthCheckAsync() { return Results.Ok(); }
}
