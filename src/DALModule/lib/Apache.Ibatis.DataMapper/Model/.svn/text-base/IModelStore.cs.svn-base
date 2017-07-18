
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
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

using Apache.Ibatis.DataMapper.Data;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.Model
{
    /// <summary>
    /// Holds all the iBATIS core model (statement, alias, resultMap, parameterMap, dataSource).
    /// Used by the <see cref="IMapperFactory"/> to build Mapper.
    /// </summary>
    public interface IModelStore
    {
        /// <summary>
        /// Name used to identify the <see cref="IModelStore"/>
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets the data mapper.
        /// </summary>
        /// <value>The data mapper.</value>
        IDataMapper DataMapper { set; get;  }

        ///// <summary>
        ///// Gets or sets the data source.
        ///// </summary>
        ///// <value>The data source.</value>
        //IDataSource DataSource { set; get;  }

        /// <summary>
        /// Gets or sets the data exchange factory.
        /// </summary>
        /// <value>The data exchange factory.</value>
        DataExchangeFactory DataExchangeFactory { set; get; }

        /// <summary>
        /// Gets or sets the session store.
        /// </summary>
        /// <value>The session store.</value>
        ISessionStore SessionStore { set; get;  }

        /// <summary>
        /// Gets the DB helper parameter cache.
        /// </summary>
        /// <value>The DB helper parameter cache.</value>
        DBHelperParameterCache DBHelperParameterCache { get; }

        /// <summary>
        /// Gets the session factory.
        /// </summary>
        /// <value>The session factory.</value>
        ISessionFactory SessionFactory { set; get;  }

        /// <summary>
        /// Get a ParameterMap by name
        /// </summary>
        /// <param name="name">The name of the ParameterMap</param>
        /// <returns>The ParameterMap</returns>
        ParameterMap GetParameterMap(string name);

        /// <summary>
        /// Adds a (named) ParameterMap.
        /// </summary>
        /// <param name="parameterMap">the ParameterMap to add</param>
        void AddParameterMap(ParameterMap parameterMap);

        /// <summary>
        /// Gets a ResultMap by name
        /// </summary>
        /// <param name="name">The name of the result map</param>
        /// <returns>The ResultMap</returns>
        IResultMap GetResultMap(string name);

        /// <summary>
        /// Adds a (named) ResultMap
        /// </summary>
        /// <param name="resultMap">The ResultMap to add</param>
        void AddResultMap(IResultMap resultMap);

        /// <summary>
        /// Adds a (named) MappedStatement.
        /// </summary>
        /// <param name="mappedStatement">The statement to add</param>
        void AddMappedStatement(IMappedStatement mappedStatement);

        /// <summary>
        /// Gets a MappedStatement by id
        /// </summary>
        /// <param name="id"> The id of the statement</param>
        /// <returns> The MappedStatement</returns>
        IMappedStatement GetMappedStatement(string id);

        /// <summary>
        /// Adds a (named) cache model.
        /// </summary>
        /// <param name="cacheModel">The cache model.</param>
        void AddCacheModel(CacheModel cacheModel);

        /// <summary>
        /// Gets a cache model by id
        /// </summary>
        /// <param name="id">The id of the cache model</param>
        /// <returns>The cache model</returns>
        CacheModel GetCacheModel(string id);

        /// <summary>
        /// Flushes the caches.
        /// </summary>
        void FlushCaches();
        
    }
}
