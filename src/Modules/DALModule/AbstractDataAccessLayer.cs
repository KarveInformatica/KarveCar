using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using DesignByContract;
using KarveDataServices;
namespace DataAccessLayer
{
    /// <summary>
    ///  Abstract class for the common interface in the data access layer.
    /// </summary>
    public class AbstractDataAccessLayer
    {
        private ISqlExecutor _executor;
        protected DataLoader _sqlFieldLoader = new DataLoader();
        protected StringBuilder _baseQuery = new StringBuilder();
        
        protected IDictionary<string, string> baseQueryDictionary = new Dictionary<string, string>();
        protected IMapper Mapper;

        /// <summary>
        /// Ctr for all the abstract access layer.
        /// </summary>
        /// <param name="executor"></param>
        internal AbstractDataAccessLayer(ISqlExecutor executor)
        {
            Dbc.Requires(executor != null, "AbstractQuery query executor is null");
            _executor = executor;
           
        }
       /// <summary>
       /// Load the database datafields directly from the xml to generate a query, 
       /// this is more far efficient than loading the visual tree.
       /// </summary>
       /// <param name="pathFile">Path file to be used</param>
        protected void InitData(string pathFile)
        {
            Dbc.Requires(!string.IsNullOrEmpty(pathFile), "Path name is not valied");
            var currentAssemblyPath = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            StringBuilder builder = new StringBuilder();
            builder.Append(currentAssemblyPath);
            builder.Append(pathFile);
            DataCollection collection = _sqlFieldLoader.LoadXmlData(builder.ToString());
            foreach (var table in collection.DataList)
            {
                StringBuilder tmpBuilder = new StringBuilder();
                List<Field> fields = table.DataFields;
                foreach (Field f in fields)
                {
                    tmpBuilder.Append(f.Name);
                    tmpBuilder.Append(",");
                }
                string query = tmpBuilder.ToString();
                query = query.Substring(0, query.Length - 1);
                tmpBuilder.Clear();
                if (!baseQueryDictionary.ContainsKey(table.Name))
                {
                    baseQueryDictionary.Add(table.Name, query);
                }
            }
            // now instance a map
            Mapper = MapperField.GetMapper();
        }
        /// <summary>
        /// Build the where clause using the supplier id..
        /// </summary>
        /// <param name="primaryKey">Primary key to be used</param>
        /// <param name="supplierId">Supplier id to be used</param>
        /// <returns></returns>
        private string BuildQuery(string primaryKey, string supplierId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" WHERE ");
            builder.Append(primaryKey);
            string clause = $"='{supplierId}'";
            builder.Append(clause);
            string query = builder.ToString();
            return query;
        }

        protected virtual bool UniqueId(string id)
        {
            return true;
        }
        /// <summary>
        /// This generate an unique id.
        /// </summary>
        /// <returns>Returns an unique id.</returns>
        protected string GenerateUniqueId()
        {
            string id = "";
            do
            {
                byte[] data = new byte[8];
                using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetBytes(data);
                }
                string hex = BitConverter.ToUInt64(data, 0).ToString();
                id = hex.Substring(0, 7);
                // we shall complement this to 7.
                if (UniqueId(id))
                {
                    break;
                }

            } while (true);

            return id;
        }
        /// <summary>
        /// This delete data using a dataset.
        /// </summary>
        /// <param name="sqlQuery">Query to be selected.</param>
        /// <param name="supplierId">Supplier Id</param>
        /// <param name="primaryKey">PrimaryKey to be used.</param>
        /// <param name="supplierDataSet"></param>
        /// <returns></returns>
        protected bool DeleteData(string sqlQuery, string supplierId, string primaryKey,
            DataSet supplierDataSet)
        {

            
            string query = BuildQuery(primaryKey, supplierId);
            
            try
            {
                _executor.BeginTransaction();
                foreach (DataTable table in supplierDataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        row.Delete();
                    }
                }
                _executor.UpdateDataSet(query, ref supplierDataSet);
                _executor.Commit();
                return true;
            }
            catch (System.Exception e)
            {
                _executor.Rollback();
                
            }
            return false;
        }
    }
}