#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 408164 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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

using System.Collections.Specialized;
using System.Xml;
using Apache.Ibatis.Common.Xml;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Elements;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Utilities.Objects.Members;

#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for IsGreaterEqualDeSerializer.
	/// </summary>
    public sealed class IsGreaterEqualDeSerializer : BaseDynamicDeSerializer
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="IsGreaterEqualDeSerializer"/> class.
        /// </summary>
        /// <param name="accessorFactory">The accessor factory.</param>
        public IsGreaterEqualDeSerializer(AccessorFactory accessorFactory)
            : base(accessorFactory)
        { }

		#region IDeSerializer Members

        /// <summary>
        /// Deserializes the specified configuration in an <see cref="IsGreaterEqual"/> object
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public override SqlTag Deserialize(IConfiguration configuration)
		{
            IsGreaterEqual isGreaterEqual = new IsGreaterEqual(accessorFactory);

			isGreaterEqual.Prepend = ConfigurationUtils.GetStringAttribute(configuration.Attributes, "prepend");
			isGreaterEqual.Property = ConfigurationUtils.GetStringAttribute(configuration.Attributes, "property");
			isGreaterEqual.CompareProperty = ConfigurationUtils.GetStringAttribute(configuration.Attributes, "compareProperty");
			isGreaterEqual.CompareValue = ConfigurationUtils.GetStringAttribute(configuration.Attributes, "compareValue");

			return isGreaterEqual;
		}

		#endregion
	}
}
