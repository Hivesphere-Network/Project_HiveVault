namespace MindDepository.API;

public static class GraphDbApi
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/api/graph/test", TestConnection).WithName("GraphConnectionTest");
    }

    private static  async Task<IResult> TestConnection()
    {
        return Results.Ok();
    }
}