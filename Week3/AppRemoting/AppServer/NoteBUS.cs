using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared;

namespace AppServer
{
    class NoteBUS : MarshalByRefObject, INoteBUS
    {
        public List<Note> GetAllNotes()
        {
            List<Note> notes = new NoteDAO().GetAllNotes();
            return notes;
        }
        public List<Note> Search(String keyword)
        {
            List<Note> notes = new NoteDAO().Search_AllNotes(keyword);
            return notes;
        }

        public bool Update(Note newNote)
        {
            bool result = new NoteDAO().UpdateNote(newNote);
            return result;
        }

        public bool Add(Note newNote)
        {
            bool notes = new NoteDAO().AddNote(newNote);
            return notes;
        }

        public bool Delete(int ID)
        {
            bool notes = new NoteDAO().DeleteNote(ID);
            return notes;
        }

    }
}
