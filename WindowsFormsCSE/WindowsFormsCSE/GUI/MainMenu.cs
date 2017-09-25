using System;
using System.Windows.Forms;

namespace WindowsFormsCSE.GUI
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
            ofile.Filter = "Image file (*.bmp, *.jpg)|*.bmp, *.jpg";
            ofile.ShowDialog();
            MYSQLServer.Connect();
            

        }
    }
}
