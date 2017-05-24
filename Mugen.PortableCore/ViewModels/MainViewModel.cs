using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : MultiViewModel<IViewModel>, INavigableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private int _counter;
        private readonly ICommand _addNewTabCommand;

        #endregion

        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter, IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(viewModelPresenter, "viewModelPresenter");
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;

            _addNewTabCommand = new RelayCommand(AddNewTab);

            var presenter = new DynamicMultiViewModelPresenter(this);
            viewModelPresenter.DynamicPresenters.Add(presenter);

            if (IsDesignMode)
            {
                InitializeViewModels();
            }
        }

        #endregion

        #region Commands

        public ICommand AddNewTabCommand
        {
            get { return _addNewTabCommand; }
        }

        private async void AddNewTab()
        {
            using (var viewModel = GetViewModel<CompositeViewModel>())
            {
                viewModel.Id = ++_counter;
                await viewModel.ShowAsync(); // first way to add VM to MainViewModel ItemsSource
                await _messagePresenter.ShowAsync(viewModel.DisplayName + " closed. Call from MainViewModel");
            }
        }

        #endregion

        #region Properties

        public string DisplayName
        {
            get { return "Main view model"; }
        }

        #endregion

        #region Methods

        private void InitializeViewModels()
        {
            // second way to add VM to MainViewModel ItemsSource
            AddViewModel(GetViewModel<ParentViewModel>());
            AddViewModel(GetViewModel(container => new CompositeViewModel {Id = ++_counter}));
        }

        #endregion

        #region Implementation of INavigableViewModel

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            if (context.ViewModelFrom != null)
                return;

            InitializeViewModels();
        }

        Task<bool> INavigableViewModel.OnNavigatingFromAsync(INavigationContext context)
        {
            return Empty.TrueTask;
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
        }

        #endregion
    }
}