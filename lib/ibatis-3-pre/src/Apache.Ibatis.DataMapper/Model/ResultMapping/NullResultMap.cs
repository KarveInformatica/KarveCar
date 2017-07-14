#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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
using Apache.Ibatis.DataMapper.DataExchange;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.Model.Events;

namespace Apache.Ibatis.DataMapper.Model.ResultMapping
{
    /// <summary>
    /// Represents a Null ResultMap
    /// </summary>
    public sealed class NullResultMap : IResultMap
    {
 
        #region Fields
        [NonSerialized]
        private readonly List<string> groupByPropertyNames = new List<string>();
        [NonSerialized]
        private readonly ResultPropertyCollection properties = new ResultPropertyCollection();
        [NonSerialized]
        private readonly ArgumentPropertyCollection parameters = new ArgumentPropertyCollection();
        [NonSerialized]
        private readonly ResultPropertyCollection groupByProperties = new ResultPropertyCollection();
        [NonSerialized]
        private readonly List<string> keyPropertyNames = new List<string>();
        [NonSerialized]
        private readonly ResultPropertyCollection keysProperties = new ResultPropertyCollection();

        #endregion

        #region Properties

        /// <summary>
        /// The GroupBy Properties.
        /// </summary>
        public List<string> GroupByPropertyNames
        {
            get { return groupByPropertyNames; }
        }

        /// <summary>
        /// The GroupBy Properties.
        /// </summary>
        public ResultPropertyCollection GroupByProperties
        {
            get { return groupByProperties; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is initalized.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is initalized; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitalized
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// The discriminator used to choose the good Case
        /// </summary>
        public static Discriminator Discriminator
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// The collection of ResultProperty.
        /// </summary>
        public ResultPropertyCollection Properties
        {
            get { return properties; }
        }

        /// <summary>
        /// The collection of constructor parameters.
        /// </summary>
        public ArgumentPropertyCollection Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// Identifier used to identify the resultMap amongst the others.
        /// </summary>
        /// <example>GetProduct</example>
        public string Id
        {
            get { return "NullResultMap.Id"; }
        }

        /// <summary>
        /// Extend ResultMap attribute
        /// </summary>
        public static string ExtendMap
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// The output type class of the resultMap.
        /// </summary>
        public Type Class
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }


        /// <summary>
        /// Sets the IDataExchange
        /// </summary>
        public IDataExchange DataExchange
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }
        #endregion

        /// <summary>
        /// Create an instance Of result.
        /// </summary>
        /// <param name="parms">An array of values that matches the number, order and type
        /// of the parameters for this constructor.</param>
        /// <returns>An object.</returns>
        public object CreateInstanceOfResult(object[] parms)
        {
            return null;
        }

        /// <summary>
        /// Set the value of an object property.
        /// </summary>
        /// <param name="target">The object to set the property.</param>
        /// <param name="property">The result property to use.</param>
        /// <param name="dataBaseValue">The database value to set.</param>
        public void SetValueOfProperty(ref object target, ResultProperty property, object dataBaseValue)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        /// <summary>
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public IResultMap ResolveSubMap(System.Data.IDataReader dataReader)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// The Key Properties name (used for resolved circular reference).
        /// </summary>
        /// <value></value>
        public List<string> KeyPropertyNames
        {
            get { return keyPropertyNames; }
        }

        /// <summary>
        /// The Keys Properties.
        /// </summary>
        /// <value></value>
        public ResultPropertyCollection KeysProperties
        {
            get { return keysProperties; }
        }

        #region IResultMapEvents Members

        /// <summary>
        /// Handles event <see cref="PreCreateEventArgs"/> generated before creating an instance of the <see cref="IResultMap"/> object.
        /// </summary>
        public event EventHandler<PreCreateEventArgs> PreCreate
        {
            add { throw new NotImplementedException("PreCreate EventHandler"); }
            remove { throw new NotImplementedException("PreCreate EventHandler"); }
        }

        /// <summary>
        /// Handles event <see cref="PostCreateEventArgs"/> generated after creating an instance of the <see cref="IResultMap"/> object.
        /// </summary>
        public event EventHandler<PostCreateEventArgs> PostCreate
        {
            add { throw new NotImplementedException("PostCreate EventHandler"); }
            remove { throw new NotImplementedException("PostCreate EventHandler"); }
        }
        #endregion
    }
}
