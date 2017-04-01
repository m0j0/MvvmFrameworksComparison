using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Cross.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Fields

        private bool _canOpenChildViewModel;
        private string _parameter;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            CanOpenChildViewModel = true;
            OpenChildViewModelCommand = new MvxCommand(OpenChildViewModel, CanExecuteOpenChildViewModel);
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
        }

        private bool CanExecuteOpenChildViewModel()
        {
            return CanOpenChildViewModel;
        }

        #endregion
    }
}
