
#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
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

using System;
namespace Apache.Ibatis.Common.Contracts
{
    /// <summary>
    /// Helper class to work with constraints. 
    /// </summary>
    public class Is
    {
        /// <summary>
        /// Check if it is Empty
        /// </summary>
        public static readonly BaseConstraint Empty = new EmptyConstraint();
        /// <summary>
        /// Check if it is False
        /// </summary>
        public static readonly BaseConstraint False = new EqualConstraint(false);
        /// <summary>
        /// Check if it is Null
        /// </summary>
        public static readonly BaseConstraint Null = new EqualConstraint(null);
        /// <summary>
        /// Check if it is True
        /// </summary>
        public static readonly BaseConstraint True = new EqualConstraint(true);
        /// <summary>
        /// A constraint that always returns <code>true</code>
        /// </summary>
        public static readonly BaseConstraint Anything = new AnythingConstraint();


        /// <summary>
        /// Check whether an object is greater than the specified object.
        /// </summary>
        /// <param name="specified">The specified.</param>
        /// <returns></returns>
        public static BaseConstraint GreaterThan(object specified)
        {
            return new GreaterThanConstraint((IComparable)specified);
        }

        /// <summary>
        /// Check whether an object is less than the specified object.
        /// </summary>
        /// <param name="specified">The specified.</param>
        /// <returns></returns>
        public static BaseConstraint LessThan(object specified)
        {
            return new LessThanConstraint((IComparable)specified);
        }

        /// <summary>
        /// Check whether an object is Equals to the specified object.
        /// </summary>
        /// <param name="specified">The specified object.</param>
        /// <returns></returns>
        public static BaseConstraint EqualTo(object specified)
        {
            return new EqualConstraint(specified);
        }

        /// <summary>
        /// Negates the next constraint.
        /// </summary>
        /// <value>The not.</value>
        public static NegationBuilder Not
        {
            get { return new NegationBuilder().Not; }
        }

        /// <summary>
        /// Checks whether an object is of the specified type.
        /// </summary>
        public static BaseConstraint TypeOf<T>()
        {
            return new TypeOfConstraint(typeof(T));
        }

        /// <summary>
        /// Checks whether an object is Assignables from the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static BaseConstraint AssignableFrom<T>()
        {
            return new AssignableFromConstraint(typeof(T));
        }

        /// <summary>
        /// Checks whether a string contains the specified string.
        /// </summary>
        /// <param name="specified">The specified string.</param>
        /// <returns></returns>
        public static BaseConstraint Contains(string specified)
        {
            return new ContainsConstraint(specified);
        }

        /// <summary>
        /// Checks whether a string is validated according to regex pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static BaseConstraint Like(string pattern)
        {
            return new LikeConstraint(pattern);
        }

        /// <summary>
        /// Checks whether an object is identical to the specified object 
        /// </summary>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static BaseConstraint SameAs(object expected)
        {
            return new SameAsConstraint(expected);
        }
    }
}
