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

    public List<BsonDocument> LoadDataAsync(string collectionName, string searchKeyParameter, string searchKey)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        
        var filter = Builders<BsonDocument>.Filter.Eq(searchKeyParameter, searchKey);

        return collection.FindAsync(filter).Result.ToList(); 
    }

    public async Task SaveDataAsync(string collectionName, BsonDocument document)
    {
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
