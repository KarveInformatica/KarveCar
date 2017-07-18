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
using Apache.Ibatis.DataMapper.MappedStatements.PropertyStrategy;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.MappedStatements.PropertStrategy
{
    /// <summary>
    /// <see cref="IPropertyStrategy"/> implementation when the resulMap have a keys attribute.
    /// </summary>
    public sealed class CircularStrategy : BaseStrategy, IPropertyStrategy
    {
        private const string KEY_SEPARATOR = "\002";
        private readonly IPropertyStrategy resultMapStrategy = null;

        /// <summary>
        /// Initializes the <see cref="CircularStrategy"/> class.
        /// </summary>
        /// <param name="resultMapStrategy">The result map strategy.</param>
        public CircularStrategy(IPropertyStrategy resultMapStrategy)
		{
            this.resultMapStrategy = resultMapStrategy;
		}

        #region IPropertyStrategy Members

        /// <summary>
        /// Sets value of the specified <see cref="ResultProperty"/> on the target object.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="resultMap">The result map.</param>
        /// <param name="mapping">The ResultProperty.</param>
        /// <param name="target">The target.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="keys">The keys</param>
        public void Set(RequestScope request, IResultMap resultMap, ResultProperty mapping, ref object target, IDataReader reader, object keys)
        {
            Get(request, resultMap, mapping, ref target, reader);
        }

        /// <summary>
        /// Gets the value of the specified <see cref="ResultProperty"/> that must be set on the target object.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="resultMap">The result map.</param>
        /// <param name="mapping">The mapping.</param>
        /// <param name="target">The target.</param>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public object Get(RequestScope request, IResultMap resultMap, ResultProperty mapping, ref object target, IDataReader reader)
        {
            object result = null;

            IResultMap propertyRresultMap = mapping.NestedResultMap.ResolveSubMap(reader);

            string circularKey = GetCircularKey(propertyRresultMap, reader);
            // Gets the [key, result object] already build
            IDictionary<string, object> buildObjects = request.GetCirularKeys(propertyRresultMap);

            if (buildObjects != null && buildObjects.ContainsKey(circularKey))
            {
                // circular key is already known, so get the existing result object
                result = buildObjects[circularKey];
            }
            else if (circularKey == null || buildObjects == null || !buildObjects.ContainsKey(circularKey))
            {
                // circular key is NOT known, so create a new result object.
                result = resultMapStrategy.Get(request, resultMap, mapping, ref target, reader);

                if (buildObjects == null)
                {
                    buildObjects = new Dictionary<string, object>();
                    request.SetCirularKeys(propertyRresultMap, buildObjects);
                }
                buildObjects[circularKey] = result;
            }

            return result;
        }

        #endregion

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
    }
}
