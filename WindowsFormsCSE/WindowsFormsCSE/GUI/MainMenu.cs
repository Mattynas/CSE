using System;
using System.Windows.Forms;
using WindowsFormsCSE.GUI;

namespace WindowsFormsCSE
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void openfileButton_Click(object sender, EventArgs e)
        {

            //var tesseractImageProcessing = new TesseractImageProcessing("null");
            

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void virtualShoppingButton_Click(object sender, EventArgs e)
        {
            var virtualShopping = new VirtualShopping();
            virtualShopping.Show();
        }
    }
}
