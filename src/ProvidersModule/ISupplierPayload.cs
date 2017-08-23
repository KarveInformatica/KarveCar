using KarveDataServices.DataObjects;

namespace ProvidersModule
{
    public interface ISupplierPayload
    {
        ISupplierDataObjectInfo SupplierDataObjectInfo { get; set; }
        ISupplierTypeDataObject SupplierDataObjectType { get; set; }
        IProvinceDataObject     SupplierProvinceDataObject { get; set; }
        ICountryDataObject      SupplierCountryDataObject { get; set; }
    }
}