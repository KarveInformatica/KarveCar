using System;

namespace Apache.Ibatis.Common.Test.Domain
{
	/// <summary>
	/// Summary description for Document.
	/// </summary>
	public abstract class Document
	{
		private DateTime _date = DateTime.MinValue;
		private int _nb = int.MinValue;
	
		public DateTime Creation
		{
			get { return _date;}
			set { _date = value;}
		}
		
		public int PageNumber
		{
			get { return _nb;}
		}
	}
}
