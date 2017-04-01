using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mugen.Core.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Mugen.View
{
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            new Bootstrapper<MainViewModel>(this, new AutofacContainer());
        }

        #endregion
    }
}
