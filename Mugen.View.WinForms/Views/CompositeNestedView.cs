using System.ComponentModel;
using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Mugen.Views
{
    public partial class CompositeNestedView : UserControl
    {
        public CompositeNestedView()
        {
            InitializeComponent();
            
            using (var set = new BindingSet<CompositeNestedViewModel>())
            {
                set.Bind(label)
                    .To(() => (vm, ctx) => vm.DisplayName);
            }
        }
    }
}