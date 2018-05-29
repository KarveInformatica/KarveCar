using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using Prism.Regions;
using KarveCommon.Generic;
using System.Windows;
using KarveCommonInterfaces;
using Syncfusion.UI.Xaml.Grid;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the base class for all master registry view model.
    /// </summary>
    public abstract class MasterControlViewModuleBase: MasterViewModuleBase, ICreateRegionManagerScope
    {
        private bool _canDeleteRegion;
       /// <summary>
       /// Constructor for the control view model.
       /// </summary>
       /// <param name="configurationService">Service for the system configuration</param>
       /// <param name="eventManager">Manager of events.</param>
       /// <param name="dataServices">Data Services. Services for fetching data and storing data</param>
       /// <param name="service">Assist Service. Service for displaying a magnifier grid (aka lupa).</param>
       /// <param name="dialogService">Dialog Service. Service for spotting errors.</param>
       /// <param name="regionManager">Region Manager. Manager of the composite region.</param>
        public MasterControlViewModuleBase(IConfigurationService configurationService, 
                                           IEventManager eventManager, 
                                           IDataServices dataServices, 
                                           IRegionManager regionManager) : this(configurationService, eventManager,
           dataServices,null,null,regionManager)
        {
        }
        /// <summary>
        ///  Constructor for the control view model.
        /// </summary>
        /// <param name="configurationService">Configuration Service. Service for managing the configuration.</param>
        /// <param name="eventManager">Event Manager. Manager for communicating between two view models.</param>
        /// <param name="services">Data Services. Services for access to the data access layer.</param>
        /// <param name="dialogService">Dialog service for spotting errors in a modal way, respect MVVM.</param>
        /// <param name="regionManager">Region manager. Manager for registering a region and handling composite UI.</param>

        public MasterControlViewModuleBase(IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IInteractionRequestController interactionService, IDialogService dialogService, IRegionManager regionManager) : base(configurationService, eventManager, 
            services, dialogService, regionManager, interactionService )

        {
            _canDeleteRegion = false;
            DeleteEventHandler += DeleteElementHandler;
        }

        protected abstract void LoadMoreItems(uint count, int baseIndex);


        /// <summary>
        /// Dispose any event.
        /// </summary>
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            DeleteEventHandler -= DeleteElementHandler;
        }
        /// <summary>
        ///  Handle to delete. this is replicate to the top level see MasterViewModuleBase.
        /// </summary>
        /// <param name="sender">Notify task completion sender</param>
        /// <param name="e">Property</param>
        private void DeleteElementHandler(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion completion = sender as INotifyTaskCompletion;
            if (completion.IsSuccessfullyCompleted)
            {
                CanDeleteRegion = true;
            }
            else
            {
                // replace with configuration service.
                string messageBox = "Delete error: " + completion.ErrorMessage;
                if (DialogService!=null)
                {
                    DialogService.ShowErrorMessage(messageBox);
                }
            }
        }
        /// <summary>
        ///  This is a view model for the navigation.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

      
        /// <summary>
        ///  Get if the region shall be scoped.
        /// </summary>
        public bool CreateRegionManagerScope
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        ///  Can delete a region or not.
        /// </summary>
        public override bool CanDeleteRegion
        {
            get
            {
                return _canDeleteRegion;
            }
            set
            {
                _canDeleteRegion = value;
            }
        }
    }
}
