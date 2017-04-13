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
                set.Bind(checkBoxCanOpenChildWindow, () => v => v.Checked)
                    .To(() => (vm, ctx) => vm.CanOpenChildViewModel)
                    .TwoWay();
                set.Bind(textBoxParameter, () => v => v.Text)
                    .To(() => (vm, ctx) => vm.Parameter)
                    .TwoWay();
                set.Bind(buttonOpenChildWindow)
                    .To(() => (vm, ctx) => vm.OpenChildViewModelCommand);
            }
        }
    }
}