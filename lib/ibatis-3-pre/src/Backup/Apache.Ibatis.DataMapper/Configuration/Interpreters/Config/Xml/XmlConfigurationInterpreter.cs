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
using System.Reflection;
using System.Xml;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor;
using CommonExceptions = Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml
{
    /// <summary>
    /// <see cref="XmlConfigurationInterpreter"/> is reponsible for translating the DataMapper configuration 
    /// in XML format to what the IConfigurationEngine expects
    /// </summary>
    /// <example>
    ///  &lt;?xml version="1.0" encoding="utf-8"?&gt;
    /// &lt;sqlMapConfig xmlns="http://ibatis.apache.org/dataMapper" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"&gt;
    ///  
    ///     &lt;properties uri="file://../../database.config"/&gt;
    ///   
    ///   	&lt;settings&gt;
    ///   	   &lt;setting useStatementNamespaces="false"/&gt;
    ///   	&lt;/settings&gt;
    ///     
    ///     ...
    /// 
    /// &lt;/sqlMapConfig&gt;
    /// </example>
    public class XmlConfigurationInterpreter : AbstractInterpreter
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlConfigurationInterpreter"/> class
        /// from an The <see cref="IResource"/>.
        /// </summary>
        /// <param name="resource">The <see cref="IResource"/>.</param>
        public XmlConfigurationInterpreter(IResource resource)
            : base(resource)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlConfigurationInterpreter"/> class
        /// from an XML file path.
        /// </summary>
        /// <param name="xmlFileName">The XML filename.</param>
        public XmlConfigurationInterpreter(string xmlFileName)
            : base(xmlFileName)
		{ }
        #endregion

        /// <summary>
        /// Should obtain the contents from the resource,
        /// interpret it and populate the <see cref="IConfigurationStore"/>
        /// accordingly.
        /// </summary>
        /// <param name="configurationStore">The store.</param>
        public override void ProcessResource(IConfigurationStore configurationStore)
        {
            Contract.Require.That(configurationStore, Is.Not.Null).When("retrieve argument configurationStore in ProcessResource method");
            Contract.Assert.That(Resource, Is.Not.Null).When("process Resource in ConfigurationInterpreter");

            using (Resource)
            {
                IConfiguration setting = configurationStore.Settings[ConfigConstants.ATTRIBUTE_VALIDATE_SQLMAP];
                if(setting !=null)
                {
                    bool mustValidate = false;
                    Boolean.TryParse(setting.Value, out mustValidate);
                    if (mustValidate)
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(Resource.Stream);
                        SchemaValidator.Validate(document.ChildNodes[1], "SqlMapConfig.xsd");             
                    }                    
                }

                Resource.Stream.Position = 0; 
                using (XmlTextReader reader = new XmlTextReader(Resource.Stream))
                {
                    using (XmlConfigProcessor processor = new XmlConfigProcessor())
                    {
                        processor.Process(reader, configurationStore);
                    }
                }
            }

            if (logger.IsInfoEnabled)
            {
                logger.Info("Configuration Store");
                logger.Info(configurationStore.ToString());
            }
        }
    }
}
