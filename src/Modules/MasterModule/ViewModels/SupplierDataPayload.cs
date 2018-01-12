using System;
using KarveCommon.Services;
using KarveDataServices.DataObjects;
using System.Data;
using MasterModule.Interfaces;

namespace MasterModule.ViewModels
{
    public class SupplierDataPayload 
    {
        public ISupplierData SupplierDataObjectInfo { get; set ; }
        public ISupplierTypeData SupplierDataObjectType { get; set; }
        public IProvinceData SupplierProvinceDataObject { get; set; }
        public ICountryData SupplierCountryDataObject { get; set; }
        public DataTable SupplierSummaryDataTable { get; set; }
        public DataSet DataSet { get; set; }
    }
}