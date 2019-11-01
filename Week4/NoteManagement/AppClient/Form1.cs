using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public gearhostNote.NoteService service = new gearhostNote.NoteService();
        public gearhostNote.Note[] notes;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            notes = service.GetAllNotes();
            dataGridView1.DataSource = notes;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbSharable.Checked;
            gearhostNote.Note newNote = new gearhostNote.Note()
            {
                ID = ID,
                Title = Title,
                Creator = Creator,
                Content = Content,
                Date = Date,
                IsSharable = IsSharable
            };
            
            bool note = service.Add(newNote);
            if (note)
            {
               notes = service.GetAllNotes();
               dataGridView1.DataSource = notes;
            }
            else
            {
                MessageBox.Show("Sorry!!!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text.Trim());
            String Title = txtTitle.Text.Trim();
            String Creator = txtCreator.Text.Trim();
            String Content = txtContent.Text.Trim();
            String Date = txtDate.Text.Trim();
            bool IsSharable = cbSharable.Checked;
            gearhostNote.Note newNote = new gearhostNote.Note()
            {
                ID = ID,
                Title = Title,
                Creator = Creator,
                Content = Content,
                Date = Date,
                IsSharable = IsSharable
            };
            bool result = service.Update(newNote);
            if (result)
            {
                notes = service.GetAllNotes();
                dataGridView1.DataSource = notes;
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
            gearhostNote.Note newNote = new gearhostNote.Note()
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
                bool note = service.Delete(ID);
                if (note)
                {
                    notes = service.GetAllNotes();
                    dataGridView1.DataSource = notes;
                }
                else
                {
                    MessageBox.Show("Sorry!!!");
                }
            }
            else return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Do you want to close?", "Warnings",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                this.Close();
            else return;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            notes = service.Search(keyword);
            dataGridView1.DataSource = notes;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int ID = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
            //    String Title = dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString();
            //    String Creator = dataGridView1.SelectedRows[0].Cells["Creator"].Value.ToString();
            //    String Content = dataGridView1.SelectedRows[0].Cells["Content"].Value.ToString();
            //    String Date = dataGridView1.SelectedRows[0].Cells["Date"].Value.ToString();
            //    bool IsSharable = bool.Parse(dataGridView1.SelectedRows[0].Cells["IsSharable"].Value.ToString());

            //    notes = service.GetAllNotes();
            //    if (notes != null)
            //    {
            //        txtID.Text = ID.ToString();
            //        txtTitle.Text = Title.ToString();
            //        txtCreator.Text = Creator.ToString();
            //        txtContent.Text = Content.ToString();
            //        txtDate.Text = Date.ToString();
            //        cbSharable.Checked = IsSharable;
            //    }
            //}
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtID.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                txtTitle.Text = dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString();
                txtCreator.Text = dataGridView1.SelectedRows[0].Cells["Creator"].Value.ToString();
                txtContent.Text = dataGridView1.SelectedRows[0].Cells["Content"].Value.ToString();
                txtDate.Text = dataGridView1.SelectedRows[0].Cells["Date"].Value.ToString();
                cbSharable.Checked = bool.Parse(dataGridView1.SelectedRows[0].Cells["IsSharable"].Value.ToString());
            }
        }
    }
}
