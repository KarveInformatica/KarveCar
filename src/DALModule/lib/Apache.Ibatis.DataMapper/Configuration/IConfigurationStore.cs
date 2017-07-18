
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-09-21 10:29:40 -0600 (Sun, 21 Sep 2008) $
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

using System.Collections.Generic;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Data;

namespace Apache.Ibatis.DataMapper.Configuration
{
    /// <summary>
    /// The contract of the configuration storage
    /// It is used by the <see cref="IConfigurationEngine"/> to build
    /// an <see cref="IMapperFactory"/>.
    /// </summary>
    public interface IConfigurationStore
    {
        #region IDataMapperConfigurationStore

        /// <summary>
        /// Associates a configuration node with a property key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddPropertyConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a Setting key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddSettingConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a Provider key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddProviderConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a Database key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddDatabaseConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a TypeHandler key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddTypeHandlerConfiguration(IConfiguration config); 

        /// <summary>
        /// Associates a configuration node with a Alias key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddAliasConfiguration(IConfiguration config);

        ///// <summary>
        ///// Associates a configuration node with a SqlMap key
        ///// </summary>
        ///// <param name="config">Configuration node</param>
        //void AddSqlMappingConfiguration(IConfiguration config);

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified setting key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetPropertyConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for properties
        /// </summary>
        /// <returns></returns>
        IConfiguration[] Properties { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified setting key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetSettingConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for setting
        /// </summary>
        /// <returns></returns>
        ConfigurationCollection Settings { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified <see cref="IDbProvider"/> key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetProviderConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for <see cref="IDbProvider"/>
        /// </summary>
        /// <returns></returns>
        IConfiguration[] Providers { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified Database key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetDatabaseConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for Database
        /// </summary>
        /// <returns></returns>
        IConfiguration[] Databases { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified TypeHandler key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetTypeHandlerConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for TypeHandler
        /// </summary>
        /// <returns></returns>
        IConfiguration[] TypeHandlers { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified Alias key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetAliasConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for Alias
        /// </summary>
        /// <returns></returns>
        IConfiguration[] Alias { get; }

        #endregion

        #region IMappingConfigurationStore

        /// <summary>
        /// Associates a configuration node with a Cache key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddCacheConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a ResultMap key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddResultMapConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a Statement key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddStatementConfiguration(IConfiguration config);

        /// <summary>
        /// Associates a configuration node with a ParameterMap key
        /// </summary>
        /// <param name="config">Configuration node</param>
        void AddParameterMapConfiguration(IConfiguration config);

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified Cache key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetCacheConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for Cache
        /// </summary>
        /// <returns></returns>
        IConfiguration[] CacheModels { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified ResultMap key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetResultMapConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for ResultMap
        /// </summary>
        /// <returns></returns>
        IConfiguration[] ResultMaps { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified Statement key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetStatementConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for Statement
        /// </summary>
        /// <returns></returns>
        IConfiguration[] Statements { get; }

        /// <summary>
        /// Returns the configuration node associated with 
        /// the specified ParameterMap key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        IConfiguration GetParameterMapConfiguration(string key);

        /// <summary>
        /// Returns all configuration nodes for ParameterMap
        /// </summary>
        /// <returns></returns>
        IConfiguration[] ParameterMaps { get; }

        #endregion
    }
}
