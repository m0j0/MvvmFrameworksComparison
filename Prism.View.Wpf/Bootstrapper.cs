using System.Windows;
using Autofac;
using Prism.Autofac;
using Prism.View.Wpf.Views;

namespace Prism.View.Wpf
{
    public class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}