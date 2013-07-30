using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Db
{
    public class MongoEntity : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
