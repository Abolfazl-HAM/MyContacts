
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
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using(PhonebookEntities db = new PhonebookEntities())
            {
                dgContacts.AutoGenerateColumns = false;
                dgContacts.DataSource = null;
                dgContacts.DataSource = db.MyNumbers.ToList();
            }
            
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                string Name = dgContacts.CurrentRow.Cells[1].Value.ToString();
                string Family = dgContacts.CurrentRow.Cells[2].Value.ToString();
                string FullName= Name + " " + Family;
                if (MessageBox.Show($"  آیا از حذف {FullName} مطمئن هستید ","توجه",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Id = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    using (PhonebookEntities db = new PhonebookEntities())
                    {
                        var contact = db.MyNumbers.Single(n=> n.CID==Id);
                        db.MyNumbers.Remove(contact);
                        db.SaveChanges();
                       
                        
                    }
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک نفر را از لیست انتخاب کنید");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                int cId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.cId = cId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (PhonebookEntities db = new PhonebookEntities())
            {
                dgContacts.DataSource=db.MyNumbers.Where(n=> n.Name.Contains(txtSearch.Text)|| n.Family.Contains(txtSearch.Text)).ToList();
            }
           
        }

        
    }
}
