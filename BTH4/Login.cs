using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TransferObject;
using BusinessLayer;

namespace BTH4
{
    public partial class Login : Form
    {
        private LoginBL loginBL;
        public Login()
        {
            InitializeComponent();
            loginBL = new LoginBL();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Xoa
        private bool UserLogin(Account account)
        {
            try
            {
                return loginBL.Login(account);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtUsername.Text.Trim();
            pass = txtPassword.Text;

            Account acc = new Account(user,pass);
            if (UserLogin(acc))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string msg = "Tai khoan hoac mat khau khong dung!";
                DialogResult result = MessageBox.Show(msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
