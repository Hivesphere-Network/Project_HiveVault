using Neo4j.Driver;

namespace DataAccess;

public class GraphRepo : IDisposable
{
    private bool Disposed = false;
    private IDriver Driver;
    
    ~GraphRepo() => Dispose(false);

    public GraphRepo()
    {
        Driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "FJSS4nPN4NZjwkv"));
    }

    public async Task ExecuteAsync(string query , string[] parameters)
    {
        await using var session = Driver.AsyncSession(builder => builder.WithDatabase("HiveVault"));
        try
        {
            Dictionary<string, string> paramObj = new Dictionary<string, string>();
            foreach (var param in parameters)
            {
                paramObj.Add(param, param);
            }

            var results = await session.ExecuteReadAsync(async tx =>
            {
                var result = await tx.RunAsync(query, paramObj);
                return await result.ToListAsync();
            });
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
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