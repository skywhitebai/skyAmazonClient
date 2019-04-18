using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skyAmazonClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                loginForm.Dispose();
                //MainForm mainForm = new MainForm();
                TestForm mainForm = new TestForm();
                mainForm.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(mainForm);
            }
            else if (loginForm.DialogResult == DialogResult.Cancel)
            {
                loginForm.Dispose();
                return;
            }
        }
    }
}
