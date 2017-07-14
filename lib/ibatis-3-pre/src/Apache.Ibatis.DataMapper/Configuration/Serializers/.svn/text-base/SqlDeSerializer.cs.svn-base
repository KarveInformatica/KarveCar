#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 469233 $
 * $Date: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
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

using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Xml;

using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.Model.Alias;

#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
    /// <summary>
    /// Summary description for ArgumentPropertyDeSerializer.
    /// </summary>
    public sealed class SqlDeSerializer
    {

        /// <summary>
        /// Deserialize the specified config to a TypeAlias object
        /// </summary>
        /// <param name="config">The config.</param>
        /// <returns></returns>
        public static TypeAlias Deserialize(IConfiguration config)
        {
            //configScope.ErrorContext.MoreInfo = "loading type alias";

            string id = config.Id;
            string className = config.Value;

            //configScope.ErrorContext.ObjectId = typeAlias.ClassName;
            //configScope.ErrorContext.MoreInfo = "initialize type alias";

            return new TypeAlias(id, className);
        }

        ///// <summary>
        ///// Deserialize a sql tag
        ///// </summary>
        ///// <param name="node"></param>
        ///// <param name="configScope"></param>
        ///// <returns></returns>
        //public static void Deserialize(XmlNode node, ConfigurationScope configScope)
        //{
        //    NameValueCollection prop = NodeUtils.ParseAttributes(node, configScope.Properties);

        //    string id = NodeUtils.GetStringAttribute(prop, "id");

        //    if (configScope.UseStatementNamespaces)
        //    {
        //        id = configScope.ApplyNamespace(id);
        //    }
        //    if (configScope.SqlIncludes.Contains(id))
        //    {
        //        throw new ConfigurationException("Duplicate <sql>-include '" + id + "' found.");
        //    }
        //    else
        //    {
        //        configScope.SqlIncludes.Add(id, node);
        //    }
        //}
    }
}
