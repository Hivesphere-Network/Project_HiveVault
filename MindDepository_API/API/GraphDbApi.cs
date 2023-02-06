﻿namespace MindDepository_API.API;
public static class GraphDbApi
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/api/graph/test", TestConnectionAsync)
            .WithName("GraphConnectionTest");
    }

    private static async Task<IResult> TestConnectionAsync()
    {
        // var result = await session.RunAsync("MATCH p=()-[:ACTED_IN]->() RETURN p
        // LIMIT 25;");
        return Results.Ok();
    }
}
