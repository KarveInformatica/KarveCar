
#region Apache Notice
/*****************************************************************************
 * $Revision: 469233 $
 * $LastChangedDate: 2009-06-28 10:11:37 -0600 (Sun, 28 Jun 2009) $
 * $LastChangedBy: rgrabowski $
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

#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Sql;
using Apache.Ibatis.DataMapper.Model.Sql.External;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Statements
{
    /// <summary>
    /// Summary description for ISql.
    /// </summary>
    public interface IStatement
    {
        #region Properties
        
        /// <summary>
        /// Gets a value indicating whether [allow remapping].
        /// </summary>
        /// <value><c>true</c> if [allow remapping]; otherwise, <c>false</c>.</value>
        bool AllowRemapping { get; }

        /// <summary>
        /// Identifier used to identify the statement amongst the others.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the  type of the statement (text or procedure).
        /// </summary>
        CommandType CommandType { get; }
        
        /// <summary>
        /// Gets the extend statement name.
        /// </summary>
        /// <value>The extend statement.</value>
        string ExtendStatement { get; }

        /// <summary>
        /// Gets the sql statement to execute.
        /// </summary>
        ISql Sql { get; set;  }

        /// <summary>
        /// The ResultMaps used by the statement.
        /// </summary>
        ResultMapCollection ResultsMap { get; }

        /// <summary>
        /// The parameterMap used by the statement.
        /// </summary>
        ParameterMap ParameterMap { get; set;  }

        /// <summary>
        /// Gets the cache model used by this statement.
        /// </summary>
        /// <value>The cache model.</value>
        CacheModel CacheModel { get; }

        /// <summary>
        /// Gets the parameter class type.
        /// </summary>
        /// <value>The parameter class.</value>
        Type ParameterClass { get; }

        /// <summary>
        /// Gets the result class type.
        /// </summary>
        /// <value>The result class.</value>
        Type ResultClass { get; }

        /// <summary>
        /// Gets the list class type.
        /// </summary>
        /// <value>The list class.</value>
        Type ListClass { get; }

        /// <summary>
        /// Gets or sets the SQL source.
        /// </summary>
        /// <value>The SQL source.</value>
        ISqlSource SqlSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether whitespace within &lt;statement&gt; nodes should be preserved.
        /// </summary>
        /// <remarks>
        /// Using the default value of false may cause single line SQL comments '--' to comment out more than expected. A 
        /// safer commenting syntax is to always use the multi-line comments supported by most vendors: '/* ... */'
        /// </remarks>
        bool PreserveWhitespace { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Create an instance of 'IList' class.
        /// </summary>
        /// <returns>An object which implement IList.</returns>
        IList CreateInstanceOfListClass();

        /// <summary>
        /// Create an instance of a generic 'IList' class.
        /// </summary>
        /// <returns>An object which implement IList.</returns>
        IList<T> CreateInstanceOfGenericListClass<T>();
        #endregion

    }
}
