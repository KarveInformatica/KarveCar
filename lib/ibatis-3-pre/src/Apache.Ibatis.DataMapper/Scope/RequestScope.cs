
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 476843 $
 * $Date: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

using System.Data;
using System.Runtime.CompilerServices;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Session;
using System.Collections.Generic;

#endregion

namespace Apache.Ibatis.DataMapper.Scope
{
    /// <summary>
    /// Hold data during the process of a mapped statement.
    /// </summary>
    public class RequestScope : IScope
    {
        #region Fields

        private readonly IStatement statement = null;
        private readonly ErrorContext errorContext = null;
        private ParameterMap parameterMap = null;
        private PreparedStatement preparedStatement = null;
        private IDbCommand command = null;
        private Queue<PostBindind> selects = new Queue<PostBindind>();
        private bool rowDataFound = false;
        private static long nextId = 0;
        private readonly long id = 0;
        private readonly DataExchangeFactory dataExchangeFactory = null;
        private readonly ISession session = null;
        private IMappedStatement mappedStatement = null;
        private int currentResultMapIndex = -1;
        // Used by N+1 Select solution
        // Holds [IResultMap, IDictionary] couple where the IDictionary holds [string key,object result]
        private IDictionary<IResultMap, IDictionary<string,object>> uniqueKeys = null;
        // Holds [IResultMap, IDictionary] couple where the IDictionary holds [string key,object result] 
        // to resolve circular reference
        private IDictionary<IResultMap, IDictionary<string, object>> cirularKeys = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the circular keys.
        /// </summary>
        /// <param name="map">The ResultMap.</param>
        /// <returns>
        /// Returns [string key, object result] which holds the result objects that have
        /// already been build during this request with this <see cref="IResultMap"/>
        /// </returns>
        public IDictionary<string, object> GetCirularKeys(IResultMap map)
        {
            if (cirularKeys == null)
            {
                return null;
            }
            IDictionary<string, object> keys = null;
            cirularKeys.TryGetValue(map, out keys);
            return keys;
        }

        /// <summary>
        /// Sets the cirular keys.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="keys">The keys.</param>
        public void SetCirularKeys(IResultMap map, IDictionary<string, object> keys)
        {
            if (cirularKeys == null)
            {
                cirularKeys = new Dictionary<IResultMap, IDictionary<string, object>>();
            }
            cirularKeys.Add(map, keys);
        }

        /// <summary>
        /// Gets the unique keys, used to resolve groupBy
        /// </summary>
        /// <param name="map">The ResultMap.</param>
        /// <returns>
        /// Returns [string key, object result] which holds the result objects that have  
        /// already been build during this request with this <see cref="IResultMap"/>
        /// </returns>
        public IDictionary<string, object> GetUniqueKeys(IResultMap map)
        {
            if (uniqueKeys == null)
            {
                return null;
            }
            IDictionary<string, object> keys = null;
            uniqueKeys.TryGetValue(map, out keys);
            return keys;
        }

        /// <summary>
        /// Sets the unique keys.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="keys">The keys.</param>
        public void SetUniqueKeys(IResultMap map, IDictionary<string, object> keys)
        {
            if (uniqueKeys == null)
            {
                uniqueKeys = new Dictionary<IResultMap, IDictionary<string, object>>();
            }
            uniqueKeys.Add(map, keys);
        }
        
        /// <summary>
        ///  The current <see cref="IMappedStatement"/>.
        /// </summary>
        public IMappedStatement MappedStatement
        {
            set { mappedStatement = value; }
            get { return mappedStatement; }
        }

        /// <summary>
        /// Gets the current <see cref="IStatement"/>.
        /// </summary>
        /// <value>The statement.</value>
        public IStatement Statement
        {
            get { return statement; }
        }

        /// <summary>
        ///  The current <see cref="ISession"/>.
        /// </summary>
        public ISession Session
        {
            get { return session; }
        }

        /// <summary>
        ///  The <see cref="IDbCommand"/> to execute
        /// </summary>
        public IDbCommand IDbCommand
        {
            set { command = value; }
            get { return command; }
        }

        /// <summary>
        ///  Indicate if the statement have find data
        /// </summary>
        public bool IsRowDataFound
        {
            set { rowDataFound = value; }
            get { return rowDataFound; }
        }

        /// <summary>
        /// The 'select' result property to process after having process the main properties.
        /// </summary>
        public Queue<PostBindind> DelayedLoad
        {
            get { return selects; }
            set { selects = value; }
        }

        /// <summary>
        /// The current <see cref="IResultMap"/> used by this request.
        /// </summary>
        public IResultMap CurrentResultMap
        {
            get { return statement.ResultsMap[currentResultMapIndex]; }
        }

        /// <summary>
        /// Moves to the next result map.
        /// </summary>
        /// <returns></returns>
        public bool MoveNextResultMap()
        {
            if (currentResultMapIndex < statement.ResultsMap.Count - 1)
            {
                currentResultMapIndex++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// The <see cref="ParameterMap"/> used by this request.
        /// </summary>
        public ParameterMap ParameterMap
        {
            set { parameterMap = value; }
            get { return parameterMap; }
        }

        /// <summary>
        /// The <see cref="PreparedStatement"/> used by this request.
        /// </summary>
        public PreparedStatement PreparedStatement
        {
            get { return preparedStatement; }
            set { preparedStatement = value; }
        }


        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="RequestScope"/> class.
        /// </summary>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="session">The session.</param>
        /// <param name="statement">The statement</param>
        public RequestScope(
            DataExchangeFactory dataExchangeFactory,
            ISession session,
            IStatement statement
            )
        {
            errorContext = new ErrorContext();

            this.statement = statement;
            parameterMap = statement.ParameterMap;
            this.session = session;
            this.dataExchangeFactory = dataExchangeFactory;
            id = GetNextId();
        }
        #endregion

        #region Method

        /// <summary>
        /// Check if the specify object is equal to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj) { return true; }
            if (!(obj is RequestScope)) { return false; }

            RequestScope scope = (RequestScope)obj;

            if (id != scope.id) return false;

            return true;
        }

        /// <summary>
        /// Get the HashCode for this RequestScope
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)(id ^ (id >> 32));
        }

        /// <summary>
        /// Method to get a unique ID
        /// </summary>
        /// <returns>The new ID</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static long GetNextId()
        {
            return nextId++;
        }
        #endregion

        #region IScope Members

        /// <summary>
        /// A factory for DataExchange objects
        /// </summary>
        public DataExchangeFactory DataExchangeFactory
        {
            get { return dataExchangeFactory; }
        }

        /// <summary>
        ///  Get the request's error context
        /// </summary>
        public ErrorContext ErrorContext
        {
            get { return errorContext; }
        }
        #endregion
    }
}
