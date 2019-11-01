using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NoteService
{
    /// <summary>
    /// Summary description for NoteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NoteService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Note> GetAllNotes()
        {
            List<Note> notes = new NoteDAO().GetAllNotes();
            return notes;
        }

        [WebMethod]
        public List<Note> Search(String keyword)
        {
            List<Note> notes = new NoteDAO().Search_AllNotes(keyword);
            return notes;
        }
        [WebMethod]
        public bool Update(Note newNote)
        {
            bool result = new NoteDAO().UpdateNote(newNote);
            return result;
        }
        [WebMethod]
        public bool Add(Note newNote)
        {
            bool notes = new NoteDAO().AddNote(newNote);
            return notes;
        }
        [WebMethod]
        public bool Delete(int ID)
        {
            bool notes = new NoteDAO().DeleteNote(ID);
            return notes;
        }
    }
}
