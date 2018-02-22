using KarveCommon.Command;
using KarveCommon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBarModule.Command
{
    internal abstract class BaseToolBarCommand: AbstractCommand, IDisposable
    {
        protected IDictionary<DataSubSystem, IDataPayLoadHandler> PayLoadHandlers =
           new Dictionary<DataSubSystem, IDataPayLoadHandler>()
           {
                { DataSubSystem.SupplierSubsystem, new SupplierDataPayload() },
                { DataSubSystem.CommissionAgentSubystem, new CommissionAgentPayload()},
                { DataSubSystem.VehicleSubsystem, new VehicleDataPayload() },
                { DataSubSystem.HelperSubsytsem, new HelperDataPayLoad() },
                { DataSubSystem.ClientSubsystem, new ClientDataPayload() },
                { DataSubSystem.OfficeSubsystem, new OfficeDataPayload() },
                { DataSubSystem.CompanySubsystem, new CompanyDataPayload() }
           };

        public abstract void Dispose();

    }
}
