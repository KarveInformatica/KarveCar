using System.Data;
using KarveDataServices.DataObjects;

namespace MasterModule.Interfaces
{
    public interface ISupplierPayload
    {
        ISupplierData SupplierDataObjectInfo { get; set; }
        ISupplierTypeData SupplierDataObjectType { get; set; }
        IProvinceData     SupplierProvinceDataObject { get; set; }
        ICountryData      SupplierCountryDataObject { get; set; }
        DataTable SupplierSummaryDataTable { get; set; }
        DataSet DataSet { get; set; }
    }
}