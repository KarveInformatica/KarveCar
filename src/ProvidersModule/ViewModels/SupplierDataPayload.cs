using System;
using KarveCommon.Services;
using KarveDataServices.DataObjects;

namespace ProvidersModule.ViewModels
{
    public class SupplierDataPayload : ISupplierPayload
    {
        public ISupplierDataObjectInfo SupplierDataObjectInfo { get; set ; }
        public ISupplierTypeDataObject SupplierDataObjectType { get; set; }
        public IProvinceDataObject SupplierProvinceDataObject { get; set; }
        public ICountryDataObject SupplierCountryDataObject { get; set; }
    }
}