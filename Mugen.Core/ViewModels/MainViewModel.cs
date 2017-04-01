using System.Windows.Input;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private bool _canOpenChildViewModel;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            OpenChildViewModelCommand =  new RelayCommand(OpenChildViewModel, CanExecuteOpenChildViewModel, this);
        }

        #endregion
        
        #region Properties

        public string DisplayName => "Main view model";

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
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OpenChildViewModelCommand { get; }

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
