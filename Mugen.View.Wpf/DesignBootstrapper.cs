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
            return new MugenContainer();
        }

        private static DesignBootstrapper CreateInstance()
        {
            if (!ServiceProvider.IsDesignMode)
            {
                return null;
            }
            var boot = new DesignBootstrapper();
            boot.Initialize();
            return boot;
        }

        #endregion

        #region Properties

        public static MainViewModel MainViewModel
        {
            get { return CreateInstance().GetDesignViewModel(provider => provider.GetViewModel<MainViewModel>()); }
        }

        public static CompositeViewModel CompositeViewModel
        {
            get { return CreateInstance().GetDesignViewModel(provider => provider.GetViewModel<CompositeViewModel>()); }
        }

        #endregion
    }
}