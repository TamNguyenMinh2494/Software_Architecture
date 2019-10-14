using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebNote.BusinessLayer;
using WebNote.Models;
using System.Text;

namespace WebNote
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Note> notes = new NoteBUS().GetAllNotes();
            grvNotes.DataSource = notes;
            grvNotes.DataBind();
        }

       
        //protected void grvNotes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int ID = int.Parse(grvNotes.SelectedRow.Cells[1].Text.Trim());
        //    String Title = grvNotes.SelectedRow.Cells[2].Text.Trim();
        //    String Creator =  grvNotes.SelectedRow.Cells[3].Text.Trim();
        //    String Content = grvNotes.SelectedRow.Cells[4].Text.Trim();
        //    String Date = grvNotes.SelectedRow.Cells[5].Text.Trim();
        //    bool isSharable = bool.Parse((grvNotes.SelectedRow.Cells[6].Controls[0] as CheckBox).Checked.ToString());
        //    List<Note> notes = new NoteBUS().GetAllNotes();
        //    if (notes != null)
        //    {

        //        txtID.Text = ID.ToString();
        //        txtTitle.Text = Title.ToString();
        //        txtCreator.Text = Creator.ToString();
        //        txtContent.Text = Content.ToString();
        //        txtDate.Text = Date.ToString();
        //        if (isSharable)
        //        {
        //            cbIsSharable.Checked = isSharable;
        //        }
        //        else { cbIsSharable.Checked = false; }
                
        //    }
        //}

        protected void Select_Item(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("Select") == 0)
            {
                int ID = int.Parse(grvNotes.SelectedRow.Cells[1].Text.Trim());
                String Title = grvNotes.SelectedRow.Cells[2].Text.Trim();
                String Creator = grvNotes.SelectedRow.Cells[3].Text.Trim();
                String Content = grvNotes.SelectedRow.Cells[4].Text.Trim();
                String Date = grvNotes.SelectedRow.Cells[5].Text.Trim();
                bool isSharable = bool.Parse((grvNotes.SelectedRow.Cells[6].Controls[0] as CheckBox).Checked.ToString());
                List<Note> notes = new NoteBUS().GetAllNotes();
                if (notes != null)
                {

                    txtID.Text = ID.ToString();
                    txtTitle.Text = Title.ToString();
                    txtCreator.Text = Creator.ToString();
                    txtContent.Text = Content.ToString();
                    txtDate.Text = Date.ToString();
                    if (isSharable)
                    {
                        cbIsSharable.Checked = isSharable;
                    }
                    else { cbIsSharable.Checked = false; }

                }
            }
            else
            {
                Response.Write("<script>alert('Your item is not exist');</script>");
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Note newNote = new Note()
                {
                    ID = int.Parse(txtID.Text.Trim()),
                    Title = txtTitle.Text.Trim(),
                    Creator = txtCreator.Text.Trim(),
                    Content = txtContent.Text.Trim(),
                    Date = txtDate.Text.Trim(),
                    IsSharable = cbIsSharable.Checked
                };
                bool note = new NoteBUS().AddNote(newNote);
                if (note)
                {
                    List<Note> notes = new NoteBUS().GetAllNotes();
                    grvNotes.DataSource = notes;
                    grvNotes.DataBind();
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Sorry cannot add !!!'); </script>");
                }
            }
            catch { Response.Write("<script language='JavaScript'> alert('Sorry cannot add !!!'); </script>"); }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbIsSharable.Checked;
            Note newNote = new Note()
            {
                ID = ID,
                Title = Title,
                Creator = Creator,
                Content = Content,
                Date = Date,
                IsSharable = IsSharable
            };
            if (true)
            {
                bool note = new NoteBUS().DeleteNote(ID);
                if (note)
                {
                    List<Note> notes = new NoteBUS().GetAllNotes();
                    grvNotes.DataSource = notes;
                    grvNotes.DataBind();
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Sorry cannot delete !!!'); </script>");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbIsSharable.Checked;
            Note newNote = new Note()
            {
                ID = ID,
                Title = Title,
                Creator = Creator,
                Content = Content,
                Date = Date,
                IsSharable = IsSharable
            };
            bool result = new NoteBUS().UpdateNotes(newNote);
            if (result)
            {
                List<Note> notes = new NoteBUS().GetAllNotes();
                grvNotes.DataSource = notes;
                grvNotes.DataBind();
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Sorry cannot update !!!'); </script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            List<Note> notes = new NoteBUS().Search(keyword);
                grvNotes.DataSource = notes;
                grvNotes.DataBind();
               
        }
    }
}