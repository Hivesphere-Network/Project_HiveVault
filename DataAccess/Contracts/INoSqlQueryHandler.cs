using MongoDB.Bson;

namespace DataAccess.Contracts;


public interface INoSqlQueryHandler
{
    List<BsonDocument> LoadDataAsync(string collectionName, string searchKeyParameter, string searchKey);
    Task SaveDataAsync(string collectionName, BsonDocument document);
}
