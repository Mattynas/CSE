using System;
using System.Windows.Forms;

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
                RegisterWarningL.Text = "Invalid email";
                RegisterWarningL.Visible = true;

            }
            else
            {
                string message = "Registration is successful!";
                string caption = "Success";
                var buttons = MessageBoxButtons.OK;

                var messagebox = MessageBox.Show(message, caption, buttons);
                // ----------------------------------------- Users.xml -----------------
                FormsController.ShowLogin();
                FormsController.DisposeRegister();

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
