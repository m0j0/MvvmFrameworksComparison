using System.Windows.Forms;
using Mugen.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace Mugen.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            using (var set = new BindingSet<MainViewModel>())
            {
                set.Bind(this, nameof(Text))
                    .To(nameof(ParentViewModel.DisplayName));
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