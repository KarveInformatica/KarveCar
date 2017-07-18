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
    /// Handles fluent configuration for Argument element
    /// </summary>
    public class ArgumentExpression : ConstructorExpression
    {
        private readonly MutableConfiguration currentArgument = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        /// <param name="parentConfiguration">The parent configuration.</param>
        /// <param name="currentArgument">The current argument.</param>
        public ArgumentExpression(ModuleBuilder builder, MutableConfiguration parentConfiguration, MutableConfiguration currentArgument)
            : base(builder, parentConfiguration)
        {
            this.currentArgument = currentArgument;
        }

        /// <summary>
        /// To the Column name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ArgumentExpression ToColumnName(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in ToColumnName method");

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMN, name);

            return this;
        }

        /// <summary>
        /// To the Column index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public ArgumentExpression ToColumnIndex(int index)
        {
            Contract.Require.That(index, Is.EqualTo(0) | Is.GreaterThan(0)).When("retrieving index argument in ToColumnIndex method");

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMNINDEX, index.ToString());

            return this;
        }

        /// <summary>
        /// Uses the result map.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ArgumentExpression UsingResultMap(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in UsingResultMap method");

            id = builder.ApplyNamespace(id);

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_RESULTMAPPING, id);

            return this;
        }

        /// <summary>
        /// With the type handler.
        /// </summary>
        /// <returns></returns>
        public ArgumentExpression WithTypeHandler<THandler>()
        {
            Type typeHandler = typeof(THandler);

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPEHANDLER, typeHandler.AssemblyQualifiedName);

            return this;
        }

        /// <summary>
        /// Uses the dbtype.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ArgumentExpression UsingDbType(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in UsingDbType method");

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_DBTYPE, name);

            return this;
        }

        /// <summary>
        /// Uses the type.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ArgumentExpression UsingType(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in UsingType method");

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPE, name);

            return this;
        }

        /// <summary>
        /// Uses the null value.
        /// </summary>
        /// <param name="val">The null value.</param>
        /// <returns></returns>
        public ArgumentExpression UsingNullValue(string val)
        {
            Contract.Require.That(val, Is.Not.Null & Is.Not.Empty).When("retrieving null value argument in UsingNullValue method");

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_NULLVALUE, val);

            return this;
        }

        /// <summary>
        /// Uses the select statment.
        /// </summary>
        /// <param name="id">The id statement.</param>
        /// <returns></returns>
        public ArgumentExpression UsingSelect(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in UsingSelect method");

            currentArgument.CreateAttribute(ConfigConstants.ATTRIBUTE_SELECT, id);

            return this;
        }
    }
}
