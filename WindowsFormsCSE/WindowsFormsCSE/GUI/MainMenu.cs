using System;
using System.Windows.Forms;

namespace WindowsFormsCSE.GUI
{
    public partial class MainMenu : Form
    {
        private LoginForm login;
        public MainMenu(LoginForm login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void openfileButton_Click(object sender, EventArgs e)
        {

            //var tesseractImageProcessing = new TesseractImageProcessing("null");
            

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Close();
        }

        private void virtualShoppingButton_Click(object sender, EventArgs e)
        {
            var virtualShopping = new VirtualShopping();
            virtualShopping.Show();
        }
    }
}
