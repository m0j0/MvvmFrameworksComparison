using System.Runtime.CompilerServices;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Mugen
{
    public static class Extensions
    {
        #region Methods

        public static void TraceNavigation(this IViewModel viewModel, INavigationContext ctx,
            IMessagePresenter messagePresenter, [CallerMemberName] string method = "")
        {
            messagePresenter.ShowAsync(
                $"Source “{GetName(viewModel)}”, method “{method}”, from “{GetName(ctx.ViewModelFrom)}” to “{GetName(ctx.ViewModelTo)}”, mode “{ctx.NavigationMode}”",
                "Navigation trace");
        }

        public static string GetName(this IViewModel viewModel)
        {
            return (viewModel as IHasDisplayName)?.DisplayName ?? viewModel?.GetType().Name ?? "(null)";
        }

        #endregion
    }
}