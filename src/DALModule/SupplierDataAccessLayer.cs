using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    class SupplierDataAccessLayer: BaseDataMapper, ISupplierDataServices
    {
        public async Task<DataSet> GetAsyncAllSupplierSummary()
        {
            DataSet dataSet = new DataSet("SupplierDataSet");
            DataTable supplierTable = dataSet.Tables.Add("SupplierDataSummary");
            supplierTable = await DataMapper.QueryAsyncForDataTable("Suppliers.GetAllSuppliersSummary", null);
            return dataSet;
        }

        public Task<DataSet> GetAsyncAllSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<ISupplierDataObject>> GetAsyncAllSupplierDataObjects()
        {
            throw new NotImplementedException();
        }

        public Task<ISupplierDataObjectInfo> GetAsyncSupplierDataObjectInfo(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncAllProvinces()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<object> GetAsyncAllProvinceDataObjects()
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllSuppliers()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<object> GetAllSupplierDataObject()
        {
            throw new NotImplementedException();
        }

        public ISupplierDataObjectInfo GetSupplierDataObjectInfo(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSupplierTypes()
        {
            throw new NotImplementedException();
        }

        public ICountryDataObject GetSupplierCountry(string id)
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ICountryDataObject> GetAllCountriesCountryDataObjects()
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllProvinces()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<IProvinceDataObject> GetAllProvinceDataObjects()
        {
            throw new NotImplementedException();
        }
    }
}
