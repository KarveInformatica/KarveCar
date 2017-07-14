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
    /// Handles fluent configuration for ResultMap
    /// </summary>
    public partial class ModuleBuilder
    {
        private ResultMapExpression resultMapExpression = null;

        /// <summary>
        /// Registers a ResultMap.
        /// </summary>
        /// <param name="id">The id.</param>
        public ResultMapExpression RegisterResultMap<TResultClass>(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in RegisterResultMap method");

            RegisterConfiguration();
            resultMapExpression = new ResultMapExpression(this);

            Type resultType = typeof(TResultClass);

            currentConfiguration = new MutableConfiguration(
                ConfigConstants.ELEMENT_RESULTMAP,
                ApplyNamespace(id),
                resultType.AssemblyQualifiedName);
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_CLASS, resultType.AssemblyQualifiedName);
            currentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_NAMESPACE, nameSpace);

            return resultMapExpression;
        }

        private void BuildResultMap(IConfigurationStore configurationStore)
        {
            for (int i = 0; i < store.ResultMaps.Length; i++)
            {
                configurationStore.AddResultMapConfiguration(store.ResultMaps[i]);
            }
        }
    }
}
