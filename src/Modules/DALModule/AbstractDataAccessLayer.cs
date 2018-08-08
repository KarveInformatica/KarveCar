using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer
{
    /// <summary>
    ///  Abstract class for the common interface in the data access layer.
    /// </summary>
    public class AbstractDataAccessLayer
    {
        /// <summary>
        ///  The executor in common between all the abstract data access layer
        /// </summary>
        protected ISqlExecutor SqlExecutor;

        protected readonly QueryStoreFactory QueryStoreFactory = new QueryStoreFactory();

        /// <summary>
        ///  The data loader for xml fields
        /// </summary>
        protected DataLoader SqlFieldLoader = new DataLoader();
        /// <summary>
        ///  The name of a table
        /// </summary>
        protected string TableName = string.Empty;
        /// <summary>
        ///  The base query dictionary
        /// </summary>
        protected IDictionary<string, string> BaseQueryDictionary = new Dictionary<string, string>();
        /// <summary>
        ///  The mapper.
        /// </summary>
        protected IMapper Mapper;

        /// <summary>
        /// Ctr for all the abstract access layer.
        /// </summary>
        /// <param name="executor">The executor to be used in the data layer.</param>
        internal AbstractDataAccessLayer(ISqlExecutor executor)
        {
            Contract.Requires(executor != null, "AbstractQuery query executor is null");
            SqlExecutor = executor;

        }
        /// <summary>
        /// Load the database datafields directly from the xml to generate a query, 
        /// this is more far efficient than loading the visual tree.
        /// </summary>
        /// <param name="pathFile">Path file to be used</param>
        protected void InitData(string pathFile)
        {
            Contract.Requires(!string.IsNullOrEmpty(pathFile), "Path name is not valied");
            var currentAssemblyPath = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            var builder = new StringBuilder();
            builder.Append(currentAssemblyPath);
            builder.Append(pathFile);
            var collection = SqlFieldLoader.LoadXmlData(builder.ToString());
            foreach (var table in collection.DataList)
            {
                var tmpBuilder = new StringBuilder();
                var fields = table.DataFields;
                foreach (var f in fields)
                {
                    tmpBuilder.Append(f.Name);
                    tmpBuilder.Append(",");
                }
                var query = tmpBuilder.ToString();
                query = query.Substring(0, query.Length - 1);
                tmpBuilder.Clear();
                if (!BaseQueryDictionary.ContainsKey(table.Name))
                {
                    BaseQueryDictionary.Add(table.Name, query);
                }
            }
            // now instance a map
            Mapper = MapperField.GetMapper();

        }
        /// <summary>
        ///  Set or Get the pages number
        /// </summary>
        public int NumberPage { get; set; }
        /// <summary>
        ///  Set or Get the number of items in the data collection.
        /// </summary>
        public long NumberItems { get; set; }

        /// <summary>
        ///  Fetch the page count.
        /// </summary>
        /// <param name="pageSize">Page dimension.</param>
        /// <returns>The number of pages</returns>
        public async Task<int> GetPageCount(int pageSize)
        {

            var pager = new DataPager<BaseDto>(SqlExecutor);
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pageInfo = await pager.GetPageCount(pageSize, TableName).ConfigureAwait(false);
            NumberItems = pageInfo.Item1;
            var pageCount = pageInfo.Item2;
            return pageCount;
        }
       
    }
}