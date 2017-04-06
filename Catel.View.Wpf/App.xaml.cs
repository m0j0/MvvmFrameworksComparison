using System.Windows;

namespace Catel
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new Bootstrapper().Run(true);
        }
    }
}
