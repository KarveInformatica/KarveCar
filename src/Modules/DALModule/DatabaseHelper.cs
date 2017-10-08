using System;
using System.Collections.Generic;
using KarveCommon.Generic;

namespace DataAccessLayer
{
    internal class DatabaseHelper
    {
        private ISqlQueryExecutor _mapperExecutor;

        public DatabaseHelper(ISqlQueryExecutor mapper)
        {
            _mapperExecutor = mapper;
        }

        public IList<string> PrependTableName(string tableName, IList<string> colList)
        {
            IList<string> list = new List<string>();
            foreach (string v in list)
            {
                string tmp = tableName + "." + v;
                list.Add(tmp);
            }
            return list;
        }
        public IList<string> GetColumnNames(string tableName)
        {
            IList<string> colName = new List<string>();
            string queryValue = string.Format("SELECT sc.* FROM syscolumns sc INNER JOIN sysobjects so ON sc.id = so.id WHERE so.name = \'{0}\'", tableName);
            if (_mapperExecutor.Open())
            {
                _mapperExecutor.ExecuteQueryDataTable(queryValue);
            }

            // prepare the query for the columns.

            return colName;

        }

        public string FormatColumns(IList<string> supplierColumns1)
        {
            string columns = "";
            for (int i = 0; i < supplierColumns1.Count - 1; i++)
            {
                columns = supplierColumns1[i] + ",";
            }
            columns = columns + supplierColumns1[supplierColumns1.Count];
            return columns;
        }
    }
}