using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayers.DTO;
using ThreeLayers.DataAccessLayer;
namespace ThreeLayers.BusinessLayer
{
    class NoteBUS
    {
        public List<Note> GetAllNotes()
        {
            List<Note> notes = new NoteDAO().Select_AllNotes();
            return notes;
        }
       
        public List<Note> Search(String keyword)
        {
            List<Note> notes = new NoteDAO().Search_AllNotes(keyword);
            return notes;
        }

        public bool UpdateNotes(Note newNote)
        {
            bool result = new NoteDAO().UpdateNote(newNote);
            return result;
        }
        public bool AddNote(Note newNote)
        {
            bool notes = new NoteDAO().AddNote(newNote);
            return notes;
        }
        public bool DeleteNote(int ID)
        {
            bool notes = new NoteDAO().DeleteNote(ID);
            return notes;
        }
    }
}
