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
            
            OpenFileDialog ofile = new OpenFileDialog();
            //ofile.Filter = "Image file (*.BMP, *.JPG, *.JPEG, *.PNG)|*.BMP, *.JPG, *.JPEG, *.PNG";
            ofile.ShowDialog();

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void virtualShoppingButton_Click(object sender, EventArgs e)
        {
            var imageAnalysis = new ImageAnalysisMenu();
            imageAnalysis.Show();
        }
    }
}
