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

using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Model.Statements;

#endregion 


namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
    /// <summary>
    /// Deserializes a selectKey element
    /// </summary>
    public sealed class SelectKeyDeSerializer : BaseStatementDeSerializer
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

            string propertyName = ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_PROPERTY);
            SelectKeyType selectKeyType = ReadSelectKeyType(ConfigurationUtils.GetMandatoryStringAttribute(config, ConfigConstants.ATTRIBUTE_TYPE));

            return  new SelectKey(
                config.Parent.Id + ConfigConstants.DOT + "SelectKey",
                propertyName,
                resultClass,
                resultsMap,
                selectKeyType,
                sqlSource,
                preserveWhitespace);
        }

        private SelectKeyType ReadSelectKeyType(string s)
        {
            switch (s)
            {
                case @"pre": return SelectKeyType.@pre;
                case @"post": return SelectKeyType.@post;
                default: throw new ConfigurationException("Unknown selectKey type : '" + s + "'");
            }
        }
    }
}
