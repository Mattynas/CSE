using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsCSE.XML;
using WindowsFormsCSE.Properties;


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
            var patternForEmail = Resources.REGISTRATION_emailPattern; //Copied from http://emailregex.com/
            var patternForOthers = Resources.REGISTRATION_passwordPattern;

            UsernameLabel.Text = "";
            EmailLabel.Text = "";
            PasswordLabel.Text = "";

            if(!Regex.IsMatch(UsernameTextBox.Text, patternForOthers))
            {
                UsernameLabel.ForeColor = System.Drawing.Color.Red;
                UsernameLabel.Text = Resources.REGISTRATION_wrongUsername;
            }
            else if (!Regex.IsMatch(EmailTextBox.Text, patternForEmail))
            {
                EmailLabel.ForeColor = System.Drawing.Color.Red;
                EmailLabel.Text = Resources.REGISTRATION_wrongEmail;
            }
            else if(!Regex.IsMatch(PasswordTextBox.Text, patternForOthers))
            {
                PasswordLabel.ForeColor = System.Drawing.Color.Red;
                PasswordLabel.Text = Resources.REGISTRATION_wrongPassword;
            }
            else if (PasswordTextBox.Text != ConfirmPassTextBox.Text)
            {
                PasswordLabel.ForeColor = System.Drawing.Color.Red;
                PasswordLabel.Text = Resources.REGISTRATION_passwordsMatchError;
            } 
            else if (UsersXML.Register(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text))
            {
                var button = MessageBoxButtons.OK;
                var messagebox = MessageBox.Show(Resources.REGISTRATION_successMessage, Resources.REGISTRATION_successWindowTitle, button);

                this.Close();
            }
            else
            {
                var button = MessageBoxButtons.OK;
                var messagebox = MessageBox.Show(Resources.REGISTRATION_failedMessage, Resources.REGISTRATION_failedWindowTitle, button);
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
