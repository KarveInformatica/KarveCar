
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 451064 $
 * $Date: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2005 - iBATIS Team
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

using System.Collections.Generic;
using System.Text;
using Apache.Ibatis.Common.Utilities;

namespace Apache.Ibatis.DataMapper.Model.Cache
{

	/// <summary>
	///  Hash value generator for cache keys
	/// </summary>
	public class CacheKey
	{
		private const int DEFAULT_MULTIPLYER = 37;
		private const int DEFAULT_HASHCODE = 17;

		private readonly int multiplier = DEFAULT_MULTIPLYER;
		private int hashCode = DEFAULT_HASHCODE;
		private long checksum = long.MinValue;
		private int count = 0;
        private readonly IList<object> paramList = new List<object>();

		/// <summary>
		/// Default constructor
		/// </summary>
		public CacheKey()
		{
			hashCode = DEFAULT_HASHCODE;
			multiplier = DEFAULT_MULTIPLYER;
			count = 0;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheKey"/> class.
        /// </summary>
        /// <param name="objects">The objects.</param>
	    public CacheKey(object[] objects):this()
        {
            UpdateAll(objects);
        }

		/// <summary>
		/// Updates this object with new information based on an object
		/// </summary>
		/// <param name="obj">the object</param>
		/// <returns>the cachekey</returns>
		public CacheKey Update(object obj) 
		{
			int baseHashCode =  (obj == null)? 1 :HashCodeProvider.GetIdentityHashCode(obj);

			count++;
			checksum += baseHashCode;
			baseHashCode *= count;

			hashCode = multiplier * hashCode + baseHashCode;

			paramList.Add(obj);

			return this;
		}

        /// <summary>
        /// Updates all.
        /// </summary>
        /// <param name="objects">The objects.</param>
          public void UpdateAll(object[] objects) 
          {
                for(int i=0; i<objects.Length;i++) 
                {
                    Update(objects[i]);
                }
            }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj) 
		{
			if (this == obj) return true;
			if (!(obj is CacheKey)) return false;

			CacheKey cacheKey = (CacheKey) obj;

			if (hashCode != cacheKey.hashCode) return false;
			if (checksum != cacheKey.checksum) return false;
			if (count != cacheKey.count) return false;

			int listCount = paramList.Count;
            for (int i = 0; i < listCount; i++) 
			{
				object thisParam = paramList[i];
				object thatParam = cacheKey.paramList[i];
				if(thisParam == null) 
				{
					if (thatParam != null) return false;
				} 
				else 
				{
					if (!thisParam.Equals(thatParam)) return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Get the HashCode for this CacheKey
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() 
		{
			return hashCode;
		}

		/// <summary>
		/// ToString implementation.
		/// </summary>
		/// <returns>A string that give the CacheKey HashCode.</returns>
		public override string ToString() 
		{
			return new StringBuilder().Append(hashCode).Append('|').Append(checksum).ToString();
		}

	}
}
