using System.Windows;
using Reactive.Core.ViewModels;

namespace Reactive.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
