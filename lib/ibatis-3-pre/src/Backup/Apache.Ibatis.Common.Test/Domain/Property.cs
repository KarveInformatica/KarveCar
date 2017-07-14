using System;

namespace Apache.Ibatis.Common.Test.Domain
{
    public enum Days : int
    {
        Sat = 1,
        Sun = 2,
        Mon = 3,
        Tue = 4,
        Wed = 5,
        Thu = 6,
        Fri = 7
    };

	/// <summary>
	/// Summary description for Property.
	/// </summary>
	public class Property
	{
        public string publicString = string.Empty;
        public int publicInt = int.MinValue;
        public DateTime publicDateTime = DateTime.MinValue;
        public decimal publicDecimal = decimal.MinValue;
        public sbyte publicSbyte = sbyte.MinValue;
        public byte publicByte = byte.MinValue;
        public char publicChar = char.MinValue;
        public short publicShort = short.MinValue;
        public ushort publicUshort = ushort.MinValue;
        public uint publicUint = uint.MinValue;
        public long publicLong = long.MinValue;
        public ulong publicUlong = ulong.MinValue;
        public bool publicBool = false;
        public double publicDouble = double.MinValue;
        public float publicFloat = float.MinValue;
        public Guid publicGuid = Guid.Empty;
        public TimeSpan publicTimeSpan = TimeSpan.MinValue;
        public Account publicAccount = null;
        public Days publicDay;
	    
		private string _string = string.Empty;
        private int _int = int.MinValue;
		private DateTime _dateTime = DateTime.MinValue;
		private decimal _decimal = decimal.MinValue;
		private sbyte _sbyte = sbyte.MinValue;
		private byte _byte = byte.MinValue;
		private char _char = char.MinValue;
		private short _short = short.MinValue;
		private ushort _ushort = ushort.MinValue;
		private uint _uint = uint.MinValue;
		private long _long = long.MinValue;
		private ulong _ulong = ulong.MinValue;
		private bool _bool = false;
		private double _double = double.MinValue;
		private float _float = float.MinValue;
		private Guid _guid = Guid.Empty;
		private TimeSpan _timeSpan = TimeSpan.MinValue;
		private Account _account = null;
        private Days _day;

        protected string protectedString = string.Empty;
        protected int protectedInt = int.MinValue;
        protected DateTime protectedDateTime = DateTime.MinValue;
        protected decimal protectedDecimal = decimal.MinValue;
        protected sbyte protectedSbyte = sbyte.MinValue;
        protected byte protectedByte = byte.MinValue;
        protected char protectedChar = char.MinValue;
        protected short protectedShort = short.MinValue;
        protected ushort protectedUshort = ushort.MinValue;
        protected uint protectedUint = uint.MinValue;
        protected long protectedLong = long.MinValue;
        protected ulong protectedUlong = ulong.MinValue;
        protected bool protectedBool = false;
        protected double protectedDouble = double.MinValue;
        protected float protectedFloat = float.MinValue;
        protected Guid protectedGuid = Guid.Empty;
        protected TimeSpan protectedTimeSpan = TimeSpan.MinValue;
        protected Account protectedAccount = null;
        protected Days protectedDay;

        private Int32? _intNullable = null;
        public Int32? publicintNullable = null;
        protected Int32? protectedintNullable = null;

        public Int32? IntNullable
        {
            get { return _intNullable; }
            set { _intNullable = value; }
        }

		public Property()
        {
        }

        public Days Day
        {
            get { return _day; }
            set { _day = value; }
        }

		public string String
		{
			get { return _string; }
			set { _string = value; }
		}

		public virtual int Int
		{
			get { return _int; }
			set { _int = value; }
		}

		public virtual DateTime DateTime
		{
			get { return _dateTime; }
			set { _dateTime = value; }
		}

		public decimal Decimal
		{
			get { return _decimal; }
			set { _decimal = value; }
		}

		public sbyte SByte
		{
			get { return _sbyte; }
			set { _sbyte = value; }
		}

		public byte Byte
		{
			get { return _byte; }
			set { _byte = value; }
		}

		public char Char
		{
			get { return _char; }
			set { _char = value; }
		}

		public short Short
		{
			get { return _short; }
			set { _short = value; }
		}

		public ushort UShort
		{
			get { return _ushort; }
			set { _ushort = value; }
		}

		public uint UInt
		{
			get { return _uint; }
			set { _uint = value; }
		}

		public long Long
		{
			get { return _long; }
			set { _long = value; }
		}

		public ulong ULong
		{
			get { return _ulong; }
			set { _ulong = value; }
		}

		public bool Bool
		{
			get { return _bool; }
			set { _bool = value; }
		}

		public virtual double Double
		{
			get { return _double; }
			set { _double = value; }
		}

		public float Float
		{
			get { return _float; }
			set { _float = value; }
		}

		public Guid Guid
		{
			get { return _guid; }
			set { _guid = value; }
		}

		public virtual TimeSpan TimeSpan
		{
			get { return _timeSpan; }
			set { _timeSpan = value; }
		}

		public virtual Account Account
		{
			get { return _account; }
			set { _account = value; }
		}
	}


    public class PropertySon : Property
    {
        private int _int = int.MinValue;
        private int _float = int.MinValue;

        private int PrivateIndex
        {
            set { _int = value; }
        }

        public int Index
        {
            get { return _int; }
            protected set { _int = value; }
        }

        public override Account Account
        {
            get { return new Account(Days.Wed); }
            set { throw new InvalidOperationException("Test virtual"); }
        }

        public override int Int
        {
            get { return -88; }
            set { throw new InvalidOperationException("Test virtual"); }
        }

        public override DateTime DateTime
        {
            get { return new DateTime(2000,1,1); }
            set { throw new InvalidOperationException("Test virtual"); }
        }

        public new int Float
        {
            get { return _float; }
            set { _float = value*2; }
        }

        private SpecialReference<Account> _referenceAccount = null;
        public SpecialReference<Account> ReferenceAccount
        {
            get { return _referenceAccount; }
            set { _referenceAccount = value; }
        }
        
    }
    
    public class SpecialReference<T> where T : class
    {
        private T _value =null;
        
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    
}
