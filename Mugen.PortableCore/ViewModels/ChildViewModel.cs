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
    public class ChildViewModel : ValidatableViewModel, IHasDisplayName, IHasOperationResult, INavigableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _parameter;
        private string _originalParameter;
        private readonly ICommand _applyCommand;

        #endregion

        #region Constructors

        public ChildViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            _applyCommand = new RelayCommand(Apply, CanApply, this);
        }

        #endregion

        #region Properties

        public string DisplayName
        {
            get { return "Child view model"; }
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
                Validate();
            }
        }

        public bool? OperationResult { get; private set; }

        #endregion

        #region Commands

        public ICommand ApplyCommand
        {
            get { return _applyCommand; }
        }

        private void Apply()
        {
            OperationResult = true;
            CloseAsync();
        }

        private bool CanApply()
        {
            return IsValid;
        }

        #endregion

        #region Methods

        public void Initialize(string parameter)
        {
            _originalParameter = parameter;
            Parameter = parameter;
            Validate();
        }

        private void Validate()
        {
            Validator.SetErrors<ChildViewModel>(() => vm => vm.Parameter,
                _originalParameter == Parameter ||
                string.IsNullOrEmpty(_originalParameter) && string.IsNullOrEmpty(Parameter)
                    ? "Change parameter before update"
                    : null);
        }

        protected override async Task<bool> OnClosing(object parameter)
        {
            if (await _messagePresenter.ShowAsync("Are you sure you want to close window?", "Question",
                    MessageButton.YesNo) == MessageResult.Yes)
            {
                await DoWorkAsync();
                return true;
            }
            return false;
        }

        private Task DoWorkAsync()
        {
            return Task.Delay(2000).WithBusyIndicator(this, "Long running process emulation");
        }

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

        #endregion
    }
}