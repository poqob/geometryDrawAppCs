using System;
using System.Windows.Forms;

namespace paint
{
    static class Program
    {
        /// <summary>
        /// Basic paint app, you can draw geometric shapes!!!
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
