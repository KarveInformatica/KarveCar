#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-06-08 20:20:44 +0200 (dim., 08 juin 2008) $
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
using System.ComponentModel;
using Apache.Ibatis.DataMapper.Model.Events;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    /// <summary>
    /// Base implementation for <see cref="IMappedStatementEvents"/>
    /// </summary>
    [Serializable]
    public abstract class MappedStatementEventSupport : IMappedStatementEvents
    {
        protected static readonly object PreInsertEventKey = new object();
        protected static readonly object PreSelectEventKey = new object();
        protected static readonly object PreUpdateOrDeleteEventKey = new object();
        protected static readonly object PostInsertEventKey = new object();
        protected static readonly object PostSelectEventKey = new object();
        protected static readonly object PostUpdateOrDeleteEventKey = new object();

        private readonly EventHandlerList events = new EventHandlerList();

        #region IMappedStatementEvents Members

        /// <summary>
        /// Will handle an <see cref="PreStatementEventArgs"/>. 
        /// </summary>
        public event EventHandler<PreStatementEventArgs> PreInsert
        {
            add { events.AddHandler(PreInsertEventKey, value); }
            remove { events.RemoveHandler(PreInsertEventKey, value); }
        }

        /// <summary>
        /// Will handle an <see cref="PreStatementEventArgs"/>. 
        /// </summary>
        public event EventHandler<PreStatementEventArgs> PreSelect
        {
            add { events.AddHandler(PreSelectEventKey, value); }
            remove { events.RemoveHandler(PreSelectEventKey, value); }
        }

        /// <summary>
        /// Will handle an <see cref="PreStatementEventArgs"/>. 
        /// </summary>
        public event EventHandler<PreStatementEventArgs> PreUpdateOrDelete
        {
            add { events.AddHandler(PreUpdateOrDeleteEventKey, value); }
            remove { events.RemoveHandler(PreUpdateOrDeleteEventKey, value); }
        }

        /// <summary>
        /// Will handle an <see cref="PostStatementEventArgs"/>. 
        /// </summary>
        public event EventHandler<PostStatementEventArgs> PostInsert
        {
            add { events.AddHandler(PostInsertEventKey, value); }
            remove { events.RemoveHandler(PostInsertEventKey, value); }
        }

        /// <summary>
        /// Will handle an <see cref="PostStatementEventArgs"/>. 
        /// </summary>
        public event EventHandler<PostStatementEventArgs> PostSelect
        {
            add { events.AddHandler(PostSelectEventKey, value); }
            remove { events.RemoveHandler(PostSelectEventKey, value); }
        }

        /// <summary>
        /// Will handle an <see cref="PostStatementEventArgs"/>. 
        /// </summary>
        public event EventHandler<PostStatementEventArgs> PostUpdateOrDelete
        {
            add { events.AddHandler(PostUpdateOrDeleteEventKey, value); }
            remove { events.RemoveHandler(PostUpdateOrDeleteEventKey, value); }
        }

        #endregion

        /// <summary>
        /// Raises the pre event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns>Returns is used as the parameter object</returns>
        protected object RaisePreEvent(object key,  object parameterObject)
        {
            var handlers = (EventHandler<PreStatementEventArgs>)events[key];

            if (handlers != null)
            {
                var eventArgs = new PreStatementEventArgs();
                eventArgs.ParameterObject = parameterObject;
                handlers(this, eventArgs);            
                return eventArgs.ParameterObject;
            }
            return parameterObject;
        }

        /// <summary>
        /// Raises the post event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <param name="resultObject">The result object.</param>
        /// <param name="cacheHit">Did the ResultObject come from cache?</param>
        /// <returns>Returns is used as the result object</returns>
        protected TType RaisePostEvent<TType>(object key, object parameterObject, TType resultObject, bool cacheHit)
        {
            var handlers = (EventHandler<PostStatementEventArgs>)events[key];

            if (handlers != null)
            {
                var eventArgs = new PostStatementEventArgs();
                eventArgs.ParameterObject = parameterObject;
                eventArgs.ResultObject = resultObject;
                eventArgs.CacheHit = cacheHit;
                handlers(this, eventArgs);
                return (TType)eventArgs.ResultObject;
            }
            return resultObject;
        }
    }
}
