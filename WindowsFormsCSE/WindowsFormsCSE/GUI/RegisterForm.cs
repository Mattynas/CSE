using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsCSE.XML;

namespace WindowsFormsCSE.GUI
{
    public partial class RegisterForm : Form
    {
        private LoginForm login;

        public RegisterForm(LoginForm login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var patternForEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"; //Copied from http://emailregex.com/
            var patternForOthers = @"^\w{6,20}$";

            if(!Regex.IsMatch(UsernameTextBox.Text, patternForOthers))
            {
                UsernameLabel.ForeColor = System.Drawing.Color.Red;
                UsernameLabel.Text = "wrong username";
            }
            else if (!Regex.IsMatch(EmailTextBox.Text, patternForEmail))
            {
                EmailLabel.ForeColor = System.Drawing.Color.Red;
                EmailLabel.Text = "Wrong email";
            }
            else if(!Regex.IsMatch(PasswordTextBox.Text, patternForOthers))
            {
                PasswordLabel.ForeColor = System.Drawing.Color.Red;
                PasswordLabel.Text = "Wrong Password";
            }
            else if (PasswordTextBox.Text != ConfirmPassTextBox.Text)
            {
                PasswordLabel.ForeColor = System.Drawing.Color.Red;
                PasswordLabel.Text = "Passwords do not match";
            } 
            else if (UsersXML.Register(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text))
            {

                string message = "Registration is successful!";
                string caption = "Success";
                var button = MessageBoxButtons.OK;
                var messagebox = MessageBox.Show(message, caption, button);

                this.Close();
            }
            else
            {
                string message = "Registration failed";
                string caption = "Failed";
                var button = MessageBoxButtons.OK;
                var messagebox = MessageBox.Show(message, caption, button);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }

        private void RegisterButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { RegisterButton_Click(this, new EventArgs()); }
        }
    }
}
