using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class MainViewModel : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private bool _canOpenChildViewModel;
        private string _parameter;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            CanOpenChildViewModel = true;
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
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OpenChildViewModelCommand { get; }

        private async void OpenChildViewModel()
        {
            using (var viewModel = GetViewModel<ChildViewModel>())
            {
                viewModel.Parameter = Parameter;
                if (!await viewModel.ShowAsync())
                {
                    return;
                }

                Parameter = viewModel.Parameter;
            }
        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion
    }
}
