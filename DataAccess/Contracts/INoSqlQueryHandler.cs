using MongoDB.Bson;

namespace DataAccess.Contracts;

public interface INoSqlQueryHandler
{
    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, string> stringParameters, Dictionary<string, long> intParameters);
    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, string> stringParameters);
    public List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, long> intParameters);

    Task SaveDataAsync(string collectionName, BsonDocument document);
}
