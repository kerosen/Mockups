using Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = new PersonService();
            var person = new Person("Certificat", "Escu");
            person.Certifications = new List<string>(new[] { "MCTS", "MCPD" });
            for (int i = 0; i < 10; i++)
            {
                person.LastName = string.Format("Escu{0}", i);
                var inserted = srv.InsertPerson(person);
            }

            var personFromDb = srv.GetPersons("Ion");
        }
    }
}
