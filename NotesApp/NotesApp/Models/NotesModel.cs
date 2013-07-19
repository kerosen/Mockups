using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesApp.Models
{
    public class NotesModel
    {
        public NotesModel()
        {
        }

        public IList<Note> GetAll()
        {
            var list = NotesList.Instance.Notes;

            return list;
        }
    }
}