using System.Windows;
using Caliburn.Interfaces;

namespace Caliburn.Views
{
    public partial class ChildView : Window, ICloseableView
    {
        public ChildView()
        {
            InitializeComponent();
        }

        public void Close(bool dialogResult)
        {
            DialogResult = dialogResult;
            Close();
        }
    }
}