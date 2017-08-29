using KarveDataServices.DataObjects;
using System.Data;

namespace ProvidersModule
{
    public interface ISupplierPayload
    {
        ISupplierDataInfo SupplierDataObjectInfo { get; set; }
        ISupplierTypeData SupplierDataObjectType { get; set; }
        IProvinceData     SupplierProvinceDataObject { get; set; }
        ICountryData      SupplierCountryDataObject { get; set; }
        DataTable SupplierSummaryDataTable { get; set; }
    }
}