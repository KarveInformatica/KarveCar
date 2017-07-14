#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
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

using Apache.Ibatis.Common.Configuration;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Represents a set of mapping code configuration and related functionality
    /// packaged together.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Build <see cref="IConfiguration"/> element.
        /// </summary>
        /// <param name="engine">The engine.</param>
        void Configure(IConfigurationEngine engine);

        /// <summary>
        /// Add code configuration mapping to the <see cref="IConfigurationEngine"/>.
        /// </summary>
        void Load();

    }
}
