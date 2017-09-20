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
                RegisterWarningL.Text = "Nesutampa slaptazodis";
                RegisterWarningL.Visible = true;
            }
            else if (RegisterEmailTB.Text.Contains("@"))
            {
                RegisterWarningL.Text = "Netinkamas paštas";
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
