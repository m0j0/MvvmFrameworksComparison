using System.Windows;

namespace Caliburn.Managers
{
    public class MessagePresenter : IMessagePresenter
    {
        public bool ShowQuestion(string text)
        {
            return MessageBox.Show(text, "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}