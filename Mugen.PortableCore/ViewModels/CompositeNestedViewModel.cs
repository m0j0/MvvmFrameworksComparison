using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class CompositeNestedViewModel : ViewModelBase, IHasDisplayName
    {
        #region Properties

        public string DisplayName { get; set; }

        #endregion
    }
}