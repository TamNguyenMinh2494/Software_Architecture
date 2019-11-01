using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace NoteService
{
    public class NoteDAO
    {
        NoteDBDataContext db = new NoteDBDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<Note> GetAllNotes()
        {
       
            List<Note> notes = db.Notes.ToList();
            return notes;
        }

        public List<Note> Search_AllNotes(String keyword)
        {
     
            List<Note> notes = db.Notes.Where(x => x.Title.Contains(keyword)).ToList();
            return notes;

        }

        public bool UpdateNote(Note newNote)
        {
         
            Note dbNote = db.Notes.SingleOrDefault(x => x.ID == newNote.ID);
            if (dbNote == null) return false;
            dbNote.ID = newNote.ID;
            dbNote.Title = newNote.Title;
            dbNote.Creator = newNote.Creator;
            dbNote.Content = newNote.Content;
            dbNote.Date = newNote.Date;
            dbNote.IsSharable = newNote.IsSharable;

            db.SubmitChanges();
            return true;
        }

        public bool AddNote(Note newNote)
        {
            try
            {
                db.Notes.InsertOnSubmit(newNote);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNote(int ID)
        {
            Note dbNote = db.Notes.SingleOrDefault(x => x.ID == ID);
            if (dbNote == null) return false;
            db.Notes.DeleteOnSubmit(dbNote);
            db.SubmitChanges();
            return true;
        }
    }
}