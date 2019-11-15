using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DemoRESTService.Models;

namespace DemoRESTService.DataAccessLayer
{

    public class NoteDAO
    {
        private NoteDBDataContext db = new NoteDBDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
        public List<Note> GetAllNotes()
        {
            List<Note> notes = db.Notes.ToList();
            return notes;
        }
        public Note DetailNote(int id)
        {
            Note note = db.Notes.SingleOrDefault(x => x.ID == id);
            return note;
        }

        public bool AddNote(Note newNote)
        {
            try {
                db.Notes.InsertOnSubmit(newNote);
                db.SubmitChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool DeleteNote(int id)
        {
            Note note = db.Notes.SingleOrDefault(x => x.ID == id);
            if (note == null) return false;
            try
            {
                db.Notes.DeleteOnSubmit(note);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, Note newNote)
        {
            if (id != newNote.ID) return false;
            Note note = db.Notes.SingleOrDefault(x => x.ID == id);
            if (note == null) return false;
            note.Title = newNote.Title;
            note.Creator = newNote.Creator;
            note.Content = newNote.Content;
            note.Date = newNote.Date;
            note.IsSharable = newNote.IsSharable;
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Update without id on routing api
        public bool Update(Note newNote)
        {
            
            Note note = db.Notes.SingleOrDefault(x => x.ID == newNote.ID);
            if (note == null) return false;
            note.Title = newNote.Title;
            note.Creator = newNote.Creator;
            note.Content = newNote.Content;
            note.Date = newNote.Date;
            note.IsSharable = newNote.IsSharable;
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Note> SearchNote(string keyword)
        {
            List<Note> notes = db.Notes.Where(i => i.Title.Contains(keyword)).ToList();
            return notes;
        }
    }
} 