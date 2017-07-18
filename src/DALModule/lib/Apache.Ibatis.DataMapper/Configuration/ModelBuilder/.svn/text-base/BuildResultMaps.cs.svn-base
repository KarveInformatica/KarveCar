#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
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

using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Serializers;
using Apache.Ibatis.DataMapper.Model.ResultMapping;

namespace Apache.Ibatis.DataMapper.Configuration
{
    public partial class DefaultModelBuilder
    {
        /// <summary>
        /// Builds the result maps.
        /// </summary>
        /// <param name="store">The store.</param>
        private void BuildResultMaps(IConfigurationStore store)
        {
            for (int i = 0; i < store.ResultMaps.Length; i++)
            {
                ResultMap resultMap = ResultMapDeSerializer.Deserialize(
                    store.ResultMaps[i],
                    modelStore.DataExchangeFactory,
                    waitResultPropertyResolution,
                    waitDiscriminatorResolution);

                modelStore.AddResultMap(resultMap);
            }
        }
    }
}
