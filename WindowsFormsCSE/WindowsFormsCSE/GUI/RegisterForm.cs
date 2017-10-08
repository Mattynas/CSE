using System;
using System.Windows.Forms;
using WindowsFormsCSE.Users;

namespace WindowsFormsCSE.GUI
{
    public partial class RegisterForm : Form
    {

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if(RegisterPasswordTB.Text != RegisterConfirmPassTB.Text)
            {
                RegisterWarningL.Text = "Passwords don't match";
                RegisterWarningL.Visible = true;
            }
            else if (!RegisterEmailTB.Text.Contains("@"))
            {
                //Make Regex
                RegisterWarningL.Text = "Invalid email";
                RegisterWarningL.Visible = true;

            }
            else if(UsersFile.Register(RegisterUsernameTB.Text, RegisterPasswordTB.Text, RegisterEmailTB.Text))
            {
                
                string message = "Registration is successful!";
                string caption = "Success";
                var buttons = MessageBoxButtons.OK;

                var messagebox = MessageBox.Show(message, caption, buttons);
                FormsController.ShowLogin();
                FormsController.DisposeRegister();

            }
            else
            {
                string message = "Registration failed!";
                string caption = "Failed";
                var buttons = MessageBoxButtons.OK;
                var messagebox = MessageBox.Show(message, caption, buttons);
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsController.ShowLogin();
        }

        private void CancelBuuton_Click(object sender, EventArgs e)
        {
            FormsController.DisposeRegister();
            FormsController.ShowLogin();
        }
    }
}
