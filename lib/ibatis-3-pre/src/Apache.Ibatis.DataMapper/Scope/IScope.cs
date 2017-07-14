using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.TypeHandlers;

#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
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

namespace Apache.Ibatis.DataMapper.Scope
{
	/// <summary>
	/// 
	/// </summary>
	public interface IScope
	{

		/// <summary>
		///  Get the error context
		/// </summary>
		ErrorContext ErrorContext { get; }

		/// <summary>
		/// The factory for DataExchange objects
		/// </summary>
		DataExchangeFactory DataExchangeFactory { get; }
	}
}