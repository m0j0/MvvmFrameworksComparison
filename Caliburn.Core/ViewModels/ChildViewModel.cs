using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Caliburn.Interfaces;
using Caliburn.Managers;
using Caliburn.Micro;

namespace Caliburn.ViewModels
{
    public class ChildViewModel : Screen, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _parameter;
        private string _originalParameter;
        private bool _isBusy;
        private string _busyMessage;
        private string _parameterError;

        #endregion

        #region Constructors

        public ChildViewModel(IMessagePresenter messagePresenter)
        {
            if (messagePresenter == null) throw new ArgumentNullException(nameof(messagePresenter));
            _messagePresenter = messagePresenter;
        }

        #endregion

        #region Properties

        public override string DisplayName => "Child view model";

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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Commands

        public void Apply()
        {
            ((ICloseableView)GetView()).Close(true);
        }

        public bool CanApply => !HasErrors;

        public void Close()
        {
            // ((IDeactivate)this).Deactivate(true); - CanClose isn't called in that case
            ((ICloseableView)GetView()).Close(false);
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
            
            NotifyOfPropertyChange(nameof(CanApply));
            if (hasErrorBefore != HasErrors)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Parameter)));
            }
        }

        public override void CanClose(Action<bool> callback)
        {
            var result = _messagePresenter.ShowQuestion("Are you sure you want to close window?");
            // await DoWorkAsync(); can't be executed ;(
            callback(result);
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

        protected override void OnActivate()
        {
            Debug.WriteLine($"{DisplayName} activated");
        }

        protected override void OnInitialize()
        {
            Debug.WriteLine($"{DisplayName} initialized");
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine($"{DisplayName} deactiveted");
        }

        protected override void OnViewLoaded(object view)
        {
            Debug.WriteLine($"{DisplayName} view loaded");
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