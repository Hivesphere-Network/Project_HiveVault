using Neo4j.Driver;

namespace MindDepository.DB;

public class DatabaseHandler
{
    private IAsyncSession _graphSession;
    
    public DatabaseHandler()
    {
        ConnectNeo4j();
    }
    
    public GetSession()
    {
        return _graphSession;
    }
    
    private static void ConnectNeo4j()
    {
        try
        {
            var driver = GraphDatabase.Driver("b2369ae1.databases.neo4j.io:7687",
                AuthTokens.Basic("neo4j", "k4cXvrOkYZgBELLTUsWS-yR2c5WGAqF4rIu-BbXwe6w"));
            _graphSession = driver.AsyncSession();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}