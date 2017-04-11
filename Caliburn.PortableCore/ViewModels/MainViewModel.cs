using System;
using System.Diagnostics;
using Caliburn.Managers;
using Caliburn.Micro;

namespace Caliburn.ViewModels
{
    public class MainViewModel : Screen
    {
        #region Fields

        private readonly IWindowManagerPortable _windowManager;
        private bool _canOpenChildViewModel;
        private string _parameter;

        #endregion

        #region Constructors

        public MainViewModel(IWindowManagerPortable windowManager)
        {
            if (windowManager == null) throw new ArgumentNullException(nameof(windowManager));
            _windowManager = windowManager;
            CanOpenChildViewModel = true;
        }

        #endregion

        #region Properties

        public override string DisplayName => "Main view model";

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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Commands

        public void OpenChildViewModel()
        {
            var childViewModel = IoC.Get<ChildViewModel>();
            childViewModel.Initialize(Parameter);

            if (!_windowManager.ShowDialog(childViewModel).GetValueOrDefault())
            {
                return;
            }

            Parameter = childViewModel.Parameter;
        }

        #endregion

        #region Methods

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
    }
}