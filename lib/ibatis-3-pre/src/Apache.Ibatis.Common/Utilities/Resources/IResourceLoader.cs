#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
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

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// Return an <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle for the
    /// specified resource.
    /// </summary>
    public interface IResourceLoader
    {
        /// <summary>
        /// Check if this loader accepts the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>True or false</returns>
        bool Accept(Uri uri);

        /// <summary>
        /// Return an <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle for the
        /// specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>
        /// An appropriate <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle.
        /// </returns>
        IResource Create(Uri uri);
    }
}
