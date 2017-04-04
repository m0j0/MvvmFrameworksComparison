using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Light.ViewModels;

namespace Light.Views
{
    public partial class ChildView : Window
    {
        public ChildView()
        {
            InitializeComponent();
            Closing += OnClosing;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "CloseChildViewModel")
            {
                Close();
            }
        }

        private async void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            cancelEventArgs.Cancel = !await ((ChildViewModel) DataContext).OnClosingAsync();
        }
    }
}