﻿using System;
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

        #endregion

        #region Constructors

        public MainViewModel(IUIVisualizerService uiVisualizerService, ITypeFactory typeFactory)
        {
            if (uiVisualizerService == null) throw new ArgumentNullException(nameof(uiVisualizerService));
            if (typeFactory == null) throw new ArgumentNullException(nameof(typeFactory));
            _uiVisualizerService = uiVisualizerService;
            _typeFactory = typeFactory;
            OpenChildViewModelCommand = new Command(OpenChildViewModel, CanExecuteOpenChildViewModel);
            CanOpenChildViewModel = true;

            CanceledAsync += async (sender, args)  => Debug.WriteLine($"{Title} canceled");
            CancelingAsync += async (sender, args) => Debug.WriteLine($"{Title} canceling");
            ClosedAsync += async (sender, args) => Debug.WriteLine($"{Title} closed");
            ClosingAsync += async (sender, args) => Debug.WriteLine($"{Title} closing");
            InitializedAsync += async (sender, args) => Debug.WriteLine($"{Title} initialized");
            NavigationCompleted += async (sender, args) => Debug.WriteLine($"{Title} navigation");
        }

        #endregion

        #region Properties

        public override string Title => "Main view model";

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
                RaisePropertyChanged(nameof(CanOpenChildViewModel));
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
                RaisePropertyChanged(nameof(Parameter));
            }
        }

        #endregion

        #region Commands

        public ICommand OpenChildViewModelCommand { get; }

        private async void OpenChildViewModel()
        {
            var vm = _typeFactory.CreateInstance<ChildViewModel>();
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