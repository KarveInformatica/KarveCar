#region Apache Notice
/*****************************************************************************
 * $Revision: 595821 $
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
using System.Data;
using Apache.Ibatis.DataMapper.Model.ResultMapping;

namespace Apache.Ibatis.DataMapper.TypeHandlers
{
	/// <summary>
	///  Implementation of TypeHandler for dealing with unknown types
	/// </summary>
    public sealed class UnknownTypeHandler : BaseTypeHandler
	{
		private readonly TypeHandlerFactory _factory = null;

		/// <summary>
		/// Constructor to create via a factory
		/// </summary>
		/// <param name="factory">the factory to associate this with</param>
		public UnknownTypeHandler(TypeHandlerFactory factory) 
		{
			_factory = factory;
		}
		/// <summary>
		/// Performs processing on a value before it is used to set
		/// the parameter of a IDbCommand.
		/// </summary>
		/// <param name="dataParameter"></param>
		/// <param name="parameterValue">The value to be set</param>
		/// <param name="dbType">Data base type</param>
		public override void SetParameter(IDataParameter dataParameter, object parameterValue, string dbType)
		{
			if (parameterValue!=null)
			{
			    ITypeHandler handler = _factory.GetTypeHandler( parameterValue.GetType(), dbType );
				handler.SetParameter(dataParameter, parameterValue, dbType);
			}
			else
			{
				// When sending a null parameter value to the server,
				// the user must specify DBNull, not null. 
                dataParameter.Value = DBNull.Value;
			}
		}

        /// <summary>
        /// Gets a column value by the name
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="dataReader"></param>
        /// <returns></returns>
		public override object GetValueByName(ResultProperty mapping, IDataReader dataReader)
		{
			int index = dataReader.GetOrdinal(mapping.ColumnName);

			if (dataReader.IsDBNull(index))
			{
				return DBNull.Value;
			}
            return dataReader.GetValue(index);
		}

        /// <summary>
        /// Gets a column value by the index
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="dataReader"></param>
        /// <returns></returns>
		public override object GetValueByIndex(ResultProperty mapping, IDataReader dataReader)
        {
            if (dataReader.IsDBNull(mapping.ColumnIndex))
			{
				return DBNull.Value;
			}
            return dataReader.GetValue(mapping.ColumnIndex);
        }

	    /// <summary>
        /// Converts the String to the type that this handler deals with
        /// </summary>
        /// <param name="type">the tyepe of the property (used only for enum conversion)</param>
        /// <param name="s">the String value</param>
        /// <returns>the converted value</returns>
		public override object ValueOf(Type type, string s)
		{
			return s;
		}

        /// <summary>
        /// Retrieve ouput database value of an output parameter
        /// </summary>
        /// <param name="outputValue">ouput database value</param>
        /// <param name="parameterType">type used in EnumTypeHandler</param>
        /// <returns></returns>
		public override object GetDataBaseValue(object outputValue, Type parameterType)
		{
			return outputValue;
		}


        /// <summary>
        /// Gets a value indicating whether this instance is simple type.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is simple type; otherwise, <c>false</c>.
        /// </value>
		public override bool IsSimpleType
		{
			get { return false; }
		}

        //public override object NullValue
        //{
        //    get { throw new InvalidCastException("UnknownTypeHandler could not cast a null value in unknown type field."); }
        //}

		/// <summary>
		///  Compares two values (that this handler deals with) for equality
		/// </summary>
		/// <param name="obj">one of the objects</param>
		/// <param name="str">the other object as a String</param>
		/// <returns>true if they are equal</returns>
		public override bool Equals(object obj, string str) 
		{
			if (obj == null || str == null) 
			{
				return (string)obj == str;
			}
		    ITypeHandler handler = _factory.GetTypeHandler(obj.GetType());
		    object castedObject = handler.ValueOf(obj.GetType(), str);
		    return obj.Equals(castedObject);
		}
	}
}
