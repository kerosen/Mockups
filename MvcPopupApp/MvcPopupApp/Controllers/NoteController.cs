using MvcPopupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPopupApp.Controllers
{
    public class NoteController : Controller
    {

        public ActionResult Index()
        {

            return View();

        }



        public ActionResult List()
        {

            var manager = new NoteManager();

            var model = manager.GetAll();

            return PartialView(model);

        }



        public ActionResult Create()
        {

            var model = new Note();

            return PartialView("NoteForm", model);

        }



        [HttpPost]

        public ActionResult Save(Note note)
        {

            var manager = new NoteManager();

            manager.Save(note);

            var model = manager.GetAll();

            return PartialView("List", model);

        }

    }
}
