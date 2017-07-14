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
    /// Handles fluent configuration for ResultMap childs
    /// </summary>
    public class ResultMapExpression
    {
        protected readonly ModuleBuilder builder = null;
        protected MutableConfiguration parentConfiguration = null;
        protected ResultExpression resultExpression = null;
        protected DiscriminatorExpression discriminatorExpression = null;
        protected ConstructorExpression constructorExpression = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMapExpression"/> class.
        /// </summary>
        /// <param name="builder">The module builder.</param>
        public ResultMapExpression(ModuleBuilder builder)
        {
            this.builder = builder;
        }
        
        /// <summary>
        /// Extendses the specified result map.
        /// </summary>
        /// <param name="extend">The extend id.</param>
        /// <returns></returns>
        public ResultExpression Extends(string extend)
        {
            Contract.Require.That(extend, Is.Not.Null & Is.Not.Empty).When("retrieving extend argument in Extends method");

            if (parentConfiguration == null)
            {
                resultExpression = new ResultExpression(builder);
                parentConfiguration = builder.RegisterConfiguration();
                resultExpression.parentConfiguration = parentConfiguration;
            }
            if (resultExpression == null)
            {
                resultExpression = new ResultExpression(builder);
                resultExpression.parentConfiguration = parentConfiguration;
            }
            parentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_EXTENDS, builder.ApplyNamespace(extend));

            return resultExpression;
        }

        /// <summary>
        /// Mappings to the specified member.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ResultExpression MappingMember(string name)
        {
            Contract.Require.That(name, Is.Not.Null & Is.Not.Empty).When("retrieving name argument in MappingMember method");

            if (parentConfiguration == null)
            {
                resultExpression = new ResultExpression(builder);
                parentConfiguration = builder.RegisterConfiguration();
                resultExpression.parentConfiguration = parentConfiguration;
            }
            if (resultExpression == null)
            {
                resultExpression = new ResultExpression(builder);
                resultExpression.parentConfiguration = parentConfiguration;
            }
            builder.CurrentConfiguration = new MutableConfiguration(ConfigConstants.ELEMENT_RESULT, name);
            builder.CurrentConfiguration.CreateAttribute(ConfigConstants.ATTRIBUTE_PROPERTY, name);

            parentConfiguration.Children.Add(builder.CurrentConfiguration);

            return resultExpression;
        }

        /// <summary>
        /// Using the constructor.
        /// </summary>
        /// <value>The using constructor.</value>
        public ConstructorExpression UsingConstructor
        {
            get 
            {
                MutableConfiguration configuration = new MutableConfiguration(ConfigConstants.ELEMENT_CONSTRUCTOR);

                if (parentConfiguration == null)
                {
                    constructorExpression = new ConstructorExpression(builder, parentConfiguration);
                    parentConfiguration = builder.RegisterConfiguration();
                    constructorExpression.parentConfiguration = parentConfiguration;
                }
                if (constructorExpression == null)
                {
                    constructorExpression = new ConstructorExpression(builder, parentConfiguration);
                    constructorExpression.parentConfiguration = parentConfiguration;
                }
                builder.CurrentConfiguration = configuration;

                parentConfiguration.Children.Add(builder.CurrentConfiguration);

                return constructorExpression;
            }
        }

        /// <summary>
        /// With a discriminator on the specified column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public DiscriminatorExpression WithDiscriminator<TType>(string column)
        {
            Contract.Require.That(column, Is.Not.Null & Is.Not.Empty).When("retrieving column argument in WithDiscriminator method");

            Type type = typeof(TType);
            MutableConfiguration configuration = new MutableConfiguration(ConfigConstants.ELEMENT_DISCRIMINATOR, column);
            configuration.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMN, column);
            configuration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPE, type.AssemblyQualifiedName);

            if (parentConfiguration == null)
            {
                discriminatorExpression = new DiscriminatorExpression(builder);
                parentConfiguration = builder.RegisterConfiguration();
                discriminatorExpression.parentConfiguration = configuration;
            }
            if (discriminatorExpression == null)
            {
                discriminatorExpression = new DiscriminatorExpression(builder);
                discriminatorExpression.parentConfiguration = configuration;
            }

            builder.CurrentConfiguration = configuration;

            parentConfiguration.Children.Add(builder.CurrentConfiguration);

            return discriminatorExpression;
        }

        /// <summary>
        /// With a discriminator on the specified column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public DiscriminatorExpression WithDiscriminator<TType, TTypeHandler>(string column)
        {
            Contract.Require.That(column, Is.Not.Null & Is.Not.Empty).When("retrieving column argument in WithDiscriminator method");

            Type type = typeof(TType);
            Type typeHandler = typeof(TTypeHandler);
            MutableConfiguration configuration = new MutableConfiguration(ConfigConstants.ELEMENT_DISCRIMINATOR, column);
            configuration.CreateAttribute(ConfigConstants.ATTRIBUTE_COLUMN, column);
            configuration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPE, type.AssemblyQualifiedName);
            configuration.CreateAttribute(ConfigConstants.ATTRIBUTE_TYPEHANDLER, typeHandler.AssemblyQualifiedName);

            if (parentConfiguration == null)
            {
                discriminatorExpression = new DiscriminatorExpression(builder);
                parentConfiguration = builder.RegisterConfiguration();
                discriminatorExpression.parentConfiguration = parentConfiguration;
            }
            if (discriminatorExpression == null)
            {
                discriminatorExpression = new DiscriminatorExpression(builder);
                discriminatorExpression.parentConfiguration = parentConfiguration;
            }

            builder.CurrentConfiguration = configuration;

            parentConfiguration.Children.Add(builder.CurrentConfiguration);

            return discriminatorExpression;
        }
    }
}
