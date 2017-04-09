using System.Windows;
using Catel.IoC;
using Catel.MVVM;
using Catel.ViewModels;
using Catel.Views;

namespace Catel
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceLocator = ServiceLocator.Default;

            serviceLocator.RegisterType<IViewLocator, ViewLocator>();
            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.Register(typeof(MainViewModel), typeof(MainView));
            viewLocator.Register(typeof(ChildViewModel), typeof(ChildView));

            new Bootstrapper().Run(true);
        }
    }
}
