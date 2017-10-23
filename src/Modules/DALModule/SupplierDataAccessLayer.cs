using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;

using EnvConfig = KarveCommon.Generic.EnvironmentConfig;

namespace DataAccessLayer
{

    internal class SupplierDataAccessLayer : AbstractDataAccessLayer, ISupplierDataServices
    {
        private IConfigurationService _service;
        private ISqlQueryExecutor _queryExecutor;
        private ISqlSession _session = null;
        public const string SupplierTable1 = "PROVEE1";
        public const string SupplierTable2 = "PROVEE2";
        public const string PrimaryKey = "NUM_PROVEE";

        private object _currentMerge = new object();
        /// <summary>
        /// This a supplier data access layer constructor
        /// </summary>
        /// <param name="mapper">The sql layer for the connection</param>
        /// <param name="service">The global configuration service</param>
        public SupplierDataAccessLayer(ISqlQueryExecutor mapper, IConfigurationService service) :base(mapper)
        {
            this._queryExecutor = mapper;
            this._service = service;
        }


        /// <summary>
        /// Return the dataset of the delegations given a supplier.
        /// </summary>
        /// <param name="supplierCode">code of the supplier</param>
        /// <returns></returns>
        public async Task<Tuple<string, DataSet>> GetAsyncDelegations(string supplierCode)
        {
            string supplierCodeQuery = "";
            DataSet delegationDataSet;

            if (!string.IsNullOrEmpty(supplierCode))
            {
                supplierCodeQuery = string.Format(GenericSql.DelegationQuery, "'" + supplierCode + "'");
                delegationDataSet = await _queryExecutor.AsyncDataSetLoad(supplierCodeQuery);

            }
            else
            {
                supplierCodeQuery = string.Format(GenericSql.DelegationGenericQuery);
                delegationDataSet = await _queryExecutor.AsyncDataSetLoad(supplierCodeQuery);
            }
            Tuple<string, DataSet> retValue = new Tuple<string, DataSet>(supplierCodeQuery, delegationDataSet);
            return retValue;
        }
        /// <summary>
        /// This function deletes a supplier form the supplierId
        /// </summary>
        /// <param name="sqlQuery"> A query for deleting the suppleir</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="supplierDataSet">The supplierDataSet</param>
        /// <returns></returns>

        public bool DeleteSupplier(string sqlQuery,
                                    string supplierId,
                                    DataSet supplierDataSet)
        {
            if (supplierDataSet == null)
            {
                return false;
            }
            return DeleteData(sqlQuery, supplierId, PrimaryKey, supplierDataSet);
        }

        /// <summary>
        /// This update a set of dataset with batch of queries.
        /// </summary>
        /// <param name="queries">List of the queries to be updated</param>
        /// <param name="setList">DataSet to be updated.</param>
        public void UpdateDataSetList(IDictionary<string, string> queries, IList<DataSet> setList)
        {
            StringBuilder queryStringBuilder = new StringBuilder();
            _queryExecutor.BeginTransaction();

            if (queries == null)
            {
                return;
            }

            foreach (DataSet set in setList)
            {
                DataSet tmp = set;
                if (set != null)
                {
                    foreach (DataTable table in set.Tables)
                    {
                        if (queries.ContainsKey(table.TableName))
                        {
                            queryStringBuilder.Append(queries[table.TableName]);
                            queryStringBuilder.Append(";");
                        }
                    }
                    _queryExecutor.UpdateDataSet(queryStringBuilder.ToString(), ref tmp);
                }
            }
            _queryExecutor.Commit();

        }

        /// <summary>
        /// Get suppliers contacts.
        /// </summary>
        /// <param name="supplierId">It returns the contact given a supplierId</param>
        /// <returns></returns>
        public Task<DataSet> GetAsyncSupplierContacts(string supplierId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update a dataset from the supplierId
        /// </summary>
        /// <param name="queries">List of the queries to be used for updating.</param>
        /// <param name="set">Set to be used for the updating.</param>
        public void UpdateDataSet(IDictionary<string, string> queries, DataSet set)
        {
            StringBuilder queryStringBuilder = new StringBuilder();
            if (queries == null)
            {
                return;
            }
            if (set != null)
            {
                foreach (DataTable table in set.Tables)
                {
                    if (queries.ContainsKey(table.TableName))
                    {
                        queryStringBuilder.Append(queries[table.TableName]);
                        queryStringBuilder.Append(";");
                    }
                }
                _queryExecutor.BeginTransaction();
                _queryExecutor.UpdateDataSet(queryStringBuilder.ToString(), ref set);
                _queryExecutor.Commit();
            }
        }

        /// <summary>
        ///  This function simply generates a new identifier.
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            string name = GenerateUniqueId();
            return name;
        }
        /// <summary>
        /// This returns a new supplier.
        /// </summary>
        /// <param name="queryList">List of the queries for the supplier</param>
        /// <returns></returns>
        public async Task<DataSet> GetNewSupplier(IDictionary<string, string> queryList)
        {
            DataSet set = await _queryExecutor.AsyncDataSetLoadBatch(queryList);
            string supplierId = GetNewId();
            for (int i = 0; i < set.Tables.Count; ++i)
            {
                if (set.Tables[i].Columns.Contains("NUM_PROVEE"))
                {
                    if (set.Tables[i].Rows.Count > 0)
                    {
                        set.Tables[i].Rows[0]["NUM_PROVEE"] = supplierId;
                    }
                    foreach (DataColumn col in set.Tables[i].Columns)
                    {
                        if (col.DataType == typeof(string))
                        {
                            if (col.ColumnName != "NUM_PROVEE")
                                set.Tables[i].Rows[0][col] = "";
                        }
                    }
                }
            }
           
            return set;
        }
        /// <summary>
        ///  This generate an uniqueId
        /// </summary>
        /// <returns></returns>
        private string GenerateUniqueId()
        {
            string id = "";
            do
            {
                byte[] data = new byte[2];
                using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetBytes(data);
                }
                var tmpNumber = BitConverter.ToUInt16(data, 0);

                id = tmpNumber.ToString();
                string str = "SELECT NUM_PROVEE FROM PROVEE1 WHERE NUM_PROVEE='{0}'";
                str = string.Format(str, id);
                DataTable table = _queryExecutor.ExecuteSelectCommand(str, CommandType.Text);
                if (table.Rows.Count == 0)
                {
                    break;
                }
            } while (true);

            return id;
        }

        /// <summary>
        ///  Get async supplier dataset
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncSuppliers()
        {
            DataSet summary = await _queryExecutor.AsyncDataSetLoad(GenericSql.SupplierQuery).ConfigureAwait(false);
            return summary;
        }
        /// <summary>
        ///  Get async supplier summary.
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncAllSupplierSummary()
        {
            DataSet summary = await _queryExecutor.AsyncDataSetLoad(GenericSql.SupplierSummaryQuery).ConfigureAwait(false);
            return summary;
        }

        public DataSet GetSuppliersSummaryPaged(long startPos)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSuppliersSummaryPaged()
        {
            throw new NotImplementedException();
        }

        public async Task<DataSet> GetAsyncSupplierInfo(IDictionary<string, string> queryList)
        {
            DataSet summary = await _queryExecutor.AsyncDataSetLoadBatch(queryList);
            return summary;
        }

        public bool DeleteSupplier(IDictionary<string, string> queries, DataSet supplierDataSet)
        {
            if (supplierDataSet == null)
            {
                return false;
            }
            if (queries == null)
            {
                return false;
            }

            StringBuilder queryStringBuilder = new StringBuilder();

            foreach (DataTable table in supplierDataSet.Tables)
            {
                if (queries.ContainsKey(table.TableName))
                {
                    queryStringBuilder.Append(queries[table.TableName]);
                    queryStringBuilder.Append(";");
                }
            }
            foreach (DataTable table in supplierDataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    row.Delete();
                }
            }
            try
            {
                _queryExecutor.BeginTransaction();
                _queryExecutor.UpdateDataSet(queryStringBuilder.ToString(), ref supplierDataSet);
                _queryExecutor.Commit();
            }
            catch (System.Exception e)
            {
                _queryExecutor.Rollback();
            }

            return true;


        }

        
    }
}