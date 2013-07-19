using Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueryBuilder.Models
{
    public class QueryBuilderModel
    {
        public string Filter1 { get; set; }
        public string Filter2 { get; set; }

        public List<Tuple<string, string>> Data { get; set; }

        public QueryBuilderModel()
        {
            Data = new List<Tuple<string, string>>();
            Filter1 = "it.Gender like '%F%'";
            Filter2 = "it.Contact.FirstName like 'A%'";
        }

        public QueryBuilderModel(string filter1, string filter2)
            : this()
        {
            Filter1 = filter1;
            Filter2 = filter2;
        }

        public void ProcessQuery()
        {
            Data.Clear();

            Data.Add(new Tuple<string,string>("unu", "descriere unu"));
            Data.Add(new Tuple<string, string>("doi", "descriere doi"));
        }

        public void FilterEmployees(string filter1, string filter2)
        {
            var employees = EmployeeService.GetEmployees(filter1, filter2);
            Data = employees;
        }
        
    }
}