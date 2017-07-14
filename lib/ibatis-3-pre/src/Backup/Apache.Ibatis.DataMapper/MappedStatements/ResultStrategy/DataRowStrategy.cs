#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

using System.Data;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.TypeHandlers;
using System;

namespace Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy
{
    /// <summary>
    /// <see cref="IResultStrategy"/> implementation when 
    /// a 'resultClass' attribute is specified and
    /// the type of the result object is <see cref="DataRow"/>.
    /// </summary>
    public class DataRowStrategy : IResultStrategy
    {
        #region IResultStrategy Members

        /// <summary>
        /// Processes the specified <see cref="IDataReader"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns></returns>
        public object Process(RequestScope request, ref IDataReader reader, object resultObject)
        {
            IResultMap resultMap = request.CurrentResultMap.ResolveSubMap(reader);
            DataRow dataRow = (DataRow)resultObject;
            DataTable dataTable = dataRow.Table;
            
            if (dataTable.Columns.Count==0)
            {
                // Builds and adss the columns
                dataTable.TableName = resultMap.Id;
                if (resultMap is AutoResultMap)
                {
                    for (int index = 0; index < reader.FieldCount; index++)
                    {
                        string columnName = reader.GetName(index);
                        Type type = reader.GetFieldType(index);

                        DataColumn column = new DataColumn();
                        column.DataType = type;
                        column.ColumnName = columnName;
                        dataTable.Columns.Add(column);
                    }
                }
                else
                {
                    for (int index = 0; index < resultMap.Properties.Count; index++)
                    {
                        ResultProperty property = resultMap.Properties[index];
                        DataColumn column = new DataColumn();
                        if (property.CLRType.Length > 0)
                        {
                            column.DataType = request.DataExchangeFactory.TypeHandlerFactory.GetType(property.CLRType);
                        }
                        else
                        {
                            object value = property.GetDataBaseValue(reader);
                            if (value == null)
                            {
                                int columnIndex = reader.GetOrdinal(property.ColumnName);
                                column.DataType = reader.GetFieldType(columnIndex);
                            }  
                            else
                            {
                                column.DataType = value.GetType();
                            }
                        }
                        column.ColumnName = property.PropertyName;

                        dataTable.Columns.Add(column);
                    }
                }
            }

           
            if (resultMap is AutoResultMap)
            {
                for (int index = 0; index < reader.FieldCount; index++)
                {
                    string propertyName = reader.GetName(index);
                    int columnIndex = index;
                    ITypeHandler typeHandler = request.DataExchangeFactory.TypeHandlerFactory.GetTypeHandler(reader.GetFieldType(index));

                    ResultProperty property = new ResultProperty(
                        propertyName,
                        string.Empty,
                        columnIndex,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        false,
                        string.Empty,
                        null,
                        string.Empty,
                        typeof(DataRow),
                        request.DataExchangeFactory,
                        typeHandler);

                    object value = property.GetDataBaseValue(reader);
                    if (value == null)
                    {
                        value = DBNull.Value;
                    }
                    dataRow[property.PropertyName] = value;
                }
            }
            else
            {
                for (int index = 0; index < resultMap.Properties.Count; index++)
                {
                    ResultProperty property = resultMap.Properties[index];
                    object value = property.GetDataBaseValue(reader);
                    if (value == null)
                    {
                        value = DBNull.Value;
                    }
                    dataRow[property.PropertyName] = value;
                }
            }

            return null;
        }

        #endregion
    }
}
