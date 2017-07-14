#region Apache Notice
/*****************************************************************************
 * $Revision: 512878 $
 * $LastChangedDate: 2009-06-13 21:53:23 -0400 (Sat, 13 Jun 2009) $
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
using Apache.Ibatis.Common.Configuration;
#endregion 

namespace Apache.Ibatis.Common.Data
{
    public sealed class ProviderSerializer
    {
        /// <summary>
        /// Serializes the specified <see cref="IDbProvider"/> into an <see cred="IConfiguration" /> node.
        /// </summary>
        public static IConfiguration Serialize(IDbProvider dbProvider)
        {
            IConfiguration providerConfig = new MutableConfiguration("provider", dbProvider.Id, dbProvider.Id);
            providerConfig.Attributes[DataConstants.ATTRIBUTE_NAME] = dbProvider.Id;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_ASSEMBLYNAME] = dbProvider.AssemblyName;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_COMMANDBUILDERCLASS] = dbProvider.CommandBuilderClass;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_COMMANDCLASS] = dbProvider.DbCommandClass;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_CONNECTIONCLASS] = dbProvider.DbConnectionClass;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_DESCRIPTION] = dbProvider.Description;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_DEFAULT] = dbProvider.IsDefault.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_ENABLED] = dbProvider.IsEnabled.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_PARAMETERDBTYPECLASS] = dbProvider.ParameterDbTypeClass;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_PARAMETERDBTYPEPROPERTY] = dbProvider.ParameterDbTypeProperty;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_PARAMETERPREFIX] = dbProvider.ParameterPrefix;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_PARAMETERPREFIX] = dbProvider.ParameterPrefix;
            providerConfig.Attributes[DataConstants.ATTRIBUTE_SETDBPARAMETERPRECISION] = dbProvider.SetDbParameterPrecision.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_SETDBPARAMETERSCALE] = dbProvider.SetDbParameterScale.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_SETDBPARAMETERSIZE] = dbProvider.SetDbParameterSize.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_USEDERIVEPARAMETERS] = dbProvider.UseDeriveParameters.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_USEPARAMETERPREFIXINPARAMETER] = dbProvider.UseParameterPrefixInParameter.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_USEPARAMETERPREFIXINSQL] = dbProvider.UseParameterPrefixInSql.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_USEPOSITIONALPARAMETERS] = dbProvider.UsePositionalParameters.ToString().ToLower();
            providerConfig.Attributes[DataConstants.ATTRIBUTE_ALLOWMARS] = dbProvider.AllowMARS.ToString().ToLower();
            return providerConfig;
        }
    }
}
