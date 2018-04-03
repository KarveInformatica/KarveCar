using KarveControls.UIObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using static KarveCommon.Generic.Enumerations;

namespace KarveControls.UIObjects
{

    /// <summary>
    /// This SQLBuilder provide differents way to build queries.
    /// </summary>
    [Obsolete]
    public class SqlBuilder
    {

        private const string TopOne = " TOP 1 ";

        /// <summary>
        ///  Build a query from user objects. Each user object has a part of the query.
        /// </summary>
        /// <param name="list">List of the userobject to be analized</param>
        /// <param name="primaryKeyValue">Primary key that it needs to be used, optional</param>
        /// <param name="isInsert"></param>
        /// <returns></returns>
        public static IDictionary<string, string> SqlBuildSelectFromUiObjects(ObservableCollection<IUiObject> list, string primaryKeyValue ="", bool isInsert = false)
        {  
            IDictionary<string, StringBuilder> tableDictionary = new Dictionary<string, StringBuilder>();
            IDictionary<string, string> primaryKeys = new Dictionary<string, string>();
            IDictionary<string, string> tableWithQuery = new Dictionary<string, string>();
            IDictionary<string, object> dataFields = new Dictionary<string, object>();
            IList<string> queryList = new List<string>();
            foreach (IUiObject obj in list)
            {
                IUiObject tmpUiObject = obj;
                if (obj.TableName != null)
                {
                    if (string.IsNullOrEmpty(obj.TableName))
                    {
                        continue;
                    }

                    
                    if (obj is UiMultipleDfObject)
                    {
                        ObservableCollection<IUiObject> objectValues = ((UiMultipleDfObject)obj).Values;
                        foreach (IUiObject objValue in objectValues)
                        {
                            if (!tableDictionary.ContainsKey(objValue.TableName))
                            {
                                tableDictionary[objValue.TableName] = new StringBuilder();
                                primaryKeys[objValue.TableName] = objValue.PrimaryKey;
                            }
                            StringBuilder currentStringBuilder = tableDictionary[objValue.TableName];

                            if (!currentStringBuilder.ToString().Contains(objValue.ToSQLString))
                            {
                                tableDictionary[objValue.TableName].Append(objValue.ToSQLString);
                            }

                        }
                    }
                    else
                    {
                        if (!tableDictionary.ContainsKey(obj.TableName))
                        {
                            tableDictionary[obj.TableName] = new StringBuilder();
                            primaryKeys[obj.TableName] = obj.PrimaryKey;
                        }
                        StringBuilder currentStringBuilder = tableDictionary[obj.TableName];

                        if (!currentStringBuilder.ToString().Contains(obj.ToSQLString))
                        {
                            tableDictionary[obj.TableName].Append(obj.ToSQLString);
                        }

                       // tableDictionary[obj.TableName].Append(obj.ToSQLString);
                    }
                }
            }
            foreach (var key in tableDictionary.Keys)
            {
                tableDictionary[key][tableDictionary[key].Length - 1] = ' ';
            }
            string modifiedKey = "";
            StringBuilder newBuilder = null;
            foreach (var key in tableDictionary.Keys)
            {
                StringBuilder current = tableDictionary[key];
                IEnumerable<string> values = current.ToString().Split(',').Distinct();
                current.Clear();
                foreach (string v in values)
                {
                    current.Append(v);
                    current.Append(",");
                }
                tableDictionary[key][tableDictionary[key].Length - 1] = ' ';
                string tmp = current.ToString();
               
                if (!tmp.Contains(primaryKeys[key]))
                {
                    newBuilder = new StringBuilder();
                    newBuilder.Append(tmp);
                    newBuilder.Append(",");
                    newBuilder.Append(primaryKeys[key]);
                    modifiedKey = key;
                    newBuilder.Append(",");
                }
            }
            if (newBuilder != null)
            {
                tableDictionary[modifiedKey] = newBuilder;
            }
            foreach (var key in tableDictionary.Keys)
            {
                tableDictionary[key][tableDictionary[key].Length - 1] = ' ';
            }
            foreach (var key in tableDictionary.Keys)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT ");
                
                if (isInsert)
                {
                    builder.Append(TopOne);
                }
                
                builder.Append(tableDictionary[key]);

                builder.Append(" FROM ");
                builder.Append(key);
                if (!isInsert)
                {
                    if (!string.IsNullOrEmpty(primaryKeyValue))
                    {
                        // if it is not null
                        builder.Append(" WHERE " + primaryKeys[key]);
                        builder.Append("=\'" + primaryKeyValue + "\'");
                    }
                }
                queryList.Add(builder.ToString());
              
                tableWithQuery[key] = builder.ToString().Replace(",,",",");
            }
            return tableWithQuery;
        }
        #region SqlBuilderSelect
        /// <summary>
        /// Crea la sentencia SELECT teniendo en cuenta lo siguiente:<para/>
        /// List&lt;string&gt; columns -> colección de columns (el mapeo con la correspondiente columna de la tabla de la BBDD se encuentra 
        ///     en el Tag del control correspondiente: alias.nombreColumna); * por defecto<para/>
        /// string table -> nombre de la tabla<para/>
        /// string tableAlias -> alias de la tabla<para/>
        /// Tuple&lt;ETopDistinct, int, int&gt; topDistinctClause -> TOP, STARTAT, DISTINCT; número de top en el caso TOP; número de start en el caso de STARTAT<para/>
        /// List&lt;Tuple&lt;EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string&gt;&gt; whereClause -> 
        ///     colección de condiciones para filtrar la tabla de la BBDD:
        ///     operador lógico para WHERE múltiples (AND, OR); 
        ///     columna a comparar; tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...); 
        ///     dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos); 
        ///     valor a comparar<para/>
        /// List&lt;Tuple&lt;string, EOrderBy&gt;&gt; orderByClause -> colección de columnas por donde ordenar; tipo de ordenación (ASC, DESC)<para/>
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="table"></param>
        /// <param name="tableAlias"></param>
        /// <param name="topDistinctClause"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderByClause"></param>
        /// <returns></returns>
        public static string SqlBuilderSelect(List<string> columns, string table, string tableAlias,
                                              Tuple<ETopDistinct, int, int> topDistinctClause,
                                              List<Tuple<EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string>> whereClause,
                                              List<Tuple<string, EOrderBy>> orderByClause)
        {
            string sqlSentence;

            //SELECT
            sqlSentence = "SELECT ";

            //TOP, STARTAT, DISTINCT
            if (topDistinctClause != null)
            {
                sqlSentence += SqlBuilderTopDistinct(topDistinctClause.Item1, topDistinctClause.Item2, topDistinctClause.Item3);
            }

            //SELECT COLUMNS o *
            if (columns != null)
            {
                if (columns.Any())
                {
                    foreach (var column in columns)
                    {
                        if (column.StartsWith(tableAlias))
                        {
                            sqlSentence += column + ", ";
                        }
                    }
                }
                else
                {
                    sqlSentence += " * ";
                }
            }
            sqlSentence = sqlSentence.TrimEnd(' ').TrimEnd(',');

            //FROM TABLE AS ALIAS
            sqlSentence += " FROM " + table + " AS " + tableAlias;

            //WHERE
            if (whereClause != null)
            {
                if (whereClause.Any())
                {
                    sqlSentence += " WHERE " + SqlBuilderWhereList(whereClause);
                }
            }

            //ORDERBY
            if (orderByClause != null)
            {
                if (orderByClause.Any())
                {
                    sqlSentence += " ORDER BY " + SqlBuilderOrderByList(orderByClause);
                }
            }

            return sqlSentence.Replace("  ", " ");
        }

        /// <summary>
        /// Crea la sentencia SELECT teniendo en cuenta lo siguiente:<para/>
        /// List&lt;string&gt; columns -> colección de columns (el mapeo con la correspondiente columna de la tabla de la BBDD se encuentra 
        ///     en el Tag del control correspondiente: alias.nombreColumna); * por defecto<para/>
        /// string table -> nombre de la tabla<para/>
        /// string tableAlias -> alias de la tabla<para/>
        /// Tuple&lt;ETopDistinct, int, int&gt; topDistinctClause -> TOP, STARTAT, DISTINCT; número de top en el caso TOP; número de start en el caso de STARTAT<para/>
        /// Tuple&lt;EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string&gt; whereClause -> 
        ///     condiciones para filtrar la tabla de la BBDD:
        ///     operador lógico para WHERE múltiples (AND, OR); 
        ///     columna a comparar; tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...); 
        ///     dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos); 
        ///     valor a comparar<para/>
        /// Tuple&lt;string, EOrderBy&gt; orderByClause -> columnas por donde ordenar; tipo de ordenación (ASC, DESC)<para/>
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="table"></param>
        /// <param name="tableAlias"></param>
        /// <param name="topDistinctClause"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderByClause"></param>
        /// <returns></returns>
        public static string SqlBuilderSelect(List<string> columns, string table, string tableAlias,
                                              Tuple<ETopDistinct, int, int> topDistinctClause,
                                              Tuple<EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string> whereClause,
                                              Tuple<string, EOrderBy> orderByClause)
        {
            string sqlSentence;

            //SELECT
            sqlSentence = "SELECT ";

            //TOP, STARTAT, DISTINCT
            if (topDistinctClause != null)
            {
                sqlSentence += SqlBuilderTopDistinct(topDistinctClause.Item1, topDistinctClause.Item2, topDistinctClause.Item3);
            }

            //SELECT COLUMNS o *
            if (columns != null)
            {
                if (columns.Any())
                {
                    foreach (var column in columns)
                    {
                        if (column.StartsWith(tableAlias))
                        {
                            sqlSentence += column + ", ";
                        }
                    }
                }
                else
                {
                    sqlSentence += " * ";
                }
            }
            sqlSentence = sqlSentence.TrimEnd(' ').TrimEnd(',');

            //FROM TABLE AS ALIAS
            sqlSentence += " FROM " + table + " AS " + tableAlias;

            //WHERE
            if (whereClause != null)
            {
                sqlSentence += " WHERE " + SqlBuilderWhereOneRegister(whereClause);
            }

            //ORDERBY
            if (orderByClause != null)
            {
                sqlSentence += " ORDER BY " + SqlBuilderOrderByOne(orderByClause);                
            }

            return sqlSentence.Replace("  ", " ");
        }

        /// <summary>
        /// Crea la sentencia SELECT teniendo en cuenta lo siguiente:<para/>
        /// List&lt;string&gt; columns -> colección de columns (el mapeo con la correspondiente columna de la tabla de la BBDD se encuentra 
        ///     en el Tag del control correspondiente: alias.nombreColumna); * por defecto<para/>
        /// string table -> nombre de la tabla<para/>
        /// string tableAlias -> alias de la tabla<para/>
        /// Tuple&lt;ETopDistinct, int, int&gt; topDistinctClause -> TOP, STARTAT, DISTINCT; número de top en el caso TOP; número de start en el caso de STARTAT<para/>
        /// string whereClause -> condiciones para filtrar la tabla de la BBDD:
        ///     operador lógico para WHERE múltiples (AND, OR); 
        ///     columna a comparar; tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...); 
        ///     dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos); 
        ///     valor a comparar<para/>
        /// string orderByClause -> columnas por donde ordenar; tipo de ordenación (ASC, DESC)<para/>
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="table"></param>
        /// <param name="tableAlias"></param>
        /// <param name="topDistinctClause"></param>
        /// <param name="whereClause"></param>
        /// <param name="orderByClause"></param>
        /// <returns></returns>
        public static string SqlBuilderSelect(List<string> columns, string table, string tableAlias,
                                              Tuple<ETopDistinct, int, int> topDistinctClause,
                                              string whereClause, string orderByClause)
        {
            string sqlSentence;

            //SELECT
            sqlSentence = "SELECT ";

            //TOP, STARTAT, DISTINCT
            if (topDistinctClause != null)
            {
                sqlSentence += SqlBuilderTopDistinct(topDistinctClause.Item1, topDistinctClause.Item2, topDistinctClause.Item3);
            }

            //SELECT COLUMNS o *
            if (columns != null)
            {
                if (columns.Any())
                {
                    foreach (var column in columns)
                    {
                        if (column.StartsWith(tableAlias))
                        {
                            sqlSentence += column + ", ";
                        }
                    }
                }
                else
                {
                    sqlSentence += " * ";
                }
            }
            sqlSentence = sqlSentence.TrimEnd(' ').TrimEnd(',');

            //FROM TABLE AS ALIAS
            sqlSentence += " FROM " + table + " AS " + tableAlias;

            //WHERE
            if (whereClause != null && !whereClause.Equals(string.Empty))
            {
                sqlSentence += " WHERE " + whereClause;
            }

            //ORDERBY
            if (orderByClause != null && !orderByClause.Equals(string.Empty))
            {
                sqlSentence += " ORDER BY " + orderByClause;
            }

            return sqlSentence.Replace("  ", " ");
        }
        #endregion

        #region SqlBuilderWhere
        /// <summary>
        /// Crea la cláusula WHERE con la condición pasada por params en un Tuple:<para/>
        /// EWhereLogicOperator -&gt; tipo de operador lógico para WHERE múltiples (WHITESPACE, AND, OR)&lt;para/&gt;
        /// string -&gt; columna a comparar&lt;para/&gt;
        /// EWhereComparisson -&gt; tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...)&lt;para/&gt;
        /// ETipoDato -&gt; Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)&lt;para/&gt;
        /// string -&gt; valor a comparar&lt;para/&gt;
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public static string SqlBuilderWhereOneRegister(Tuple<EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string> whereClause)
        {
            string sqlWhereClause = string.Empty;

            //Tipo de operador lógico para WHERE múltiples
            sqlWhereClause += SqlBuilderWhereLogicOperator(whereClause.Item1);

            //Nombre de la columna a comparar
            sqlWhereClause += whereClause.Item2;

            //Tipo de comparación
            sqlWhereClause += SqlBuilderWhereComparissonType(whereClause.Item3);


            if (whereClause.Item3 != EWhereComparisson.ISNULL && whereClause.Item3 != EWhereComparisson.ISNOTNULL)
            {   //Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)
                ETipoDato wherecomparissonvaluetype = whereClause.Item4;
                string wherecomparissonvalue = whereClause.Item5.Equals(string.Empty) || whereClause.Item5 == null || whereClause.Item5[0] == ' ' ? "%" : whereClause.Item5;
                sqlWhereClause += SqlBuilderWhereComparissonValue(wherecomparissonvaluetype, wherecomparissonvalue);
            }
        
            return sqlWhereClause.Replace("  ", " "); //eliminamos el exceso de caracteres en blanco        
        }

        /// <summary>
        /// Crea la cláusula WHERE con la condición pasada por params:<para/>
        /// EWhereLogicOperator -> tipo de operador lógico para WHERE múltiples (WHITESPACE, AND, OR)<para/>
        /// string -> columna a comparar<para/>
        /// EWhereComparisson -> tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...)<para/>
        /// ETipoDato -> Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)<para/>
        /// string -> valor a comparar<para/>
        /// </summary>
        /// <param name="wherelogicoperator"></param>
        /// <param name="column"></param>
        /// <param name="wherecomparissontype"></param>
        /// <param name="wherecomparissonvaluetype"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SqlBuilderWhereOneRegister(EWhereLogicOperator wherelogicoperator, string column, EWhereComparisson wherecomparissontype, 
                                                        ETipoDato wherecomparissonvaluetype, string value)
        {
            string sqlWhereClause = string.Empty;

            //Tipo de operador lógico para WHERE múltiples            
            sqlWhereClause += SqlBuilderWhereLogicOperator(wherelogicoperator);

            //Nombre de la columna a comparar
            sqlWhereClause += column;

            //Tipo de comparación
            sqlWhereClause += SqlBuilderWhereComparissonType(wherecomparissontype);

            if (wherecomparissontype != EWhereComparisson.ISNULL && wherecomparissontype != EWhereComparisson.ISNOTNULL)
            {   
                //Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)
                string wherecomparissonvalue = value.Equals(string.Empty) || value == null || value[0] == ' ' ? "%" : value;
                sqlWhereClause += SqlBuilderWhereComparissonValue(wherecomparissonvaluetype, wherecomparissonvalue);
            }

            return sqlWhereClause.Replace("  ", " "); //eliminamos el exceso de caracteres en blanco        
        }

        /// <summary>
        /// Crea la cláusula WHERE con la List de condiciones pasadas por params:<para/>
        /// EWhereLogicOperator -> tipo de operador lógico para WHERE múltiples (WHITESPACE, AND, OR)<para/>
        /// string -> columna a comparar<para/>
        /// EWhereComparisson -> tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...)<para/>
        /// ETipoDato -> Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)<para/>
        /// string -> valor a comparar<para/>
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public static string SqlBuilderWhereList(List<Tuple<EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string>> whereClause)
        {
            string sqlWhereClause = string.Empty;

            foreach (Tuple<EWhereLogicOperator, string, EWhereComparisson, ETipoDato, string> item in whereClause)
            {
                //Tipo de operador lógico para WHERE múltiples
                sqlWhereClause += SqlBuilderWhereLogicOperator(item.Item1);

                //Nombre de la columna a comparar
                sqlWhereClause += item.Item2;

                //Tipo de comparación
                sqlWhereClause += SqlBuilderWhereComparissonType(item.Item3);

                if (item.Item3 != EWhereComparisson.ISNULL && item.Item3 != EWhereComparisson.ISNOTNULL)
                {   //Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)
                    ETipoDato wherecomparissonvaluetype = item.Item4;
                    string wherecomparissonvalue = item.Item5.Equals(string.Empty) || item.Item5 == null || item.Item5[0] == ' ' ? "%" : item.Item5;
                    sqlWhereClause += SqlBuilderWhereComparissonValue(wherecomparissonvaluetype, wherecomparissonvalue);
                }
            }
            return sqlWhereClause.Replace("  ", " "); //eliminamos el exceso de caracteres en blanco
        }
        #endregion

        #region SqlBuilderOrderBy
        /// <summary>
        /// Crea la cláusula ORDER BY con la condición pasada por params en un Tuple:<para/>
        /// string -> columna por donde ordenar;<para/>
        /// EOrderBy -> tipo de operador ORDER BY (WHITESPACE, ASC, DESC);<para/>
        /// </summary>
        /// <param name="orderByClause"></param>
        /// <returns></returns>
        public static string SqlBuilderOrderByOne(Tuple<string, EOrderBy> orderByClause)
        {
            string sqlOrderBy = string.Empty;

            sqlOrderBy += orderByClause.Item1;

            EOrderBy orderby = orderByClause.Item2;
            switch (orderby)
            {
                case EOrderBy.WHITESPACE: sqlOrderBy += " ASC, "; break;
                case EOrderBy.ASC: sqlOrderBy += " ASC, "; break;
                case EOrderBy.DESC: sqlOrderBy += " DESC, "; break;
                default: break;
            }
            
            return sqlOrderBy.TrimEnd(' ').TrimEnd(',').Replace("  ", " ");
        }

        /// <summary>
        /// Crea la cláusula ORDER BY con la condición pasada por params:<para/>
        /// string -> columna por donde ordenar;<para/>
        /// EOrderBy -> tipo de operador ORDER BY (WHITESPACE, ASC, DESC);<para/>
        /// </summary>
        /// <param name="column"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static string SqlBuilderOrderByOne(string column, EOrderBy orderby)
        {
            string sqlOrderBy = string.Empty;

            sqlOrderBy += column;

            switch (orderby)
            {
                case EOrderBy.WHITESPACE: sqlOrderBy += " ASC, "; break;
                case EOrderBy.ASC: sqlOrderBy += " ASC, "; break;
                case EOrderBy.DESC: sqlOrderBy += " DESC, "; break;
                default: break;
            }

            return sqlOrderBy.TrimEnd(' ').TrimEnd(',').Replace("  ", " ");
        }

        /// <summary>
        /// Crea la cláusula ORDER BY con la List de condiciones pasadas por params:<para/>
        /// string -> columna por donde ordenar<para/>
        /// EOrderBy -> tipo de operador ORDER BY (WHITESPACE, ASC, DESC);<para/>
        /// </summary>
        /// <param name="orderByClause"></param>
        /// <returns></returns>
        public static string SqlBuilderOrderByList(List<Tuple<string, EOrderBy>> orderByClause)
        {
            string sqlOrderBy = string.Empty;

            foreach (Tuple<string, EOrderBy> item in orderByClause)
            {
                sqlOrderBy += item.Item1;

                EOrderBy orderby = item.Item2;
                switch (orderby)
                {
                    case EOrderBy.WHITESPACE: sqlOrderBy += " ASC, "; break;
                    case EOrderBy.ASC: sqlOrderBy += " ASC, "; break;
                    case EOrderBy.DESC: sqlOrderBy += " DESC, "; break;
                    default: break;
                }
            }
            return sqlOrderBy.TrimEnd(' ').TrimEnd(',').Replace("  ", " ");
        }
        #endregion

        #region TopDistinctStartAt WhereLogicOperator WhereComparissonType WhereComparissonValue
        /// <summary>
        /// Crea la cláusula TOP, DISCTINCT o START AT con las condiciones pasadas por params:<para/>
        /// ETopDistinct topdistinct -> tipo de operador (TOP, DISCTINCT o STARTAT)<para/>
        /// int top -> (sólo para TOP y START AT), límite de columnas a mostrar<para/>
        /// int startat -> (sólo para START AT), índice desde donde se mostrarán las columnas<para/>
        /// </summary>
        /// <param name="topdistinct"></param>
        /// <param name="top"></param>
        /// <param name="startat"></param>
        /// <returns></returns>
        public static string SqlBuilderTopDistinct(ETopDistinct topdistinct, int top, int startat)
        {
            string sqlSentence = string.Empty;
            switch (topdistinct)
            {
                case ETopDistinct.WHITESPACE: sqlSentence += " "; break;
                case ETopDistinct.TOP: sqlSentence += " TOP " + top + " "; break;
                case ETopDistinct.STARTAT: sqlSentence += " TOP " + top + " START AT " + startat + " "; break;
                case ETopDistinct.DISTINCT: sqlSentence += " DISTINCT "; break;
                default: break;
            }
            return sqlSentence;
        }

        /// <summary>
        /// Devuelve el operador lógico AND O or con las condiciones pasadas por params:
        /// EWhereLogicOperator wherelogicoperator -> tipo de operador lógico(WHITESPACE, AND o OR)
        /// </summary>
        /// <param name="wherelogicoperator"></param>
        /// <returns></returns>
        public static string SqlBuilderWhereLogicOperator(EWhereLogicOperator wherelogicoperator)
        {
            string sqlWhereClause = string.Empty;
            switch (wherelogicoperator)
            {
                case EWhereLogicOperator.WHITESPACE: sqlWhereClause += " "; break;
                case EWhereLogicOperator.AND: sqlWhereClause += " AND "; break;
                case EWhereLogicOperator.OR: sqlWhereClause += " OR "; break;
                default: break;
            }
            return sqlWhereClause;
        }

        /// <summary>
        /// Devuelve el tipo de operador (LIKE, IS NULL, IS NOT NULL, EQUALS, =,...) con las condiciones pasadas por params:<para/>
        /// EWhereComparisson wherecomparissontype -> tipo de operador (LIKE, IS NULL, IS NOT NULL, EQUALS, =,...)<para/>
        /// </summary>
        /// <param name="wherecomparissontype"></param>
        /// <returns></returns>
        public static string SqlBuilderWhereComparissonType(EWhereComparisson wherecomparissontype)
        {
            string sqlWhereClause = string.Empty;
            switch (wherecomparissontype)
            {
                case EWhereComparisson.WHITESPACE: sqlWhereClause += " "; break;
                case EWhereComparisson.ISNULL:     sqlWhereClause += " IS NULL "; break;
                case EWhereComparisson.ISNOTNULL:  sqlWhereClause += " IS NOT NULL "; break;
                case EWhereComparisson.LIKE:    sqlWhereClause += " LIKE "; break;
                case EWhereComparisson.NOTLIKE: sqlWhereClause += " NOT LIKE "; break;
                case EWhereComparisson.EQUALS:    sqlWhereClause += " = "; break;
                case EWhereComparisson.NOTEQUALS: sqlWhereClause += " <> "; break;
                case EWhereComparisson.GREATEROREQUALS: sqlWhereClause += " >= "; break;
                case EWhereComparisson.GREATERTHAN:     sqlWhereClause += " > "; break;
                case EWhereComparisson.LESSOREQUALS:    sqlWhereClause += " <= "; break;
                case EWhereComparisson.LESSTHAN:        sqlWhereClause += " < "; break;
                case EWhereComparisson.IN: sqlWhereClause += " IN "; break;
                default: break;
            }
            return sqlWhereClause;
        }

        /// <summary>
        /// Devuelve el valor a comparar (con comillas simples '' para strings, sin comillas simples para numéricos) con las condiciones pasadas por params:<para/>
        /// ETipoDato wherecomparissonvaluetype -> tipo de dato del valor de la condición a comparar<para/>
        /// string wherecomparissonvalue -> valor de la condición a comparar<para/>
        /// </summary>
        /// <param name="wherecomparissonvaluetype"></param>
        /// <param name="wherecomparissonvalue"></param>
        /// <returns></returns>
        public static string SqlBuilderWhereComparissonValue(ETipoDato wherecomparissonvaluetype, string wherecomparissonvalue)
        {
            string sqlWhereClause = string.Empty;
            switch (wherecomparissonvaluetype)
            {
                case ETipoDato.DBstring:   sqlWhereClause += " '" + wherecomparissonvalue + "' "; break;
                case ETipoDato.DBchar:     sqlWhereClause += " '" + wherecomparissonvalue[0] + "' "; break;
                case ETipoDato.DBbyte:     sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case ETipoDato.DBshort:    sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case ETipoDato.DBint:      sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case ETipoDato.DBlong:     sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case ETipoDato.DBdecimal:  sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case ETipoDato.DBdouble:   sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case ETipoDato.DBdatetime: sqlWhereClause += " '" + wherecomparissonvalue + "' "; break;
                default: break;
            }
            return sqlWhereClause;
        }

        
        /// <summary>
        ///  This add or create a name.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="fieldName">Table field</param>
        /// <param name="dictionary">Table dictionary that contains the fields for table</param>
        private static void AddOrCreate(string tableName, string fieldName,
            ref IDictionary<string, List<string>> dictionary)
        {
            if (!dictionary.ContainsKey(tableName))
            {
                List<string> str = new List<string>();
                str.Add(fieldName);
                dictionary.Add(tableName, str);
            }
            else
            {
                List<string> name = dictionary[tableName];
                name.Add(fieldName);
                dictionary[tableName] = name;
            }
        }
        
        /// <summary>
        ///  This walks the visual tree to get all the controls and create a query with a tag. It is not longer used in 
        ///  the code base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="currentList"></param>
        /// <returns></returns>
        public static List<string> SqlBuilderColumns<T>(DependencyObject container, ref List<Tuple<string, string>> currentList)
        {
            List<string> resultchild = new List<string>();
            

            if (container.GetType().BaseType == typeof(Window) || container.GetType().BaseType == typeof(UserControl) ||
                container.GetType().BaseType == typeof(Page))
            {
                IEnumerable children = LogicalTreeHelper.GetChildren(container);

                foreach (DependencyObject child in children)
                {
                    resultchild.AddRange(SqlBuilderColumns<T>(child, ref currentList));
                }
            }
            else
            {               
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(container); i++)
                {
                    FrameworkElement child = (FrameworkElement) VisualTreeHelper.GetChild(container, i);

                    if (child.GetType() == typeof(DockPanel) || child.GetType() == typeof(StackPanel) || child.GetType() == typeof(WrapPanel) ||
                        child.GetType() == typeof(Grid) || child.GetType() == typeof(Canvas) || child.GetType() == typeof(GroupBox) || 
                        child.GetType() == typeof(ScrollViewer) || child.GetType() == typeof(Border) || child.GetType() == typeof(UniformGrid) ||
                        child.GetType() == typeof(Table) || child.GetType() == typeof(TabPanel) || child.GetType() == typeof(ToolBarOverflowPanel) ||
                        child.GetType() == typeof(VirtualizingPanel) || child.GetType() == typeof(VirtualizingStackPanel))
                    {
                        resultchild.AddRange(SqlBuilderColumns<T>(child, ref currentList));
                    }
                    else
                    {
                        if (child.GetType() == typeof(System.Windows.Controls.ItemsControl))
                        {
                            Tuple<string, string> currentTemp; 
                            System.Windows.Controls.ItemsControl currentControl = (System.Windows.Controls.ItemsControl) child;
                            foreach (IUiObject control in currentControl.ItemsSource)
                            {
                                resultchild.Add(control.DataField);
                                currentTemp= new Tuple<string, string>(control.DataField, control.TableName);
                                currentList.Add(currentTemp);
                            }
                        }
                        if (child.GetType() == typeof(ListView))
                        {
                            Tuple<string, string> currentTemp;
                            System.Windows.Controls.ItemsControl currentControl = (System.Windows.Controls.ItemsControl)child;
                            foreach (IUiObject control in currentControl.ItemsSource)
                            {
                                resultchild.Add(control.DataField);
                                currentTemp = new Tuple<string, string>(control.DataField, control.TableName);
                                currentList.Add(currentTemp);
                            }
                        }
                    }
                }
            }
            
            return resultchild;
        }
        #endregion
        /// <summary>
        ///  This strip the top from a query dictionary.
        /// </summary>
        /// <param name="dictionary">Query dictionary</param>
        public static void StripTop(ref IDictionary<string, string> dictionary)
        {
            IDictionary<string, string> strValue = new Dictionary<string, string>();

            if (dictionary == null)
            {
                return;
            }
            if (dictionary.Keys.Count == 0)
            {
                return;
            }
            foreach (string k in dictionary.Keys)
            {
                if (dictionary[k].Contains(TopOne))
                {
                    strValue.Add(k, dictionary[k].Replace(TopOne, ""));
                }
                else
                {
                    strValue.Add(k, dictionary[k]);
                }
            }
            dictionary = strValue;

        }

        /// <summary>
        /// This add or create a dictionary for the key/value/
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="tableDictionary"></param>
        private static void AddOrCreate(string key, string value, ref IDictionary<string, string> tableDictionary)
        {
            if (tableDictionary.ContainsKey(key))
            {
                string tmpValue = tableDictionary[key];
                if (!tmpValue.Contains(value))
                {
                    tmpValue += "," + value;
                    tableDictionary[key] = tmpValue;
                }
            }
            else
            {
                tableDictionary.Add(key, value);
            }
        }
        /// <summary>
        /// Fetch table and assist stable fields
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tableFields"></param>
        /// <param name="assistTableFields"></param>
        private static void FetchTableAndAssistTable(DependencyObject value,
            ref IDictionary<string, string> tableFields,
            ref IDictionary<string, string> assistTableFields)
        {
            if (value is DataField)
            {
                DataField df = (DataField)value;
                AddOrCreate(df.TableName, df.DataSourcePath, ref tableFields);
            }
            else

            {
                OtherDataFieldComponent(value, tableFields, assistTableFields);
            }

        }
        /// <summary>
        ///  This looks up about the tagged named.
        /// </summary>
        /// <param name="value">Dependency object in a tree</param>
        /// <param name="tableFields">Fields of the table on which we depend</param>
        /// <param name="assistTableFields">Fields of the assist table on which we depend</param>
        private static void OtherDataFieldComponent(DependencyObject value,
            IDictionary<string, string> tableFields,
            IDictionary<string, string> assistTableFields)
        {
            if (value is DualFieldSearchBox)
            {
                // get the table and the field.
                DualFieldSearchBox dualFieldSearchBox = (DualFieldSearchBox)value;
                AddOrCreate(dualFieldSearchBox.AssistTableName, dualFieldSearchBox.AssistDataFieldFirst,
                    ref assistTableFields);
                AddOrCreate(dualFieldSearchBox.AssistTableName, dualFieldSearchBox.AssistDataFieldSecond,
                    ref assistTableFields);
                AddOrCreate(dualFieldSearchBox.TableName, dualFieldSearchBox.DataFieldFirst, ref tableFields);
            }
            else
            {
                PropertyInfo fieldInfo = value.GetType().GetProperty("DataField");
                PropertyInfo tableInfo = value.GetType().GetProperty("TableName");
                if ((fieldInfo != null) || (tableInfo != null))
                {
                    string fieldName = (string)fieldInfo.GetValue(value);
                    string tableName = (string)tableInfo.GetValue(value);
                    if ((fieldName != null) || (tableName != null))
                    {
                        AddOrCreate(tableName, fieldName, ref tableFields);
                    }
                }
            }

        }
        /// <summary>
        ///  Get the fields from the visual tree.
        ///  This method has been deprecated because of issues during displaying the visual tree.
        /// </summary>
        /// <param name="allDataFields">This is a list of DependencyObject</param>
        /// <param name="tableFields">This is a list of tables</param>
        /// <param name="assistDictionary">This is an assist dictionary</param>
        public static void SqlGetFields(IEnumerable<DependencyObject> allDataFields, ref IDictionary<string, string> tableFields, ref IDictionary<string,string> assistDictionary)
        {
            foreach (var value in allDataFields)
            {
                FetchTableAndAssistTable(value, ref tableFields, ref assistDictionary);
            }

        }
    }
}