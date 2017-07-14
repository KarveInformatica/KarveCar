using System;
using Apache.Ibatis.Common.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.Common.Test.Fixtures.Utilities
{
	/// <summary>
	/// Summary description for FieldAccessorTest.
	/// </summary>
	[TestFixture] 
	public class PrivateFieldAccessorTest : BaseMemberTest
	{

        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
		[SetUp]
		public void SetUp()
		{
            intSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_int");
            intGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_int");

            longSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_long");
            longGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_long");

            sbyteSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_sbyte");
            sbyteGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_sbyte");

            stringSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_string");
            stringGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_string");

            datetimeSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_dateTime");
            datetimeGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_dateTime");

            decimalSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_decimal");
            decimalGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_decimal");

            byteSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_byte");
            byteGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_byte");

            charSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_char");
            charGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_char");

            shortSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_short");
            shortGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_short");

            ushortSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_ushort");
            ushortGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_ushort");

            uintSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_uint");
            uintGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_uint");

            ulongSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_ulong");
            ulongGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_ulong");

            boolSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_bool");
            boolGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_bool");

            doubleSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_double");
            doubleGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_double");

            floatSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_float");
            floatGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_float");

            guidSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_guid");
            guidGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_guid");

            timespanSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_timeSpan");
            timespanGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_timeSpan");

            accountSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_account");
            accountGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_account");

            enumSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_day");
            enumGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_day");

            nullableSetAccessor = factorySet.CreateSetAccessor(typeof(Property), "_intNullable");
            nullableGetAccessor = factoryGet.CreateGetAccessor(typeof(Property), "_intNullable");
		}


        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        {
        }

        #endregion


        private T GetDefault<T>()
        {
            T frm = default(T);
            return frm;
        }

        /// <summary>
        /// Test Default value.
        /// </summary>
        [Test]
        public void TestDefault()
        {
            Console.WriteLine("DateTime : " + GetDefault<DateTime>());
            Console.WriteLine("TimeSpan : " + GetDefault<TimeSpan>());
            Console.WriteLine("Guid : " + GetDefault<Guid>());
            Console.WriteLine("Decimal : " + GetDefault<Decimal>());
        }

        ///// <summary>
        ///// Test setting null on integer public field.
        ///// </summary>
        //[Test]
        //public void TestSetNullOnIntegerField()
        //{
        //    Property prop = new Property();
        //    prop.publicInt = -99;

        //    // Property accessor
        //    ISetAccessor setAccessor = factorySet.CreateSetAccessor(typeof(Property), "publicInt");
        //    setAccessor.Set(prop, null);
        //    Assert.AreEqual(0, prop.publicInt);
        //}

        ///// <summary>
        ///// Test setting an integer public field.
        ///// </summary>
        //[Test]
        //public void TestSetPublicFieldInteger()
        //{
        //    Property prop = new Property();
        //    prop.publicInt = -99;

        //    // Property accessor
        //    int test = 57;
        //    ISetAccessor setAccessor = factorySet.CreateSetAccessor(typeof(Property), "publicInt");
        //    setAccessor.Set(prop, test);
        //    Assert.AreEqual(test, prop.publicInt);
        //}

        ///// <summary>
        ///// Test getting an integer public field.
        ///// </summary>
        //[Test]
        //public void TestGetPublicFieldInteger()
        //{
        //    int test = -99;
        //    Property prop = new Property();
        //    prop.publicInt = test;

        //    // Property accessor
        //    IGetAccessor getAccessor = factoryGet.CreateGetAccessor(typeof(Property), "publicInt");
        //    Assert.AreEqual(test, getAccessor.Get(prop));
        //}

        ///// <summary>
        ///// Test setting null on String public field.
        ///// </summary>
        //[Test]
        //public void TestSetNullOnStringField()
        //{
        //    Property prop = new Property();
        //    prop.publicString = "hello";

        //    // Property accessor
        //    ISetAccessor setAccessor = factorySet.CreateSetAccessor(typeof(Property), "publicString");
        //    setAccessor.Set(prop, null);
        //    Assert.AreEqual(null, prop.publicString);
        //}

        ///// <summary>
        ///// Test setting an String public field.
        ///// </summary>
        //[Test]
        //public void TestSetPublicFieldString()
        //{
        //    Property prop = new Property();
        //    prop.publicString = "hello";

        //    // Property accessor
        //    string test = "gilles";
        //    ISetAccessor setAccessor = factorySet.CreateSetAccessor(typeof(Property), "publicString");
        //    setAccessor.Set(prop, test);
        //    Assert.AreEqual(test, prop.publicString);
        //}

        ///// <summary>
        ///// Test getting an String public field.
        ///// </summary>
        //[Test]
        //public void TestGetPublicFieldString()
        //{
        //    string test = "gilles";
        //    Property prop = new Property();
        //    prop.publicString = test;

        //    // Property accessor
        //    IGetAccessor getAccessor = factoryGet.CreateGetAccessor(typeof(Property), "publicString");
        //    Assert.AreEqual(test, getAccessor.Get(prop));
        //}
	}
}
