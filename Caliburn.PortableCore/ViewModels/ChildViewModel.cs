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
            if (messagePresenter == null) throw new ArgumentNullException("messagePresenter");
            _messagePresenter = messagePresenter;
        }

        #endregion

        #region Properties

        public override string DisplayName
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

        public bool CanApply
        {
            get { return !HasErrors; }
        }

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
            
            NotifyOfPropertyChange(() => CanApply);
            if (hasErrorBefore != HasErrors)
            {
                var handler = ErrorsChanged;
                if (handler != null)
                {
                    handler(this, new DataErrorsChangedEventArgs("Parameter"));
                }
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
            Debug.WriteLine("{0} activated", DisplayName);
        }

        protected override void OnInitialize()
        {
            Debug.WriteLine("{0} initialized", DisplayName);
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine("{0} deactiveted", DisplayName);
        }

        protected override void OnViewLoaded(object view)
        {
            Debug.WriteLine("{0} view loaded", DisplayName);
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