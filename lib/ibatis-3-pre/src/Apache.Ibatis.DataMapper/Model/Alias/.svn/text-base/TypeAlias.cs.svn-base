
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 408099 $
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
using Apache.Ibatis.Common.Utilities;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.DataMapper.Model.Alias
{
    /// <summary>
    /// Represent a type alias
    /// </summary>
    [Serializable]
    [DebuggerDisplay("TypeAlias: {Id}-{typeName}")]
    public class TypeAlias
    {
        private readonly string id = string.Empty;
        private readonly Type type = null;
        private readonly string typeName = string.Empty;

        /// <summary>
        /// Gets the alias identifier.
        /// </summary>
        /// <value>The alias.</value>
        public string Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type
        {
            get { return type; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAlias"/> class.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="type">The type.</param>
        public TypeAlias(string alias, string type)
        {
            Contract.Require.That(alias, Is.Not.Null & Is.Not.Empty).When("retrieving argument alias in TypeAlias constructor");
            Contract.Require.That(type, Is.Not.Null & Is.Not.Empty).When("retrieving argument type in TypeAlias constructor");

            id = alias;
            typeName = type;
            this.type = TypeUtils.ResolveType(type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAlias"/> class.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="type">The type.</param>
        public TypeAlias(string alias, Type type)
        {
            Contract.Require.That(alias, Is.Not.Null & Is.Not.Empty).When("retrieving argument alias in TypeAlias constructor");
            Contract.Require.That(type, Is.Not.Null & Is.Not.Empty).When("retrieving argument type in TypeAlias constructor");

            id = alias;
            typeName = type.AssemblyQualifiedName;
            this.type = type;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return typeName;
        }
    }
}
