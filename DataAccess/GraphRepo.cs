using Neo4j.Driver;

namespace DataAccess;

public class GraphRepo : IDisposable
{
    private bool Disposed = false;
    private IDriver Driver;

    ~GraphRepo() => Dispose(false);

    public GraphRepo()
    {
        Driver = GraphDatabase.Driver("neo4j://localhost:7687", AuthTokens.Basic("neo4j", "mynewpass"));
    }

    public async Task<List<IRecord>> ExecuteAsync(string query)
    {
        await using var session = Driver.AsyncSession(builder => builder.WithDatabase("neo4j"));
        var Execute = await session.ExecuteReadAsync(async tx =>
        {
            var result = await tx.RunAsync(query).Result.ToListAsync();
            return result;
        });
        return Execute;
    }

    public async Task<IResultCursor> ExecuteWriteAsync(string query)
    {
        await using var session = Driver.AsyncSession(builder => builder.WithDatabase("neo4j"));
        var response = await session.ExecuteWriteAsync(async
            tx =>
            {
                var result = await tx.RunAsync(query);
                return result;
            });

        return response;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (Disposed) return;
        if (disposing) Driver?.Dispose();
        Disposed = true;
    }
}