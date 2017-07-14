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


using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.DataExchange;
using System;

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for ResultPropertyDeSerializer.
	/// </summary>
	public sealed class ResultPropertyDeSerializer
	{
        /// <summary>
        /// Deserialize the specified config in a ResultProperty object
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="resultClass">The result class.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <returns></returns>
        public static ResultProperty Deserialize(
            IConfiguration config, 
            Type resultClass,
            string prefix,
            string suffix,
            DataExchangeFactory dataExchangeFactory)
		{
            string propertyName = ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_PROPERTY);
            string columnName = prefix+ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_COLUMN)+suffix;
            int columnIndex = ConfigurationUtils.GetIntAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_COLUMNINDEX, ResultProperty.UNKNOWN_COLUMN_INDEX);
            string clrType = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_TYPE);
            string callBackName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_TYPEHANDLER);
            string dbType = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_DBTYPE);
            bool isLazyLoad = ConfigurationUtils.GetBooleanAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_LAZYLOAD, false);
            string nestedResultMapName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_RESULTMAPPING);
            string nullValue = config.GetAttributeValue(ConfigConstants.ATTRIBUTE_NULLVALUE);
            string select = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SELECT);

            return new ResultProperty(
                propertyName,
                columnName,
                columnIndex,
                clrType,
                callBackName,
                dbType,
                isLazyLoad,
                nestedResultMapName,
                nullValue,
                select,
                resultClass,
                dataExchangeFactory,
                null
                );
		}
	}
}
