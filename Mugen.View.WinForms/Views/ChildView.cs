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

            using (var set = new BindingSet())
            {
                set.Bind(this, nameof(Text))
                    .To(nameof(MainViewModel.DisplayName));
                set.Bind(textBoxParameter, nameof(textBoxParameter.Text))
                    .To(nameof(ChildViewModel.Parameter))
                    .TwoWay()
                    .Validate();
                set.Bind(buttonUpdateParameter, nameof(buttonUpdateParameter.Click))
                    .To(nameof(ChildViewModel.ApplyCommand));
                set.Bind(buttonClose, nameof(buttonClose.Click))
                    .To(nameof(ChildViewModel.CloseCommand));

                set.Bind(progressBarIsBusy, nameof(progressBarIsBusy.Visible))
                    .To(nameof(ChildViewModel.IsBusy));
                set.Bind(labelBusyMessage, nameof(labelBusyMessage.Visible))
                    .To(nameof(ChildViewModel.IsBusy));
                set.Bind(labelBusyMessage, nameof(labelBusyMessage.Text))
                    .To(nameof(ChildViewModel.BusyMessage));
            }
        }
    }
}