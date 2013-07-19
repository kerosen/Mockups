using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Utils
{
    static class QueryableExtensions
    {
        public static ObjectQuery<Employee> ContainsKeywords(this ObjectQuery<Employee> source, params string[] keywords)
        {
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                source = source.Where(string.Format("it.Contact.FirstName LIKE '%{0}%'", keyword));
            }

            return source;
        }
    }
}
