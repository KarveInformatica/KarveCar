#region Apache Notice
/*****************************************************************************
 * $Revision: 512878 $
 * $LastChangedDate: 2009-06-13 19:53:23 -0600 (Sat, 13 Jun 2009) $
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

#region Using

using System.Collections.Specialized;
using System.Xml;
using Apache.Ibatis.Common.Xml;
using Apache.Ibatis.Common.Configuration;
#endregion 

namespace Apache.Ibatis.Common.Data
{

    public sealed class ProviderDeSerializer
    {

        /// <summary>
        /// Deserializes the specified node in a <see cref="IDbProvider"/>.
        /// </summary>
        /// <param name="config">The IConfiguration node.</param>
        /// <returns>The <see cref="IDbProvider"/></returns>
        public static IDbProvider Deserialize(IConfiguration config)
        {
            IDbProvider provider = new DbProvider();

            provider.Id = config.Attributes[DataConstants.ATTRIBUTE_NAME];
            provider.AssemblyName = config.Attributes[DataConstants.ATTRIBUTE_ASSEMBLYNAME];
            provider.CommandBuilderClass = config.Attributes[DataConstants.ATTRIBUTE_COMMANDBUILDERCLASS];
            provider.DbCommandClass = config.Attributes[DataConstants.ATTRIBUTE_COMMANDCLASS];
            provider.DbConnectionClass = config.Attributes[DataConstants.ATTRIBUTE_CONNECTIONCLASS];
            provider.Description = config.Attributes[DataConstants.ATTRIBUTE_DESCRIPTION];
            provider.IsDefault = ConfigurationUtils.GetBooleanAttribute(config.Attributes, "default", false);
            provider.IsEnabled = ConfigurationUtils.GetBooleanAttribute(config.Attributes, "enabled", true);
            provider.ParameterDbTypeClass = config.Attributes[DataConstants.ATTRIBUTE_PARAMETERDBTYPECLASS];
            provider.ParameterDbTypeProperty = config.Attributes[DataConstants.ATTRIBUTE_PARAMETERDBTYPEPROPERTY];
            provider.ParameterPrefix = ConfigurationUtils.GetStringAttribute(config.Attributes, DataConstants.ATTRIBUTE_PARAMETERPREFIX);
            provider.SetDbParameterPrecision = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_SETDBPARAMETERPRECISION, true);
            provider.SetDbParameterScale = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_SETDBPARAMETERSCALE, true);
            provider.SetDbParameterSize = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_SETDBPARAMETERSIZE, true);
            provider.UseDeriveParameters = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_USEDERIVEPARAMETERS, true);
            provider.UseParameterPrefixInParameter = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_USEPARAMETERPREFIXINPARAMETER, true);
            provider.UseParameterPrefixInSql = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_USEPARAMETERPREFIXINSQL, true);
            provider.UsePositionalParameters = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_USEPOSITIONALPARAMETERS, false);
            provider.AllowMARS = ConfigurationUtils.GetBooleanAttribute(config.Attributes, DataConstants.ATTRIBUTE_ALLOWMARS, false);

            return provider;
        }
    }
}
