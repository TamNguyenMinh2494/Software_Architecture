using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShared
{
    // Cái này tương đương AbstractServer
    public interface INoteBUS
    {
        List<Note> GetAllNotes();
        List<Note> Search(String keyword);
        bool Update(Note newNote);
        bool Add(Note newNote);
        bool Delete(int ID);
    }
}
