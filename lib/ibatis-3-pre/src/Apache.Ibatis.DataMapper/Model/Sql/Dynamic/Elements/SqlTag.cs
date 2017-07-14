
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
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
using System.Collections;
using System.Xml.Serialization;

using Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Handlers;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Elements
{
	/// <summary>
	/// SqlTag is a children element of dynamic Sql element.
	/// SqlTag represent any binary unary/conditional element (like isEmpty, isNull, iEquall...) 
	/// or other element as isParameterPresent, isNotParameterPresent, iterate.
	/// </summary>
	[Serializable]
	public abstract class SqlTag : ISqlChild, IDynamicParent
	{
		#region Fields
		
		[NonSerialized]
		private string prepend = string.Empty;
		[NonSerialized]
		private ISqlTagHandler handler = null;
		[NonSerialized]
		private SqlTag parent = null;
		[NonSerialized]
        private IList<ISqlChild> children = new List<ISqlChild>();

		#endregion

		/// <summary>
		/// Parent tag element
		/// </summary>
		public SqlTag Parent
		{
			get { return parent; }
			set { parent = value; }
		}


		/// <summary>
		/// Prepend attribute
		/// </summary>
		public string Prepend
		{
			get { return prepend; }
			set { prepend = value; }
		}


		/// <summary>
		/// Handler for this sql tag
		/// </summary>
		public ISqlTagHandler Handler
		{

			get { return handler; }
			set { handler = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsPrependAvailable 
		{
			get { return (prepend != null && prepend.Length > 0); }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public IEnumerator<ISqlChild> GetChildrenEnumerator() 
		{
			return children.GetEnumerator();
		}

		#region IDynamicParent Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="child"></param>
		public void AddChild(ISqlChild child)
		{
			if (child is SqlTag) 
			{
				((SqlTag) child).Parent = this;
			}
			children.Add(child);		
		}

		#endregion
	}
}
