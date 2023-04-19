using MongoDB.Bson;

namespace DataAccess.Contracts;


public interface INoSqlQueryHandler
{
    List<BsonDocument> LoadDataAsync(string collectionName, Dictionary<string, string> searchParameters);
    Task SaveDataAsync(string collectionName, BsonDocument document);
}
