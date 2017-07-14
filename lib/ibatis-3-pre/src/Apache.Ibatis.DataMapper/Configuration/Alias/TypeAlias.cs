
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 408099 $
 * $Date: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
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
using System.Xml.Serialization;
using Apache.Ibatis.Common.Utilities;

#endregion

namespace Apache.Ibatis.DataMapper.Configuration.Alias
{
	/// <summary>
	/// TypeAlias.
	/// </summary>
	[Serializable]
	[XmlRoot("typeAlias", Namespace="http://ibatis.apache.org/dataMapper")]
	public class TypeAlias
	{

		#region Fields
		[NonSerialized]
		private string _id = string.Empty;
		[NonSerialized]
		private string _className = string.Empty;
		[NonSerialized]
		private Type _class = null;
		#endregion

		#region Properties
		/// <summary>
		/// Name used to identify the typeAlias amongst the others.
		/// </summary>
		/// <example> Account</example>
		[XmlAttribute("alias")]
		public string Id
		{
			get { return _id; }
		}


		/// <summary>
		/// The type class for the typeAlias
		/// </summary>
		[XmlIgnore]
		public Type Class
		{
			get { return _class; }
		}
	

		/// <summary>
		/// The class name to identify the typeAlias.
		/// </summary>
		/// <example>Com.Site.Domain.Product</example>
		[XmlAttribute("type")]
		public string ClassName
		{
			get { return _className; }
		}
		#endregion

		#region Constructor (s) / Destructor


        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAlias"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="className">Name of the class.</param>
        public TypeAlias(string id, string className)
		{
            if ((id == null) || (id.Length < 1))
            {
                throw new ArgumentNullException("The Id attribute is mandatory in the typeAlias ");
            }
            _id = id;

            if ((className == null) || (className.Length < 1))
            {
                throw new ArgumentNullException("The class attribute is mandatory in the typeAlias " + _id);
            }
            _className = className;  
            _class = TypeUtils.ResolveType(_className);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAlias"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="type">The type.</param>
        public TypeAlias(string id, Type type)
		{
            if ((id == null) || (id.Length < 1))
            {
                throw new ArgumentNullException("The Id attribute is mandatory in the typeAlias ");
            }
            _id = id;
			_class = type;
		}
		#endregion


	}
}
