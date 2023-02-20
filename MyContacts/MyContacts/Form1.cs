using MyContacts.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactsRepository Repository;
        public Form1()
        {
            InitializeComponent();
            Repository = new ContactsRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgContacts.AutoGenerateColumns = false;
            dgContacts.DataSource = null;
            dgContacts.DataSource = Repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frmAddOrEdit = new frmAddOrEdit();
            frmAddOrEdit.ShowDialog();
            if (frmAddOrEdit.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }
    }
}
