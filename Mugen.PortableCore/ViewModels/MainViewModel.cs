using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : MultiViewModel
    {
        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter)
        {
            Should.NotBeNull(viewModelPresenter, nameof(viewModelPresenter));

            var presenter = new DynamicMultiViewModelPresenter(this);
            viewModelPresenter.DynamicPresenters.Add(presenter);
        }

        #endregion
    }
}