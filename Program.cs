using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.View;

namespace VaultApp
{
    internal static class Program
    {
        public static bool OpenMainFormOnClose {  get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OpenMainFormOnClose = false;

            Application.Run(new Login());

            if (OpenMainFormOnClose)
            {
                Application.Run(new MainForm());
            } 

        }



    }
}
