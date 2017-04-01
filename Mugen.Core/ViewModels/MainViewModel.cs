using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.Core.ViewModels
{
    public class MainViewModel : CloseableViewModel, IHasDisplayName
    {
        public string DisplayName => "Mugen main view model";
    }
}
