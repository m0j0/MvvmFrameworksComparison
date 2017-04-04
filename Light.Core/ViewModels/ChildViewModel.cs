using System;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Light.Services;

namespace Light.ViewModels
{
    public class ChildViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _parameter;
        private string _originalParameter;
        private bool _isBusy;
        private string _busyMessage;
        private string _parameterError;
        private readonly RelayCommand _applyCommand;

        #endregion

        #region Constructors

        public ChildViewModel(IMessagePresenter messagePresenter)
        {
            if (messagePresenter == null) throw new ArgumentNullException(nameof(messagePresenter));
            _messagePresenter = messagePresenter;
            _applyCommand = new RelayCommand(Apply, CanApply);
            CloseCommand = new RelayCommand(Close);
        }

        #endregion

        #region Properties

        public string DisplayName => "Child view model";

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
                RaisePropertyChanged();
                Validate();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                if (value == _isBusy)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public string BusyMessage
        {
            get { return _busyMessage; }
            private set
            {
                if (value == _busyMessage)
                {
                    return;
                }

                _busyMessage = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand ApplyCommand => _applyCommand;

        private void Apply()
        {
            //if (!await TryCloseAsync())
            //{
            //    return;
            //}

            //ShowViewModel<MainViewModel>(new { parameter = Parameter });
        }

        private bool CanApply()
        {
            return !HasErrors;
        }

        public ICommand CloseCommand { get; }

        private async void Close()
        {
            //if (!await TryCloseAsync())
            //{
            //    return;
            //}

            //ShowViewModel<MainViewModel>(new { parameter = _originalParameter });
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
            bool hasErrorBefore = HasErrors;
            _parameterError = _originalParameter == Parameter ||
                              string.IsNullOrEmpty(_originalParameter) && string.IsNullOrEmpty(Parameter)
                ? "Change parameter before update"
                : null;

            _applyCommand.RaiseCanExecuteChanged();
            if (hasErrorBefore != HasErrors)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Parameter)));
            }
        }

        public async Task<bool> OnClosingAsync()
        {
            var result = _messagePresenter.ShowQuestion("Are you sure you want to close window?");
            // await DoWorkAsync(); can't be executed ;(
            return result;
        }

        private async Task DoWorkAsync()
        {
            try
            {
                IsBusy = true;
                BusyMessage = "Long running process emulation";

                await Task.Delay(2000);
            }
            finally
            {
                IsBusy = false;
                BusyMessage = null;
            }
        }

        //protected override async Task<bool> OnClosing(object parameter)
        //{
        //    var result = await _messagePresenter.ShowAsync("Are you sure you want to close window?", "Question",
        //        MessageButton.YesNo);
        //    await DoWorkAsync();
        //    return result == MessageResult.Yes;
        //}

        #endregion

        #region Implementation of INotifyDataErrorInfo

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName != nameof(Parameter))
            {
                return null;
            }

            return _parameterError;
        }

        public bool HasErrors => !string.IsNullOrEmpty(_parameterError);

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion
    }
}