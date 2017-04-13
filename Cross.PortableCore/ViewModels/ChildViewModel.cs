using System;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cross.Services;
using MvvmCross.Core.ViewModels;

namespace Cross.ViewModels
{
    public class ChildViewModel : MvxViewModel, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _parameter;
        private string _originalParameter;
        private bool _isBusy;
        private string _busyMessage;
        private string _parameterError;
        private readonly MvxCommand _applyCommand;
        private readonly ICommand _closeCommand;

        #endregion

        #region Constructors

        public ChildViewModel(IMessagePresenter messagePresenter)
        {
            if (messagePresenter == null) throw new ArgumentNullException("messagePresenter");
            _messagePresenter = messagePresenter;
            _applyCommand = new MvxCommand(Apply, CanApply);
            _closeCommand = new MvxCommand(Close);
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

        public ICommand ApplyCommand
        {
            get { return _applyCommand; }
        }

        private async void Apply()
        {
            if (!await TryCloseAsync())
            {
                return;
            }

            ShowViewModel<MainViewModel>(new { parameter = Parameter });
        }

        private bool CanApply()
        {
            return !HasErrors;
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
        }

        private async void Close()
        {
            if (!await TryCloseAsync())
            {
                return;
            }

            ShowViewModel<MainViewModel>(new {parameter = _originalParameter});
        }

        #endregion

        #region Methods

        public void Init(string parameter)
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
                var handler = ErrorsChanged;
                if (handler != null)
                {
                    handler(this, new DataErrorsChangedEventArgs("Parameter"));
                }
            }
        }

        private async Task<bool> TryCloseAsync()
        {
            if (_messagePresenter.ShowQuestion("Are you sure you want to close window?"))
            {
                await DoWorkAsync();
                return true;
            }
            return false;
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

        #endregion

        #region Implementation of INotifyDataErrorInfo

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName != "Parameter")
            {
                return null;
            }

            return _parameterError;
        }

        public bool HasErrors
        {
            get { return !string.IsNullOrEmpty(_parameterError); }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion
    }
}