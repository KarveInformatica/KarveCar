
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 474141 $
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

namespace Apache.Ibatis.Common.Logging
{
    /// <summary>
    /// The logging levels used by Log are (in order): 
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 
        /// </summary>
        All = 0,
         /// <summary>
        ///
        /// </summary>
        Trace = 1,       
        /// <summary>
        /// 
        /// </summary>
        Debug = 2,
        /// <summary>
        /// 
        /// </summary>
        Info = 3,
        /// <summary>
        /// 
        /// </summary>
        Warn = 4,
        /// <summary>
        /// 
        /// </summary>
        Error = 5,
        /// <summary>
        ///
        /// </summary>
        Fatal = 6,
        /// <summary>
        /// Do not log anything.
        /// </summary>
        Off = 7
    }
}
