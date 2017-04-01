using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cross.ViewModels;
using MvvmCross.Wpf.Views;

namespace Cross.Views
{
    public partial class MainView : MvxWpfView//<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
