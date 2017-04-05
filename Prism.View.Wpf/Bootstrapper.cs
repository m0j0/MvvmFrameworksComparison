using System;
using System.Windows;
using Autofac;
using Prism.Autofac;
using Prism.Mvvm;
using Prism.View.Wpf.Views;
using Prism.ViewModels;

namespace Prism.View.Wpf
{
    public class Bootstrapper : AutofacBootstrapper
    {
        #region Methods

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                viewType =>
                {
                    if (viewType == typeof(MainView))
                    {
                        return typeof(MainViewModel);
                    }
                    if (viewType == typeof(ChildView))
                    {
                        return typeof(ChildViewModel);
                    }
                    throw new NotSupportedException();
                });
        }

        #endregion
    }
}