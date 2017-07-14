
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 397590 $
 * $Date: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

#region Using

using System;
using System.Collections;
using System.Data;
using System.Reflection;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.TypeHandlers;
using System.Collections.Generic;

#endregion

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    /// <summary>
    /// Build a dynamic instance of a <see cref="ResultPropertyCollection"/>
    /// </summary>
    public sealed class ReaderAutoMapper 
	{
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        /// <summary>
        /// Builds a <see cref="ResultPropertyCollection"/> for an <see cref="AutoResultMap"/>.
        /// </summary>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="resultObject">The result object.</param>
		public static ResultPropertyCollection Build(DataExchangeFactory dataExchangeFactory,
		                        IDataReader reader,
			                    ref object resultObject) 
		{
        	Type targetType = resultObject.GetType();
            ResultPropertyCollection properties = new ResultPropertyCollection();
			
            try 
			{
				// Get all PropertyInfo from the resultObject properties
				ReflectionInfo reflectionInfo = ReflectionInfo.GetInstance(targetType);
				string[] membersName = reflectionInfo.GetWriteableMemberNames();

                IDictionary<string, ISetAccessor> propertyMap = new Dictionary<string, ISetAccessor>();
				int length = membersName.Length;
				for (int i = 0; i < length; i++) 
				{
                    ISetAccessorFactory setAccessorFactory = dataExchangeFactory.AccessorFactory.SetAccessorFactory;
                    ISetAccessor setAccessor = setAccessorFactory.CreateSetAccessor(targetType, membersName[i]);
                    propertyMap.Add(membersName[i], setAccessor);
				}

				// Get all column Name from the reader
				// and build a resultMap from with the help of the PropertyInfo[].
				DataTable dataColumn = reader.GetSchemaTable();
				int count = dataColumn.Rows.Count;
				for (int i = 0; i < count; i++) 
				{
                    string propertyName = string.Empty;
					string columnName = dataColumn.Rows[i][0].ToString();

                    ISetAccessor matchedSetAccessor = null;
                    propertyMap.TryGetValue(columnName, out matchedSetAccessor);

					int columnIndex = i;

					if (resultObject is Hashtable) 
					{
						propertyName = columnName;

                        ResultProperty property = new ResultProperty(
                            propertyName,
                            columnName,
                            columnIndex,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            false,
                            string.Empty,
                            null,
                            string.Empty,
                            targetType,
                            dataExchangeFactory,
                            null);
                        properties.Add(property);
					}

					Type propertyType = null;

                    if (matchedSetAccessor == null)
					{
						try
						{
							propertyType = ObjectProbe.GetMemberTypeForSetter(resultObject, columnName);
						}
						catch
						{
							_logger.Error("The column [" + columnName + "] could not be auto mapped to a property on [" + resultObject + "]");
						}
					}
					else
					{
                        propertyType = matchedSetAccessor.MemberType;
					}

                    if (propertyType != null || matchedSetAccessor != null) 
					{
                        propertyName = (matchedSetAccessor != null ? matchedSetAccessor.Name : columnName);
                        ITypeHandler typeHandler = null;

                        if (matchedSetAccessor != null)
						{
                            //property.Initialize(dataExchangeFactory.TypeHandlerFactory, matchedSetAccessor);
                            typeHandler = dataExchangeFactory.TypeHandlerFactory.GetTypeHandler(matchedSetAccessor.MemberType);
						}
						else
						{
                            typeHandler = dataExchangeFactory.TypeHandlerFactory.GetTypeHandler(propertyType);
						}

						//property.PropertyStrategy = PropertyStrategyFactory.Get(property);

                        ResultProperty property = new ResultProperty(
                            propertyName,
                            columnName,
                            columnIndex,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            false,
                            string.Empty,
                            null,
                            string.Empty,
                            targetType,
                            dataExchangeFactory,
                            typeHandler);

                        properties.Add(property);
					} 
				}
			} 
			catch (Exception e) 
			{
				throw new DataMapperException("Error automapping columns. Cause: " + e.Message, e);
			}
            
            return properties;
		}

	}
}
