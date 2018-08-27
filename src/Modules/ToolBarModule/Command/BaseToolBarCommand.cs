using KarveCommon.Command;
using KarveCommon.Services;
using KarveDataServices.ViewObjects;
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
                { DataSubSystem.CompanySubsystem, new CompanyDataPayload() },
                { DataSubSystem.InvoiceSubsystem, new InvoiceDataPayload()},
                { DataSubSystem.BookingSubsystem, new BookingDataPayload()}
           };
        public override bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            if (!base.CanExecute(parameter))
            {
                return false;
            }
            if (parameter is BaseViewObject baseDto)
            {
                var tmp = baseDto.IsNew;
                if (tmp == true)
                {
                    baseDto.IsNew = false;
                }
                if (baseDto.HasErrors)
                    return false;
            }
            return true;
        }
        public abstract void Dispose();

    }
}
