#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Data;

namespace Apache.Ibatis.DataMapper.Configuration
{
    /// <summary>
	/// This implementation of <see cref="IConfigurationStore"/>
	/// </summary>
	[Serializable]
    [DebuggerDisplay("DefaultConfigurationStore")]
    public class DefaultConfigurationStore : IConfigurationStore
    {
        #region private fieds
        private readonly Dictionary<string, IConfiguration> properties = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> settings = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> providers = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> databases = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> typeHandlers = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> alias = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> caches = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> resultMaps = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> statements = new Dictionary<string, IConfiguration>();
        private readonly Dictionary<string, IConfiguration> parameterMaps = new Dictionary<string, IConfiguration>();

        private readonly List<IConfiguration> propertyList = new List<IConfiguration>();
        private readonly ConfigurationCollection settingList = new ConfigurationCollection();
        private readonly List<IConfiguration> providerList = new List<IConfiguration>();
        private readonly List<IConfiguration> databaseList = new List<IConfiguration>();
        private readonly List<IConfiguration> typeHandlerList = new List<IConfiguration>();
        private readonly List<IConfiguration> aliasList = new List<IConfiguration>();
        private readonly List<IConfiguration> sqlMappingList = new List<IConfiguration>();
        private readonly List<IConfiguration> cacheList = new List<IConfiguration>();
        private readonly List<IConfiguration> resultMapList = new List<IConfiguration>();
        private readonly List<IConfiguration> statementList = new List<IConfiguration>();
        private readonly List<IConfiguration> parameterMapList = new List<IConfiguration>();
        #endregion

        #region IConfigurationStore Members

        /// <summary>
        /// Associates a configuration node with a property key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddPropertyConfiguration(IConfiguration config)
        {
            AddToList(config, properties, propertyList);
            properties[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a Setting key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddSettingConfiguration(IConfiguration config)
        {
            AddToList(config, settings, settingList);
            settings[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a Provider key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]        
        public void AddProviderConfiguration(IConfiguration config)
        {
            AddToList(config, providers, providerList);
            providers[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a Database key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddDatabaseConfiguration(IConfiguration config)
        {
            AddToList(config, databases, databaseList);
            databases[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a TypeHandler key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddTypeHandlerConfiguration(IConfiguration config)
        {
            AddToList(config, typeHandlers, typeHandlerList);
            typeHandlers[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a Alias key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddAliasConfiguration(IConfiguration config)
        {
            AddToList(config, alias, aliasList);
            alias[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a Cache key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddCacheConfiguration(IConfiguration config)
        {
            AddToList(config, caches, cacheList);
            caches[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a ResultMap key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddResultMapConfiguration(IConfiguration config)
        {
            AddToList(config, resultMaps, resultMapList);
            resultMaps[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a Statement key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddStatementConfiguration(IConfiguration config)
        {
            AddToList(config, statements, statementList);
            statements[config.Id] = config;
        }

        /// <summary>
        /// Associates a configuration node with a ParameterMap key
        /// </summary>
        /// <param name="config">Configuration node</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddParameterMapConfiguration(IConfiguration config)
        {
            AddToList(config, parameterMaps, parameterMapList);
            parameterMaps[config.Id] = config;
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified setting key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetPropertyConfiguration(string key)
        {
            return GetConfiguration(properties, key);
        }

        /// <summary>
        /// Returns all configuration nodes for property
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] Properties
        {
            get { return propertyList.ToArray(); }
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified setting key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetSettingConfiguration(string key)
        {
            return GetConfiguration(settings, key);
        }

        /// <summary>
        /// Returns all configuration nodes for setting
        /// </summary>
        /// <returns></returns>
        public ConfigurationCollection Settings
        {
           get { return settingList; }
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified <see cref="DbProvider"/> key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetProviderConfiguration(string key)
        {
            return GetConfiguration(providers, key);
        }

        /// <summary>
        /// Returns all configuration nodes for <see cref="IDbProvider"/>
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] Providers
        {
            get { return providerList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified Database key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetDatabaseConfiguration(string key)
        {
            return GetConfiguration(databases, key);
        }

        /// <summary>
        /// Returns all configuration nodes for Database
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] Databases
        {
            get { return databaseList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified TypeHandler key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetTypeHandlerConfiguration(string key)
        {
            return GetConfiguration(typeHandlers, key);
        }

        /// <summary>
        /// Returns all configuration nodes for TypeHandler
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] TypeHandlers
        {
            get { return typeHandlerList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified Alias key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetAliasConfiguration(string key)
        {
            return GetConfiguration(alias, key);
        }

        /// <summary>
        /// Returns all configuration nodes for Alias
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] Alias
        {
            get { return aliasList.ToArray();}
        }


        /// <summary>
        /// Returns all configuration nodes for SqlMapping
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] SqlMappings
        {
            get { return sqlMappingList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified Cache key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetCacheConfiguration(string key)
        {
            return GetConfiguration(caches, key);
        }

        /// <summary>
        /// Returns all configuration nodes for Cache
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] CacheModels
        {
            get { return cacheList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified ResultMap key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetResultMapConfiguration(string key)
        {
            return GetConfiguration(resultMaps, key); 
        }

        /// <summary>
        /// Returns all configuration nodes for ResultMap
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] ResultMaps
        {
            get { return resultMapList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified Statement key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetStatementConfiguration(string key)
        {
            return GetConfiguration(statements, key);
        }

        /// <summary>
        /// Returns all configuration nodes for Statement
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] Statements
        {
            get { return statementList.ToArray();}
        }

        /// <summary>
        /// Returns the configuration node associated with
        /// the specified ParameterMap key. Should return null
        /// if no association exists.
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public IConfiguration GetParameterMapConfiguration(string key)
        {
            return GetConfiguration(parameterMaps, key);
        }

        /// <summary>
        /// Returns all configuration nodes for ParameterMap
        /// </summary>
        /// <returns></returns>
        public IConfiguration[] ParameterMaps
        {
            get { return parameterMapList.ToArray(); }
        }

        #endregion

        private IConfiguration GetConfiguration(Dictionary<string, IConfiguration> map, string key)
        {
            IConfiguration config = null;
            map.TryGetValue(key, out config);
            return config;
        }

        private void Browse(StringBuilder builder, IConfiguration[] tab, int level)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                builder.AppendLine(string.Empty.PadLeft(level * 4, ' ') + tab[i].Type + "/" + tab[i].Id);

            IEnumerator<KeyValuePair<string, string>> attributes = tab[i].Attributes.GetEnumerator();
            while (attributes.MoveNext())
            {
                builder.AppendLine(string.Empty.PadLeft((level + 1) * 4, ' ') + attributes.Current.Key + "/" + attributes.Current.Value);
             }
             Browse(builder, tab[i].Children.ToArray(), level + 1);
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Databases:");
            Browse(builder, Databases, 1);
            builder.AppendLine(string.Empty);

            builder.AppendLine("Alias:");
            Browse(builder, Alias, 1);
            builder.AppendLine(string.Empty);

            builder.AppendLine("TypeHandlers:");
            Browse(builder, TypeHandlers, 1);
            builder.AppendLine(string.Empty);

            builder.AppendLine("CacheModel:");
            Browse(builder, CacheModels, 1);
            builder.AppendLine(string.Empty);

            builder.AppendLine("ResultMaps:");
            Browse(builder, ResultMaps, 1);
            builder.AppendLine(string.Empty);

            builder.AppendLine("Statements:");
            Browse(builder, Statements, 1);
            builder.AppendLine(string.Empty);

            builder.AppendLine("ParameterMaps:");
            Browse(builder, ParameterMaps, 1);
            builder.AppendLine(string.Empty);

            return builder.ToString();
        }

        /// <summary>
        /// Adds to list, remove the <see cref="IConfigurationStore"/> element 
        /// if it is already register under the same id in the dictionary.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="list">The list.</param>
        private void AddToList(IConfiguration config, IDictionary<string, IConfiguration> dictionary, List<IConfiguration> list)
        {
            if (dictionary.ContainsKey(config.Id))
            {
                IConfiguration configuration = list.Find(delegate(IConfiguration item)
                                   {
                                       return (item.Id == config.Id);
                                   });
                list.Remove(configuration);
            }
            list.Add(config);
        }
    }
}
