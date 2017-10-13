using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This represent the detailed class for the view model in case of each car.
    /// </summary>
    class VehiclesInfoViewModel: MasterViewModuleBase, IEventObserver
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="configurationService">This is the configurartion service</param>
        /// <param name="eventManager"> The event manager for sending/recieving messages from the view model</param>
        /// <param name="services">Data access layer interface</param>
        public VehiclesInfoViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services) : base(configurationService, eventManager, services)
        {
        }

        public override void StartAndNotify()
        {
            throw new NotImplementedException();
        }

        public override void NewItem()
        {
            throw new NotImplementedException();
        }

        protected override void SetTable(DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        protected override string GetRouteName(string name)
        {
            throw new NotImplementedException();
        }

        public void incomingPayload(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }
    }
}
