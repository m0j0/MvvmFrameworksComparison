using System;
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
            _windowManager.ShowDialog(new ChildViewModel());
        }

        #endregion
    }
}