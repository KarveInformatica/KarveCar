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

using System;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Serializers;
using Apache.Ibatis.DataMapper.TypeHandlers;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.DataMapper.Model.Alias;


namespace Apache.Ibatis.DataMapper.Configuration
{
    public partial class DefaultModelBuilder
    {
        /// <summary>
        /// Builds the type handlers.
        /// </summary>
        /// <param name="store">The store.</param>
        private void BuildTypeHandlers(IConfigurationStore store)
        {
            for (int i = 0; i < store.TypeHandlers.Length ; i++)
            {
                IConfiguration handlerConfig = store.TypeHandlers[i];
                try
                {
                    //_configScope.ErrorContext.Activity = "loading typeHandler";
                    TypeHandler handler = TypeHandlerDeSerializer.Deserialize(handlerConfig);

                    //configScope.ErrorContext.MoreInfo = "Check the callback attribute '" + handler.CallBackName + "' (must be a classname).";
                    ITypeHandler typeHandler = null;
                    Type type = modelStore.DataExchangeFactory.TypeHandlerFactory.GetType(handler.Callback);
                    
                    object impl = Activator.CreateInstance(type);
                    if (impl is ITypeHandlerCallback)
                    {
                        typeHandler = new CustomTypeHandler((ITypeHandlerCallback)impl);
                    }
                    else if (impl is ITypeHandler)
                    {
                        typeHandler = (ITypeHandler)impl;
                    }
                    else
                    {
                        throw new ConfigurationException("The callBack type is not a valid implementation of ITypeHandler or ITypeHandlerCallback");
                    }                
                
                    //configScope.ErrorContext.MoreInfo = "Check the type attribute '" + handler.ClassName + "' (must be a class name) or the dbType '" + handler.DbType + "' (must be a DbType type name).";
                    if (handler.DbType != null && handler.DbType.Length > 0)
                    {
                        modelStore.DataExchangeFactory.TypeHandlerFactory.Register(handler.Type, handler.DbType, typeHandler);
                    }
                    else
                    {
                        modelStore.DataExchangeFactory.TypeHandlerFactory.Register(handler.Type, typeHandler);
                    }                
                
                }
                catch (Exception e)
                {
                    throw new ConfigurationException(
                        String.Format("Error registering TypeHandler class \"{0}\" for handling .Net type \"{1}\" and dbType \"{2}\". Cause: {3}",
                        handlerConfig.GetAttributeValue("callback"),
                        handlerConfig.GetAttributeValue("type"),
                        handlerConfig.GetAttributeValue("dbType"),
                        e.Message), e);
                }
            }
        }
        
    }
}
