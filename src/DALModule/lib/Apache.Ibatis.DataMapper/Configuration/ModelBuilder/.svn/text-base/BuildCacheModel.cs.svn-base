#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
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
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Configuration.Serializers;
using Apache.Ibatis.DataMapper.Model.Cache;

namespace Apache.Ibatis.DataMapper.Configuration
{
    public partial class DefaultModelBuilder
    {

        /// <summary>
        /// Builds the cache model.
        /// </summary>
        /// <param name="store">The store.</param>
        private void BuildCacheModels(IConfigurationStore store)
        {
            for(int i=0;i<store.CacheModels.Length;i++)
            {
                IConfiguration cacheModelConfig = store.CacheModels[i];
                CacheModel cacheModel = CacheModelDeSerializer.Deserialize(cacheModelConfig, modelStore.DataExchangeFactory);

                string nameSpace = ConfigurationUtils.GetMandatoryStringAttribute(cacheModelConfig, ConfigConstants.ATTRIBUTE_NAMESPACE);

                // Gets all the flush on excecute statement id
                ConfigurationCollection flushConfigs = cacheModelConfig.Children.Find(ConfigConstants.ELEMENT_FLUSHONEXECUTE);
                for (int j = 0; j < flushConfigs.Count; j++)
                {
                    string statementId = flushConfigs[j].Attributes[ConfigConstants.ATTRIBUTE_STATEMENT];
                    if (useStatementNamespaces)
                    {
                        statementId = ApplyNamespace(nameSpace, statementId);
                    }

                    cacheModel.StatementFlushNames.Add(statementId);
                }

                modelStore.AddCacheModel(cacheModel);
            }
        }

        /// <summary>
        /// Gets the cacheModel properties.
        /// </summary>
        /// <param name="cacheModelConfiguration">The cache model configuration.</param>
        /// <returns></returns>
        private IDictionary<string, string> GetProperties(IConfiguration cacheModelConfiguration)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();

            // Get Properties 
            ConfigurationCollection propertiesConfigs = cacheModelConfiguration.Children.Find(ConfigConstants.ELEMENT_PROPERTY);

            for (int i = 0; i < propertiesConfigs.Count; i++)
            {
                IConfiguration propertie = propertiesConfigs[i];
                string name = propertie.Attributes[ConfigConstants.ATTRIBUTE_NAME];
                string value = propertie.Attributes[ConfigConstants.ATTRIBUTE_VALUE];

                properties.Add(name, value);
            }

            return properties;
        }

    }
}
