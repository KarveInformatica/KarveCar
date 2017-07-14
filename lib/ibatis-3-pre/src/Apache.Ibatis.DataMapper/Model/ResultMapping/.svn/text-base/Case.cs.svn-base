
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 576082 $
 * $Date: 2008-09-20 12:15:29 -0600 (Sat, 20 Sep 2008) $
 * Author : Gilles Bayon
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - Apache Fondation
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

#region Using

using System;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;

#endregion

namespace Apache.Ibatis.DataMapper.Model.ResultMapping
{
	/// <summary>
	/// Summary description for Case.
	/// </summary>
	[Serializable]
    [DebuggerDisplay("case: {discriminatorValue}-{resultMapName}")]
	public class Case
	{
		#region Fields
		[NonSerialized]
        private readonly string discriminatorValue = string.Empty;
		[NonSerialized]
        private readonly string resultMapName = string.Empty;
		[NonSerialized]
		private IResultMap resultMap = null;
		#endregion 

		#region Properties

		/// <summary>
		/// Discriminator value
		/// </summary>
		public string DiscriminatorValue
		{
			get { return discriminatorValue; }
		}

		/// <summary>
		/// The name of the ResultMap used if the column value is = to the Discriminator Value
		/// </summary>
		public string ResultMapName
		{
			get { return resultMapName; }
		}

		/// <summary>
		/// The resultMap used if the column value is = to the Discriminator Value
		/// </summary>
		public IResultMap ResultMap
		{
			get { return resultMap; }
			set { resultMap = value; }
		}

		#endregion 

		#region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Case"/> class.
        /// </summary>
        /// <param name="discriminatorValue">The discriminator value.</param>
        /// <param name="resultMapName">Name of the result map.</param>
        public Case(string discriminatorValue, string resultMapName)
		{
            Contract.Require.That(discriminatorValue, Is.Not.Null & Is.Not.Empty).When("retrieving argument discriminatorValue in Case constructor");
            Contract.Require.That(resultMapName, Is.Not.Null & Is.Not.Empty).When("retrieving argument resultMapName in Case constructor");

            this.discriminatorValue = discriminatorValue;
            this.resultMapName = resultMapName;
		}
		#endregion 

	}
}
