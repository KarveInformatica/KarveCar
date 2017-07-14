#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 512878 $
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
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.DataExchange;
using System;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for ParameterPropertyDeSerializer.
	/// </summary>
	public sealed class ParameterPropertyDeSerializer
	{

        /// <summary>
        /// Deserializes the specified config in a ResultMap object.
        /// </summary>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="parameterClass">The parameter class.</param>
        /// <param name="config">The config.</param>
        /// <returns></returns>
        public static ParameterProperty Deserialize(
            DataExchangeFactory dataExchangeFactory, 
            Type parameterClass,
            IConfiguration config)
        {
            string propertyName = ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_PROPERTY);
            string columnName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_COLUMN);
            string callBackName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_TYPEHANDLER);
            string clrType = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_TYPE);
            string dbType = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_DBTYPE, null);
            string direction = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_DIRECTION);
            string nullValue = config.GetAttributeValue(ConfigConstants.ATTRIBUTE_NULLVALUE);
            Byte precision = ConfigurationUtils.GetByteAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_PRECISION, 0);
            Byte scale = ConfigurationUtils.GetByteAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SCALE, 0);
            int size = ConfigurationUtils.GetIntAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SIZE, -1);

            return new ParameterProperty(
                propertyName,
                columnName,
                callBackName,
                clrType,
                dbType,
                direction,
                nullValue,
                precision,
                scale,
                size,
                parameterClass,
                dataExchangeFactory);
        }
    }
}
