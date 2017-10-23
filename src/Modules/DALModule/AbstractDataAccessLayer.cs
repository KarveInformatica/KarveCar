using System.Collections.Generic;
using System.Data;
using System.Text;
using AutoMapper;
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
        private ISqlQueryExecutor _queryExecutor;
        protected DataLoader _sqlFieldLoader = new DataLoader();
        protected StringBuilder _baseQuery = new StringBuilder();
        
        protected IDictionary<string, string> baseQueryDictionary = new Dictionary<string, string>();
        /// <summary>
        /// Ctr for all the abstract access layer.
        /// </summary>
        /// <param name="queryExecutor"></param>
        internal AbstractDataAccessLayer(ISqlQueryExecutor queryExecutor)
        {
            Dbc.Requires(queryExecutor != null, "AbstractQuery query executor is null");
            _queryExecutor = queryExecutor;
           
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
                _queryExecutor.BeginTransaction();
                foreach (DataTable table in supplierDataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        row.Delete();
                    }
                }
                _queryExecutor.UpdateDataSet(query, ref supplierDataSet);
                _queryExecutor.Commit();
                return true;
            }
            catch (System.Exception e)
            {
                _queryExecutor.Rollback();
                
            }
            return false;
        }
    }
}