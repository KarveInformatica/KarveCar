
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
    [Serializable]
    [DebuggerDisplay("TypeHandler: {type}-{DbType}-{Callback}")]
    public class TypeHandler
    {
        private readonly string dbType = string.Empty;
        private readonly string callback = string.Empty;
        private readonly Type type = null;

        /// <summary>
        /// Gets the type of the db.
        /// </summary>
        /// <value>The type of the db.</value>
        public string DbType
        {
            get { return dbType; }
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>The callback.</value>
        public string Callback
        {
            get { return callback; }
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
        /// Initializes a new instance of the <see cref="TypeHandler"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="callback">The callback.</param>
        public TypeHandler(string type, string dbType, string callback)
        {
            Contract.Require.That(type, Is.Not.Null & Is.Not.Empty).When("retrieving argument type");

            this.dbType = dbType;
            this.callback = callback;
            this.type = TypeUtils.ResolveType(type);
        }
    }
}
