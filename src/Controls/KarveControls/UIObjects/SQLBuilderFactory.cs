using System;
using System.Collections.Generic;
using System.Windows;

namespace KarveControls.UIObjects
{
    public class SQLBuilderFactory
    {
        public static string GetSqlQueryBuilder(string tableName, List<string> columns)
        {
            string tableAlias = tableName + "_ALIAS";
            return SQLBuilder.SqlBuilderSelect(columns, tableName,tableAlias, null, string.Empty, null);
        }

        public static string GetSqlQueryBuilder<T>(DependencyObject mainWindow)
        {
            List<Tuple<string,string>> listDictionaryTuples = new List<Tuple<string, string>>();
            List<string> columns = SQLBuilder.SqlBuilderColumns<T>(mainWindow, ref listDictionaryTuples);
            string tableAlias = listDictionaryTuples[0].Item2 + "_ALIAS";
            string tableName = listDictionaryTuples[0].Item2;
            return SQLBuilder.SqlBuilderSelect(columns, tableName, tableAlias, null, string.Empty, null);
        }
    }
}