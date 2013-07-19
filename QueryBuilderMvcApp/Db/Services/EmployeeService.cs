using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Services
{
    ////public System.DateTime BirthDate { get; set; }
    ////public string MaritalStatus { get; set; }
    ////public string Gender { get; set; }

    public class EmployeeService
    {
        public static List<Tuple<string,string>> GetEmployees(string filter1, string filter2)
        {
            using (var context = new AdventureWorksEntities())
            {
                var employeeSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<Employee>("Employees");


                Employee employee = new Employee();

                ObjectQuery<Employee> employees = employeeSet.Where("1=1");

                if (string.IsNullOrEmpty(filter1) == false)
                {
                    employees = employees.Where(filter1);
                }
                if (string.IsNullOrEmpty(filter2) == false)
                {
                    employees = employees.Where(filter2);
                }

                var list = from e in employees.ToList()
                           select Tuple.Create(e.Contact.FirstName, e.BirthDate.ToString());

                return new List<Tuple<string, string>>(list);
            }
        }
    }
}
