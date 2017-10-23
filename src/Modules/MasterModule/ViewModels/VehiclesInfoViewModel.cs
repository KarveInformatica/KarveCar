using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        ///  This the private basic data template selector.
        /// </summary>
        private DataTemplateSelector _dataTemplateSelector;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="configurationService">This is the configurartion service</param>
        /// <param name="eventManager"> The event manager for sending/recieving messages from the view model</param>
        /// <param name="services">Data access layer interface</param>
        public VehiclesInfoViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services) : base(configurationService, eventManager, services)
        {
        }
        /// <summary>
        ///  This return a basic template selector for each item colletion.
        /// </summary>
        public DataTemplateSelector BasicTemplateSelector
        {
            
            get { return _dataTemplateSelector; }
            set { _dataTemplateSelector = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// This is the start notify.
        /// </summary>
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
        /// <summary>
        /// Set Data Object.
        /// </summary>
        /// <param name="result"></param>
        protected override void SetDataObject(object result)
        {
           
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
