using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace Prism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Fields
        
        private bool _canOpenChildViewModel;
        private string _parameter;
        private readonly ICommand _openChildViewModelCommand;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            CanOpenChildViewModel = true;
            _openChildViewModelCommand = new DelegateCommand(OpenChildViewModel, CanExecuteOpenChildViewModel).ObservesProperty(() => CanOpenChildViewModel);
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


        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion
    }
}