#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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
using System.Reflection;
using System.Reflection.Emit;

namespace Apache.Ibatis.Common.Utilities.Objects.Members
{
    /// <summary>
    /// The <see cref="DelegatePropertyGetAccessor"/> class defines a get property accessor and
    /// provides <c>Reflection.Emit</c>-generated <see cref="IGet"/> 
    /// via the new DynamicMethod (.NET V2).
    /// </summary>
    public sealed class DelegatePropertyGetAccessor : BaseAccessor, IGetAccessor
    {
        private delegate object GetValue(object instance);

        private readonly GetValue _get = null;
         /// <summary>
        /// The property type
        /// </summary>
        private readonly Type _propertyType = null;
        private readonly bool _canRead = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegatePropertyGetAccessor"/> class
        /// for get property access via DynamicMethod.
        /// </summary>
        /// <param name="targetObjectType">Type of the target object.</param>
        /// <param name="propertyName">Name of the property.</param>
        public DelegatePropertyGetAccessor(Type targetObjectType, string propertyName)
		{
            targetType = targetObjectType;
            this.propertyName = propertyName;

            PropertyInfo propertyInfo = GetPropertyInfo(targetObjectType);

            if (propertyInfo == null)
            {
                propertyInfo = targetType.GetProperty(propertyName);
            }
            
			// Make sure the property exists
			if(propertyInfo == null)
			{
				throw new NotSupportedException(
					string.Format("Property \"{0}\" does not exist for type "
                    + "{1}.", propertyName, targetType));
			}
            _propertyType = propertyInfo.PropertyType;
            _canRead = propertyInfo.CanRead;

            nullInternal = GetNullInternal(_propertyType);

            if (propertyInfo.CanRead)
            {
                DynamicMethod dynamicMethod = new DynamicMethod("GetImplementation", typeof(object), new Type[] { typeof(object) }, GetType().Module, true);
                ILGenerator ilgen = dynamicMethod.GetILGenerator();

                // Emit the IL for get access. 
                MethodInfo targetGetMethod = propertyInfo.GetGetMethod();

                ilgen.DeclareLocal(typeof(object));
                ilgen.Emit(OpCodes.Ldarg_0);	//Load the first argument,(target object)
                ilgen.Emit(OpCodes.Castclass, targetObjectType);	//Cast to the source type
                ilgen.EmitCall(OpCodes.Callvirt, targetGetMethod, null); //Get the property value
                if (targetGetMethod.ReturnType.IsValueType)
                {
                    ilgen.Emit(OpCodes.Box, targetGetMethod.ReturnType); //Box if necessary
                }
                ilgen.Emit(OpCodes.Stloc_0); //Store it
                ilgen.Emit(OpCodes.Ldloc_0);
                ilgen.Emit(OpCodes.Ret);
  
                _get = (GetValue)dynamicMethod.CreateDelegate(typeof(GetValue));
            }
		}
            
        #region IAccessor Members

        /// <summary>
        /// Gets the property's name.
        /// </summary>
        /// <value></value>
        public string Name
        {
            get { return propertyName; }
        }

        /// <summary>
        /// Gets the property's type.
        /// </summary>
        /// <value></value>
        public Type MemberType
        {
            get { return _propertyType; }
        }

        #endregion

        #region IGet Members

        /// <summary>
        /// Gets the field value from the specified target.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <returns>Property value.</returns>
        public object Get(object target)
        {
            if (_canRead)
            {
                return _get(target);
            }
            else
            {
                throw new NotSupportedException(
                    string.Format("Property \"{0}\" on type "
                    + "{1} doesn't have a get method.", propertyName, targetType));
            }
        }

        #endregion
    }
}
