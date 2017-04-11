using Cross.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Cross
{
    public class CrossApp : MvxApplication
    {
        public CrossApp()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
        }
    }
}