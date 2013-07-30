using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Db
{
    [BsonIgnoreExtraElements]
    public class Person : MongoEntity
    {
        [BsonElement("firstName")]
        [BsonRepresentation(BsonType.String)]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("certifications")]
        public List<string> Certifications { get; set; }

        public Person()
        {
            Certifications = new List<string>();
        }

        public Person(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
