using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesApp.Models
{
    public class NotesList
    {
        private static NotesList instance = null;
        private List<Note> notes = null;

        public static NotesList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotesList();
                }

                return instance;
            }
        }

        public NotesList()
        {
            notes = new List<Note>();
        }

        public List<Note> Notes
        {
            get
            {
                return notes;
            }
        }

        public static void AddNote()
        {
            var time = DateTime.Now.ToString("HH:mm:sss");
            NotesList.Instance.Notes.Add(new Note(string.Format("Note {0}", time), string.Format("made at {0}", time)));
        }

        public static void AddNote(Note note)
        {
            NotesList.instance.Notes.Add(note);
        }

        public static void Load()
        {
            for (int index = 0; index < 3; index++)
            {
                AddNote();
            }
        }
    }
}