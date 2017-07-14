
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2009-10-10 11:53:18 -0600 (Sat, 10 Oct 2009) $
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

using System;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;


namespace Apache.Ibatis.DataMapper.Configuration
{
    public partial class DefaultModelBuilder
    {

        /// <summary>
        /// Loads the setting.
        /// </summary>
        /// <param name="store">The store.</param>
        private void LoadSetting(IConfigurationStore store)
        {
            if (store.Settings.Count > 0)
            {
                for (int i = 0; i < store.Settings.Count; i++)
                {
                    IConfiguration setting = store.Settings[i];
                    if (setting.Id == ConfigConstants.ATTRIBUTE_USE_STATEMENT_NAMESPACES)
                    {
                        useStatementNamespaces = Convert.ToBoolean(setting.Value);
                    }
                    else if (setting.Id == ConfigConstants.ATTRIBUTE_CACHE_MODELS_ENABLED)
                    {
                        isCacheModelsEnabled = Convert.ToBoolean(setting.Value);
                    }
                    else if (setting.Id == ConfigConstants.ATTRIBUTE_USE_REFLECTION_OPTIMIZER)
                    {
                        useReflectionOptimizer = Convert.ToBoolean(setting.Value);
                    }
                    else if (setting.Id == ConfigConstants.ATTRIBUTE_COMMAND_TIMEOUT)
                    {
                        // not documented well? not a property on ConfigurationSetting ???
                        commandTimeOut = Convert.ToInt32(setting.Value);
                    }
                    else if (setting.Id == ConfigConstants.ATTRIBUTE_PRESERVEWHITSPACE)
                    {
                        preserveWhitespace = Convert.ToBoolean(setting.Value);
                    }
                }
            }
        }

    }
}
