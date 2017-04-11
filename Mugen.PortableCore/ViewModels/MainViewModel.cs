using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : MultiViewModel, INavigableViewModel
    {
        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter)
        {
            Should.NotBeNull(viewModelPresenter, nameof(viewModelPresenter));

            var presenter = new DynamicMultiViewModelPresenter(this);
            viewModelPresenter.DynamicPresenters.Add(presenter);
        }

        #endregion

        #region Implementation of INavigableViewModel

        public void OnNavigatedTo(INavigationContext context)
        {
            if (context.ViewModelFrom != null)
            {
                return;
            }

            AddViewModel(GetViewModel<ParentViewModel>());
        }

        public Task<bool> OnNavigatingFrom(INavigationContext context)
        {
            return Empty.TrueTask;
        }

        public void OnNavigatedFrom(INavigationContext context)
        {
        }

        #endregion
    }
}