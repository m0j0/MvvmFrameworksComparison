using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : MultiViewModel, INavigableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private int _counter;

        #endregion

        #region Constructors

        public MainViewModel(IViewModelPresenter viewModelPresenter, IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(viewModelPresenter, nameof(viewModelPresenter));
            Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            _messagePresenter = messagePresenter;

            AddNewTabCommand = new RelayCommand(AddNewTab);

            var presenter = new DynamicMultiViewModelPresenter(this);
            viewModelPresenter.DynamicPresenters.Add(presenter);

            if (IsDesignMode)
            {
                InitializeViewModels();
            }
        }

        #endregion

        #region Commands

        public ICommand AddNewTabCommand { get; }

        private async void AddNewTab()
        {
            using (var viewModel = GetViewModel<CompositeViewModel>())
            {
                viewModel.Id = ++_counter;
                await viewModel.ShowAsync(); // first way add VM to MainViewModel ItemsSource
                await _messagePresenter.ShowAsync(String.Format("{0} closed. Call from MainViewModel", viewModel.DisplayName));
            }
        }

        #endregion

        #region Methods
        
        private void InitializeViewModels()
        {
            // second way add VM to MainViewModel ItemsSource
            AddViewModel(GetViewModel<ParentViewModel>());
            AddViewModel(GetViewModel(container => new CompositeViewModel { Id = ++_counter }));
        }

        #endregion

        #region Implementation of INavigableViewModel

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            if (context.ViewModelFrom != null)
                return;

            InitializeViewModels();
        }

        Task<bool> INavigableViewModel.OnNavigatingFrom(INavigationContext context)
        {
            return Empty.TrueTask;
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
        }

        #endregion
    }
}