using Controls.Views;
using Infrastructure;
using Infrastructure.Events;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Threading;

namespace Instruments
{
    [Module(ModuleName = "InstrumentsModule")]
    public class InstrumentsModule : IModule
    {
        private readonly IEventAggregator _eventAggregator;

        #region Constructors

        public InstrumentsModule(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        #endregion Constructors

        #region Methods

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();

            if (Thread.CurrentPrincipal.IsInRole(UserRoleNames.InstrumentView))
                regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion,
                                                    typeof(Views.InstrumentsNavigationItem));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Views.InstrumentCreationDialog>();

            containerRegistry.Register<ViewModels.InstrumentCreationDialogViewModel>();
            containerRegistry.Register<ViewModels.InstrumentEditViewModel>();
            containerRegistry.Register<ViewModels.InstrumentMainViewModel>();

            containerRegistry.Register<Object, Views.CalibrationReportEdit>(InstrumentViewNames.CalibrationReportEditView);
            containerRegistry.Register<Object, Views.InstrumentEdit>(InstrumentViewNames.InstrumentEditView);
            containerRegistry.Register<Object, Views.InstrumentMain>(InstrumentViewNames.InstrumentsMainView);

            containerRegistry.RegisterForNavigation(typeof(Views.InstrumentMain), InstrumentViewNames.InstrumentsMainView);
            
            containerRegistry.RegisterSingleton<InstrumentService, InstrumentService>();

            _eventAggregator.GetEvent<NavigationRequested>()
                .Publish(new NavigationToken(InstrumentViewNames.InstrumentsMainView));
        }

        #endregion Methods
    }
}