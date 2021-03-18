using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DariuszWroniak_WZ_INiN1_2._2
{
    static class Program
    {
        public static void justNumbers(KeyPressEventArgs e)
        {
            char a = e.KeyChar;

            if (!Char.IsDigit(a) && a != 8) // 8 to kod bcksp, zablokowanie liter
            {
                e.Handled = true;
            }
        }

        internal static void justNumbers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
