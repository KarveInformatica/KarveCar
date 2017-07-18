
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
    /// 
    /// </summary>
    public sealed class ContractMessage
    {
        private readonly string messagePrefix = string.Empty;
        private readonly ThrowException throwException = null;
        private readonly IsSatisfied isSatisfied = null;
        private readonly GetErrorMessage getErrorMessage = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractMessage"/> class.
        /// </summary>
        /// <param name="messagePrefix">The message prefix.</param>
        /// <param name="throwException">The throw exception.</param>
        /// <param name="isSatisfied">The is failed.</param>
        /// <param name="getErrorMessage">The get error message.</param>
        public ContractMessage(
            string messagePrefix, 
            ThrowException throwException,
            IsSatisfied isSatisfied,
            GetErrorMessage getErrorMessage)
        {
            this.messagePrefix = messagePrefix;
            this.throwException = throwException;
            this.isSatisfied = isSatisfied;
            this.getErrorMessage = getErrorMessage;

        }

        /// <summary>
        /// Whens the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void When(string message)
        {
            if (!isSatisfied())
            {
                string whenPart = " when " + message;
                throwException(messagePrefix + getErrorMessage() + whenPart);
            }
        }
    }
}
