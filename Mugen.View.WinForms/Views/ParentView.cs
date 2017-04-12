using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Mugen.Views
{
    public partial class ParentView : UserControl
    {
        public ParentView()
        {
            InitializeComponent();

            using (var set = new BindingSet<ParentViewModel>())
            {
                set.Bind(checkBoxCanOpenChildWindow, nameof(checkBoxCanOpenChildWindow.Checked))
                    .To(nameof(ParentViewModel.CanOpenChildViewModel))
                    .TwoWay();
                set.Bind(textBoxParameter, nameof(checkBoxCanOpenChildWindow.Text))
                    .To(nameof(ParentViewModel.Parameter))
                    .TwoWay();
                set.Bind(buttonOpenChildWindow, nameof(buttonOpenChildWindow.Click))
                    .To(nameof(ParentViewModel.OpenChildViewModelCommand));
            }
        }
    }
}