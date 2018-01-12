using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class VehicleRepostajeReasonViewModel : BaseHelperViewModel
    {
        public override void OnExitCommand(object value)
        {
         
        }

        public override void OnHelpCommand()
        {
        
        }
        public override void OnSaveCommand(object value)
        {
        }
        public VehicleRepostajeReasonViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(dataServices, region, manager)
        {
        }
    }
}
