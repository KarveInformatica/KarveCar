using KarveCommon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBarModule.ViewModel
{
    // The only reason to change of this class is adding a new subsystem to the toolbar dispatching
    internal static class SubsystemFactory
    {
        internal static Dictionary<DataSubSystem, string> GetSubsytem()
        {
            return new Dictionary<DataSubSystem, string>()
            {
                {DataSubSystem.CommissionAgentSubystem, EventSubsystem.CommissionAgentSummaryVm},
                {DataSubSystem.CompanySubsystem, EventSubsystem.CompanySummaryVm},
                {DataSubSystem.ClientSubsystem, EventSubsystem.ClientSummaryVm},
                {DataSubSystem.OfficeSubsystem, EventSubsystem.OfficeSummaryVm},
                {DataSubSystem.HelperSubsytsem, EventSubsystem.HelperSubsystem},
                {DataSubSystem.SupplierSubsystem, EventSubsystem.SuppliersSummaryVm},
                {DataSubSystem.VehicleSubsystem, EventSubsystem.VehichleSummaryVm}
            };

        }
    }
}
