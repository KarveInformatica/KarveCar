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
    /// Handles fluent configuration for ParameterMap element
    /// </summary>
    public class ParameterExpression : ParameterMapExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        public ParameterExpression(ModuleBuilder builder)
            : base(builder)
        {
            parameterExpression = this;
        }

        /// <summary>
        /// To the Column name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ParameterExpression ToColumn(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in ToColumn method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMN, name);

            return this;
        }

        /// <summary>
        /// With the type handler.
        /// </summary>
        /// <returns></returns>
        public ParameterExpression WithTypeHandler<THandler>()
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
        public ParameterExpression UsingDbType(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in UsingDbType method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_DBTYPE, name);

            return this;
        }

        /// <summary>
        /// Uses the type.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ParameterExpression UsingType(string name)
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
        public ParameterExpression UsingNullValue(string val)
        {
            Contract.Require.That(val, Is.Not.Null & Is.Not.Empty).When("retrieving null value argument in UsingNullValue method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_NULLVALUE, val);

            return this;
        }

        /// <summary>
        /// With the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public ParameterExpression WithDirection(string direction)
        {
            Contract.Require.That(direction, Is.Not.Null & Is.Not.Empty).When("retrieving direction argument in UsingNullValue method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_DIRECTION, direction);

            return this;
        }

        /// <summary>
        /// With the size
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public ParameterExpression WithSize(string size)
        {
            Contract.Require.That(size, Is.Not.Null & Is.Not.Empty).When("retrieving size argument in WithSize method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_SIZE, size);

            return this;
        }

        /// <summary>
        /// With the scale
        /// </summary>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public ParameterExpression WithScale(string scale)
        {
            Contract.Require.That(scale, Is.Not.Null & Is.Not.Empty).When("retrieving scale argument in WithScale method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_SCALE, scale);

            return this;
        }
        
    /// <summary>
        /// With the precision
        /// </summary>
        /// <param name="precision">The precision.</param>
        /// <returns></returns>
        public ParameterExpression WithPrecision(string precision)
        {
            Contract.Require.That(precision, Is.Not.Null & Is.Not.Empty).When("retrieving precision argument in WithPrecision method");

            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_PRECISION, precision);

            return this;
        }
    }
}
