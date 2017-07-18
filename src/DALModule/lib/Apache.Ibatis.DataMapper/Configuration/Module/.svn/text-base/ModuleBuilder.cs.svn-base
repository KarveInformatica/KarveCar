#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
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
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Exceptions;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Used to incrementally build <see cref="IConfiguration"/> element.
    /// </summary>
    public partial class ModuleBuilder
    {
        private readonly IConfigurationStore store = null;
        private readonly string nameSpace = string.Empty;
        private MutableConfiguration currentConfiguration = null;

        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>The current configuration.</value>
        public MutableConfiguration CurrentConfiguration
        {
            get { return currentConfiguration; }
            set { currentConfiguration = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBuilder"/> class.
        /// </summary>
        public ModuleBuilder()
        {
            store = new DefaultConfigurationStore();
            nameSpace = GetType().Name.Replace("Module", string.Empty);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBuilder"/> class.
        /// </summary>
        /// <param name="nameSpace">The name space.</param>
        public ModuleBuilder(string nameSpace)
        {
            store = new DefaultConfigurationStore();
            this.nameSpace = nameSpace; 
        }


        /// <summary>
        /// Create new <see cref="IConfiguration"/> elements with the registration.
        /// </summary>
        /// <param name="configurationStore">The configuration store.</param>
        protected void Build(IConfigurationStore configurationStore)
        {
            Contract.Require.That(configurationStore, Is.Not.Null).When("retrieving store argument in Build method");
            
            //Register the last configuration
            RegisterConfiguration();

            BuildTypeAlias(configurationStore);
            BuildTypeHandler(configurationStore);

            BuildResultMap(configurationStore);
            BuildParameterMap(configurationStore);
        }

        /// <summary>
        /// Register under Name or Fully Qualified Statement Name
        /// </summary>
        /// <param name="ids">The Identities</param>
        /// <returns>The new Identity</returns>
        public string ApplyNamespace(string ids)
        {
            string newIds = string.Empty;
            char[] splitter = { ',' };
            string[] idTab = ids.Split(splitter);

            for (int i = 0; i < idTab.Length; i++)
            {
                string id = idTab[i].Trim();
                string newId = id;
                if (nameSpace != null && nameSpace.Length > 0
                    && id.Length > 0 && id.IndexOf(".") < 0)
                {
                    newId = nameSpace + ConfigConstants.DOT + id;
                }
                newIds += newId + ",";
            }
            if (newIds.EndsWith(","))
            {
                newIds = newIds.Remove(newIds.Length - 1);
            }
            return newIds;
        }

        /// <summary>
        /// Registers the current configuration.
        /// </summary>
        /// <returns></returns>
        public MutableConfiguration RegisterConfiguration()
        {
            MutableConfiguration configuration = currentConfiguration;

            if (currentConfiguration!=null)
            {
                switch(currentConfiguration.Type)
                {
                    case ConfigConstants.ELEMENT_TYPEALIAS:
                        store.AddAliasConfiguration(currentConfiguration);
                        break;
                    case ConfigConstants.ELEMENT_TYPEHANDLER:
                        store.AddTypeHandlerConfiguration(currentConfiguration);
                        break;
                    case ConfigConstants.ELEMENT_RESULTMAP:
                        store.AddResultMapConfiguration(currentConfiguration);
                        break;
                    case ConfigConstants.ELEMENT_PARAMETERMAP:
                        store.AddParameterMapConfiguration(currentConfiguration);
                        break;
                    case ConfigConstants.ELEMENT_RESULT:
                    case ConfigConstants.ELEMENT_DISCRIMINATOR:
                    case ConfigConstants.ELEMENT_CONSTRUCTOR:
                    case ConfigConstants.ELEMENT_PARAMETER:
                        break;
                    default:
                        throw new DataMapperException("Invalid configuration registration for configuration type:" + currentConfiguration.Type);
                }
                currentConfiguration = null;
            }

            return configuration;
        }
    }
}
