using System;
using System.Windows.Forms;
using WindowsFormsCSE.XML;
using WindowsFormsCSE.Properties;
using WindowsFormsCSE.Validation;
using WindowsFormsCSE.Exceptions.Register;

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
            try
            {
                RegisterDataValidation.RegisterValidation(UsernameTextBox.Text, EmailTextBox.Text, PasswordTextBox.Text, ConfirmPassTextBox.Text);
                if(UsersXML.Register(UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text))
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
            catch (InvalidUsernameException)
            {
                UsernameLabel.ForeColor = System.Drawing.Color.Red;
                UsernameLabel.Text = Resources.REGISTRATION_wrongUsername;
            }
            catch (InvalidEmailException)
            {
                EmailLabel.ForeColor = System.Drawing.Color.Red;
                EmailLabel.Text = Resources.REGISTRATION_wrongEmail;
            }
            catch (InvalidPasswordException)
            {
                PasswordLabel.ForeColor = System.Drawing.Color.Red;
                PasswordLabel.Text = Resources.REGISTRATION_wrongPassword;
            }
            catch (PasswordsDontMachException)
            {
                PasswordLabel.ForeColor = System.Drawing.Color.Red;
                PasswordLabel.Text = Resources.REGISTRATION_passwordsMatchError;
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

        private void ConfirmPassTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RegisterButton_Click(this, new EventArgs());
            }
        }
    }
}
