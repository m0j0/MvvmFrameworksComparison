using System.ComponentModel;
using System.Windows;
using Light.ViewModels;

namespace Light.Views
{
    public partial class ChildView : Window
    {
        public ChildView()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        private async void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            cancelEventArgs.Cancel = !await ((ChildViewModel) DataContext).OnClosingAsync();
        }
    }
}