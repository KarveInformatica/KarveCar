
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
    /// Checks whether the actual value is the same object as the supplied
    /// </summary>
    public class SameAsConstraint : BaseConstraint
    {
       private readonly object expected = null;

        /// <summary>
       /// Initializes a new instance of the <see cref="SameAsConstraint"/> class.
        /// </summary>
       /// <param name="expected">The expected.</param>
        public SameAsConstraint(object expected)
        {
            this.expected = expected;
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified obj].
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="appendErrorMessage">The append error message.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified obj]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(object actual, AppendErrorMessage appendErrorMessage)
        {
            bool test = ((actual != null) && ReferenceEquals(expected, actual));
            ErrorMessage = NegationMessage + "be same as " + expected;

            if (!test)
            {
                appendErrorMessage(ErrorMessage);
            }

            return test;
        }
    }
}
