using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Catel.MVVM;
using Catel.Services;

namespace Catel.ViewModels
{
    public class ChildViewModel : ViewModelBase
    {
        #region Fields

        private readonly IMessageService _messagePresenter;
        private string _parameter;
        private string _originalParameter;

        #endregion

        #region Constructors

        public ChildViewModel(IMessageService messagePresenter)
        {
            if (messagePresenter == null) throw new ArgumentNullException(nameof(messagePresenter));
            _messagePresenter = messagePresenter;
            ApplyCommand = new Command(Apply, CanApply, this);
        }

        #endregion

        #region Properties

        public override string Title => "Child view model";

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
                RaisePropertyChanged(nameof(Parameter));
                Validate();
            }
        }

        public bool? OperationResult { get; private set; }

        #endregion

        #region Commands

        public ICommand ApplyCommand { get; }

        private void Apply()
        {
            OperationResult = true;
            CloseAsync();
        }

        private bool CanApply()
        {
            return true;
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
            //Validator.SetErrors(nameof(Parameter),
            //    _originalParameter == Parameter ||
            //    string.IsNullOrEmpty(_originalParameter) && string.IsNullOrEmpty(Parameter)
            //        ? "Change parameter before update"
            //        : null);
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
            return Task.Delay(2000); //.WithBusyIndicator(this, "Long running process emulation");
        }

        #endregion
    }
}