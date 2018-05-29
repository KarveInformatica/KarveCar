using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQL
{
    /// <summary>
    ///  This is a query filter. It can be used inside a queryStore to build a valid query.
    /// </summary>
    public class QueryFilter: IQueryFilter
    {
       
        private QueryOperation _queryOperation;
        private string _fieldName;
        private string _dataValue;
        /// <summary>
        /// This is a filter to be used within a query.
        /// </summary>
        /// <param name="firstValue">Name of the field</param>
        /// <param name="secondValue">Value of the field</param>
        public QueryFilter(string firstValue, string secondValue)
        {
            this._fieldName=firstValue;
            this._dataValue = secondValue;
        }


        /// <summary>
        ///  Identifier.
        /// </summary>
        public long Id { set; get;}
        /// <summary>
        ///  operatin to query.
        /// </summary>
        public QueryOperation QueryOperation { get => _queryOperation; set => _queryOperation = value; }
        // Name of the query
        public string Name { get => _fieldName; set => _fieldName = value; }
        /// <summary>
        ///  Type of the data.
        /// </summary>
        public string Value { get => _dataValue; set => _dataValue = value; }
        /// <summary>
        ///  Resolve the query
        /// </summary>
        /// <returns></returns>
        public string Resolve()
        {
            StringBuilder _stringBuilder = new StringBuilder();
            switch (_queryOperation)
            {
                case QueryOperation.FIRST:
                    {
                        _stringBuilder.Append(Name);
                        _stringBuilder.Append(" REGEXP ");
                        _stringBuilder.Append("'"+Value+ "'");
                        _stringBuilder.Append(" ");
                        break;
                    }
                case QueryOperation.AND:
                    {
                        _stringBuilder.Append(" AND ");
                        _stringBuilder.Append(Name);
                        _stringBuilder.Append(" REGEXP ");
                        _stringBuilder.Append(Value);
                        _stringBuilder.Append(" ");
                        break;
                    }

                case QueryOperation.OR:
                    {
                        _stringBuilder.Append(" OR ");
                        _stringBuilder.Append(Name);
                        _stringBuilder.Append(" REGEXP ");
                        _stringBuilder.Append(Value);
                        _stringBuilder.Append(" ");
                        break;

                    }
                    
                case QueryOperation.NOT:
                    {
                        _stringBuilder.Append(" NOT ");
                        _stringBuilder.Append(Name);
                        _stringBuilder.Append(" REGEXP ");
                        _stringBuilder.Append(Value);
                        _stringBuilder.Append(" ");
                        break;

                    }
            }
            return _stringBuilder.ToString();
        }
    }
}