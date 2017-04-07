using System;
using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WinForms.Infrastructure;

namespace Mugen
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bootstrapper = new Bootstrapper<MainViewModel>(new AutofacContainer());
            bootstrapper.Start();
        }
    }
}