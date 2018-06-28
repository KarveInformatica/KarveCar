using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.DataObjects.Wrapper;
using DataAccessLayer.Model;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using NLog;
using System.Diagnostics;
using DataAccessLayer.DataObjects;
using DataAccessLayer.SQL;
using KarveCommonInterfaces;
using KarveDapper.Extensions;

namespace DataAccessLayer
{

    /// <inheritdoc />
    /// <summary>
    ///  Implementation of the supplier data access layer.
    /// </summary>
    internal class SupplierDataAccessLayer : AbstractDataAccessLayer, ISupplierDataServices
    {
      
       
        public const string SupplierTable1 = "PROVEE1";
        public const string SupplierTable2 = "PROVEE2";
        public const string PrimaryKey = "NUM_PROVEE";

        internal const string SupplierQuery = "SELECT NUM_PROVEE,NIF,TIPO,NOMBRE,DIRECCION,CP," +
                                              "PROVEE2.COMERCIAL,PROVEE2.PREFIJO,PROVEE2.CONTABLE,PROVEE2.FORPA,PROVEE2.PLAZO,PROVEE2.PLAZO2,PROVEE2.PLAZO3," +
                                              "PROVEE2.DIA,PROVEE2.DIA2,PROVEE2.DIA3,PROVEE2.DTO,PROVEE2.PP,PROVEE2.DIVISA,PROVEE2.PALBARAN,PROVEE2.INTRACO" +
                                              "POBLACION,PROV,DIREC2,NACIOPER,TELEFONO,FAX,MOVIL,INTERNET,EMAIL,PERSONA," +
                                              "SUBLICEN,OFICINA,FBAJA,FALTA,NOTAS,OBSERVA,CTAPAGO,TIPOIVA,MESVACA," +
                                              "MESVACA2,CC,IBAN,BANCO,SWIFT,IDIOMA_PR1,GESTION_IVA_IMPORTA,NOAUTOMARGEN," +
                                              "PROALB_COSTE_TRANSP,EXENCIONES_INT,AUTOFAC_MANTE,CTACP,CTALP,DIR_PAGO,DIR2_PAGO," +
                                              "CP_PAGO,PROV_PAGO,PAIS_PAGO,TELF_PAGO,FAX_PAGO, PERSONA_PAGO,MAIL_PAGO,DIR_DEVO," +
                                              "DIR2_DEVO,CP_DEVO,PROV_DEVO,PAIS_DEVO,TELF_DEVO,FAX_DEVO,PERSONA_DEVO,MAIL_DEVO, DIR_RECLAMA,DIR2_RECLAMA," +
                                              "CP_RECLAMA,PROV_RECLAMA,PAIS_RECLAMA,TELF_RECLAMA,FAX_RECLAMA,PERSONA_RECLAMA,MAIL_RECLAMA,VIA,FORMA_ENVIO,CONDICION_VENTA,DIRENVIO6," +
                                              "CTAINTRACOP,CTAINTRACOPREP FROM PROVEE1 INNER JOIN PROVEE2 ON PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE WHERE NUM_PROVEE='{0}'";

      
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
     


        /// <summary>
        /// This a supplier data access layer constructor
        /// </summary>
        /// <param name="mapper">The sql layer for the connection</param>
        /// <param name="service">The global configuration service</param>
        public SupplierDataAccessLayer(ISqlExecutor mapper) :base(mapper)
        { 
            SqlExecutor = mapper;
            // this is used for paging, to count the number of items.
            TableName = "PROVEE1";


        }
        /// <summary>
        ///  Get Supplier Data Object
        /// </summary>
        /// <param name="supplierId">The supplier identifier to fetch from the database</param>
        /// <returns></returns>

        public async Task<SupplierPoco> GetSupplierDo(string supplierId)
        {
            SupplierPoco ret;
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                var query = string.Format(SupplierQuery, supplierId);
                var result = await connection.QueryAsync<SupplierPoco>(query);
                ret = result.FirstOrDefault();
            }
            return ret ?? (ret = new SupplierPoco());
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

            if (!String.IsNullOrEmpty(supplierCode))
            {
                supplierCodeQuery = string.Format(GenericSql.DelegationQuery, "'" + supplierCode + "'");
                delegationDataSet = await SqlExecutor.AsyncDataSetLoad(supplierCodeQuery);

            }
            else
            {
                supplierCodeQuery = GenericSql.DelegationGenericQuery;
                delegationDataSet = await SqlExecutor.AsyncDataSetLoad(supplierCodeQuery);
            }
            var retValue = new Tuple<string, DataSet>(supplierCodeQuery, delegationDataSet);
            return retValue;
        }
        /// <summary>
        ///  Get the paged summary data object
        /// </summary>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>
        public async Task<IEnumerable<SupplierSummaryDto>> GetPagedSummaryDo(int pageIndex, int pageSize)
        {
            var dataPager = new DataPager<SupplierSummaryDto>(SqlExecutor);
            var pageStart = (pageSize == 0) ? 1 : pageSize;
            var paged = await dataPager.GetPagedSummaryDoAsync(QueryType.QuerySupplierSummaryPaged,pageStart, pageSize);
            return paged;
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
            throw  new NotImplementedException();
        }

        /// <summary>
        /// This update a set of dataset with batch of queries.
        /// </summary>
        /// <param name="queries">List of the queries to be updated</param>
        /// <param name="setList">DataSet to be updated.</param>
        public void UpdateDataSetList(IDictionary<string, string> queries, IList<DataSet> setList)
        {
            StringBuilder queryStringBuilder = new StringBuilder();
            SqlExecutor.BeginTransaction();

            if (queries == null)
            {
                return;
            }

            foreach (var set in setList)
            {
                var tmp = set;
                if (set == null)
                {
                    continue;
                }
                foreach (DataTable table in set.Tables)
                {
                    if (!queries.ContainsKey(table.TableName)) continue;
                    queryStringBuilder.Append(queries[table.TableName]);
                    queryStringBuilder.Append(";");
                }
                SqlExecutor.UpdateDataSet(queryStringBuilder.ToString(), ref tmp);
            }
           SqlExecutor.Commit();

        }
        /// <summary>
        /// Update a dataset from the supplierId
        /// </summary>
        /// <param name="queries">List of the queries to be used for updating.</param>
        /// <param name="set">Set to be used for the updating.</param>
        public void UpdateDataSet(IDictionary<string, string> queries, DataSet set)
        {
            var queryStringBuilder = new StringBuilder();
            if (queries == null)
            {
                return;
            }

            if (set == null)
            {
                return;
            }
            foreach (DataTable table in set.Tables)
            {
                if (queries.ContainsKey(table.TableName))
                {
                    queryStringBuilder.Append(queries[table.TableName]);
                    queryStringBuilder.Append(";");
                }
            }
            SqlExecutor.BeginTransaction();
            SqlExecutor.UpdateDataSet(queryStringBuilder.ToString(), ref set);
            SqlExecutor.Commit();
        }

        /// <summary>
        ///  Save a supplier data.
        /// </summary>
        /// <param name="data">Data to be saved.</param>
        /// <returns></returns>
        public async Task<bool> Save(ISupplierData data)
        {
            bool ret = await data.Save();
            return ret;
        }

        /// <inheritdoc />
        /// <summary>
        ///  This function simply generates a new identifier.
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            var id = string.Empty;
            var provee = new PROVEE1();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    id = dbConnection.UniqueId(provee);
                }
            }
            return id;
        }

        /// <summary>
        /// GetAsyncSupplierCodeDo. Returns a data object from a supplierCode.
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <returns></returns>
        public async Task<ISupplierData> GetAsyncSupplierDo(string supplierCode)
        {
            var supplier = new Supplier(SqlExecutor);
            var loaded = await supplier.LoadValue(null, supplierCode).ConfigureAwait(false);
            if (loaded)
            {
                return supplier;
            }
            return supplier;
        }

        public async Task<bool> DeleteAsyncSupplierDo(ISupplierData data)
        {
            var retValue = false;
            var supplierId = data.Value.NUM_PROVEE;
            if (!string.IsNullOrEmpty(supplierId))
            {
                retValue = await data.DeleteAsyncData();
            }
            return retValue;
        }

        public ISupplierData GetNewSupplierDo(string id)
        {
            var supplier= new Supplier(SqlExecutor, id);
            return supplier;
        }

        public async Task<bool> SaveChanges(ISupplierData supplierData)
        {
            var ret = await supplierData.SaveChanges().ConfigureAwait(false);
            return ret;
        }

        public Task<IEnumerable<ContactsDto>> GetAsyncContacts(string codeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SupplierSummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            var pager = new DataPager<SupplierSummaryDto>(SqlExecutor);
            var startIndex = (baseIndex == 0) ? 1 : defaultPageSize;
            NumberPage = await GetPageCount(defaultPageSize);
            var summary = await pager.GetPagedSummaryDoAsync(QueryType.QuerySupplierSummaryPaged, startIndex, defaultPageSize);
            return summary;
           
        }

        /// <summary>
        /// This returns a new supplier.
        /// </summary>
        /// <param name="queryList">List of the queries for the supplier</param>
        /// <returns></returns>
        public async Task<DataSet> GetNewSupplier(IDictionary<string, string> queryList)
        {
            DataSet set = await SqlExecutor.AsyncDataSetLoadBatch(queryList).ConfigureAwait(false);
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
        ///  Get async supplier dataset
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncSuppliers()
        {
            var summary = await SqlExecutor.AsyncDataSetLoad(GenericSql.SupplierQuery).ConfigureAwait(false);
            return summary;
        }
        /// <summary>
        ///  Get async supplier summary.
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncAllSupplierSummary()
        {
            string str = GenericSql.SupplierSummaryQuery;
            var summary = await SqlExecutor.AsyncDataSetLoad(str).ConfigureAwait(false);
            return summary;
        }
       
        public async Task<DataSet> GetAsyncSupplierInfo(IDictionary<string, string> queryList)
        {
            var summary = await SqlExecutor.AsyncDataSetLoadBatch(queryList).ConfigureAwait(false);
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
                SqlExecutor.BeginTransaction();
               SqlExecutor.UpdateDataSet(queryStringBuilder.ToString(), ref supplierDataSet);
               SqlExecutor.Commit();
            }
            catch (System.Exception e)
            {
                SqlExecutor.Rollback();
                _logger.Error("Error deleting a supplier");
                throw new DataLayerExecutionException("Error deleting a supplier", e);
            }

            return true;


        }
        /// <summary>
        ///  GetSupplierAsyncSummaryDto.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SupplierSummaryDto>> GetSupplierAsyncSummaryDo()
        {
            IEnumerable<SupplierSummaryDto> queryAsync = null;
            using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
            {
                queryAsync = await connection.QueryAsync<SupplierSummaryDto>(GenericSql.SupplierSummaryQuery)
                    .ConfigureAwait(false);
            }
            return queryAsync;
        }

    }
}