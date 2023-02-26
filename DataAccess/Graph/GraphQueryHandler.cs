using Neo4j.Driver;

namespace DataAccess.Graph;

public sealed class GraphQueryHandler : IGraphQueryHandler, IDisposable
{
    private readonly IDriver _driver;

    public GraphQueryHandler(string uri, string user, string password)
    {
        _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
    }
    
    public void ExecuteQuery(string query)
    {
        using var session = _driver.AsyncSession();
        session.RunAsync(query);
    }
    
    public void Dispose()
    {
        _driver.Dispose();
        GC.SuppressFinalize(this);
    }
}
