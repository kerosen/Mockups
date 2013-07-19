using MefCalcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MefCalcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var model = new CalculationSet();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Calculate(CalculationSet calculationSet)
        {
            if (Request.IsAjaxRequest())
            {
                var calculationService = calculationSet.GetCalculationService(calculationSet.submitAction);
                var result = calculationService.Calculate(calculationSet.Param1, calculationSet.Param2);

                return result.ToString();
            }

            return string.Empty;
        }

        public string Add1(int param1, int param2)
        {
            var result = param1 + param2;

            return result.ToString();
        }

        public string ExamineTextBox(string textBox1)
        {
            if (textBox1 != "Initial Data")
            {
                return "This text is MVC different from before!";
            }

            return String.Empty;
        }
    }
}
