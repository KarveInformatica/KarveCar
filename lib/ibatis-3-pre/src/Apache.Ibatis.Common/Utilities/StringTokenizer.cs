
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

using System.Collections;

namespace Apache.Ibatis.Common.Utilities
{
		
	/// <summary>
	/// A StringTokenizer java like object 
    /// Allows to break a string into tokens
	/// </summary>
	public sealed class StringTokenizer : IEnumerable 
	{
		private const string DEFAULT_DELIM = " \t\n\r\f";
        private readonly string  origin = string.Empty;
        private readonly string delimiters = string.Empty;
        private readonly bool returnDelimiters = false;

		/// <summary>
		/// Constructs a StringTokenizer on the specified String, using the
		/// default delimiter set (which is " \t\n\r\f").
		/// </summary>
		/// <param name="str">The input String</param>
		public StringTokenizer(string str) 
		{
			origin = str;
			delimiters = DEFAULT_DELIM;
			returnDelimiters = false;
		}


		/// <summary>
		/// Constructs a StringTokenizer on the specified String, 
		/// using the specified delimiter set.
		/// </summary>
		/// <param name="str">The input String</param>
		/// <param name="delimiters">The delimiter String</param>
		public StringTokenizer(string str, string delimiters) 
		{
			origin = str;
			this.delimiters = delimiters;
			returnDelimiters = false;
		}


		/// <summary>
		/// Constructs a StringTokenizer on the specified String, 
		/// using the specified delimiter set.
		/// </summary>
		/// <param name="str">The input String</param>
		/// <param name="delimiters">The delimiter String</param>
		/// <param name="returnDelimiters">Returns delimiters as tokens or skip them</param>
		public StringTokenizer(string str, string delimiters, bool returnDelimiters) 
		{
			origin = str;
			this.delimiters = delimiters;
			this.returnDelimiters = returnDelimiters;
		}


        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
		public IEnumerator GetEnumerator() 
		{
			return new StringTokenizerEnumerator(this);
		}


		/// <summary>
		/// Returns the number of tokens in the String using
		/// the current deliminter set.  This is the number of times
		/// nextToken() can return before it will generate an exception.
		/// Use of this routine to count the number of tokens is faster
		/// than repeatedly calling nextToken() because the substrings
		/// are not constructed and returned for each token.
		/// </summary>
		public int TokenNumber
		{
			get
			{
				int count = 0;
				int currpos = 0;
				int maxPosition = origin.Length;

				while (currpos < maxPosition) 
				{
					while (!returnDelimiters &&
						(currpos < maxPosition) &&
						(delimiters.IndexOf(origin[currpos]) >= 0))
					{
						currpos++;
					}

					if (currpos >= maxPosition)
					{
						break;
					}

					int start = currpos;
					while ((currpos < maxPosition) && 
						(delimiters.IndexOf(origin[currpos]) < 0))
					{
						currpos++;
					}
					if (returnDelimiters && (start == currpos) &&
						(delimiters.IndexOf(origin[currpos]) >= 0))
					{
						currpos++;
					}
					count++;
				}
				return count;

			}

		}


		private sealed class StringTokenizerEnumerator : IEnumerator 
		{
			private readonly StringTokenizer stokenizer;
			private int cursor = 0;
			private string next = null;
		
			public StringTokenizerEnumerator(StringTokenizer stok) 
			{
				stokenizer = stok;
			}

			public bool MoveNext() 
			{
				next = GetNext();
				return next != null;
			}

			public void Reset() 
			{
				cursor = 0;
			}

			public object Current 
			{
				get 
				{
					return next;
				}
			}

			private string GetNext() 
			{
			    if( cursor >= stokenizer.origin.Length )
					return null;

				char c = stokenizer.origin[cursor];
				bool isDelim = (stokenizer.delimiters.IndexOf(c) != -1);
			
				if ( isDelim ) 
				{
					cursor++;
					if ( stokenizer.returnDelimiters ) 
					{
						return c.ToString();
					}
					return GetNext();
				}

				int nextDelimPos = stokenizer.origin.IndexOfAny(stokenizer.delimiters.ToCharArray(), cursor);
				if (nextDelimPos == -1) 
				{
					nextDelimPos = stokenizer.origin.Length;
				}

				string nextToken = stokenizer.origin.Substring(cursor, nextDelimPos - cursor);
				cursor = nextDelimPos;
				return nextToken;
			}

		}
	}

}
