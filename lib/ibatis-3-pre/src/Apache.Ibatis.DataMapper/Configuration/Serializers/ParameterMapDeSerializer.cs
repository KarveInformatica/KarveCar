#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 410610 $
 * $Date: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using System;
#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for ParameterMapDeSerializer.
	/// </summary>
	public sealed class ParameterMapDeSerializer
	{

        /// <summary>
        /// Deserializes a ParameterMap object
        /// </summary>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="config">The config.</param>
        /// <param name="modelStore">The model store.</param>
        /// <returns></returns>
        public static ParameterMap Deserialize(
            DataExchangeFactory dataExchangeFactory,
            IConfiguration config,
            IModelStore modelStore)
        {
            Type type = null;
            IDataExchange dataExchange = null;

            string id = config.Id;
            string className = ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_CLASS);
            string extendMap = config.GetAttributeValue(ConfigConstants.ATTRIBUTE_EXTENDS);
            if (className.Length > 0)
            {
                type = dataExchangeFactory.TypeHandlerFactory.GetType(className);
                dataExchange = dataExchangeFactory.GetDataExchangeForClass(type);
            }
            else
            {
                // Get the ComplexDataExchange
                dataExchange = dataExchangeFactory.GetDataExchangeForClass(dataExchangeFactory.TypeHandlerFactory.GetTypeAlias(className).Type);
            }

            return new ParameterMap(
                id,
                className,
                extendMap,
                type,
                dataExchange,
                modelStore.SessionFactory.DataSource.DbProvider.UsePositionalParameters);
        }
    }
}
