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
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Handles fluent configuration for ResultMapping element
    /// </summary>
    public class ResultExpression : ResultMapExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        public ResultExpression(ModuleBuilder builder)
            : base(builder)
        {
            resultExpression = this;
        }


        /// <summary>
        /// To the Column name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ResultExpression ToColumnName(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in ToColumnName method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMN, name);

            return this;
        }

        /// <summary>
        /// To the Column index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public ResultExpression ToColumnIndex(int index)
        {
            Contract.Require.That(index, Is.EqualTo(0) | Is.GreaterThan(0)).When("retrieving index argument in ToColumnIndex method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMNINDEX, index.ToString());

            return this;
        }

        /// <summary>
        /// Uses the result map.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ResultExpression UsingResultMap(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in UsingResultMap method");

            id = builder.ApplyNamespace(id);

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_RESULTMAPPING, id);

            return this;
        }

        /// <summary>
        /// With the type handler.
        /// </summary>
        /// <returns></returns>
        public ResultExpression WithTypeHandler<THandler>()
        {
            Type typeHandler = typeof(THandler);

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPEHANDLER, typeHandler.AssemblyQualifiedName);

            return this;
        }

        /// <summary>
        /// Uses the dbtype.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ResultExpression UsingDbType(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in UsingDbType method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_DBTYPE, name);

            return this;
        }

        /// <summary>
        /// Uses lazy loadind.
        /// </summary>
        /// <value>The using lazy load.</value>
        public ResultExpression UsingLazyLoad()
        {
            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_LAZYLOAD, "true");

            return this;                
        }

        /// <summary>
        /// Uses the type.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ResultExpression UsingType(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in UsingType method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPE, name);

            return this;
        }

        /// <summary>
        /// Uses the null value.
        /// </summary>
        /// <param name="val">The null value.</param>
        /// <returns></returns>
        public ResultExpression UsingNullValue(string val)
        {
            Contract.Require.That(val, Is.Not.Null & Is.Not.Empty).When("retrieving null value argument in UsingNullValue method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_NULLVALUE, val);

            return this;
        }

        /// <summary>
        /// Uses the select statment.
        /// </summary>
        /// <param name="id">The id statement.</param>
        /// <returns></returns>
        public ResultExpression UsingSelect(string id)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving id argument in UsingSelect method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_SELECT, id);

            return this;
        }
    }
}
