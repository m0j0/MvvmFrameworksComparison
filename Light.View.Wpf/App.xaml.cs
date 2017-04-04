using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using Light.Services;

namespace Light
{
    public partial class App : Application
    {
        public App()
        {
            SimpleIoc.Default.Register<IMessagePresenter, MessagePresenter>();
        }
    }
}