using System;
using System.Windows.Forms;
using WindowsFormsCSE.GUI;

namespace WindowsFormsCSE
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormsController.Start());
        }
    }
}
