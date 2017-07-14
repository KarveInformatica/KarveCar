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

using System;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Handles fluent configuration for Discriminator element
    /// </summary>
    public class DiscriminatorExpression : ResultMapExpression
    {
        protected MutableConfiguration currentSubMap = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscriminatorExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        public DiscriminatorExpression(ModuleBuilder builder)
            : base(builder)
        {
            discriminatorExpression = this;
        }

        /// <summary>
        /// Using as subMap the ResulMap with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public DiscriminatorExpression UsingResultMap(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in UsingResultMap method");

            id = builder.ApplyNamespace(id);
            currentSubMap = new MutableConfiguration(ConfigConstants.ELEMENT_CASE, id);
            currentSubMap.CreateAttribute(ConfigConstants.ATTRIBUTE_RESULTMAP, id);
            parentConfiguration.Children.Add(currentSubMap);
 
            return this;
        }

        /// <summary>
        /// For the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DiscriminatorExpression ForValue(string value)
        {
            Contract.Require.That(value, Is.Not.Null & Is.Not.Empty).When("retrieving value argument in ForValue method");

            currentSubMap.CreateAttribute(ConfigConstants.ATTRIBUTE_VALUE, value);

            return this;
        }

        /// <summary>
        /// With the type handler.
        /// </summary>
        /// <returns></returns>
        public DiscriminatorExpression WithTypeHandler<THandler>()
        {
            Type typeHandler = typeof(THandler);

            parentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPEHANDLER, typeHandler.AssemblyQualifiedName);

            return this;
        }
    }
}
