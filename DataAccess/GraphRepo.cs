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
        var result = new List<IRecord>();
        try
        {
            await session.ExecuteReadAsync(async tx =>
            {
                result = await tx.RunAsync(query).Result.ToListAsync();
            });
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
        return result;
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