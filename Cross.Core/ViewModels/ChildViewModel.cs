using System;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Cross.ViewModels
{
    public class ChildViewModel : MvxViewModel, INotifyDataErrorInfo
    {
        #region Fields

        //private readonly IMessagePresenter _messagePresenter;
        private string _parameter;
        private string _originalParameter;
        private bool _isBusy;
        private string _busyMessage;
        private string _parameterError;
        private readonly MvxCommand _applyCommand;

        #endregion

        #region Constructors

        public ChildViewModel( /*IMessagePresenter messagePresenter*/)
        {
            //Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            //_messagePresenter = messagePresenter;
            _applyCommand = new MvxCommand(Apply, CanApply);
            CloseCommand = new MvxCommand(Close);
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
            ShowViewModel<MainViewModel>(new {parameter = Parameter});
        }

        private bool CanApply()
        {
            return !HasErrors;
        }

        public ICommand CloseCommand { get; }

        private void Close()
        {
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
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Parameter)));
            }
        }

        //protected override async Task<bool> OnClosing(object parameter)
        //{
        //    var result = await _messagePresenter.ShowAsync("Are you sure you want to close window?", "Question",
        //        MessageButton.YesNo);
        //    await DoWorkAsync();
        //    return result == MessageResult.Yes;
        //}

        private Task DoWorkAsync()
        {
            try
            {
                IsBusy = true;
                BusyMessage = "Long running process emulation";

                return Task.Delay(2000);
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