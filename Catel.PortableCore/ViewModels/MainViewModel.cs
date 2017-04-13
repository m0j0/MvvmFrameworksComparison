using System;
using System.Diagnostics;
using System.Windows.Input;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;

namespace Catel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly ITypeFactory _typeFactory;
        private bool _canOpenChildViewModel;
        private string _parameter;
        private readonly ICommand _openChildViewModelCommand;

        #endregion

        #region Constructors

        public MainViewModel(IUIVisualizerService uiVisualizerService, ITypeFactory typeFactory)
        {
            if (uiVisualizerService == null) throw new ArgumentNullException("uiVisualizerService");
            if (typeFactory == null) throw new ArgumentNullException("typeFactory");
            _uiVisualizerService = uiVisualizerService;
            _typeFactory = typeFactory;
            _openChildViewModelCommand = new Command(OpenChildViewModel, CanExecuteOpenChildViewModel);
            CanOpenChildViewModel = true;

            CanceledAsync += async (sender, args)  => Debug.WriteLine("{0} canceled", Title);
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
            get { return "Main view model"; }
        }

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
                RaisePropertyChanged(() => CanOpenChildViewModel);
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
                RaisePropertyChanged(() => Parameter);
            }
        }

        #endregion

        #region Commands

        public ICommand OpenChildViewModelCommand
        {
            get { return _openChildViewModelCommand; }
        }

        private async void OpenChildViewModel()
        {
            ChildViewModel vm = _typeFactory.CreateInstance<ChildViewModel>();
            vm.Initialize(Parameter);

            if (!(await _uiVisualizerService.ShowDialogAsync(vm)).GetValueOrDefault())
            {
                return;
            }

            Parameter = vm.Parameter;
        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion
    }
}