
#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
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

namespace Apache.Ibatis.Common.Contracts
{
    /// <summary>
    /// Resolve the Not constraint
    /// </summary>
    public class NegationBuilder
    {

        /// <summary>
        /// Check if it is Empty
        /// </summary>
        public BaseConstraint Empty
        {
            get { return Resolve(new EmptyConstraint()); }
        }

        /// <summary>
        /// Check if it is False
        /// </summary>
        public BaseConstraint False
        {
            get { return Resolve(new EqualConstraint(false)); }
        }

        /// <summary>
        /// Check if it is Null
        /// </summary>
        public BaseConstraint Null
        {
            get { return Resolve(new EqualConstraint(null)); }
        }

        /// <summary>
        /// Check if it is True
        /// </summary>
        public BaseConstraint True
        {
            get { return Resolve(new EqualConstraint(true)); }
        }

        /// <summary>
        /// Check whether an object is Equals to the specified object.
        /// </summary>
        /// <param name="specified">The specified object.</param>
        /// <returns></returns>
        public BaseConstraint EqualTo(object specified)
        {
            return Resolve(new EqualConstraint(specified));
        }
        /// <summary>
        /// Checks whether an object is of the specified type.
        /// </summary>
        public BaseConstraint TypeOf<T>()
        {
            return Resolve(new TypeOfConstraint(typeof(T)));
        }

        /// <summary>
        /// Checks whether an object is Assignables from the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public BaseConstraint AssignableFrom<T>()
        {
            return Resolve(new AssignableFromConstraint(typeof(T)));
        }

        /// <summary>
        /// Checks whether a string contains the specified string.
        /// </summary>
        /// <param name="specified">The specified string.</param>
        /// <returns></returns>
        public BaseConstraint Contains(string specified)
        {
            return Resolve(new ContainsConstraint(specified));
        }

        /// <summary>
        /// Checks whether a string is validated according to regex pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public BaseConstraint Like(string pattern)
        {
            return Resolve(new LikeConstraint(pattern));
        }

        /// <summary>
        /// Checks whether an object is identical to the specified object 
        /// </summary>
        /// <param name="specified">The specified object.</param>
        /// <returns></returns>
        public BaseConstraint SameAs(object specified)
        {
            return Resolve(new SameAsConstraint(specified));
        }

        /// <summary>
        /// Negate teh next constraint.
        /// </summary>
        /// <value>The not.</value>
        public NegationBuilder Not
        {
            get { return this; }
        }
        
        private static BaseConstraint Resolve(BaseConstraint constraint)
        {
            return new NotConstraint(constraint);
        }
    }
}
