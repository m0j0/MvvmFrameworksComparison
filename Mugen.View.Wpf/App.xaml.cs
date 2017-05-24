using System.Windows;
using Mugen.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Mugen
{
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            new Bootstrapper<MainViewModel>(this, new MugenContainer());
        }

        #endregion
    }
}
