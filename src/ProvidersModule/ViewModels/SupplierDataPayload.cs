using System;
using KarveCommon.Services;
using KarveDataServices.DataObjects;

namespace ProvidersModule.ViewModels
{
    internal class SupplierDataPayload : ISupplierPayload
    {
        public ISupplierDataObjectInfo SupplierDataObjectInfo { get; set ; }
        public ISupplierTypeDataObject SupplierDataObjectType { get; set; }
    }
}