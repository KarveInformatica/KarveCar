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

using System;
using System.Data;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Model.Sql.External;
using Apache.Ibatis.DataMapper.Model.Statements;

#endregion 

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
    /// <summary>
    /// Base class for StatementDeserializer
    /// </summary>
    public abstract class BaseStatementDeSerializer
    {
        protected string id = string.Empty;
        protected string cacheModelName = string.Empty;
        protected string extendsName = string.Empty;
        protected string listClassName = string.Empty;
        protected string parameterClassName = string.Empty;
        protected string parameterMapName = string.Empty;
        protected string resultClassName = string.Empty;
        protected string resultMapName = string.Empty;
        protected bool remapResults = false;
        protected string nameSpace = string.Empty;
        protected string sqlSourceClassName = string.Empty;
        protected bool preserveWhitespace;

        protected ResultMapCollection resultsMap = new ResultMapCollection();
        protected Type resultClass = null;
        protected ParameterMap parameterMap = null;
        protected Type parameterClass = null;
        protected Type listClass = null;
        protected IFactory listClassFactory = null;
        protected CacheModel cacheModel = null;
        protected ISqlSource sqlSource = null;

        /// <summary>
        /// Deserializes the specified configuration in a Statement object.
        /// </summary>
        /// <param name="modelStore"></param>
        /// <param name="config">The config.</param>
        /// <param name="configurationSetting">Default settings.</param>
        /// <returns></returns>
        protected void BaseDeserialize(IModelStore modelStore, IConfiguration config, ConfigurationSetting configurationSetting)
        {
            nameSpace = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_NAMESPACE);
            id = configurationSetting.UseStatementNamespaces ? ApplyNamespace(nameSpace, config.Id) : config.Id;
            cacheModelName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_CACHEMODEL);
            extendsName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_EXTENDS);
            listClassName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_LISTCLASS);
            parameterClassName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_PARAMETERCLASS);
            parameterMapName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_PARAMETERMAP);
            resultClassName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_RESULTCLASS);
            resultMapName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_RESULTMAP);
            remapResults = ConfigurationUtils.GetBooleanAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_REMAPRESULTS, false);
            sqlSourceClassName = ConfigurationUtils.GetStringAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_SQLSOURCE);
            preserveWhitespace = ConfigurationUtils.GetBooleanAttribute(config.Attributes, ConfigConstants.ATTRIBUTE_PRESERVEWHITSPACE, configurationSetting.PreserveWhitespace);

            // Gets the results Map
            if (resultMapName.Length > 0)
            {
                string[] ids = resultMapName.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    string name = ApplyNamespace(nameSpace, ids[i].Trim());
                    resultsMap.Add(modelStore.GetResultMap(name));
                }
            }
            // Gets the results class
            if (resultClassName.Length > 0)
            {
                string[] classNames = resultClassName.Split(',');
                for (int i = 0; i < classNames.Length; i++)
                {
                    resultClass = modelStore.DataExchangeFactory.TypeHandlerFactory.GetType(classNames[i].Trim());
                    IFactory resultClassFactory = null;
                    if (Type.GetTypeCode(resultClass) == TypeCode.Object &&
                        (resultClass.IsValueType == false) && resultClass != typeof(DataRow))
                    {
                        resultClassFactory = modelStore.DataExchangeFactory.ObjectFactory.CreateFactory(resultClass, Type.EmptyTypes);
                    }
                    IDataExchange dataExchange = modelStore.DataExchangeFactory.GetDataExchangeForClass(resultClass);
                    bool isSimpleType = modelStore.DataExchangeFactory.TypeHandlerFactory.IsSimpleType(resultClass);
                    IResultMap autoMap = new AutoResultMap(resultClass, resultClassFactory, dataExchange, isSimpleType);
                    resultsMap.Add(autoMap);
                }
            }

            // Gets the ParameterMap
            if (parameterMapName.Length > 0)
            {
                parameterMap = modelStore.GetParameterMap(parameterMapName);
            }
            // Gets the ParameterClass
            if (parameterClassName.Length > 0)
            {
                parameterClass = modelStore.DataExchangeFactory.TypeHandlerFactory.GetType(parameterClassName);
            }

            // Gets the listClass
            if (listClassName.Length > 0)
            {
                listClass = modelStore.DataExchangeFactory.TypeHandlerFactory.GetType(listClassName);
                listClassFactory = modelStore.DataExchangeFactory.ObjectFactory.CreateFactory(listClass, Type.EmptyTypes);
            }

            // Gets the CacheModel
            if (cacheModelName.Length > 0)
            {
                cacheModel = modelStore.GetCacheModel(cacheModelName);
            }
            // Gets the SqlSource
            if (sqlSourceClassName.Length > 0)
            {
                Type sqlSourceType = modelStore.DataExchangeFactory.TypeHandlerFactory.GetType(sqlSourceClassName);
                IFactory factory = modelStore.DataExchangeFactory.ObjectFactory.CreateFactory(sqlSourceType, Type.EmptyTypes);
                sqlSource = (ISqlSource)factory.CreateInstance(null);
            }
        }

        /// <summary>
        /// Deserializes the specified configuration in a Statement object.
        /// </summary>
        /// <param name="modelStore">The model store.</param>
        /// <param name="config">The config.</param>
        /// <returns></returns>
        public abstract IStatement Deserialize(IModelStore modelStore, IConfiguration config, ConfigurationSetting configurationSetting);

        /// <summary>
        /// Register under Statement Name or Fully Qualified Statement Name
        /// </summary>
        /// <param name="nameSpace">The name space.</param>
        /// <param name="id">An Identity</param>
        /// <returns>The new Identity</returns>
        public string ApplyNamespace(string nameSpace, string id)
        {
            string newId = id;

            if (nameSpace != null && nameSpace.Length > 0
                && id != null && id.Length > 0 && id.IndexOf(".") < 0)
            {
                newId = nameSpace + ConfigConstants.DOT + id;
            }
            return newId;
        }
    }
}
