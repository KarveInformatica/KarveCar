using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace KarveCommon.Generic
{
    public class SQLBuilder
    {
        #region SQLBuilder
        #region SqlSelectBuilder        
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
        public static string SqlBuilderSelectComplex(List<string> columns, string table, string tableAlias,
                                                     Tuple<RecopilatorioEnumerations.ETopDistinct, int, int> topDistinctClause,
                                                     List<Tuple<RecopilatorioEnumerations.EWhereLogicOperator, string, RecopilatorioEnumerations.EWhereComparisson, RecopilatorioEnumerations.ETipoDato, string>> whereClause,
                                                     List<Tuple<string, RecopilatorioEnumerations.EOrderBy>> orderByClause)
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
                    sqlSentence += " WHERE " + SqlWhereBuilderList(whereClause);
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

        public static string SqlBuilderSelectSimple(List<string> columns, string table, string tableAlias,
                                                    Tuple<RecopilatorioEnumerations.ETopDistinct, int, int> topDistinctClause,
                                                    Tuple<RecopilatorioEnumerations.EWhereLogicOperator, string, RecopilatorioEnumerations.EWhereComparisson, RecopilatorioEnumerations.ETipoDato, string> whereClause,
                                                    Tuple<string, RecopilatorioEnumerations.EOrderBy> orderByClause)
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
                sqlSentence += " WHERE " + SqlBuilderWhereOne(whereClause);
            }

            //ORDERBY
            if (orderByClause != null)
            {
                sqlSentence += " ORDER BY " + SqlBuilderOrderByOne(orderByClause);                
            }

            return sqlSentence.Replace("  ", " ");
        }

        public static string SqlBuilderSelectSimple(List<string> columns, string table, string tableAlias,
                                                    Tuple<RecopilatorioEnumerations.ETopDistinct, int, int> topDistinctClause,
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

        #region SqlWhereBuilder
        public static string SqlBuilderWhereOne(Tuple<RecopilatorioEnumerations.EWhereLogicOperator, string, RecopilatorioEnumerations.EWhereComparisson, RecopilatorioEnumerations.ETipoDato, string> whereClause)
        {
            string sqlWhereClause = string.Empty;

            //Tipo de operador lógico para WHERE múltiples
            sqlWhereClause += SqlBuilderWhereLogicOperator(whereClause.Item1);

            //Nombre de la columna a comparar
            sqlWhereClause += whereClause.Item2;

            //Tipo de comparación
            sqlWhereClause += SqlBuilderWhereComparissonType(whereClause.Item3);


            if (whereClause.Item3 != RecopilatorioEnumerations.EWhereComparisson.ISNULL && whereClause.Item3 != RecopilatorioEnumerations.EWhereComparisson.ISNOTNULL)
            {   //Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)
                RecopilatorioEnumerations.ETipoDato wherecomparissonvaluetype = whereClause.Item4;
                string wherecomparissonvalue = whereClause.Item5.Equals(string.Empty) || whereClause.Item5 == null || whereClause.Item5[0] == ' ' ? "%" : whereClause.Item5;
                sqlWhereClause += SqlBuilderWhereComparissonValue(wherecomparissonvaluetype, wherecomparissonvalue);
            }
        
            return sqlWhereClause.Replace("  ", " "); //eliminamos el exceso de caracteres en blanco        
        }

        public static string SqlBuilderWhereOne(RecopilatorioEnumerations.EWhereLogicOperator wherelogicoperator, string column, RecopilatorioEnumerations.EWhereComparisson wherecomparissontype, 
                                                RecopilatorioEnumerations.ETipoDato wherecomparissonvaluetype, string value)
        {
            string sqlWhereClause = string.Empty;

            //Tipo de operador lógico para WHERE múltiples            
            sqlWhereClause += SqlBuilderWhereLogicOperator(wherelogicoperator);

            //Nombre de la columna a comparar
            sqlWhereClause += column;

            //Tipo de comparación
            sqlWhereClause += SqlBuilderWhereComparissonType(wherecomparissontype);

            if (wherecomparissontype != RecopilatorioEnumerations.EWhereComparisson.ISNULL && wherecomparissontype != RecopilatorioEnumerations.EWhereComparisson.ISNOTNULL)
            {   
                //Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)
                string wherecomparissonvalue = value.Equals(string.Empty) || value == null || value[0] == ' ' ? "%" : value;
                sqlWhereClause += SqlBuilderWhereComparissonValue(wherecomparissonvaluetype, wherecomparissonvalue);
            }

            return sqlWhereClause.Replace("  ", " "); //eliminamos el exceso de caracteres en blanco        
        }

        /// <summary>
        /// Crea la cláusula WHERE con la List de valores pasados por params:<para/>
        /// EWhereLogicOperator -> tipo de operador lógico para WHERE múltiples (WHITESPACE, AND, OR)<para/>
        /// string -> columna a comparar<para/>
        /// EWhereComparisson -> tipo de comparación (LIKE, IS NULL, IS NOT NULL, =,...)<para/>
        /// ETipoDato -> Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)<para/>
        /// string -> valor a comparar<para/>
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public static string SqlWhereBuilderList(List<Tuple<RecopilatorioEnumerations.EWhereLogicOperator, string, RecopilatorioEnumerations.EWhereComparisson, RecopilatorioEnumerations.ETipoDato, string>> whereClause)
        {
            string sqlWhereClause = string.Empty;

            foreach (Tuple<RecopilatorioEnumerations.EWhereLogicOperator, string, RecopilatorioEnumerations.EWhereComparisson, RecopilatorioEnumerations.ETipoDato, string> item in whereClause)
            {
                //Tipo de operador lógico para WHERE múltiples
                sqlWhereClause += SqlBuilderWhereLogicOperator(item.Item1);

                //Nombre de la columna a comparar
                sqlWhereClause += item.Item2;

                //Tipo de comparación
                sqlWhereClause += SqlBuilderWhereComparissonType(item.Item3);

                if (item.Item3 != RecopilatorioEnumerations.EWhereComparisson.ISNULL && item.Item3 != RecopilatorioEnumerations.EWhereComparisson.ISNOTNULL)
                {   //Dependiendo del tipo de valor, añadirá comillas simples (strings, char,...) + valor, o sólo el valor (numéricos)
                    RecopilatorioEnumerations.ETipoDato wherecomparissonvaluetype = item.Item4;
                    string wherecomparissonvalue = item.Item5.Equals(string.Empty) || item.Item5 == null || item.Item5[0] == ' ' ? "%" : item.Item5;
                    sqlWhereClause += SqlBuilderWhereComparissonValue(wherecomparissonvaluetype, wherecomparissonvalue);
                }
            }
            return sqlWhereClause.Replace("  ", " "); //eliminamos el exceso de caracteres en blanco
        }
        #endregion

        #region SqlOrderByBuilder
        public static string SqlBuilderOrderByOne(Tuple<string, RecopilatorioEnumerations.EOrderBy> orderByClause)
        {
            string sqlOrderBy = string.Empty;

            sqlOrderBy += orderByClause.Item1;

            RecopilatorioEnumerations.EOrderBy orderby = orderByClause.Item2;
            switch (orderby)
            {
                case RecopilatorioEnumerations.EOrderBy.WHITESPACE: sqlOrderBy += " ASC, "; break;
                case RecopilatorioEnumerations.EOrderBy.ASC: sqlOrderBy += " ASC, "; break;
                case RecopilatorioEnumerations.EOrderBy.DESC: sqlOrderBy += " DESC, "; break;
                default: break;
            }
            
            return sqlOrderBy.TrimEnd(' ').TrimEnd(',').Replace("  ", " ");
        }

        public static string SqlBuilderOrderByOne(string column, RecopilatorioEnumerations.EOrderBy orderby)
        {
            string sqlOrderBy = string.Empty;

            sqlOrderBy += column;

            switch (orderby)
            {
                case RecopilatorioEnumerations.EOrderBy.WHITESPACE: sqlOrderBy += " ASC, "; break;
                case RecopilatorioEnumerations.EOrderBy.ASC: sqlOrderBy += " ASC, "; break;
                case RecopilatorioEnumerations.EOrderBy.DESC: sqlOrderBy += " DESC, "; break;
                default: break;
            }

            return sqlOrderBy.TrimEnd(' ').TrimEnd(',').Replace("  ", " ");
        }

        /// <summary>
        /// Crea la cláusula ORDER BY con la List de valores pasados por params:<para/>
        /// string -> columna por donde ordenar<para/>
        /// EOrderBy -> tipo de ordenación (ASC, DESC)<para/>
        /// </summary>
        /// <param name="orderByClause"></param>
        /// <returns></returns>
        public static string SqlBuilderOrderByList(List<Tuple<string, RecopilatorioEnumerations.EOrderBy>> orderByClause)
        {
            string sqlOrderBy = string.Empty;

            foreach (Tuple<string, RecopilatorioEnumerations.EOrderBy> item in orderByClause)
            {
                sqlOrderBy += item.Item1;

                RecopilatorioEnumerations.EOrderBy orderby = item.Item2;
                switch (orderby)
                {
                    case RecopilatorioEnumerations.EOrderBy.WHITESPACE: sqlOrderBy += " ASC, "; break;
                    case RecopilatorioEnumerations.EOrderBy.ASC: sqlOrderBy += " ASC, "; break;
                    case RecopilatorioEnumerations.EOrderBy.DESC: sqlOrderBy += " DESC, "; break;
                    default: break;
                }
            }
            return sqlOrderBy.TrimEnd(' ').TrimEnd(',').Replace("  ", " ");
        }
        #endregion

        #region TopDistinct WhereLogicOperator WhereComparissonType WhereComparissonValue
        private static string SqlBuilderTopDistinct(RecopilatorioEnumerations.ETopDistinct topdistinct, int top, int startat)
        {
            string sqlSentence = string.Empty;
            switch (topdistinct)
            {
                case RecopilatorioEnumerations.ETopDistinct.WHITESPACE: sqlSentence += " "; break;
                case RecopilatorioEnumerations.ETopDistinct.TOP: sqlSentence += " TOP " + top + " "; break;
                case RecopilatorioEnumerations.ETopDistinct.STARTAT: sqlSentence += " TOP " + top + " START AT " + startat + " "; break;
                case RecopilatorioEnumerations.ETopDistinct.DISTINCT: sqlSentence += " DISTINCT "; break;
                default: break;
            }
            return sqlSentence;
        }

        private static string SqlBuilderWhereLogicOperator(RecopilatorioEnumerations.EWhereLogicOperator wherelogicoperator)
        {
            string sqlWhereClause = string.Empty;
            switch (wherelogicoperator)
            {
                case RecopilatorioEnumerations.EWhereLogicOperator.WHITESPACE: sqlWhereClause += " "; break;
                case RecopilatorioEnumerations.EWhereLogicOperator.AND: sqlWhereClause += " AND "; break;
                case RecopilatorioEnumerations.EWhereLogicOperator.OR: sqlWhereClause += " OR "; break;
                default: break;
            }
            return sqlWhereClause;
        }

        private static string SqlBuilderWhereComparissonType(RecopilatorioEnumerations.EWhereComparisson wherecomparissontype)
        {
            string sqlWhereClause = string.Empty;
            switch (wherecomparissontype)
            {
                case RecopilatorioEnumerations.EWhereComparisson.WHITESPACE: sqlWhereClause += " "; break;
                case RecopilatorioEnumerations.EWhereComparisson.ISNULL:     sqlWhereClause += " IS NULL "; break;
                case RecopilatorioEnumerations.EWhereComparisson.ISNOTNULL:  sqlWhereClause += " IS NOT NULL "; break;
                case RecopilatorioEnumerations.EWhereComparisson.LIKE:    sqlWhereClause += " LIKE "; break;
                case RecopilatorioEnumerations.EWhereComparisson.NOTLIKE: sqlWhereClause += " NOT LIKE "; break;
                case RecopilatorioEnumerations.EWhereComparisson.EQUALS:    sqlWhereClause += " = "; break;
                case RecopilatorioEnumerations.EWhereComparisson.NOTEQUALS: sqlWhereClause += " <> "; break;
                case RecopilatorioEnumerations.EWhereComparisson.GREATEROREQUALS: sqlWhereClause += " >= "; break;
                case RecopilatorioEnumerations.EWhereComparisson.GREATERTHAN:     sqlWhereClause += " > "; break;
                case RecopilatorioEnumerations.EWhereComparisson.LESSOREQUALS:    sqlWhereClause += " <= "; break;
                case RecopilatorioEnumerations.EWhereComparisson.LESSTHAN:        sqlWhereClause += " < "; break;
                case RecopilatorioEnumerations.EWhereComparisson.IN: sqlWhereClause += " IN "; break;
                default: break;
            }
            return sqlWhereClause;
        }

        private static string SqlBuilderWhereComparissonValue(RecopilatorioEnumerations.ETipoDato wherecomparissonvaluetype, string wherecomparissonvalue)
        {
            string sqlWhereClause = string.Empty;
            switch (wherecomparissonvaluetype)
            {
                case RecopilatorioEnumerations.ETipoDato.DBstring:   sqlWhereClause += " '" + wherecomparissonvalue + "' "; break;
                case RecopilatorioEnumerations.ETipoDato.DBchar:     sqlWhereClause += " '" + wherecomparissonvalue[0] + "' "; break;
                case RecopilatorioEnumerations.ETipoDato.DBbyte:     sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case RecopilatorioEnumerations.ETipoDato.DBshort:    sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case RecopilatorioEnumerations.ETipoDato.DBint:      sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case RecopilatorioEnumerations.ETipoDato.DBlong:     sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case RecopilatorioEnumerations.ETipoDato.DBdecimal:  sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case RecopilatorioEnumerations.ETipoDato.DBdouble:   sqlWhereClause += " "  + wherecomparissonvalue + " "; break;
                case RecopilatorioEnumerations.ETipoDato.DBdatetime: sqlWhereClause += " '" + wherecomparissonvalue + "' "; break;
                default: break;
            }
            return sqlWhereClause;
        }
        #endregion
        #endregion

        #region GetChild
        public static List<string> GetChild<T>(DependencyObject container)
        {
            List<string> resultchild = new List<string>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(container); i++)
            {
                FrameworkElement child = (FrameworkElement)VisualTreeHelper.GetChild(container, i);

                if (child.GetType() == typeof(Grid) || child.GetType() == typeof(GroupBox) || child.GetType() == typeof(ScrollViewer) ||
                    child.GetType() == typeof(DockPanel) || child.GetType() == typeof(StackPanel) || child.GetType() == typeof(WrapPanel) ||
                    child.GetType() == typeof(Border) || child.GetType() == typeof(Canvas) || child.GetType() == typeof(Page) ||
                    child.GetType() == typeof(Table) || child.GetType() == typeof(TabPanel) || child.GetType() == typeof(ToolBarOverflowPanel) ||
                    child.GetType() == typeof(UniformGrid) || child.GetType() == typeof(VirtualizingPanel) || child.GetType() == typeof(VirtualizingStackPanel))
                {
                    resultchild.AddRange(GetChild<T>(child));
                }
                else
                {
                    if (child.GetType() != typeof(Label) && child.GetType() != typeof(Button))
                    {
                        if (child.Tag != null)
                        {
                            resultchild.Add(child.Tag.ToString());
                        }
                    }
                }
            }
            return resultchild;
        }
        #endregion
    }
}
