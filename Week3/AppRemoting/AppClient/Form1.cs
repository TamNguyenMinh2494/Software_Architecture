using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AppShared;
using AppServer;
using System.Runtime.Serialization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;



namespace AppClient
{
    public partial class Form1 : Form
    {
        public INoteBUS iBus = (INoteBUS)Activator.GetObject(typeof(INoteBUS), "tcp://192.168.1.11:1234/xxx");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<Note> notes = ibus.GetAllNotes();
            //dgrShow.DataSource = notes;
            try
            {
                
                //iBus = (INoteBUS)Activator.GetObject(typeof(INoteBUS), "tcp://127.0.0.1:1234/xxx");
                List<Note> notes = iBus.GetAllNotes();
                dgrShow.DataSource = notes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void dgrShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgrShow.SelectedRows.Count > 0)
            {
                int ID = int.Parse(dgrShow.SelectedRows[0].Cells["ID"].Value.ToString());
                String Title = dgrShow.SelectedRows[0].Cells["Title"].Value.ToString();
                String Creator = dgrShow.SelectedRows[0].Cells["Creator"].Value.ToString();
                String Content = dgrShow.SelectedRows[0].Cells["Content"].Value.ToString();
                String Date = dgrShow.SelectedRows[0].Cells["Date"].Value.ToString();
                bool IsSharable = bool.Parse(dgrShow.SelectedRows[0].Cells["IsSharable"].Value.ToString());

                List<Note> notes = iBus.GetAllNotes();
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
            List<Note> notes = iBus.Search(keyword);
            dgrShow.DataSource = notes;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            List<Note> notes = iBus.Search(keyword);
            dgrShow.DataSource = notes;
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
            bool result = iBus.Update(newNote);
            if (result)
            {
                List<Note> notes = iBus.GetAllNotes();
                dgrShow.DataSource = notes;
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
            bool note = iBus.Add(newNote);
            if (note)
            {
                List<Note> notes = iBus.GetAllNotes();
                dgrShow.DataSource = notes;
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
                bool note = iBus.Delete(ID);
                if (note)
                {
                    List<Note> notes = iBus.GetAllNotes();
                    dgrShow.DataSource = notes;
                }
                else
                {
                    MessageBox.Show("Sorry!!!");
                }
            }
            else return;
        }

        
    }
}
