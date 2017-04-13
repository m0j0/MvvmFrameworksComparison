using System.Windows.Forms;
using Mugen.Templates;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace Mugen.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            using (var set = new BindingSet<MainViewModel>())
            {
                set.Bind(this, () => v => v.Text)
                    .To(() => (vm, ctx) => vm.DisplayName);

                set.Bind(buttonAddNewTab)
                    .To(() => (vm, ctx) => vm.AddNewTabCommand);

                tabControl.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector,
                    ViewModelTabDataTemplate.Instance);
                set.Bind(tabControl, AttachedMembers.Object.ItemsSource)
                    .To(() => (vm, ctx) => vm.ItemsSource);
                set.Bind(tabControl, AttachedMembers.TabControl.SelectedItem)
                    .To(() => (vm, ctx) => vm.SelectedItem)
                    .TwoWay();
            }
        }
    }
}