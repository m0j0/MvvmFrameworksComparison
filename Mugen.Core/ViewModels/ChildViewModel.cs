using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.Core.ViewModels
{
    public class ChildViewModel : CloseableViewModel, IHasDisplayName
    {
        public string DisplayName => "Child view model";
    }
}