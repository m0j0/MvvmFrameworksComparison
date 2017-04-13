using System;
using Mugen.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.ViewModels;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Mugen
{
    public class DesignBootstrapper : WpfDesignBootstrapperBase
    {
        #region Nested types

        private sealed class DefaultApp : MvvmApplication
        {
            #region Methods

            public override Type GetStartViewModelType()
            {
                return typeof(MainViewModel);
            }

            #endregion
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

        public MainViewModel MainViewModel
        {
            get { return GetOrAddViewModel(provider => provider.GetViewModel<MainViewModel>()); }
        }

        public CompositeViewModel CompositeViewModel
        {
            get { return GetOrAddViewModel(provider => provider.GetViewModel<CompositeViewModel>()); }
        }

        #endregion
    }
}