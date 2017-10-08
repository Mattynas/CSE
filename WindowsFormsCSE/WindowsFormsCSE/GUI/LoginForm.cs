using System;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsCSE.Users;

namespace WindowsFormsCSE.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            if(UsersFile.Login(userNameTextbox.Text, passwordTextbox.Text))
            {
                FormsController.ShowMain();
                FormsController.HideLogin();
            }
            else
            {
                string message = "Wrong username or password";
                string caption = "Wrong";
                var buttons = MessageBoxButtons.OK;
                var messagebox = MessageBox.Show(message, caption, buttons);
            }

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            FormsController.HideLogin();
            FormsController.ShowRegister();
        }
    }
}
