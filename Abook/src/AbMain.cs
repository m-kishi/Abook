using System;
using System.Windows.Forms;

namespace Abook
{
    static class AbMain
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AbFormMain());
        }
    }
}
