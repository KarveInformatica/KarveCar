using KarveControls.UIObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveControls.UIObjects
{
    public class SQLBuilder
    {
       
    public static IDictionary<string, string> SqlBuildSelectFromUiObjects(ObservableCollection<IUiObject> list, string primaryKeyValue ="")
        {  
            IDictionary<string, StringBuilder> tableDictionary = new Dictionary<string, StringBuilder>();
            IDictionary<string, string> primaryKeys = new Dictionary<string, string>();
            IDictionary<string, string> tableWithQuery = new Dictionary<string, string>();
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
                            tableDictionary[objValue.TableName].Append(objValue.ToSQLString);
                        }
                    }
                    else
                    {
                        if (!tableDictionary.ContainsKey(obj.TableName))
                        {
                            tableDictionary[obj.TableName] = new StringBuilder();
                            primaryKeys[obj.TableName] = obj.PrimaryKey;
                        }
                        tableDictionary[obj.TableName].Append(obj.ToSQLString);
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
                newBuilder = new StringBuilder();
                string tmp = current.ToString();
                if (!tmp.Contains(primaryKeys[key]))
                {
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

              /*  string tmpString = tableDictionary[key].ToString();
                if (!tmpString.Contains(primaryKeyValue))
                {
                    tmpString = "," + primaryKeyValue;
                }
                */
                builder.Append(tableDictionary[key]);
                
                builder.Append(" FROM ");
                builder.Append(key);
                if (!string.IsNullOrEmpty(primaryKeyValue))
                {
                    // if it is not null
                    builder.Append(" WHERE "+primaryKeys[key]);
                    builder.Append("=\'" + primaryKeyValue + "\'");
                }
                queryList.Add(builder.ToString());
                tableWithQuery[key] = builder.ToString();
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
        /// Recorre los controles de una pantalla (de forma recursiva para el caso que encuentre un control contenedor, p.e.: Grid, GroupBox, DockPanel, StackPanel,...),
        /// y devuelve un List&lt;string&gt; con el nombre de las columnas correspondientes en la BBDD para cada control<para/>
        /// DependencyObject container -> container a recorrer<para/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
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
                        if (child.GetType() == typeof(ItemsControl))
                        {
                            Tuple<string, string> currentTemp; 
                            ItemsControl currentControl = (ItemsControl) child;
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
                            ItemsControl currentControl = (ItemsControl)child;
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
    }
}