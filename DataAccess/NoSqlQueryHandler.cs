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

    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, string> stringParameters, Dictionary<string, long> intParameters)
    {
        Debug.Assert(_database != null, nameof(_database) + " != null");
        var collection = _database.GetCollection<BsonDocument>(collectionName);

        var filter = FilterDefinition<BsonDocument>.Empty;
        foreach (var parameter in stringParameters)
        {
            filter &= Builders<BsonDocument>.Filter.Eq(parameter.Key, parameter.Value);
        }

        foreach (var parameter in intParameters)
        {
            filter &= Builders<BsonDocument>.Filter.Eq(parameter.Key, parameter.Value);
        }
        var result_list = collection.FindAsync(filter).Result.ToList();
        return result_list;
    }

    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, string> stringParameters)
    {
        Debug.Assert(_database != null, nameof(_database) + " != null");
        var collection = _database.GetCollection<BsonDocument>(collectionName);

        var filter = FilterDefinition<BsonDocument>.Empty;
        foreach (var parameter in stringParameters)
        {
            filter &= Builders<BsonDocument>.Filter.Eq(parameter.Key, parameter.Value);
        }
        var result_list = collection.FindAsync(filter).Result.ToList();
        return result_list;
    }

    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, long> intParameters)
    {
        Debug.Assert(_database != null, nameof(_database) + " != null");
        var collection = _database.GetCollection<BsonDocument>(collectionName);

        var filter = FilterDefinition<BsonDocument>.Empty;
        foreach (var parameter in intParameters)
        {
            filter &= Builders<BsonDocument>.Filter.Eq(parameter.Key, parameter.Value);
        }
        var result_list = collection.FindAsync(filter).Result.ToList();
        return result_list;
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
