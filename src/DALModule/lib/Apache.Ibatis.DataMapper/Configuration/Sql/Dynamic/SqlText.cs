
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 408164 $
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

using Apache.Ibatis.Common;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
#endregion

namespace Apache.Ibatis.DataMapper.Configuration.Sql.Dynamic
{
	/// <summary>
	/// Summary description for SqlText.
	/// </summary>
	public sealed class SqlText : ISqlChild 	
	{

		#region Fields

		private string _text = string.Empty;
		private bool _isWhiteSpace = false;
		private ParameterProperty[] _parameters = null;

		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public string Text 
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				_isWhiteSpace = (_text.Trim().Length == 0);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsWhiteSpace 
		{
			get
			{
				return _isWhiteSpace;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ParameterProperty[] Parameters 
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters = value;
			}
		}
		#endregion

	}
}
