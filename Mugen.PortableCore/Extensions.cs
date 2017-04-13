using System.Diagnostics;
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
            //messagePresenter.ShowAsync(
            Debug.WriteLine(string.Format("Source “{0}”, method “{1}”, from “{2}” to “{3}”, mode “{4}”",
                    GetName(viewModel), method, GetName(ctx.ViewModelFrom), GetName(ctx.ViewModelTo), ctx.NavigationMode),
                "Navigation trace");
        }

        private static string GetName(IViewModel viewModel)
        {
            var hasDisplayName = viewModel as IHasDisplayName;
            if (viewModel == null || hasDisplayName == null)
            {
                return "(null)";
            }
            return hasDisplayName.DisplayName ?? viewModel.GetType().Name ?? "(null)";
        }

        #endregion
    }
}