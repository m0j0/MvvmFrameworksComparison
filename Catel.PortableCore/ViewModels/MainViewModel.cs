using System.Windows.Input;
using Catel.MVVM;

namespace Catel.ViewModels
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
            OpenChildViewModelCommand = new Command(OpenChildViewModel, CanExecuteOpenChildViewModel);
            CanOpenChildViewModel = true;
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