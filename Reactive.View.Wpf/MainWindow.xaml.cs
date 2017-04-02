using System.Windows;
using Reactive.Core.ViewModels;

namespace Reactive
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
