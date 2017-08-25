using KarveDataServices.DataObjects;

namespace ProvidersModule
{
    public interface ISupplierPayload
    {
        ISupplierDataInfo SupplierDataObjectInfo { get; set; }
        ISupplierTypeData SupplierDataObjectType { get; set; }
        IProvinceData     SupplierProvinceDataObject { get; set; }
        ICountryData      SupplierCountryDataObject { get; set; }
    }
}