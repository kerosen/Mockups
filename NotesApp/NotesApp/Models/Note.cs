using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models
{
    public class Note
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public Note()
        {
        }

        public Note(string title, string description)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
        }
    }
}