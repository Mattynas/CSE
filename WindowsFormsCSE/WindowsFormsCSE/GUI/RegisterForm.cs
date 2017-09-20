using System;
using System.Windows.Forms;

namespace WindowsFormsCSE.GUI
{
    public partial class RegisterForm : Form
    {

        private LoginForm main;
        public RegisterForm(LoginForm main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if(RegisterPasswordTB.Text != RegisterConfirmPassTB.Text)
            {
                RegisterWarningL.Visible = true;
            }
            else
            {
               // MYSQLServer.

            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }
    }
}
