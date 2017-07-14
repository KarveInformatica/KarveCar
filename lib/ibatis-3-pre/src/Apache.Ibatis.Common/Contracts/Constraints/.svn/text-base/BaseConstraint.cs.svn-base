
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

namespace Apache.Ibatis.Common.Contracts
{
    /// <summary>
    /// Base class for all constraint.
    /// </summary>
    public abstract class BaseConstraint
    {
        private string errorMessage = string.Empty;

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
        private string negationMessage = string.Empty;

        /// <summary>
        /// Gets or sets the negation message.
        /// </summary>
        /// <value>The negation message.</value>
        public string NegationMessage
        {
            get { return negationMessage; }
            set { negationMessage = value; }
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified obj].
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="appendErrorMessage">The append error message.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified obj]; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsSatisfiedBy(object obj, AppendErrorMessage appendErrorMessage);

        /// Represents the And operator between two constraints
        /// </summary>
        /// <param name="left">The first constraint</param>
        /// <param name="right">The second constraint</param>
        /// <returns></returns>
        public static BaseConstraint operator &(BaseConstraint left, BaseConstraint right)
        {
            return new AndConstraint(left, right);
        }

        /// <summary>
        /// Represents the Or operator between two constraints
        /// </summary>
        /// <param name="left">The first constraint</param>
        /// <param name="right">The second constraint</param>
        /// <returns></returns>
        public static BaseConstraint operator |(BaseConstraint left, BaseConstraint right)
        {
            return new OrConstraint(left, right);
        }

        /// <summary>
        /// Inverts the result of the specified constraint.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns></returns>
        public static BaseConstraint operator !(BaseConstraint constraint)
        {
            return new NotConstraint(constraint);
        }

    }
}
