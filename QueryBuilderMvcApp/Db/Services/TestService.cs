using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Utils;

namespace Db.Services
{
    public class TestService
    {
        public static void Test()
        {
            TestQueryBuilder();
            TestQuerySQLString();
            TestLinqToEntities();
        }

        private static void TestQueryBuilder()
        {
            using (var context = new AdventureWorksEntities())
            {
                var customerSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<Employee>("Employees");
                //ObjectQuery<SaleAd> adQuery = ((IObjectContextAdapter) context).ObjectContext.CreateQuery<SaleAd>(queryString, paramList) );

                var customers = customerSet
                    .Where("it.Gender = @gender", new ObjectParameter("gender", "F"))
                    .ContainsKeywords("A", "i")
                    .OrderBy("it.Contact.FirstName");

                var lis = customers.ToList();
            }
        }

        private static void TestQuerySQLString()
        {
            string query = //@"SELECT [Extent1].[AccountNumber] AS [AccountNumber] FROM [Sales].[Customer] AS [Extent1] WHERE [Extent1].[AccountNumber] like '%3%'";// WHERE Customers.UserName = @username AND Customers.Password = @password";
                @"SELECT [Extent1].[EmployeeID] AS [EmployeeID] FROM [HumanResources].[Employee] AS [Extent1] WHERE [Extent1].[Gender] like '%M%'";// WHERE Customers.UserName = @username AND Customers.Password = @password";
            using (var context = new AdventureWorksEntities())
            {
                IEnumerable<int> results = context.Database.SqlQuery<int>(query);

                var lis = results.ToList();
            }
        }

        private static void TestLinqToEntities()
        {
            using (var context = new AdventureWorksEntities())
            {
                var customers = from e in context.Employees.Where(p => p.Contact.FirstName.Contains(""))
                                from c in context.Contacts
                                where e.ContactID == c.ContactID
                                select new { DateOfBirth = e.BirthDate, Name = c.FirstName};

                var lis = customers.ToList();
            }
        }
    }
}
