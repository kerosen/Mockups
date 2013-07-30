using MongoDB.Bson;

namespace Db
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
