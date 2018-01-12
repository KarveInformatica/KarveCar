using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    internal class VehicleOwnerViewModel : BaseHelperViewModel
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

        public VehicleOwnerViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(dataServices, region, manager)
        {
        }
    }
}
