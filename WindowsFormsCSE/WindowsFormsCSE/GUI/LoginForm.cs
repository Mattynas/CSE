using System;
using System.Windows.Forms;
using WindowsFormsCSE.XML;

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
            if(UsersXML.Login(userNameTextbox.Text, passwordTextbox.Text))
            {
                var main = new MainMenu(this);
                main.Show();
                this.Hide();
            }
            else
            {
                string message = "Wrong username or password";
                string caption = "Failed";
                var button = MessageBoxButtons.OK;

                var messagebox = MessageBox.Show(message, caption, button);
            }

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            var register = new RegisterForm(this);
            register.Show();
            this.Hide();

        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                signinButton_Click(this, new EventArgs());
            }
        }
    }
}
