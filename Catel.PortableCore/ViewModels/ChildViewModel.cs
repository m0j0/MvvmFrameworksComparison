using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;

namespace Catel.ViewModels
{
    public class ChildViewModel : ViewModelBase
    {
        #region Fields

        private readonly IMessageService _messageService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private string _parameter;
        private string _originalParameter;
        private readonly ICommand _applyCommand;
        private readonly ICommand _closeCommand;

        #endregion

        #region Constructors

        public ChildViewModel(IMessageService messageService, IPleaseWaitService pleaseWaitService)
        {
            if (messageService == null) throw new ArgumentNullException("messageService");
            if (pleaseWaitService == null) throw new ArgumentNullException("pleaseWaitService");
            _messageService = messageService;
            _pleaseWaitService = pleaseWaitService;
            _applyCommand = new Command(Apply, CanApply);
            _closeCommand = new Command(CloseCmd);

            CanceledAsync += async (sender, args) => Debug.WriteLine("{0} canceled", Title);
            CancelingAsync += async (sender, args) => Debug.WriteLine("{0} canceling", Title);
            ClosedAsync += async (sender, args) => Debug.WriteLine("{0} closed", Title);
            ClosingAsync += async (sender, args) => Debug.WriteLine("{0} closing", Title);
            InitializedAsync += async (sender, args) => Debug.WriteLine("{0} initialized", Title);
            NavigationCompleted += async (sender, args) => Debug.WriteLine("{0} navigation", Title);
        }

        #endregion

        #region Properties

        public override string Title
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
                RaisePropertyChanged(() => Parameter);
            }
        }

        #endregion

        #region Commands

        public ICommand ApplyCommand
        {
            get { return _applyCommand; }
        }

        private void Apply()
        {
            CloseViewModelAsync(true);
        }

        private bool CanApply()
        {
            return !HasErrors;
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
        }

        private void CloseCmd()
        {
            CloseViewModelAsync(false);
        }

        #endregion

        #region Methods

        public void Initialize(string parameter)
        {
            _originalParameter = parameter;
            Parameter = parameter;
        }
        
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (_originalParameter == Parameter ||
                string.IsNullOrEmpty(_originalParameter) && string.IsNullOrEmpty(Parameter))
            {
                validationResults.Add(FieldValidationResult.CreateError(() => Parameter, "Change parameter before update"));
            }
        }

        protected override async Task OnClosingAsync()
        {
            await _messageService.ShowAsync("Are you sure you want to close window?", "Question", MessageButton.YesNo); // need to add cancelation of closing operation
            _pleaseWaitService.Show(() => Task.Delay(2000), "Long running process emulation"); // need to add method ShowAsync
        }
        
        #endregion
    }
}