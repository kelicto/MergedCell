using System;
using System.Windows.Forms;
using KeLi.ExcelMerge.App.Forms;

namespace KeLi.ExcelMerge.App
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(new MergeCellForm());
        }
    }
}