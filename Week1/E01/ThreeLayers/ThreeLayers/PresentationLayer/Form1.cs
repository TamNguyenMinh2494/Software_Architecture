using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeLayers.DTO;
using ThreeLayers.BusinessLayer;
namespace ThreeLayers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Note> notes = new NoteBUS().GetAllNotes();
            dataGridViewNotes.DataSource = notes;
        }
        private void dataGridViewNotes_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewNotes.SelectedRows.Count > 0)
            {
                int ID = int.Parse(dataGridViewNotes.SelectedRows[0].Cells["ID"].Value.ToString());
                String Title = dataGridViewNotes.SelectedRows[0].Cells["Title"].Value.ToString();
                String Creator = dataGridViewNotes.SelectedRows[0].Cells["Creator"].Value.ToString();
                String Content = dataGridViewNotes.SelectedRows[0].Cells["Content"].Value.ToString();
                String Date = dataGridViewNotes.SelectedRows[0].Cells["Date"].Value.ToString();
                bool IsSharable = bool.Parse(dataGridViewNotes.SelectedRows[0].Cells["IsSharable"].Value.ToString());
   
                List<Note> notes = new NoteBUS().GetAllNotes();
                if (notes != null)
                {
                    txtID.Text = ID.ToString();
                    txtTitle.Text = Title.ToString();
                    txtCreator.Text = Creator.ToString();
                    txtContent.Text = Content.ToString();
                    txtDate.Text = Date.ToString();
                    cbSharable.Checked = IsSharable;
                }
            }
        }
     
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            List<Note> notes = new NoteBUS().Search(keyword);
            dataGridViewNotes.DataSource = notes;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbSharable.Checked;
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
                dataGridViewNotes.DataSource = notes;
            }
            else
            {
                MessageBox.Show("Sorry!!!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbSharable.Checked;
            Note newNote = new Note()
            {
                ID = ID,
                Title = Title,
                Creator = Creator,
                Content = Content,
                Date = Date,
                IsSharable = IsSharable
            };
            bool note = new NoteBUS().AddNote(newNote);
            if (note)
            {
                List<Note> notes = new NoteBUS().GetAllNotes();
                dataGridViewNotes.DataSource = notes;
            }
            else
            {
                MessageBox.Show("Sorry!!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbSharable.Checked;
            Note newNote = new Note()
            {
                ID = ID,
                Title = Title,
                Creator = Creator,
                Content = Content,
                Date = Date,
                IsSharable = IsSharable
            };
            DialogResult r;
            r = MessageBox.Show("Do you want to delete this item?", "Warnings",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                bool note = new NoteBUS().DeleteNote(ID);
                if (note)
                {
                    List<Note> notes = new NoteBUS().GetAllNotes();
                    dataGridViewNotes.DataSource = notes;
                }
                else
                {
                    MessageBox.Show("Sorry!!!");
                }
            }
            else return;
        }

        private void cbMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMode.Checked == true)
            {
                this.BackColor = Color.LightPink;
            }
            else
            { this.BackColor = Color.White; }
        }
    }
}
