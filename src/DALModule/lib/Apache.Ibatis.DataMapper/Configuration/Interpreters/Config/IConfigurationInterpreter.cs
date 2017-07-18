#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-06-28 11:17:59 -0600 (Sat, 28 Jun 2008) $
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
using Apache.Ibatis.Common.Resources;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config
{
    /// <summary>
    /// <see cref="IConfigurationInterpreter"/> is reponsible for translating the DataMapper configuration 
    /// from what is being read to what the IConfigurationEngine expects
    /// </summary>
    public interface IConfigurationInterpreter
    {

        /// <summary>
        /// Exposes the reference to <see cref="IResource"/>
        /// which the interpreter is likely to hold
        /// </summary>
        IResource Resource { get; }

        /// <summary>
        /// Should obtain the contents from the resource,
        /// interpret it and populate the <see cref="IConfigurationStore"/>
        /// accordingly.
        /// </summary>
        /// <param name="store">The store.</param>
        void ProcessResource(IConfigurationStore store);
    }

}
