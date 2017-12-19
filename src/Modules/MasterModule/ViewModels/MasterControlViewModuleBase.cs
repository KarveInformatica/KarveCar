using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  TODO rethink about this. 
    /// </summary>
    public abstract class MasterControlViewModuleBase: MasterViewModuleBase
    {
        public MasterControlViewModuleBase(IConfigurationService configurationService, IEventManager eventManager, IDataServices services, IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)
        {
        }
        protected override void SetTable(DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        public override long GridId { get; set; }
        public override string MagnifierGridName { get; set; }
        protected override void SetDataObject(object result)
        {
            throw new NotImplementedException();
        }
       
    }
}
