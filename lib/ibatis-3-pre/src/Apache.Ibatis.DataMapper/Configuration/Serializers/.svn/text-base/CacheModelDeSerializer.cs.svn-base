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

using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Model.Cache;

#endregion 


namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for CacheModelDeSerializer.
	/// </summary>
	public sealed class CacheModelDeSerializer
	{

        /// <summary>
        /// Deserializes the specified config in a CacheModel object.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <returns>A CacheModel object</returns>
        public static CacheModel Deserialize(IConfiguration config, DataExchangeFactory dataExchangeFactory)
        {
            string id = config.Id;
            string type = ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_TYPE);
            type = dataExchangeFactory.TypeHandlerFactory.GetTypeAlias(type).Type.AssemblyQualifiedName;
            long flushInterval = ConfigurationUtils.GetLongAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_FLUSHINTERVAL, int.MinValue);
            bool isShare = ConfigurationUtils.GetBooleanAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SHARE, false);
            int size = ConfigurationUtils.GetIntAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SIZE, int.MinValue);

            return new CacheModel(id, type, flushInterval, size, isShare);
        }
	}
}
