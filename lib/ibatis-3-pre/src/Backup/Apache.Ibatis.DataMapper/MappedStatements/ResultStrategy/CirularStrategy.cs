#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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
using System.Text;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy
{
    /// <summary>
    /// <see cref="IResultStrategy"/> implementation ro resolve circular refrence when 
    /// a 'keyColumns' attribute is specified on the resultMap tag.
    /// </summary>
    public sealed class CirularStrategy : BaseStrategy, IResultStrategy
    {

        private const string KEY_SEPARATOR = "\002";

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
            object outObject = resultObject;

            IResultMap resultMap = request.CurrentResultMap.ResolveSubMap(reader);

            string circularKey = GetCircularKey(resultMap, reader);
            // Gets the [key, result object] already build
            IDictionary<string, object> buildObjects = request.GetCirularKeys(resultMap);

            if (buildObjects != null && buildObjects.ContainsKey(circularKey))
            {
                // circular key is already known, so get the existing result object
                outObject = buildObjects[circularKey];
            }
            else if (circularKey == null || buildObjects == null || !buildObjects.ContainsKey(circularKey))
            {
                // circular key is NOT known, so create a new result object.
                if (outObject == null)
                {
                    object[] parameters = null;
                    if (resultMap.Parameters.Count > 0)
                    {
                        parameters = new object[resultMap.Parameters.Count];
                        // Fill parameters array
                        for (int index = 0; index < resultMap.Parameters.Count; index++)
                        {
                            ResultProperty resultProperty = resultMap.Parameters[index];
                            parameters[index] = resultProperty.GetValue(request, ref reader, null);
                        }
                    }

                    outObject = resultMap.CreateInstanceOfResult(parameters);
                }

                // For each Property in the ResultMap, set the property in the object 
                for (int index = 0; index < resultMap.Properties.Count; index++)
                {
                    ResultProperty resultProperty = resultMap.Properties[index];
                    resultProperty.PropertyStrategy.Set(request, resultMap, resultProperty, ref outObject, reader, null);
                }

                if (buildObjects == null)
                {
                    buildObjects = new Dictionary<string, object>();
                    request.SetCirularKeys(resultMap, buildObjects);
                }
                buildObjects[circularKey] = outObject;
            }

            return outObject;
        }

        /// <summary>
        /// Gets the circular key.
        /// </summary>
        /// <param name="resultMap">The result map.</param>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private static string GetCircularKey(IResultMap resultMap, IDataReader reader)
        {
            if (resultMap.KeysProperties.Count > 0)
            {
                StringBuilder keyBuffer = new StringBuilder();

                for (int i = 0; i < resultMap.KeysProperties.Count; i++)
                {
                    ResultProperty resultProperty = resultMap.KeysProperties[i];
                    keyBuffer.Append(resultProperty.GetDataBaseValue(reader));
                    keyBuffer.Append('-');
                }

                if (keyBuffer.Length < 1)
                {
                    // we should never go here
                    return null;
                }
                // separator value not likely to appear in a database
                keyBuffer.Append(KEY_SEPARATOR);
                return keyBuffer.ToString();
            }
            // we should never go here
            return null;
        }

        #endregion
    }
}
