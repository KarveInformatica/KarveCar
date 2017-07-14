#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2009-06-28 10:11:37 -0600 (Sun, 28 Jun 2009) $
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

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor
{
    public partial class XmlMappingProcessor
    {
        /// <summary>
        /// Processes the statement element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        private void ProcessStatementElement(Tag element, IConfigurationStore configurationStore)
        {
            MutableConfiguration config = new MutableConfiguration(
                    element.Name,
                    element.Attributes[ConfigConstants.ATTRIBUTE_ID]);
            config.CreateAttributes(element.Attributes);
            config.CreateAttribute(ConfigConstants.ATTRIBUTE_NAMESPACE, nameSpace);

            AddAttribute(config, ConfigConstants.ATTRIBUTE_CACHEMODEL, true);
            AddAttribute(config, ConfigConstants.ELEMENT_PARAMETERMAP, true);
            AddAttribute(config, ConfigConstants.ELEMENT_RESULTMAP, true);
            AddAttribute(config, ConfigConstants.ELEMENT_PRESERVEWHITESPACE, false);

            configurationStore.AddStatementConfiguration(config);
            element.Configuration = config;
        }

        private void AddAttribute(IConfiguration config, string configConstant, bool applyNamespace)
        {
            if (config.Attributes.ContainsKey(configConstant))
            {
                config.Attributes[configConstant] = applyNamespace
                    ? ApplyNamespace(config.Attributes[configConstant])
                    : config.Attributes[configConstant];
            }
        }
    }
}
