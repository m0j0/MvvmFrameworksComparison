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

            //serviceLocator.RegisterType<IViewModelLocator, ViewModelLocator>();
            //var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            //viewModelLocator.NamingConventions.Add("Catel.ViewModels.[VW]ViewModel");

            new Bootstrapper().Run(true);
        }
    }
}
