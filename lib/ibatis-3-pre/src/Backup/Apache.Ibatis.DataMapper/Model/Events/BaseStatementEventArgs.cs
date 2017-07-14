#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-06-08 20:20:44 +0200 (dim., 08 juin 2008) $
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

using System;

namespace Apache.Ibatis.DataMapper.Model.Events
{
    /// <summary>
    /// Base class for event statement
    /// </summary>
    public abstract class BaseStatementEventArgs : EventArgs
    {
        #region ISatementEvent Members

        /// <summary>
        /// Gets or sets the parameter object.
        /// </summary>
        /// <value>The parameter object.</value>
        public object ParameterObject { get; set; }

        #endregion
    }
}
