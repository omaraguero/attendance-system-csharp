using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    internal static class Program
    {
        public static int UserID { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Open Login Form
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            // Check login status before opening MainForm
            if (loginForm.loginFlag)
            {
                UserID = loginForm.UserID;
                Application.Run(new MainForm(UserID));
            }
            else
            {
                // Exit the application if login fails
                Application.Exit();
            }
        }
    }
}
