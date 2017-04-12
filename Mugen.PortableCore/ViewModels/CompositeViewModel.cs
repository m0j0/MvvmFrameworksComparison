using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class CompositeViewModel : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private string _displayName;
        private int _id;

        #endregion

        #region Constructors

        public CompositeViewModel()
        {
            FirstNestedViewModel = GetViewModel<CompositeNestedViewModel>();
            FirstNestedViewModel.DisplayName = "First nested view model";
            SecondNestedViewModel = GetViewModel<CompositeNestedViewModel>();
            SecondNestedViewModel.DisplayName = "Second nested view model";
            ThirdNestedViewModel = GetViewModel<CompositeNestedViewModel>();
            ThirdNestedViewModel.DisplayName = "Third nested view model";
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                _displayName = "Composite view model " + _id;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public CompositeNestedViewModel FirstNestedViewModel { get; }

        public CompositeNestedViewModel SecondNestedViewModel { get; }

        public CompositeNestedViewModel ThirdNestedViewModel { get; }

        #endregion
    }
}