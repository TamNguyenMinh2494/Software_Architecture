using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using noteFirebase.BLL;
using noteFirebase.EL;

namespace noteFirebase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            new NoteBUS().ListenFirebase(gridNote);
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Application.Exit();
        //}

        private async void gridNote_SelectionChanged(object sender, EventArgs e)
        {
            if (gridNote.SelectedRows.Count > 0)
            {
                int ID = int.Parse(gridNote.SelectedRows[0].Cells["ID"].Value.ToString());
                Note Note = await new NoteBUS().GetDetails(ID);
                if (Note != null)
                {
                    txtID.Text = Note.ID.ToString();
                    txtTitle.Text = Note.Title.ToString();
                    txtCreator.Text = Note.Creator.ToString();
                    txtContent.Text = Note.Content.ToString();
                    txtDate.Text = Note.Date.ToString();
                    txtIsSharable.Text = Note.IsSharable.ToString();
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            List<Note> Notes = await new NoteBUS().Search(keyword);
            gridNote.BeginInvoke(new MethodInvoker(delegate { gridNote.DataSource = Notes; })); // set asynchronous datasource
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            Note newNote = new Note()
            {

                ID = int.Parse(txtID.Text.Trim()),
                Title = txtTitle.Text.Trim(),
                Creator = txtCreator.Text.Trim(),
                Content = txtContent.Text.Trim(),
                Date = txtDate.Text.Trim(),
                IsSharable = txtIsSharable.Text.Trim()
            };
            bool result = await new NoteBUS().AddNew(newNote);
            if (!result) MessageBox.Show("Sorry bae !!!");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Note newNote = new Note()
            {
                ID = int.Parse(txtID.Text.Trim()),
                Title = txtTitle.Text.Trim(),
                Creator = txtCreator.Text.Trim(),
                Content = txtContent.Text.Trim(),
                Date = txtDate.Text.Trim(),
                IsSharable = txtIsSharable.Text.Trim()
            };
            bool result = await new NoteBUS().Update(newNote);
            if (result) MessageBox.Show("Update successfully !!!");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRM", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int ID = int.Parse(txtID.Text);
                bool result = await new NoteBUS().Delete(ID);
                if (!result) MessageBox.Show("Sorry bae !!!");

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
