using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Services;
using MasterModule.Common;
using Prism.Regions;
using KarveDataServices;

namespace MasterModule.ViewModels { 
	
    /// <summary>
    ///  This base claass simply override the things that are not needed for the Info Viewmodels.
    /// </summary>
	public abstract class MasterInfoViewModuleBase : MasterViewModuleBase
    {
        // TODO: let see for the SRP
        public MasterInfoViewModuleBase(IEventManager eventManager, 
                                        IConfigurationService configurationService,
                                        IDataServices dataServices, IRegionManager manager) : base(configurationService, eventManager, dataServices, manager)
        { 
		}

        public override async Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            await Task.Delay(1);
            return false;
        }

        public override void NewItem()
        {
        }

        public override void StartAndNotify()
        {
          
        }
        protected override string GetRouteName(string name)
        {
            return "";
        }

        protected override void SetDataObject(object result)
        {   
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {   
        }

        protected override void SetTable(DataTable table)
        {   
        }
        public override long GridId { set; get; }
        public override string MagnifierGridName { set; get; }
        protected IDictionary<string, string> ViewModelQueries { get; set; }
    }

}