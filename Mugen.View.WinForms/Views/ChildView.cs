using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Mugen.Views
{
    public partial class ChildView : Form
    {
        public ChildView()
        {
            InitializeComponent();

            using (var set = new BindingSet<ChildViewModel>())
            {
                set.Bind(this, () => v => v.Text)
                    .To(() => (vm, ctx) => vm.DisplayName);
                set.Bind(textBoxParameter, () => v => v.Text)
                    .To(() => (vm, ctx) => vm.Parameter)
                    .TwoWay()
                    .Validate();
                set.Bind(buttonUpdateParameter)
                    .To(() => (vm, ctx) => vm.ApplyCommand);
                set.Bind(buttonClose)
                    .To(() => (vm, ctx) => vm.CloseCommand);

                set.Bind(progressBarIsBusy, () => v => v.Visible)
                    .To(() => (vm, ctx) => vm.IsBusy);
                set.Bind(labelBusyMessage, () => v => v.Visible)
                    .To(() => (vm, ctx) => vm.IsBusy);
                set.Bind(labelBusyMessage, () => v => v.Text)
                    .To(() => (vm, ctx) => vm.BusyMessage);
            }
        }
    }
}