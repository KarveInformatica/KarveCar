#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
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

using System;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Handles fluent configuration for TypeHandler element
    /// </summary>
    public partial class ModuleBuilder
    {
        /// <summary>
        /// Registers a TypeHandler.
        /// </summary>
        /// <returns>The TypeHandler identifiant</returns>
        public string RegisterTypeHandler<THandler, TCallBack>()
        {
            RegisterConfiguration();

            Type typeHandler = typeof(THandler);
            Type callBack = typeof(TCallBack);

            currentConfiguration = new MutableConfiguration(
                ConfigConstants.ELEMENT_TYPEHANDLER,
                typeHandler.Name
                );
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_CALLBACK, callBack.AssemblyQualifiedName);
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPE, typeHandler.Name);

            return currentConfiguration.Id;
        }

        /// <summary>
        /// Registers a TypeHandler.
        /// </summary>
        /// <param name="dbType">Type of the db.</param>
        /// <returns>The TypeHandler identifiant</returns>
        public string RegisterTypeHandler<THandler, TCallBack>(string dbType)
        {
            Contract.Require.That(dbType, Is.Not.Null & Is.Not.Empty).When("retrieving dbType argument in RegisterTypeHandler method");

            RegisterConfiguration();

            Type typeHandler = typeof(THandler);
            Type callBack = typeof(TCallBack);

            currentConfiguration = new MutableConfiguration(
                ConfigConstants.ELEMENT_TYPEHANDLER,
                typeHandler.Name
                );
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_DBTYPE, dbType);
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_CALLBACK, callBack.AssemblyQualifiedName);
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPE, typeHandler.Name);

            return currentConfiguration.Id;
        }

        private void BuildTypeHandler(IConfigurationStore configurationStore)
        {
            for (int i = 0; i < store.TypeHandlers.Length; i++)
            {
                configurationStore.AddTypeHandlerConfiguration(store.TypeHandlers[i]);
            }
        }
    }
}
