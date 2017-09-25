using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSE.GUI
{
    public static class FormsController
    {
        private static LoginForm loginForm;
        private static MainMenu mainMenu;
        private static RegisterForm registerForm;

        public static LoginForm Start()
        {
            loginForm = new LoginForm();
            return loginForm;
        }

        public static void ShowLogin()
        {
            if(loginForm == null || loginForm.IsDisposed) { loginForm = new LoginForm(); }
            loginForm.Show();
        }

        public static void HideLogin()
        {
            if (loginForm != null || !loginForm.IsDisposed) { loginForm.Hide(); }
        }

        public static void DisposeLogin()
        {
            if(loginForm != null || !loginForm.IsDisposed) { loginForm.Dispose(); }
        }

        public static void ShowMain()
        {
            if (mainMenu == null || mainMenu.IsDisposed) { mainMenu = new MainMenu(); }
            mainMenu.Show();
        }

        public static void HideMain()
        {
            if (mainMenu != null || !mainMenu.IsDisposed) { mainMenu.Hide(); }
        }

        public static void DisposeMain()
        {
            if (mainMenu != null || !mainMenu.IsDisposed) { mainMenu.Dispose(); }
        }

        public static void ShowRegister()
        {
            if (registerForm == null || registerForm.IsDisposed) { registerForm = new RegisterForm(); }
            registerForm.Show();
        }

        public static void HideRegister()
        {
            if (registerForm != null || !registerForm.IsDisposed) { registerForm.Hide(); }
        }

        public static void DisposeRegister()
        {
            if (registerForm != null || !registerForm.IsDisposed) { registerForm.Dispose(); }
        }

        public static void DisposeAll()
        {
            if (loginForm != null || !loginForm.IsDisposed) { loginForm.Dispose(); }
            if (mainMenu != null || !mainMenu.IsDisposed) { mainMenu.Dispose(); }
            if (registerForm != null || !registerForm.IsDisposed) { registerForm.Dispose(); }
        }
    }
}
