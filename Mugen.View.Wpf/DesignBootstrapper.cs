using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugen.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.ViewModels;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Mugen
{
    public class DesignBootstrapper : WpfDesignBootstrapperBase
    {
        #region Nested types

        private sealed class DefaultApp : MvvmApplication
        {
            public override Type GetStartViewModelType()
            {
                return typeof(MainViewModel);
            }
        }

        #endregion

        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new DefaultApp();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        #endregion

        #region Properties

        public MainViewModel MainViewModel => GetOrAddViewModel(provider => provider.GetViewModel<MainViewModel>());

        public CompositeViewModel CompositeViewModel => GetOrAddViewModel(provider => provider.GetViewModel<CompositeViewModel>());

        public CompositeNestedViewModel CompositeNestedViewModel => GetOrAddViewModel(provider => provider.GetViewModel<CompositeNestedViewModel>());

        #endregion
    }
}
