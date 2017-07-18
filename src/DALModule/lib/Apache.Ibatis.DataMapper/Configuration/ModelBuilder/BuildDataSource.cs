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

using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Data;

namespace Apache.Ibatis.DataMapper.Configuration
{
    public partial class DefaultModelBuilder
    {

        /// <summary>
        /// Builds the data source model.
        /// </summary>
        /// <param name="store">The store.</param>
        private void BuildDataSource(IConfigurationStore store)
        {
            if (dataSource == null)
            {
                IConfiguration dataBaseConfig = store.Databases[0];

                IConfiguration providerConfig = dataBaseConfig.Children.Find(DataConstants.ELEMENT_PROVIDER)[0];
                string key = providerConfig.Value ?? providerConfig.GetAttributeValue(DataConstants.ATTRIBUTE_NAME);
                IDbProvider dbProvider = dbProviderFactory.GetDbProvider(key);

                dataSource = DataSourceDeSerializer.Deserialize(dbProvider, commandTimeOut, dataBaseConfig);
            }


        }
    }
}
