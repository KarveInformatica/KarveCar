using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Exceptions;

namespace Apache.Ibatis.DataMapper.MappedStatements
{

    /// <summary>
    /// this implements an async command to be used within a single connection
    /// </summary>
    
    public class QueryAsyncForObjectCommand<T> : BaseQueryAsyncCommand
    {
        private string _param;
        private object _transformLock = new object();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">statement id</param>
        /// <param name="param">statement parameter </param>
       
        public QueryAsyncForObjectCommand(string src, string param)
        {
            this._statement = src;
            this._param = param;
           
        }
        /// <summary>
        /// Data table 
        /// </summary>
        /// <param name="mapper">Data mapper execute asynchronously a thing</param>
        /// <returns></returns>
        public override async Task<DataTable> ExecuteAsync()
        {
            if ((_mapper == null) || (_scope == null))
            {
                throw new DataMapperException("Scope and mapper shall be set before executing");
            }
            
            DataTable table = new DataTable();
            
            T x = await _mapper.QueryAsyncForObjectSession<T>(this._statement, this._param, _scope).ConfigureAwait(false);
            // re
            if (x != null)
            {
                table = TransformToTable(x);
            }
            return table;
        }
        private DataTable TransformToTable<V>(V x)
        {
            DataTable table;
            lock (_transformLock)
            {
                Type t = x.GetType();
                table = new DataTable(t.Name);
                PropertyInfo[] prop = t.GetProperties();
                IList<object> list = new List<object>();
                // we build the data table.
                foreach (PropertyInfo p in prop)
                {
                    table.Columns.Add(p.Name);
                }
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                foreach (DataColumn cols in table.Columns)
                {
                    string colName = cols.ColumnName;
                    object o = t.GetProperty(colName).GetValue(x, null);
                    if (row.Table.Columns.Contains(colName))
                    {
                        row[colName] = o;
                    }
                }
            }
            return table;
        }

    }
}
