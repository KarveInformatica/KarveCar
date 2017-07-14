
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

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Handles fluent configuration for ResultMap constructor
    /// </summary>
    public class ConstructorExpression : ResultMapExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMapExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        /// <param name="parentConfiguration">The parent configuration.</param>
        public ConstructorExpression(ModuleBuilder builder, MutableConfiguration parentConfiguration)
            : base(builder)
        {
            constructorExpression = this;
            this.parentConfiguration = parentConfiguration;
        }

        /// <summary>
        /// Mappings to the specified Argument.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ArgumentExpression MappingArgument(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in MappingArgument method");

            //if (parentConfiguration == null)
            //{
            //    argumentExpression = new ArgumentExpression(builder);
            //    parentConfiguration = builder.RegisterConfiguration();
            //    argumentExpression.parentConfiguration = parentConfiguration;
            //}
            //if (argumentExpression == null)
            //{
            //    argumentExpression = new ArgumentExpression(builder);
            //    argumentExpression.parentConfiguration = parentConfiguration;
            //}
            //currentArgument = new MutableConfiguration(ConfigConstants.ELEMENT_ARGUMENT, name);
            //currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_ARGUMENTNAME, name);

            //parentConfiguration.Children.Add(currentSubMap);

            MutableConfiguration configArgument = new MutableConfiguration(ConfigConstants.ELEMENT_ARGUMENT, name);
            configArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_ARGUMENTNAME, name);
            builder.CurrentConfiguration.Children.Add(configArgument);

            ArgumentExpression argumentExpression = new ArgumentExpression(builder, parentConfiguration, configArgument);

            return argumentExpression;
        }
    }
}
