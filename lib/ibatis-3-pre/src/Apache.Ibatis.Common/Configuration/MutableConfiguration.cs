
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
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
using System.Collections.Generic;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.Common.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Configuration: {Type}-{Id}")]
    public class MutableConfiguration : AbstractConfiguration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MutableConfiguration"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public MutableConfiguration(string type)
            : this(type, type)
        { }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="MutableConfiguration"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The id.</param>
        public MutableConfiguration(string type, string id)
            : this(type, id, null)
        { }
 

        /// <summary>
        /// Initializes a new instance of the <see cref="MutableConfiguration"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The id.</param>
        /// <param name="value">The value.</param>
        public MutableConfiguration(string type, string id, string value)
        {
            Contract.Require.That(type, Is.Not.Null & Is.Not.Empty).When("retrieving type argument in MutableConfiguration constructor");

            internalId = id;
            internalValue = value;
            internalType = type;
        }


        /// <summary>
        /// Gets the value of <see cref="IConfiguration"/>.
        /// </summary>
        /// <value>The Value of the <see cref="IConfiguration"/>.</value>
        public new string Value
        {
            set { internalValue = value; }
        }

        /// <summary>
        /// Create an attributes the specified name, value on the <see cref="MutableConfiguration"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="MutableConfiguration"/></returns>
        public MutableConfiguration CreateAttribute(string name, string value)
        {
            Attributes[name] = value;
            return this;
        }

        /// <summary>
        /// Create attributes on the <see cref="MutableConfiguration"/>.
        /// </summary>
        /// <param name="attr">The Attributes.</param>
        /// <returns>The <see cref="MutableConfiguration"/></returns>
        public MutableConfiguration CreateAttributes(IDictionary<string, string> attr)
        {
            attributes = attr;
            return this;
        }

        /// <summary>
        /// Creates the child on the <see cref="MutableConfiguration"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="MutableConfiguration"/></returns>
        public MutableConfiguration CreateChild(string name)
        {
            MutableConfiguration child = new MutableConfiguration(name);
            Children.Add(child);
            return child;
        }

        /// <summary>
        /// Creates the child on the <see cref="MutableConfiguration"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="MutableConfiguration"/></returns>
        public MutableConfiguration CreateChild(string name, string value)
        {
            MutableConfiguration child = new MutableConfiguration(name, value);
            Children.Add(child);
            return child;
        }
    }
}