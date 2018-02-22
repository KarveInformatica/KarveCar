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

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the base class for all master registry view model.
    /// </summary>
    public abstract class MasterControlViewModuleBase: MasterViewModuleBase
    {
        private bool _canDeleteRegion;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configurationService">Configuration Service</param>
        /// <param name="eventManager">Event manager</param>
        /// <param name="services">Services</param>
        /// <param name="regionManager">Region manager</param>
        public MasterControlViewModuleBase(IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)

        {
            _canDeleteRegion = false;
            DeleteEventHandler += DeleteElementHandler;
        }
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
                MessageBox.Show(messageBox);
                
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
