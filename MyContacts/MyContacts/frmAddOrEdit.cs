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
    public partial class frmAddOrEdit : Form
    {
        IContactsRepository Repository;
        public int cId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            Repository = new ContactsRepository();
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
                bool isSuccess;

                if (cId == 0)
                {
                    isSuccess= Repository.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
                }
                else
                {
                   isSuccess= Repository.Update(cId, txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
                }
                if(isSuccess== true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                DataTable dt = Repository.SelectRow(cId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtAge.Value = int.Parse( dt.Rows[0][3].ToString());
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtEmail.Text = dt.Rows[0][5].ToString();
                txtAddress.Text = dt.Rows[0][6].ToString();
                btnRegister.Text = "ویرایش";
            }
        }
    }
}
