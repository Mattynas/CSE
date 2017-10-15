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
            
            OpenFileDialog ofile = new OpenFileDialog();
            //ofile.Filter = "Image file (*.BMP, *.JPG, *.JPEG, *.PNG)|*.BMP, *.JPG, *.JPEG, *.PNG";
            ofile.ShowDialog();

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Close();
        }

        private void virtualShoppingButton_Click(object sender, EventArgs e)
        {
            var imageAnalysis = new ImageAnalysisMenu();
            imageAnalysis.Show();
        }
    }
}
