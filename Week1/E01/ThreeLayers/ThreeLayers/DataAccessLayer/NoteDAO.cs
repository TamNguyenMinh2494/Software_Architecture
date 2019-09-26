using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayers.DTO;
using System.Data.SqlClient;
using System.Configuration;
namespace ThreeLayers.DataAccessLayer
{
    class NoteDAO
    {
        public List<Note> Select_AllNotes()
        {
            List<Note> notes = new List<Note>();
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String getAllNotes = "SELECT * FROM Note";
            SqlCommand com = new SqlCommand(getAllNotes, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                int ID = (int)dr["ID"];
                String Title = (String)dr["Title"];
                String Creator = (String)dr["Creator"];
                String Content = (String)dr["Content"];
                String Date = (String)dr["Date"];
                bool IsSharable = (bool)dr["IsSharable"];
                Note note = new Note()
                {
                    ID = ID,
                    Title = Title,
                    Creator = Creator,
                    Content = Content,
                    Date = Date,
                    IsSharable = IsSharable
                };
                notes.Add(note);
            }
            con.Close();
            return notes;
        }
        

        public List<Note> Search_AllNotes(String keyword)
        {
            List<Note> notes = new List<Note>();
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String getAllNotes = "SELECT * FROM Note WHERE Title LIKE '%" + keyword + "%'";
            SqlCommand com = new SqlCommand(getAllNotes, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                int ID = (int)dr["ID"];
                String Title = (String)dr["Title"];
                String Creator = (String)dr["Creator"];
                String Content = (String)dr["Content"];
                String Date = (String)dr["Date"];
                bool IsSharable = (bool)dr["IsSharable"];
                Note note = new Note()
                {
                    ID = ID,
                    Title = Title,
                    Creator = Creator,
                    Content = Content,
                    Date = Date,
                    IsSharable = IsSharable
                };
                notes.Add(note);
            }
            con.Close();
            return notes;
        }

        public bool UpdateNote(Note newNote)
        {
            List<Note> notes = new List<Note>();
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String updateNote = "UPDATE Note SET ID=@ID,Title=@Title,Creator=@Creator,Content=@Content,Date=@Date,IsSharable=@IsSharable WHERE ID=@ID";
            SqlCommand com = new SqlCommand(updateNote, con);
            com.Parameters.Add(new SqlParameter("@ID", newNote.ID));
            com.Parameters.Add(new SqlParameter("@Title", newNote.Title));
            com.Parameters.Add(new SqlParameter("@Creator", newNote.Creator));
            com.Parameters.Add(new SqlParameter("@Content", newNote.Content));
            com.Parameters.Add(new SqlParameter("@Date", newNote.Date));
            com.Parameters.Add(new SqlParameter("@IsSharable", newNote.IsSharable ? "1" : "0"));//
            try { return com.ExecuteNonQuery() > 0; }
            catch { return false; }
        }

        public bool AddNote(Note newNote)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String insertNote = "INSERT INTO Note VALUES(@ID,@Title,@Creator,@Content,@Date,@IsSharable)";
            SqlCommand com = new SqlCommand(insertNote, con);
            com.Parameters.Add(new SqlParameter("@ID", newNote.ID));
            com.Parameters.Add(new SqlParameter("@Title", newNote.Title));
            com.Parameters.Add(new SqlParameter("@Creator", newNote.Creator));
            com.Parameters.Add(new SqlParameter("@Content", newNote.Content));
            com.Parameters.Add(new SqlParameter("@Date", newNote.Date));
            com.Parameters.Add(new SqlParameter("@IsSharable", newNote.IsSharable ? "1" : "0"));
            try { return com.ExecuteNonQuery() > 0; }
            catch { return false; }
        }

        public bool DeleteNote(int ID)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String deleteNote = "DELETE FROM Note WHERE ID=@ID";
            SqlCommand com = new SqlCommand(deleteNote, con);
            com.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return com.ExecuteNonQuery() > 0;
            }
            catch { return false; }
        }
    }
}
