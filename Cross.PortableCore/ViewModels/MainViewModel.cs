using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Cross.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Fields

        private bool _canOpenChildViewModel;
        private string _parameter;
        private readonly MvxCommand _openChildViewModelCommand;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            _openChildViewModelCommand = new MvxCommand(OpenChildViewModel, CanExecuteOpenChildViewModel);
            CanOpenChildViewModel = true;
        }

        #endregion

        #region Properties

        public string DisplayName
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
                RaisePropertyChanged();
                _openChildViewModelCommand.RaiseCanExecuteChanged();
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
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OpenChildViewModelCommand
        {
            get { return _openChildViewModelCommand; }
        }

        private void OpenChildViewModel()
        {
            ShowViewModel<ChildViewModel>(new {parameter = Parameter});
        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion

        #region Methods
        
        public void Init(string parameter)
        {
            Parameter = parameter;
        }

        #endregion
    }
}
