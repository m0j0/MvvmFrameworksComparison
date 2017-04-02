using System.Windows;

namespace Cross.Services
{
    public class MessagePresenter : IMessagePresenter
    {
        public bool ShowQuestion(string text)
        {
            return MessageBox.Show(text, "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}