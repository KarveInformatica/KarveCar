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

using System.Data;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.MappedStatements.PostSelectStrategy
{
	/// <summary>
	/// <see cref="IPostSelectStrategy"/> contract to excute a 'select' <see cref="ResultProperty"/>
	/// after the process of the main <see cref="IDataReader"/>
	/// </summary>
	public interface IPostSelectStrategy
	{

		/// <summary>
		/// Executes the specified <see cref="PostBindind"/>.
		/// </summary>
		/// <param name="postSelect">The <see cref="PostBindind"/>.</param>
		/// <param name="request">The <see cref="RequestScope"/></param>
		void Execute(PostBindind postSelect, RequestScope request);
	}
}
