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
    /// NotConstraint negates the effect of some other constraint 
    /// </summary>
    public class NotConstraint: BaseConstraint 
    {
        // Fields
        private readonly BaseConstraint baseConstraint = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotConstraint"/> class.
        /// </summary>
        /// <param name="baseConstraint">The base constraint.</param>
        public NotConstraint(BaseConstraint baseConstraint)
        {
            this.baseConstraint = baseConstraint;
            this.baseConstraint.NegationMessage = "not ";
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified actual].
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="appendErrorMessage">The append error message.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified actual]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(object actual, AppendErrorMessage appendErrorMessage)
        {
            bool test = !baseConstraint.IsSatisfiedBy(actual, appendErrorMessage);
            if (!test)
            {
                appendErrorMessage(baseConstraint.ErrorMessage);
            }
            return test;
        }
    }
}
