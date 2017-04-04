using GalaSoft.MvvmLight.Ioc;
using Light.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Light
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ChildViewModel ChildViewModel => ServiceLocator.Current.GetInstance<ChildViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}