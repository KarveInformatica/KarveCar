using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    // This view model is useful fro 
    class CompanyInfoViewModel: MasterInfoViewModuleBase

    {
        public CompanyInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IRegionManager manager) : base(eventManager, configurationService, dataServices, manager)
        {
        }

    }
}
