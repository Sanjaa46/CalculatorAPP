using System;
using System.Windows.Forms;

namespace CalculatorInterface
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());  // Make sure this matches your form class name
        }
    }
}