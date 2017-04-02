using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : CloseableViewModel, IHasDisplayName, INavigableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private readonly IToastPresenter _toastPresenter;
        private bool _canOpenChildViewModel;
        private string _parameter;

        #endregion

        #region Constructors

        public MainViewModel(IMessagePresenter messagePresenter, IToastPresenter toastPresenter)
        {
            Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            Should.NotBeNull(toastPresenter, nameof(toastPresenter));
            _messagePresenter = messagePresenter;
            _toastPresenter = toastPresenter;
            CanOpenChildViewModel = true;
            OpenChildViewModelCommand =  new RelayCommand(OpenChildViewModel, CanExecuteOpenChildViewModel, this);
        }

        #endregion
        
        #region Properties

        public string DisplayName => "Main view model";

        public bool CanOpenChildViewModel
        {
            get { return _canOpenChildViewModel; }
            set
            {
                if (value == _canOpenChildViewModel)
                {
                    return;
                }

                _canOpenChildViewModel = value;
                OnPropertyChanged();
            }
        }

        public string Parameter
        {
            get { return _parameter; }
            set
            {
                if (value == _parameter)
                {
                    return;
                }

                _parameter = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OpenChildViewModelCommand { get; }

        private async void OpenChildViewModel()
        {
            using (var viewModel = GetViewModel<ChildViewModel>())
            {
                viewModel.Initialize(Parameter);

                var operation = viewModel.ShowAsync();

                await operation.NavigationCompletedTask;
                ShowOpenNotification(viewModel);

                var operationResult = await operation;
                ShowCloseNotification(viewModel);

                if (!operationResult)
                {
                    return;
                }

                Parameter = viewModel.Parameter;
            }
        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion

        #region Methods

        private void ShowOpenNotification(IViewModel viewModel)
        {
            _toastPresenter.ShowAsync($"The '{viewModel.GetName()}' is opened.", ToastDuration.Short);
        }

        private void ShowCloseNotification(IViewModel viewModel)
        {
            _toastPresenter.ShowAsync($"The '{viewModel.GetName()}' is closed.", ToastDuration.Short);
        }

        #endregion

        #region Implementation of INavigableViewModel

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            this.TraceNavigation(context, _messagePresenter);
        }

        Task<bool> INavigableViewModel.OnNavigatingFrom(INavigationContext context)
        {
            this.TraceNavigation(context, _messagePresenter);
            return Empty.TrueTask;
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
            this.TraceNavigation(context, _messagePresenter);
        }

        #endregion
    }
}
