#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2009-06-13 20:02:32 -0600 (Sat, 13 Jun 2009) $
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
using Apache.Ibatis.Common.Data;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor
{
    public partial class XmlConfigProcessor
    {
        /// <summary>
        /// Processes the DataSource element in the SqlMap.config file. 
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        private void ProcessDataSourceElement(Tag element, IConfigurationStore configurationStore)
        {
            if (element.Parent != null && element.Parent.Name == ConfigConstants.ELEMENT_DATABASE)
            {
                MutableConfiguration config = new MutableConfiguration(
                    element.Name,
                    element.Attributes[DataConstants.ATTRIBUTE_NAME],
                    element.Attributes[DataConstants.ATTRIBUTE_CONNECTIONSTRING]);
                config.CreateAttributes(element.Attributes);

                element.Parent.Configuration.Children.Add(config);
            }
        }
    }
}
