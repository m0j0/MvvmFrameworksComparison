using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace Mugen.Views
{
    public partial class CompositeView : UserControl
    {
        public CompositeView()
        {
            InitializeComponent();

            using (var set = new BindingSet<CompositeViewModel>())
            {
                set.Bind(compositeNestedView3, AttachedMembers.Object.DataContext)
                    .To(() => (vm, ctx) => vm.ThirdNestedViewModel);
            }
        }
    }
}