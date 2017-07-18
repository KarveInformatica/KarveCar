#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-09-20 12:15:29 -0600 (Sat, 20 Sep 2008) $
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
    /// <summary>
    /// Analyse XML mapping file and import their configurations in the <see cref="IConfigurationStore"/>
    /// </summary>
    public partial class XmlMappingProcessor : BaseXmlProcessor
    {
        private string nameSpace = string.Empty;

        /// <summary>
        /// Registers the element handlers.
        /// </summary>
        protected override void RegisterElementHandlers()
		{
            RegisterElementHandler(ConfigConstants.ELEMENT_SQLMAP, ProcessSqlMapElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_TYPEALIAS, ProcessTypeAliasElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_CACHEMODEL, ProcessCacheModelElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_FLUSHINTERVAL, ProcessFlushIntervallElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_FLUSHONEXECUTE, ProcessFlushOnExecuteElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_PROPERTY, ProcessPropertyElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_RESULTMAP, ProcessResultMapElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_CONSTRUCTOR, ProcessConstructorElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_RESULT, ProcessResultElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_DISCRIMINATOR, ProcessDiscriminatorElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_CASE, ProcessCaseElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_DEFAULT, ProcessDefaultElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ARGUMENT, ProcessArgumentElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_PARAMETERMAP, ProcessParameterMapElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_PARAMETER, ProcessParameterElement);

            RegisterElementHandler(ConfigConstants.ELEMENT_SELECT, ProcessStatementElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_STATEMENT, ProcessStatementElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_UPDATE, ProcessStatementElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_DELETE, ProcessStatementElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_INSERT, ProcessStatementElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_PROCEDURE, ProcessStatementElement);

            RegisterElementHandler(ConfigConstants.ELEMENT_SQL, ProcessSqlElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_INCLUDE, ProcessIncludeElement);

            RegisterElementHandler(ConfigConstants.ELEMENT_SELECTKEY, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_DYNAMIC, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISEMPTY, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISEQUAL, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISGREATEREQUAL, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISGREATERTHAN, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISLESSTHAN, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISLESSEQUAL, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISNOTEMPTY, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISNOTEQUAL, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISNOTNULL, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISNOTPARAMETERPRESENT, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISNOTPROPERTYAVAILABLE, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISNULL, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISPARAMETERPRESENT, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ISPROPERTYAVAILABLE, ProcessDynamicElement);
            RegisterElementHandler(ConfigConstants.ELEMENT_ITERATE, ProcessDynamicElement);

		}

        /// <summary>
        /// Processes the SQL map element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        private void ProcessSqlMapElement(Tag element, IConfigurationStore configurationStore)
        {
            nameSpace = element.Attributes[ConfigConstants.ATTRIBUTE_NAMESPACE];
        }

        /// <summary>
        /// Processes the type alias element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        private void ProcessTypeAliasElement(Tag element, IConfigurationStore configurationStore)
        {
            IConfiguration config = new MutableConfiguration(
                element.Name,
                element.Attributes[ConfigConstants.ATTRIBUTE_ALIAS],
                element.Attributes[ConfigConstants.ATTRIBUTE_TYPE]);

            configurationStore.AddAliasConfiguration(config);
        }


        /// <summary>
        /// Processes the property element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        private void ProcessPropertyElement(Tag element, IConfigurationStore configurationStore)
        {
            if (element.Parent != null && element.Parent.Name == ConfigConstants.ELEMENT_CACHEMODEL)
            {
                MutableConfiguration config = new MutableConfiguration(element.Name);
                config.CreateAttributes(element.Attributes);

                element.Parent.Configuration.Children.Add(config);
            }
        }

        /// <summary>
        /// Register under Name or Fully Qualified Statement Name
        /// </summary>
        /// <param name="ids">The Identities</param>
        /// <returns>The new Identity</returns>
        private string ApplyNamespace(string ids)
        {
            string newIds = string.Empty;
            char[] splitter  = {','};
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
                newIds += newId+",";
           }
            if (newIds.EndsWith(","))
            {
                newIds = newIds.Remove(newIds.Length - 1);
            }
            return newIds;
        }
    }
}
