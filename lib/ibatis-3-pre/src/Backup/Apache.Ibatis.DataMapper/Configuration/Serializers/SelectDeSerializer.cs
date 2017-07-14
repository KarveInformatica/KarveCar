#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 469233 $
 * $Date: 2009-06-28 10:11:37 -0600 (Sun, 28 Jun 2009) $
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
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.Common.Configuration;

#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for SelectDeSerializer.
	/// </summary>
    public sealed class SelectDeSerializer : BaseStatementDeSerializer
	{
        /// <summary>
        /// Deserializes the specified configuration in a <see cref="Select"/> object.
        /// </summary>
        /// <param name="modelStore">The model store.</param>
        /// <param name="config">The config.</param>
        /// <param name="configurationSetting"></param>
        /// <returns></returns>
        public override IStatement Deserialize(IModelStore modelStore, IConfiguration config, ConfigurationSetting configurationSetting)
        {
            BaseDeserialize(modelStore, config, configurationSetting);

            return new Select(
                id,
                parameterClass,
                parameterMap,
                resultClass,
                resultsMap,
                listClass,
                listClassFactory,
                cacheModel,
                remapResults,
                extendsName,
                sqlSource,
                preserveWhitespace);

        }

	}
}
