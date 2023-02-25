
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
    public partial class frmAddOrEdit : Form
    {
        PhonebookEntities db = new PhonebookEntities();
        public int cId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            
        }
        bool ValidateInputs()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                

                if (cId == 0)
                {
                    MyNumber contact = new MyNumber();
                    contact.Name = txtName.Text;
                    contact.Family = txtFamily.Text;
                    contact.Mobile = txtMobile.Text;
                    contact.Age =(int)txtAge.Value;
                    contact.Email = txtEmail.Text;
                    contact.Address = txtAddress.Text;
                    db.MyNumbers.Add(contact);
                }
                else
                {
                    var contact = db.MyNumbers.Find(cId);
                    contact.Name = txtName.Text;
                    contact.Family = txtFamily.Text;
                    contact.Mobile = txtMobile.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Email = txtEmail.Text;
                    contact.Address = txtAddress.Text;
                    
                }
                db.SaveChanges();
                
                
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                
               
                
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (cId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                MyNumber contact=db.MyNumbers.Find(cId);
                txtName.Text = contact.Name;
                txtFamily.Text = contact.Family;
                txtAge.Value = (int)contact.Age;
                txtMobile.Text = contact.Mobile;
                txtEmail.Text = contact.Email;
                txtAddress.Text = contact.Address;
                btnRegister.Text = "ویرایش";
            }
        }
    }
}
