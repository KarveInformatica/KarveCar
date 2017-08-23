using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using DataAccessLayer.DataObjects;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.MappedStatements;
using System.Reflection;

namespace DataAccessLayer
{
    class SupplierDataAccessLayer : BaseDataMapper, ISupplierDataServices
    {
        #region ISupplierDataService Interface

        /// <summary>
        /// This method returns a table of the join between PROVEE1 and PROVEE2 
        /// </summary>
        /// <returns>It returns a dataset containing the complete summary.</returns>
        public async Task<DataSet> GetAsyncCompleteSummary()
        {
            DataSet dataSet = new DataSet("FullSupplierDataSet");
            DataTable supplierTable;
            supplierTable = await DataMapper.QueryAsyncForDataTable("Suppliers.GetFullSuppliersSummary", null).ConfigureAwait(false);
            dataSet.Tables.Add(supplierTable);
            return dataSet;
        }
        /// <summary>
        /// This method look for the Number, Nif, and brief summary of the supplier.
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncAllSupplierSummary()
        {
            DataSet dataSet = new DataSet("SupplierDataSet");
            DataTable supplierTable ;
            supplierTable = await DataMapper.QueryAsyncForDataTable("Suppliers.GetAllSuppliersSummary", null).ConfigureAwait(false);
            dataSet.Tables.Add(supplierTable);
            return dataSet;
        }
        /// <summary>
        ///  This method resutins all providers types 
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncAllProviderTypes()
        {
            DataSet dataSet = new DataSet("SuppliersTypesDataSet");
            DataTable supplierTable;
            supplierTable = await DataMapper.QueryAsyncForDataTable("Suppliers.GetSupplierTypes", null).ConfigureAwait(false);
            dataSet.Tables.Add(supplierTable);
            return dataSet;
        }
        /// <summary>
        /// Retrieve the supplier data object info for the general summary.
        /// </summary>
        /// <param name="id">Identifier of the provider</param>
        /// <returns>A supplier data object info for the the UI, which contains all the info for the general</returns>
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
                DataSet resultBatch = await DataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
                // nombre tabla.
                for (int i = 0; i < resultBatch.Tables.Count; ++i)
                {
                    string tableName = resultBatch.Tables[i].TableName;
                  
                    if (tableName.Contains("SupplierInfo"))
                    {
                        SetDataObjectFields(resultBatch.Tables[i].Rows[0], ref dataObject);
                    }
                    if (tableName.Contains("Province"))
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
                        resultBatch = await DataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
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
        public async Task<ISupplierTypeDataObject> GetAsyncSupplierTypesDataObject(string id)
        {
            IMapperCommand mapperSupplierTypes = new QueryAsyncForObjectCommand<ISupplierTypeDataObject>("Suppliers.GetSupplierTypeById", id);
            DataMapper.AddBatch(mapperSupplierTypes);
            DataSet supplierTypesDataSet = await DataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
            ISupplierTypeDataObject dataObjectType = new SupplierTypeDataObject();
            // we need at least a result
           if (supplierTypesDataSet.Tables.Count == 1)
            {
                DataTable table = supplierTypesDataSet.Tables[0];
                SetDataObjectFields(table.Rows[0], ref dataObjectType);

            }
            return dataObjectType;
        }
#endregion
        #region Private Methods
        private void SetDataObjectFields<T>(DataRow row, ref  T dataObject)
        {
  
            Type t = dataObject.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo p in props)
            {
                string tmpValue = row.Table.Columns.Contains(p.Name) ? row[p.Name] as string : null;
                if ((tmpValue != null) && (p != null) && (dataObject != null))
                {


                    t.GetProperty(p.Name).SetValue(dataObject, Convert.ChangeType(tmpValue, p.PropertyType), null);
                }
            }

        }
        #endregion

    }
}
