using DataAccess.Contracts;
using Microsoft.Extensions.Configuration;
using Neo4j.Driver;

namespace DataAccess;

public class GraphQueryHandler : IGraphQueryHandler
{
    private readonly IAsyncSession? _session;
    private readonly IDriver Driver;
    public GraphQueryHandler()
    {
        string uri = "neo4j+s://a76c660c.databases.neo4j.io";
        string user = "neo4j";
        string password = "k4cXvrOkYZgBELLTUsWS-yR2c5WGAqF4rIu-BbXwe6w";
        Driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        _session = Driver.AsyncSession();
    }

    public void ExecuteQuery(string query)
    {
        _session?.RunAsync(query);
    }

    public string? ExecuteQueryWithReturn(string query)
    {
        var result = _session?.RunAsync(query);
        return result?.Result.SingleAsync().Result.Values.ToString();
    }
}
