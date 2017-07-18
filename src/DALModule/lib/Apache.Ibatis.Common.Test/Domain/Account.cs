using System;

namespace Apache.Ibatis.Common.Test.Domain
{
	/// <summary>
	/// Account.
	/// </summary>
	[Serializable]
	public class Account
	{
		private int _id = 0;
		private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _emailAddress = string.Empty;
		private int[] _ids = null;
		private string _test = string.Empty;
		private Days _days ;
		private Property _prop = null ;
		private DateTime _date = DateTime.MinValue;

		public Account()
		{}

        public Account(int[] ids)
        {
            _ids = ids;
        }

		public Account(DateTime date)
		{
			_date = date;
		}

		public Account(int id)
		{
			_id = id;
		}

		public Account(string test)
		{
			_test = test;
		}

		public Account(Days days)
		{
			_days = days;
		}

		public Account(Property prop)
		{
			_prop = prop;
		}

		public Account(string firstName, Property prop)
		{
			_firstName = firstName;
			_prop = prop;
		}

		public Property Property
		{
			get { return _prop; }
		}

		public DateTime Date
		{
			get { return _date; }
		}

		public Days Days
		{
			get { return _days; }
		}

		public string Test
		{
			get { return _test; }
		}

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public string EmailAddress
		{
			get { return _emailAddress; }
			set { _emailAddress = value; }
		}

		public int[] Ids
		{
			get { return _ids; }
			set { _ids = value; }
		}
	}
}
