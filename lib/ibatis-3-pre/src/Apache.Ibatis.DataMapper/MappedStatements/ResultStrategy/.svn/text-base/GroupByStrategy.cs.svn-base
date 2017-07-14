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

using System.Collections.Generic;
using System.Data;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy
{
    /// <summary>
    /// <see cref="IResultStrategy"/> implementation when 
    /// a 'groupBy' attribute is specified on the resultMap tag.
    /// </summary>
    /// <remarks>N+1 Select solution</remarks>
    public sealed class GroupByStrategy : BaseStrategy, IResultStrategy
    {

        #region IResultStrategy Members

        /// <summary>
        /// Processes the specified <see cref="IDataReader"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="resultObject">The result object.</param>
        /// <returns>The result object</returns>
        public object Process(RequestScope request, ref IDataReader reader, object resultObject)
        {
            object outObject = resultObject;

            IResultMap resultMap = request.CurrentResultMap.ResolveSubMap(reader);

            string uniqueKey = GetUniqueKey(resultMap, reader);
            // Gets the [key, result object] already build
            IDictionary<string, object> buildObjects = request.GetUniqueKeys(resultMap);

            if (buildObjects != null && buildObjects.ContainsKey(uniqueKey))
            {
                // Unique key is already known, so get the existing result object and process additional results.
                outObject = buildObjects[uniqueKey];
                // process resulMapping attribute which point to a groupBy attribute
                for (int index = 0; index < resultMap.Properties.Count; index++)
                {
                    ResultProperty resultProperty = resultMap.Properties[index];
                    if (resultProperty.PropertyStrategy is PropertStrategy.GroupByStrategy)
                    {
                        resultProperty.PropertyStrategy.Set(request, resultMap, resultProperty, ref outObject, reader, null);
                    }
                }
                outObject = SKIP;
            }
            else if (uniqueKey == null || buildObjects == null || !buildObjects.ContainsKey(uniqueKey))
            {
                // Unique key is NOT known, so create a new result object and process additional results.

                // Fix IBATISNET-241
                if (outObject == null)
                {
                    // temp ?, we don't support constructor tag with groupBy attribute
                    outObject = resultMap.CreateInstanceOfResult(null);
                }

                for (int index = 0; index < resultMap.Properties.Count; index++)
                {
                    ResultProperty resultProperty = resultMap.Properties[index];
                    resultProperty.PropertyStrategy.Set(request, resultMap, resultProperty, ref outObject, reader, null);                   
                }

                if (buildObjects == null)
                {
                    buildObjects = new Dictionary<string, object>();
                    request.SetUniqueKeys(resultMap, buildObjects);
                }
                buildObjects[uniqueKey] = outObject;
            }

            return outObject;
        }

        #endregion
    }
}
