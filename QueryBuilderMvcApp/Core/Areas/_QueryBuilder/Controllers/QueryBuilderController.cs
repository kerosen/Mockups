using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Areas.QueryBuilder.Models;

namespace Core.Areas.QueryBuilder.Controllers
{
    public class QueryBuilderController : Controller
    {
        public ViewResult Index()
        {
            var model = new QueryBuilderModel();

            return View(model);
        }

        public ActionResult List(string filter1, string filter2)
        {
            var model = new QueryBuilderModel();
            //model.ProcessQuery();
            model.FilterEmployees(filter1, filter2);

           return View(model);
        }
    }
}
