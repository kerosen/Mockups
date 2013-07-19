using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MvcPopupApp.Models
{

    public class NoteManager
    {

        public Collection<Note> Notes
        {

            get
            {

                if (HttpRuntime.Cache["Notes"] == null)

                    this.loadInitialData();

                return (Collection<Note>)HttpRuntime.Cache["Notes"];

            }

        }



        private void loadInitialData()
        {

            var notes = new Collection<Note>();

            notes.Add(new Note

            {

                Id = 1,

                Title = "Set DVR for Sunday",

                Body = "Don't forget to record Game of Thrones!"

            });

            HttpRuntime.Cache["Notes"] = notes;

        }



        public Collection<Note> GetAll()
        {

            return Notes;

        }



        public Note GetById(int id)
        {

            return Notes.Where(i => i.Id == id).FirstOrDefault();

        }



        public int Save(Note item)
        {

            if (item.Id <= 0)

                return saveAsNew(item);

            var existingNote = Notes.Where(i => i.Id == item.Id).FirstOrDefault();

            existingNote.Title = item.Title;

            existingNote.Body = item.Body;

            return existingNote.Id;

        }



        private int saveAsNew(Note item)
        {

            item.Id = Notes.Count + 1;

            Notes.Add(item);

            return item.Id;

        }

    }
}