using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.DataObjects;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.MappedStatements;
using System.Reflection;

namespace DataAccessLayer
{
    class SupplierDataAccessLayer : BaseDataMapper, ISupplierDataServices
    {

        public async Task<DataSet> GetAsyncAllSupplierSummary()
        {
            DataSet dataSet = new DataSet("SupplierDataSet");
            DataTable supplierTable = new DataTable("SuppliersSummary");
            supplierTable = await DataMapper.QueryAsyncForDataTable("Suppliers.GetAllSuppliersSummary", null);
            dataSet.Tables.Add(supplierTable);
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
        private void SetDataObjectFields(DataRow row, ref ISupplierDataObjectInfo dataObject)
        {
            Type t = dataObject.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo p in props)
            {
                string tmpValue = row[p.Name] as string;
                if ((tmpValue != null) && (p != null) && (dataObject != null))
                {


                    t.GetProperty(p.Name).SetValue(dataObject, tmpValue);
                }
                else
                {
                    t.GetProperty(p.Name).SetValue(dataObject, "");
                }
            }

        }
        public async Task<ISupplierDataObjectInfo> GetAsyncSupplierDataObjectInfo(string id)
        {
            ISupplierDataObjectInfo dataObject = new SupplierInfoDataObject();
            if (id != String.Empty)
            {

                IMapperCommand mapper1 = new QueryAsyncForObjectCommand<ISupplierDataObjectInfo>("Suppliers.GetSupplierInfos", id);
                IMapperCommand mapper2 = new QueryAsyncForDataTableCommand("Suppliers.GetProvinceForEachSupplier", null);

                DataMapper.AddBatch(mapper1);
                DataMapper.AddBatch(mapper2);

                DataTable provinceDataCode = null;
                DataSet resultBatch = await DataMapper.ExecuteAsyncBatch();
                // nombre tabla.
                for (int i = 0; i < resultBatch.Tables.Count; ++i)
                {
                    string tableName = resultBatch.Tables[i].TableName;
                    if (tableName.Contains("SupplierInfoResultMap"))
                    {
                        SetDataObjectFields(resultBatch.Tables[i].Rows[0], ref dataObject);
                    }
                    if (tableName.Contains("ProvinceData"))
                    {
                        provinceDataCode = resultBatch.Tables[i];
                    }
                }
                if (provinceDataCode != null)
                {
                    EnumerableRowCollection<DataRow> dataRows = provinceDataCode.AsEnumerable().Where(r => r.Field<string>("ProvinceCode") == dataObject.ProvinceCode);
                    foreach (DataRow dr in dataRows)
                    {
                        string provinceValue = (string)dr["Province"];
                        if (provinceValue.Length > 0)
                            dataObject.Province = provinceValue;
                        break;
                    }
                    string code = dataObject.CountryCode;
                    if (code != null)
                    {

                        IMapperCommand mapper3 = new QueryAsyncForDataTableCommand("Suppliers.GetCountryForSingleSupplier", code);
                        DataMapper.AddBatch(mapper3);
                        resultBatch = await DataMapper.ExecuteAsyncBatch();
                        DataTable countryDataCode = resultBatch.Tables[0];
                        dataRows = countryDataCode.AsEnumerable().Where(r => r.Field<string>("CountryCode") == dataObject.CountryCode);
                        foreach (DataRow dr in dataRows)
                        {
                            string countryValue = (string)dr["Name"];
                            if (countryValue.Length > 0)
                                dataObject.Country = countryValue;
                            break;
                        }
                    }
                }

            }
            return dataObject;
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
