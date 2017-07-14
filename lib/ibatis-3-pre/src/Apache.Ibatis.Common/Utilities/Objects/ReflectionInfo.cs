
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 511513 $
 * $Date: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
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
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;

using Apache.Ibatis.Common.Exceptions;
using System.Collections.Generic;

namespace Apache.Ibatis.Common.Utilities.Objects
{
	/// <summary>
	/// This class represents a cached set of class definition information that
	/// allows for easy mapping between property names and get/set methods.
	/// </summary>
    public sealed class ReflectionInfo
	{
		/// <summary>
		/// 
		/// </summary>
		public static BindingFlags BINDING_FLAGS_PROPERTY
			= BindingFlags.Public
            | BindingFlags.NonPublic
			| BindingFlags.Instance
			;


		/// <summary>
		/// 
		/// </summary>
		public static BindingFlags BINDING_FLAGS_FIELD
            = BindingFlags.Public
            | BindingFlags.NonPublic 
			| BindingFlags.Instance 

			;

		private static readonly string[] _emptyStringArray = new string[0];
        private static readonly IList<Type> _simleTypeMap = new List<Type>();
        private static readonly IDictionary<Type, ReflectionInfo> _reflectionInfoMap = new Dictionary<Type, ReflectionInfo>();

		private readonly string _className = string.Empty;
        private readonly string[] _readableMemberNames = _emptyStringArray;
        private readonly string[] _writeableMemberNames = _emptyStringArray;
		// (memberName, MemberInfo)
        private readonly IDictionary<string, MemberInfo> _setMembers = new Dictionary<string, MemberInfo>();
        // (memberName, MemberInfo)
        private readonly IDictionary<string, MemberInfo> _getMembers = new Dictionary<string, MemberInfo>();
		// (memberName, member type)
        private readonly IDictionary<string, Type> _setTypes = new Dictionary<string, Type>();
		// (memberName, member type)
        private readonly IDictionary<string, Type> _getTypes = new Dictionary<string, Type>();

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
		public string ClassName 
		{
			get { return _className; }
		}

        /// <summary>
        /// Initializes the <see cref="ReflectionInfo"/> class.
        /// </summary>
		static ReflectionInfo()
		{
			_simleTypeMap.Add(typeof(string));
			_simleTypeMap.Add(typeof(byte));
			_simleTypeMap.Add(typeof(char));
			_simleTypeMap.Add(typeof(bool));
			_simleTypeMap.Add(typeof(Guid));
			_simleTypeMap.Add(typeof(Int16));
			_simleTypeMap.Add(typeof(Int32));
			_simleTypeMap.Add(typeof(Int64));
			_simleTypeMap.Add(typeof(Single));
			_simleTypeMap.Add(typeof(Double));
			_simleTypeMap.Add(typeof(Decimal));
			_simleTypeMap.Add(typeof(DateTime));
			_simleTypeMap.Add(typeof(TimeSpan));
			_simleTypeMap.Add(typeof(Hashtable));
			_simleTypeMap.Add(typeof(SortedList));
			_simleTypeMap.Add(typeof(ListDictionary));
			_simleTypeMap.Add(typeof(HybridDictionary));


			//			_simleTypeMap.Add(Class.class);
			//			_simleTypeMap.Add(Collection.class);
			//			_simleTypeMap.Add(HashMap.class);
			//			_simleTypeMap.Add(TreeMap.class);
			_simleTypeMap.Add(typeof(ArrayList));
			//			_simleTypeMap.Add(HashSet.class);
			//			_simleTypeMap.Add(TreeSet.class);
			//			_simleTypeMap.Add(Vector.class);
			_simleTypeMap.Add(typeof(IEnumerator));
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionInfo"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
		private ReflectionInfo(Type type) 
		{
			_className = type.Name;
			AddMembers(type);

			string[] getArray = new string[_getMembers.Count];
			_getMembers.Keys.CopyTo(getArray,0);
			_readableMemberNames = getArray;

			string[] setArray = new string[_setMembers.Count];
			_setMembers.Keys.CopyTo(setArray,0);
			_writeableMemberNames = setArray;
		}

        /// <summary>
        /// Adds the members.
        /// </summary>
        /// <param name="type">The type.</param>
		private void AddMembers(Type type) 
		{
			#region Properties
            PropertyInfo[] properties = type.GetProperties(BINDING_FLAGS_PROPERTY);
			for (int i = 0; i < properties.Length; i++) 
			{
                if (properties[i].CanWrite)
                {
                    string name = properties[i].Name;
                    _setMembers[name] = properties[i];
                    _setTypes[name] = properties[i].PropertyType;
                }
                if (properties[i].CanRead)
                {
                    string name = properties[i].Name;
                    _getMembers[name] = properties[i];
                    _getTypes[name] = properties[i].PropertyType;
                }
            }
            
			#endregion

			#region Fields
			FieldInfo[] fields = type.GetFields(BINDING_FLAGS_FIELD) ;
			for (int i = 0; i < fields.Length; i++) 
			{
				string name = fields[i].Name;
				_setMembers[name] = fields[i];
				_setTypes[name] = fields[i].FieldType;
				_getMembers[name] = fields[i];
				_getTypes[name] = fields[i].FieldType;
			}
			#endregion

            // Fix for problem with interfaces inheriting other interfaces
            if (type.IsInterface)
            {
                // Loop through interfaces for the type and add members from
                // these types too
                for (int i = 0; i < type.GetInterfaces().Length; i++)
                {
                    AddMembers(type.GetInterfaces()[i]);
                }
            }
		}

        /// <summary>
        /// Gets the setter.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns></returns>
		public MemberInfo GetSetter(string memberName) 
		{
            MemberInfo memberInfo = null;
            _setMembers.TryGetValue(memberName, out memberInfo);

			if (memberInfo == null) 
			{
				throw new ProbeException("There is no Set member named '" + memberName + "' in class '" + _className + "'");
			}				

			return memberInfo;
		}

        /// <summary>
        /// Gets the <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="memberName">Member's name.</param>
        /// <returns>The <see cref="MemberInfo"/></returns>
		public MemberInfo GetGetter(string memberName) 
		{
            MemberInfo memberInfo = null;
            _getMembers.TryGetValue(memberName, out memberInfo);

			if (memberInfo == null) 
			{
				throw new ProbeException("There is no Get member named '" + memberName + "' in class '" + _className + "'");
			}
			return memberInfo;
		}

        /// <summary>
        /// Gets the type of the member.
        /// </summary>
        /// <param name="memberName">Member's name.</param>
        /// <returns></returns>
		public Type GetSetterType(string memberName) 
		{
            Type type = null;
            _setTypes.TryGetValue(memberName, out type);

			if (type == null) 
			{
				throw new ProbeException("There is no Set member named '" + memberName + "' in class '" + _className + "'");
			}
			return type;
		}

        /// <summary>
        /// Gets the type of the getter.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns></returns>
		public Type GetGetterType(string memberName) 
		{
            Type type = null;
            _getTypes.TryGetValue(memberName, out type);

            if (type == null) 
			{
				throw new ProbeException("There is no Get member named '" + memberName + "' in class '" + _className + "'");
			}
			return type;
		}

        /// <summary>
        /// Gets the readable member names.
        /// </summary>
        /// <returns></returns>
		public string[] GetReadableMemberNames() 
		{
			return _readableMemberNames;
		}

        /// <summary>
        /// Gets the writeable member names.
        /// </summary>
        /// <returns></returns>
		public string[] GetWriteableMemberNames() 
		{
			return _writeableMemberNames;
		}

        /// <summary>
        /// Determines whether [has writable member] [the specified member name].
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>
        /// 	<c>true</c> if [has writable member] [the specified member name]; otherwise, <c>false</c>.
        /// </returns>
		public bool HasWritableMember(string memberName) 
		{
			return _setMembers.ContainsKey(memberName);
		}

        /// <summary>
        /// Determines whether [has readable member] [the specified member name].
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>
        /// 	<c>true</c> if [has readable member] [the specified member name]; otherwise, <c>false</c>.
        /// </returns>
		public bool HasReadableMember(string memberName) 
		{
			return _getMembers.ContainsKey(memberName);
		}

        /// <summary>
        /// Determines whether [is known type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if [is known type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
		public static bool IsKnownType(Type type)
        {
            if (_simleTypeMap.Contains(type)) 
			{
				return true;
			}
            if (typeof(IList).IsAssignableFrom(type)) 
            {
                return true;
            }
            if (typeof(IDictionary).IsAssignableFrom(type)) 
            {
                return true;
            }
            if (typeof(IEnumerator).IsAssignableFrom(type)) 
            {
                return true;
            }
            return false;
        }

	    /// <summary>
		/// Gets an instance of ReflectionInfo for the specified type.
		/// </summary>summary>
		/// <param name="type">The type for which to lookup the method cache.</param>
		/// <returns>The properties cache for the type</returns>
		public static ReflectionInfo GetInstance(Type type) 
		{
			lock (type) 
			{
                ReflectionInfo reflectionInfo = null;
                _reflectionInfoMap.TryGetValue(type, out reflectionInfo);
                if (reflectionInfo == null) 
				{
                    reflectionInfo = new ReflectionInfo(type);
                    _reflectionInfoMap.Add(type, reflectionInfo);
				}
                return reflectionInfo;
			}
		}
																								
	}
	
}
