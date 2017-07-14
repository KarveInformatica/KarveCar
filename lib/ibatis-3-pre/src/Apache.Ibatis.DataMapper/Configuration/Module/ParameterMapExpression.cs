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
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Handles fluent configuration for ParameterMap childs
    /// </summary>
    public class ParameterMapExpression
    {
        protected readonly ModuleBuilder builder = null;
        protected MutableConfiguration parentConfiguration = null;
        protected ParameterExpression parameterExpression = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterMapExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        public ParameterMapExpression(ModuleBuilder builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// Extendses the specified parameter map.
        /// </summary>
        /// <param name="extend">The extend id.</param>
        /// <returns></returns>
        public ParameterExpression Extends(string extend)
        {
            Contract.Require.That(extend, Is.Not.Null & Is.Not.Empty).When("retrieving extend argument in Extends method");

            if (parentConfiguration == null)
            {
                parameterExpression = new ParameterExpression(builder);
                parentConfiguration = builder.RegisterConfiguration();
                parameterExpression.parentConfiguration = parentConfiguration;
            }
            if (parameterExpression == null)
            {
                parameterExpression = new ParameterExpression(builder);
                parameterExpression.parentConfiguration = parentConfiguration;
            }
            parentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_EXTENDS, builder.ApplyNamespace(extend));

            return parameterExpression;
        }

        /// <summary>
        /// Mappings to the specified Parameter.
        /// </summary>
        /// <param name="id">The name.</param>
        /// <returns></returns>
        public ParameterExpression MappingMember(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in MappingMember method");

            if (parentConfiguration == null)
            {
                parameterExpression = new ParameterExpression(builder);
                parentConfiguration = builder.RegisterConfiguration();
                parameterExpression.parentConfiguration = parentConfiguration;
            }
            if (parameterExpression == null)
            {
                parameterExpression = new ParameterExpression(builder);
                parameterExpression.parentConfiguration = parentConfiguration;
            }
            builder.CurrentConfiguration = new MutableConfiguration(ConfigConstants.ELEMENT_PARAMETER, id);
            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_PROPERTY, id);

            parentConfiguration.Children.Add(builder.CurrentConfiguration);

            return parameterExpression;
        }
    }
}
