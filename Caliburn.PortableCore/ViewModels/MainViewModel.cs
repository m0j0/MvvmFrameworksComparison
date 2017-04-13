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
            if (windowManager == null) throw new ArgumentNullException("windowManager");
            _windowManager = windowManager;
            CanOpenChildViewModel = true;
        }

        #endregion

        #region Properties

        public override string DisplayName
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
    }
}