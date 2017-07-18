#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-09-21 13:25:16 -0600 (Sun, 21 Sep 2008) $
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

namespace Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy
{
	/// <summary>
	/// <see cref="IResultStrategy"/> implementation when 
	/// a 'resultClass' attribute is specified and
	/// the type of the result object is primitive.
	/// </summary>
    public sealed class SimpleTypeStrategy : IResultStrategy
    {
        #region IResultStrategy Members

        /// <summary>
        /// Processes the specified <see cref="IDataReader"/> 
        /// when a ResultClass is specified on the statement and
        /// the ResultClass is a SimpleType.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="resultObject">The result object.</param>
        public object Process(RequestScope request, ref IDataReader reader, object resultObject)
        {
            object outObject = resultObject;
            AutoResultMap resultMap = (AutoResultMap)request.CurrentResultMap;
            
            if (outObject == null) 
            {
                outObject = resultMap.CreateInstanceOfResult(null);
            }

            if (!resultMap.IsInitalized)
            { 
                lock(resultMap)
                {
                    if (!resultMap.IsInitalized)
                    {
                        // Create a ResultProperty
                        const string propertyName = "value";
                        const int columnIndex = 0;
                        ITypeHandler typeHandler = request.DataExchangeFactory.TypeHandlerFactory.GetTypeHandler(outObject.GetType());

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
                            null,
                            null,
                            typeHandler);
                        //property.PropertyStrategy = PropertyStrategyFactory.Get(property);

                        resultMap.Properties.Add(property);
                        resultMap.DataExchange = request.DataExchangeFactory.GetDataExchangeForClass(typeof(int));// set the PrimitiveDataExchange
                        resultMap.IsInitalized = true;
                    }
                }
            }

            resultMap.Properties[0].PropertyStrategy.Set(request, resultMap, resultMap.Properties[0], ref outObject, reader, null); 
      
			return outObject;
		}

        #endregion
    }
}
