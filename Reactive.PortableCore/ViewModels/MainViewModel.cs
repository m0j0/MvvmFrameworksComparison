using ReactiveUI;

namespace Reactive.Core.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public string DisplayName
        {
            get { return "Main view model"; }
        }
    }
}