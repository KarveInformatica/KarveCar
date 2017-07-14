
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
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Model.Sql;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Model.Sql.External;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Statements
{
    /// <summary>
    /// Summary description for Statement.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Statement: {Id}")]
    public class Statement : IStatement
    {

        #region Fields

        [NonSerialized]
        private readonly string id = string.Empty;
        [NonSerialized]
        private ParameterMap parameterMap = null;
        [NonSerialized]
        private readonly Type parameterClass = null;        
        [NonSerialized]
        private readonly ResultMapCollection resultMaps = new ResultMapCollection();
        [NonSerialized]
        private readonly Type resultClass = null;   
        [NonSerialized]
        private readonly Type listClass = null;    
        [NonSerialized]
        private readonly IFactory listClassFactory = null;
        [NonSerialized]
        private readonly CacheModel cacheModel = null;
        [NonSerialized]
        private readonly bool allowRemapping = false;
        [NonSerialized]
        private readonly string extends = string.Empty;
        [NonSerialized]
        private ISql sql = null;
        [NonSerialized]
        private ISqlSource sqlSource = null;
        [NonSerialized]
        private readonly bool preserveWhitespace;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the result class type.
        /// </summary>
        /// <value>The result class.</value>
        public Type ResultClass
        {
            get { return resultClass; }
        }

        /// <summary>
        /// Gets the list class type.
        /// </summary>
        /// <value>The list class.</value>
        public Type ListClass
        {
            get { return listClass; }
        }

        /// <summary>
        /// Gets a value indicating whether [allow remapping].
        /// </summary>
        /// <value><c>true</c> if [allow remapping]; otherwise, <c>false</c>.</value>
        public bool AllowRemapping
        {
            get { return allowRemapping; }
        }

        /// <summary>
        /// Gets the extend statement name.
        /// </summary>
        /// <value>The extend statement.</value>
        public virtual string ExtendStatement
        {
            get { return extends; }
        }

        /// <summary>
        /// Tell us if a cacheModel is attached to this statement.
        /// </summary>
        public bool HasCacheModel
        {
            get { return cacheModel != null; }
        }


        /// <summary>
        /// Gets the cache model used by this statement.
        /// </summary>
        /// <value>The cache model.</value>
        public CacheModel CacheModel
        {
            get { return cacheModel; }
        }


        /// <summary>
        /// Gets the parameter class type.
        /// </summary>
        /// <value>The parameter class.</value>
        public Type ParameterClass
        {
            get { return parameterClass; }
        }

        /// <summary>
        /// Gets the name used to identify the statement amongst the others.
        /// </summary>
        public string Id
        {
            get { return id; }
        }


        /// <summary>
        /// The sql statement
        /// </summary>
        public ISql Sql
        {
            get { return sql; }
            set
            {
                if (value == null)
                    throw new DataMapperException("The sql statement query text is required in the statement tag " + id);

                sql = value;
            }
        }

        /// <summary>
        /// The ResultMap used by the statement.
        /// </summary>
        public ResultMapCollection ResultsMap
        {
            get { return resultMaps; }
        }

        /// <summary>
        /// The parameterMap used by the statement.
        /// </summary>
        public ParameterMap ParameterMap
        {
            get { return parameterMap; }
            set { parameterMap = value; }
        }

        /// <summary>
        /// The type of the statement (text or procedure)
        /// Default Text.
        /// </summary>
        /// <example>Text or StoredProcedure</example>
        public virtual CommandType CommandType
        {
            get { return CommandType.Text; }
        }

        /// <summary>
        /// Gets the SQL source.
        /// </summary>
        /// <value>The SQL source.</value>
        public ISqlSource SqlSource
        {
            get { return sqlSource; }
            set { sqlSource = value;}
        }

        /// <summary>
        /// Gets or sets a value indicating whether whitespace within &lt;statement&gt; nodes should be preserved.
        /// </summary>
        /// <remarks>
        /// Using the default value of false may cause single line SQL comments '--' to comment out more than expected. A 
        /// safer commenting syntax is to always use the multi-line comments supported by most vendors: '/* ... */'
        /// </remarks>
        public bool PreserveWhitespace
        {
            get { return preserveWhitespace; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Statement"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="parameterClass">The parameter class.</param>
        /// <param name="parameterMap">The parameter map.</param>
        /// <param name="resultClass">The result class.</param>
        /// <param name="resultMaps">The result maps.</param>
        /// <param name="listClass">The list class.</param>
        /// <param name="listClassFactory">The list class factory.</param>
        /// <param name="cacheModel">The cache model.</param>
        /// <param name="remapResults">if set to <c>true</c> [remap results].</param>
        /// <param name="extends">The extends.</param>
        /// <param name="sqlSource">The SQL source.</param>
        /// <param name="preserveWhitespace">Preserve whitespace.</param>
        public Statement(
            string id, 
            Type parameterClass,
            ParameterMap parameterMap,
            Type resultClass,
            ResultMapCollection resultMaps,
            Type listClass,
            IFactory listClassFactory,
            CacheModel cacheModel,
            bool remapResults,
            string extends,
            ISqlSource sqlSource,
            bool preserveWhitespace)
        {
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving argument id");

            this.id = id;
            this.parameterClass = parameterClass;
            this.parameterMap = parameterMap;
            this.resultClass = resultClass;
            this.resultMaps = resultMaps;
            this.listClass = listClass;
            this.listClassFactory = listClassFactory;
            this.cacheModel = cacheModel;
            allowRemapping = remapResults;
            this.extends = extends;
            this.sqlSource = sqlSource;
            this.preserveWhitespace = preserveWhitespace;
        }

        #region Methods
 
        /// <summary>
        /// Create an instance of 'IList' class.
        /// </summary>
        /// <returns>An object which implment IList.</returns>
        public IList CreateInstanceOfListClass()
        {
            return (IList)listClassFactory.CreateInstance(null); 
        }

        /// <summary>
        /// Create an instance of a generic 'IList' class.
        /// </summary>
        /// <returns>An object which implment IList.</returns>
        public IList<T> CreateInstanceOfGenericListClass<T>()
        {
            return (IList<T>)listClassFactory.CreateInstance(null); 
        }
        #endregion
    }
}
