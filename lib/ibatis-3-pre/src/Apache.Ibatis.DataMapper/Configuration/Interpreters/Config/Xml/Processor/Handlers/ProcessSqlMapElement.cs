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

using System;
using System.Xml;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Resources;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor
{
    public partial class XmlConfigProcessor
    {
        /// <summary>
        /// Processes the SQL map element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        private void ProcessSqlMapElement(Tag element, IConfigurationStore configurationStore)
        {
            if (element.Attributes.ContainsKey(ConfigConstants.ATTRIBUTE_URI))
            {
                string uri = element.Attributes[ConfigConstants.ATTRIBUTE_URI];
                IResource resource = ResourceLoaderRegistry.GetResource(uri);

                Contract.Assert.That(resource, Is.Not.Null).When("process Resource in ConfigurationInterpreter");

                using (resource)
                {
                    IConfiguration setting = configurationStore.Settings[ConfigConstants.ATTRIBUTE_VALIDATE_SQLMAP];
                    if (setting != null)
                    {
                        bool mustValidate = false;
                        Boolean.TryParse(setting.Value, out mustValidate);
                        if (mustValidate)
                        {
                            XmlDocument document = new XmlDocument();
                            document.Load(resource.Stream);
                            SchemaValidator.Validate(document.ChildNodes[1], "SqlMap.xsd");
                        }
                    }

                    resource.Stream.Position = 0; 
                    using (XmlTextReader reader = new XmlTextReader(resource.Stream))
                    {
                        using (XmlMappingProcessor processor = new XmlMappingProcessor())
                        {
                            processor.Process(reader, configurationStore);
                        }
                    }
                }
            }
        }
    }
}
