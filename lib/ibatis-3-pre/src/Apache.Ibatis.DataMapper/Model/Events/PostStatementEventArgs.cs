#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2009-06-28 01:03:34 -0600 (Sun, 28 Jun 2009) $
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

namespace Apache.Ibatis.DataMapper.Model.Events
{
    /// <summary>
    /// Base class for post <see cref="BaseStatementEventArgs"/>
    /// </summary>
    public class PostStatementEventArgs : BaseStatementEventArgs
    {
        /// <summary>
        /// Gets or sets the result object.
        /// </summary>
        /// <value>The result object.</value>
        public object ResultObject { get; set; }

        /// <summary>
        /// Was the ResultObject populated from cache?
        /// </summary>
        public bool CacheHit { get; set; }
    }
}
