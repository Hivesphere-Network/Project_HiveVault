using System.Diagnostics;
using System.Numerics;
using DataAccess.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess;

public class NoSqlQueryHandler : INoSqlQueryHandler
{
    private const string ConnectionString = "mongodb://localhost:27017";
    private static IMongoDatabase? _database;
    public NoSqlQueryHandler()
    {
        _database = ConnectToServer();
    }

    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, string> searchParameters)
    {
        Debug.Assert(_database != null, nameof(_database) + " != null");
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        
        var filter = searchParameters.Aggregate(FilterDefinition<BsonDocument>.Empty, (current, searchParameter) => current | Builders<BsonDocument>.Filter.Eq(searchParameter.Key, searchParameter.Value));

        var debug_string = collection.FindAsync(filter).Result.ToList();
        return debug_string;
    }

    public async Task SaveDataAsync(string collectionName, BsonDocument document)
    {
        Debug.Assert(_database != null, nameof(_database) + " != null");
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        await collection.InsertOneAsync(document);
    }

    private static IMongoDatabase? ConnectToServer()
    {
        MongoClient client = new(ConnectionString);
        var database = client.GetDatabase("HiveVault");
        return database;
    }
}
