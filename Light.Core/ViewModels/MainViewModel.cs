using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Light.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        
        private bool _canOpenChildViewModel;
        private string _parameter;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            CanOpenChildViewModel = true;
            OpenChildViewModelCommand = new RelayCommand(OpenChildViewModel, CanExecuteOpenChildViewModel);
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

        public ICommand OpenChildViewModelCommand { get; }

        private void OpenChildViewModel()
        {
            //using (var viewModel = GetViewModel<ChildViewModel>())
            //{
            //    viewModel.Initialize(Parameter);

            //    if (!await viewModel.ShowAsync())
            //    {
            //        return;
            //    }

            //    Parameter = viewModel.Parameter;
            //}
        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion
    }
}