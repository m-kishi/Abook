namespace Abook
{
    using System;
    using System.Windows.Forms;

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
