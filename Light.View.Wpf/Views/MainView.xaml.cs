using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Light.ViewModels;

namespace Light.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ViewModelLocator.ShowChildViewModelMessage)
            {
                var view2 = new ChildView();
                view2.Show();
            }
        }
    }
}
