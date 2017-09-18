using System;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsCSE
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextbox.Text;
            string password = passwordTextbox.Text;
            if ((!String.IsNullOrEmpty(username)) && (!String.IsNullOrEmpty(username)))
            {
                var usersdoc = new XmlDocument();
                usersdoc.Load("../../users.xml");

                var nodes = usersdoc.GetElementsByTagName("user");

                foreach(XmlNode node in nodes)
                {
                    if (username.Equals(node.FirstChild.InnerText))
                    {
                        if(password.Equals(node.LastChild.InnerText))
                        {
                            // login
                            MessageBox.Show("Login success!", "hooray!", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }
                // if the username or password isnt correct
                string message = "Couldn't Sign in, Incorrect username or password";
                string caption = "error";
                var buttons = MessageBoxButtons.OK;

                var messagebox = MessageBox.Show(message, caption, buttons);

            }

        }
    }
}
