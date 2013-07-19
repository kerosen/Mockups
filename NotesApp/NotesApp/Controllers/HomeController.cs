using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var model = new NotesModel();

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

        public PartialViewResult Notes()
        {
            NotesList.AddNote();

            return PartialView(NotesList.Instance.Notes);
        }

        public PartialViewResult Note()
        {
            var model = new Note();

            ViewBag.EditMode = false;
            return PartialView(model);
        }


        public PartialViewResult EditNote(Guid id)
        {
            var model = NotesList.Instance.Notes.First(x => x.Id == id);
            ViewBag.EditMode = true;
            return PartialView("Note", model);
        }

        [HttpPost]
        public PartialViewResult EditNote(Note note)
        {
            var model = NotesList.Instance.Notes.First(x => x.Id == note.Id);

            NotesList.Instance.Notes.Remove(model);
            NotesList.AddNote(note);

            return PartialView("Notes", NotesList.Instance.Notes);
        }

        [HttpPost]
        public ActionResult AddNote(Note note)
        {
            if (ModelState.IsValid)
            {
                NotesList.AddNote(note);
                return PartialView("Notes", NotesList.Instance.Notes);
            }
            else
            {
                ViewBag.EditMode = false;
                return View("Note", note);
            }
        }
    }
}
