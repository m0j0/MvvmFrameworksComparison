using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;
using MugenMvvmToolkit.WinForms.Binding.Infrastructure;

namespace Mugen.Views
{
    public partial class CompositeView : UserControl
    {
        public CompositeView()
        {
            InitializeComponent();
            
            using (var set = new BindingSet<CompositeViewModel>())
            {
                set.Bind(buttonClose)
                    .To(() => (vm, ctx) => vm.CloseCommand);

                nestedTableLayoutPanel.SetBindingMemberValue(AttachedMembers.Control.ContentViewManager, new ContentViewManager());
                set.Bind(nestedTableLayoutPanel, AttachedMemberConstants.Content)
                    .To(() => (vm, ctx) => vm.FirstNestedViewModel);

                set.Bind(compositeNestedView3, AttachedMembers.Object.DataContext)
                    .To(() => (vm, ctx) => vm.ThirdNestedViewModel);
            }
        }
    }

    public class ContentViewManager : ContentViewManagerBase<Control, Control>
    {
        #region Overrides of ContentViewManagerBase<Control,Control>

        protected override void SetContent(Control view, Control content)
        {
            if (content == null)
            {
                view.Controls.Clear();
            }
            else
            {
                view.Controls.Add(content);
            }
        }

        #endregion
    }
}