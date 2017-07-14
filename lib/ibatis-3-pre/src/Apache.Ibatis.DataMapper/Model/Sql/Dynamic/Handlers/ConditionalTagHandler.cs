
#region Apache Notice
/*****************************************************************************
 * $Revision: 405046 $
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

#region Imports
using System;
using System.Text;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Elements;
using Apache.Ibatis.Common.Utilities.Objects;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Handlers
{
	/// <summary>
	/// Description résumée de ConditionalTagHandler.
	/// </summary>
	public abstract class ConditionalTagHandler : BaseTagHandler 
	{

		#region Const
		/// <summary>
		/// 
		/// </summary>
		public const long NOT_COMPARABLE = long.MinValue;
		#endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalTagHandler"/> class.
        /// </summary>
        /// <param name="accessorFactory">The accessor factory.</param>
        protected ConditionalTagHandler(AccessorFactory accessorFactory)
            : base(accessorFactory)
		{
		}

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
		public abstract bool IsCondition(SqlTagContext ctx, SqlTag tag, object parameterObject);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
		public override int DoStartFragment(SqlTagContext ctx, SqlTag tag, Object parameterObject)
		{
		    if (IsCondition(ctx, tag, parameterObject)) 
			{
				return INCLUDE_BODY;
			}
		    return SKIP_BODY;
		}

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <param name="bodyContent"></param>
		/// <returns></returns>
		public override int DoEndFragment(SqlTagContext ctx, SqlTag tag, Object parameterObject, StringBuilder bodyContent) 
		{
			return INCLUDE_BODY;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="sqlTag"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
		protected long Compare(SqlTagContext ctx, SqlTag sqlTag, object parameterObject)
		{
			Conditional tag = (Conditional)sqlTag;
			string propertyName = tag.Property;
			string comparePropertyName = tag.CompareProperty;
			string compareValue = tag.CompareValue;

			object value1 = null;
			Type type = null;
			if (!string.IsNullOrEmpty(propertyName)) 
			{
				value1 = ObjectProbe.GetMemberValue(parameterObject, propertyName, AccessorFactory);
				type = value1.GetType();
			} 
			else 
			{
				value1 = parameterObject;
				if (value1 != null) 
				{
					type = parameterObject.GetType();
				} 
				else 
				{
					type = typeof(object);
				}
			}
			if (!string.IsNullOrEmpty(comparePropertyName)) 
			{
                object value2 = ObjectProbe.GetMemberValue(parameterObject, comparePropertyName, AccessorFactory);
				return CompareValues(type, value1, value2);
			}
		    if (!string.IsNullOrEmpty(compareValue)) 
		    {
		        return CompareValues(type, value1, compareValue);
		    }
		    throw new DataMapperException("Error comparing in conditional fragment.  Uknown 'compare to' values.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value1"></param>
		/// <param name="value2"></param>
		/// <returns></returns>
		protected static long CompareValues(Type type, object value1, object value2) 
		{
			long result = NOT_COMPARABLE;

			if (value1 == null || value2 == null) 
			{
				result = value1 == value2 ? 0 : NOT_COMPARABLE;
			} 
			else 
			{
				if (value2.GetType() != type) 
				{
					value2 = ConvertValue(type, value2.ToString());
				}
				if (value2 is string && type != typeof(string)) 
				{
					value1 = value1.ToString();
				}
				if (!(value1 is IComparable && value2 is IComparable)) 
				{
					value1 = value1.ToString();
					value2 = value2.ToString();
				}
				result = ((IComparable) value1).CompareTo(value2);
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		protected static object ConvertValue(Type type, string value)
		{
		    if (type == typeof(String)) 
			{
				return value;
			}
		    if (type == typeof(bool)) 
		    {
		        return Convert.ToBoolean(value);
		    }
		    if (type == typeof(Byte)) 
		    {
		        return Convert.ToByte(value);
		    }
		    if (type == typeof(Char)) 
		    {
		        return Convert.ToChar(value.Substring(0,1));//new Character(value.charAt(0));
		    }
		    if (type == typeof(DateTime)) 
		    {
		        try 
		        {
		            return Convert.ToDateTime(value);
		        } 
		        catch (Exception e) 
		        {
		            throw new DataMapperException("Error parsing date. Cause: " + e.Message, e);
		        }
		    }
		    if (type == typeof(Decimal)) 
		    {
		        return Convert.ToDecimal(value);
		    }
		    if (type == typeof(Double))  
		    {
		        return Convert.ToDouble(value);
		    }
		    if (type == typeof(Int16)) 
		    {
		        return Convert.ToInt16(value);
		    }
		    if (type == typeof(Int32)) 
		    {
		        return Convert.ToInt32(value);
		    }
		    if (type == typeof(Int64)) 
		    {
		        return Convert.ToInt64(value);
		    }
		    if (type == typeof(Single)) 
		    {
		        return Convert.ToSingle(value);
		    }
		    return value;
		}

	    #endregion

	}
}
