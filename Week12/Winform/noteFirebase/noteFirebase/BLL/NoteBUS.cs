using noteFirebase.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Firebase.Database;
using Firebase.Database.Query;


namespace noteFirebase.BLL
{
    class NoteBUS
    {
        private const String FIREBASE = "https://softwarearchitecture-bceee.firebaseio.com/";
        private readonly FirebaseClient firebase = new FirebaseClient(FIREBASE);

        public void ListenFirebase(DataGridView gridNote)
        {
            firebase.Child("notes").AsObservable<Note>().Subscribe(async item =>
            {
                List<Note> Notes = await GetAll();
                gridNote.BeginInvoke(new MethodInvoker(delegate { gridNote.DataSource = Notes; })); // set asynchronous datasource
            });
        }

        public async Task<List<Note>> GetAll()
        {
            List<Note> Notes = new List<Note>();
            var fbNotes = await firebase.Child("notes").OnceAsync<Note>();
            foreach (var item in fbNotes)
                Notes.Add(item.Object);
            return Notes;
        }

        public async Task<Note> GetDetails(int ID)
        {
            var fbNotes = await firebase.Child("notes").OnceAsync<Note>();
            foreach (var item in fbNotes)
                if (item.Object.ID == ID)
                    return item.Object;
            return null;
        }

        public async Task<List<Note>> Search(String keyword)
        {
            List<Note> Notes = new List<Note>();
            var fbNotes = await firebase.Child("notes").OnceAsync<Note>();
            foreach (var item in fbNotes)
                if (item.Object.Content.Contains(keyword))
                    Notes.Add(item.Object);
            return Notes;
        }

        public async Task<bool> AddNew(Note newNote)
        {
            try
            {
                //await firebase.Child("Notes").PostAsync(newNote); // auto-generated key
                await firebase.Child("notes").Child("N" + newNote.ID).PutAsync(newNote); // custom key
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(Note newNote)
        {
            try
            {
                String key = await GetKeyByID(newNote.ID);
                if (String.IsNullOrEmpty(key)) return false;
                await firebase.Child("notes").Child(key).PutAsync(newNote);
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(int ID)
        {
            try
            {
                String key = await GetKeyByID(ID);
                if (String.IsNullOrEmpty(key)) return false;
                await firebase.Child("notes").Child(key).DeleteAsync();
                return true;
            }
            catch { return false; }
        }

        private async Task<String> GetKeyByID(int ID)
        {
            var fbNotes = await firebase.Child("notes").OnceAsync<Note>();
            foreach (var item in fbNotes)
                if (item.Object.ID == ID)
                    return item.Key;
            return null;
        }
    }
}
