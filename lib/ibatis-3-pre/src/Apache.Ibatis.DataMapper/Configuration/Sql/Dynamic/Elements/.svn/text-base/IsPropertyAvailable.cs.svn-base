
#region Apache Notice
/*****************************************************************************
 * $Revision: 408164 $
 * $LastChangedDate: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2006/2005 - The Apache Software Foundation
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
using System.Xml.Serialization;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.Configuration.Sql.Dynamic.Handlers;

namespace Apache.Ibatis.DataMapper.Configuration.Sql.Dynamic.Elements
{
	/// <summary>
	/// Represent an isPropertyAvailable sql tag element.
	/// </summary>
	[Serializable]
	[XmlRoot("isPropertyAvailable", Namespace="http://ibatis.apache.org/mapping")]
	public sealed class IsPropertyAvailable : BaseTag
	{

        /// <summary>
        /// Initializes a new instance of the <see cref="IsPropertyAvailable"/> class.
        /// </summary>
        /// <param name="accessorFactory">The accessor factory.</param>
        public IsPropertyAvailable(AccessorFactory accessorFactory)
		{
            this.Handler = new IsPropertyAvailableTagHandler(accessorFactory);
		}
	}
}
