using KarveDataServices.DataObjects;
using System.Data;

namespace MasterModule
{
    public interface ISupplierPayload
    {
        ISupplierDataInfo SupplierDataObjectInfo { get; set; }
        ISupplierTypeData SupplierDataObjectType { get; set; }
        IProvinceData     SupplierProvinceDataObject { get; set; }
        ICountryData      SupplierCountryDataObject { get; set; }
        DataTable SupplierSummaryDataTable { get; set; }
        DataSet DataSet { get; set; }
    }
}