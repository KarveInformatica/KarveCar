
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2009-06-28 10:11:37 -0600 (Sun, 28 Jun 2009) $
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

#region Imports

using System;
using System.Diagnostics;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Model.Sql.External;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Statements
{
	/// <summary>
	/// Represent a SelectKey tag element.
	/// </summary>
	[Serializable]
    [DebuggerDisplay("SelectKey: {SelectKeyType}-{PropertyName}")]
	public class SelectKey : Statement 
	{
		[NonSerialized]
		private readonly SelectKeyType selectKeyType = SelectKeyType.post;
		[NonSerialized]
        private readonly string propertyName = string.Empty;

		#region Properties
		/// <summary>
		/// Extend statement attribute
		/// </summary>
		public override string ExtendStatement
		{
			get { return string.Empty;  }
		}

		/// <summary>
		/// The property name object to fill with the key.
		/// </summary>
		public string PropertyName
		{
            get { return propertyName; }
		}

		/// <summary>
		/// The type of the selectKey tag : 'Pre' or 'Post'
		/// </summary>
		public SelectKeyType SelectKeyType
		{
			get { return selectKeyType; }
		}


		/// <summary>
		/// True if it is a post-generated key.
		/// </summary>
		public bool isAfter
		{
			get { return selectKeyType == SelectKeyType.post; }
		}
		#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectKey"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="type">The type.</param>
        /// <param name="resultMaps">The result maps.</param>
        /// <param name="selectKeyType">Type of the select key.</param>
        /// <param name="sqlSource">The SQL source.</param>
        /// <param name="preserveWhitespace">Preserve whitespace.</param>
        public SelectKey(
            string id, 
            string propertyName,
            Type type,
            ResultMapCollection resultMaps,
            SelectKeyType selectKeyType,
            ISqlSource sqlSource,
            bool preserveWhitespace
            )
            : base(id, null, null, type, resultMaps, null, null, null, false, string.Empty, sqlSource, preserveWhitespace)
		{
            this.propertyName = propertyName;
            this.selectKeyType = selectKeyType;
        }
	}
}
