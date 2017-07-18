
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
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

using Apache.Ibatis.DataMapper.Configuration;

namespace Apache.Ibatis.DataMapper.Model
{
    /// <summary>
    /// The contract used by the <see cref="IConfigurationEngine"/> to build
    /// all the iBATIS core model (statement, alias, resultMap, parameterMap, dataSource)
    /// from an <see cref="IConfigurationStore"/> 
    /// </summary>
    public interface IModelBuilder
    {

        /// <summary>
        /// Builds the the iBATIS core model (statement, alias, resultMap, parameterMap, dataSource)
        /// from an <see cref="IConfigurationStore"/> and store all the refrences in an <see cref="IModelStore"/> .
        /// </summary>
        /// <param name="configurationSetting">The configuration setting.</param>
        /// <param name="store">The configurationS store.</param>
        /// <returns>The model store</returns>
        void BuildModel(ConfigurationSetting configurationSetting, IConfigurationStore store); 
    }
}
