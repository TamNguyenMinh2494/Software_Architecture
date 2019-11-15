using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DemoRESTService.Models;
using DemoRESTService.DataAccessLayer;

namespace DemoRESTService.Controllers
{
    public class NoteController : ApiController
    {
        [Route("api/notes")]
        [HttpGet]
        public List<Note> GetAll()
        {
            List<Note> notes = new NoteDAO().GetAllNotes();
            return notes;

        }

        [Route("api/notes/{id}")]
        [HttpGet]
        public Note NoteDetails(int id)
        {
            Note note = new NoteDAO().DetailNote(id);
            return note;

        }

        [Route("api/notes")]
        [HttpPost]
        public bool AddNewNote(Note newNote)
        {
            bool note = new NoteDAO().AddNote(newNote);
            return note;

        }

        [Route("api/notes/{id}")]
        [HttpDelete]
        public bool DeleteNote(int id)
        {
            bool result = new NoteDAO().DeleteNote(id);
            return result;
        }

        [Route("api/notes/{id}")]
        [HttpPut]
        public bool UpdateNote(int id, Note newNote)
        {
            bool result = new NoteDAO().Update(id, newNote);
            return result;
        }

        [Route("api/notes")]
        [HttpPut]
        public bool UpdateNote(Note newNote)
        {
            bool result = new NoteDAO().Update(newNote);
            return result;
        }

        [Route("api/notes/search/{keyword}")]
        [HttpGet]
        public List<Note> Search(string keyword)
        {
            List<Note> notes = new NoteDAO().SearchNote(keyword);
            return notes;
        }
    }
}