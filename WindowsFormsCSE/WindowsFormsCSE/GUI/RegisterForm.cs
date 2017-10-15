using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCSE.XML;

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
            if (PasswordTextBox.Text != ConfirmPassTextBox.Text)
            {
                
            }
            else if (!EmailTextBox.Text.Contains("@"))
            {
                //Make Regex
                

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
            var login = new LoginForm();
            login.Show();
        }
    }
}
