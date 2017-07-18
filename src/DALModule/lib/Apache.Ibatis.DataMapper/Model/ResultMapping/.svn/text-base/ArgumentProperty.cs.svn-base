
#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
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

#region Using

using System;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.MappedStatements.ArgumentStrategy;
using Apache.Ibatis.DataMapper.TypeHandlers;
using CommonExceptions = Apache.Ibatis.Common.Exceptions;

#endregion


namespace Apache.Ibatis.DataMapper.Model.ResultMapping
{
	/// <summary>
	/// Summary description for ArgumentProperty.
	/// </summary>
	[Serializable]
    [DebuggerDisplay("ArgumentProperty: {argumentName}-{columnName}")]
    public class ArgumentProperty : ResultProperty
	{

		#region Fields
		[NonSerialized]
        private readonly string argumentName = string.Empty;
		[NonSerialized]
        private readonly Type type = null;
		[NonSerialized]
		private readonly IArgumentStrategy argumentStrategy = null;
		#endregion

		#region Properties

		/// <summary>
		/// Sets or gets the <see cref="IArgumentStrategy"/> used to fill the object property.
		/// </summary>
		public override IArgumentStrategy ArgumentStrategy
		{
			get { return argumentStrategy ; }
		}

		/// <summary>
		/// Specify the constructor argument name.
		/// </summary>
		public string ArgumentName
		{
            get { return argumentName; }
		}

		/// <summary>
		/// Tell us if we must lazy load this property..
		/// </summary>
		public override bool IsLazyLoad
		{
			get { return false; }
		}

		/// <summary>
		/// Get the argument type
		/// </summary>
		public override Type MemberType
		{
			get { return type; }
		}

		#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentProperty"/> class.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <param name="clrType">Type of the CLR.</param>
        /// <param name="callBackName">Name of the call back.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="nestedResultMapName">Name of the nested result map.</param>
        /// <param name="nullValue">The null value.</param>
        /// <param name="select">The select.</param>
        /// <param name="type">The argument type.</param>
        /// <param name="resultClass">The result class.</param>
        /// <param name="dataExchangeFactory">The data exchange factory.</param>
        /// <param name="typeHandler">The type handler.</param>
		public ArgumentProperty(
            string    argumentName,
            string    columnName,
            int       columnIndex,
            string    clrType,
            string    callBackName,
            string    dbType,
            string    nestedResultMapName,
            string    nullValue,
            string    select,
            Type      type,
            Type      resultClass,
            DataExchangeFactory dataExchangeFactory,
            ITypeHandler typeHandler
            )
            : base("value", columnName, columnIndex, clrType, callBackName, dbType, false, nestedResultMapName, nullValue, select, resultClass,
            dataExchangeFactory, typeHandler)
		{
            Contract.Require.That(argumentName, Is.Not.Null & Is.Not.Empty).When("retrieving argument argumentName in ArgumentProperty constructor");
            Contract.Require.That(type, Is.Not.Null & Is.Not.Empty).When("retrieving argument type in ArgumentProperty constructor");
            Contract.Require.That(resultClass, Is.Not.Null & Is.Not.Empty).When("retrieving argument resultClass in ArgumentProperty constructor");

            this.argumentName = argumentName;
            this.type = type;

            argumentStrategy = ArgumentStrategyFactory.Get(this);
		}
	}
}
