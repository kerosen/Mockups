using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class PersonService
    {
        private string connectionString;
        private string databaseName;
        private string collectionName;

        public PersonService()
        {
            connectionString = "mongodb://localhost";
            databaseName = "test";
            collectionName = "persons";
        }

        public Person GetPersons(string firstName)
        {
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            var db = mongoServer.GetDatabase(databaseName);

            var persons = db.GetCollection<Person>(collectionName);

            var personsQuery = Query<Person>.EQ(p => p.FirstName, firstName);
            var foundPerson = persons.FindOne(personsQuery);

            var mctsQuery = Query<Person>.Where(p => p.Certifications.Contains("MCTS"));
            var personsCursor = persons.Find(mctsQuery);
            IEnumerable<Person> enumerable = (IEnumerable<Person>)personsCursor;

            return foundPerson;
        }

        public bool InsertPerson(Person person)
        {
            try
            {
                var mongoClient = new MongoClient(connectionString);
                var mongoServer = mongoClient.GetServer();
                var db = mongoServer.GetDatabase(databaseName);

                var persons = db.GetCollection<Person>(collectionName);

                var document = new BsonDocument {
                    { "firstName", person.FirstName },
                    { "lastName", person.LastName },
                    { "certifications", new BsonArray(person.Certifications) }
                };

                var result = persons.Insert(document);

                //var personsQuery = Query<Person>.EQ(p => p.FirstName, firstName);
                //var insertedPerson = persons.Insert(person);// (personsQuery);

                return result.Ok;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            return false;
        }
    }
}
