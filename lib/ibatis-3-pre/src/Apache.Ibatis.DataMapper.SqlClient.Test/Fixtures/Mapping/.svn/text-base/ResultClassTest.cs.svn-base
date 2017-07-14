using System;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;

using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ResultClassTest.
    /// </summary>
    [TestFixture] 
    public class ResultClassTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void Init() 
        {
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        #region Specific statement test

        /// <summary>
        ///  Test a boolean resultClass
        /// </summary>
        [Test]
        public void TestBoolean() 
        {
            bool bit = (bool) dataMapper.QueryForObject("GetBoolean", 1);

            Assert.AreEqual(true, bit);
        }

        /// <summary>
        ///  Test a boolean implicit resultClass
        /// </summary>
        [Test]
        public void TestBooleanWithoutResultClass() 
        {
            bool bit = Convert.ToBoolean(dataMapper.QueryForObject("GetBooleanWithoutResultClass", 1));

            Assert.AreEqual(true, bit);
        }

        /// <summary>
        ///  Test a byte resultClass
        /// </summary>
        [Test] 
        public void TestByte() 
        {
            byte letter = (byte) dataMapper.QueryForObject("GetByte", 1);

            Assert.AreEqual(155, letter);
        }

        /// <summary>
        ///  Test a byte implicit resultClass
        /// </summary>
        [Test] 
        public void TestByteWithoutResultClass() 
        {
            byte letter = Convert.ToByte(dataMapper.QueryForObject("GetByteWithoutResultClass", 1));

            Assert.AreEqual(155, letter);
        }

        /// <summary>
        ///  Test a char resultClass
        /// </summary>
        [Test] 
        public void TestChar() 
        {
            char letter = (char) dataMapper.QueryForObject("GetChar", 1);

            Assert.AreEqual('a', letter);
        }

        /// <summary>
        ///  Test a char implicit resultClass
        /// </summary>
        [Test] 
        public void TestCharWithoutResultClass() 
        {
            char letter = Convert.ToChar(dataMapper.QueryForObject("GetCharWithoutResultClass", 1));

            Assert.AreEqual('a', letter);
        }

        /// <summary>
        ///  Test a DateTime resultClass
        /// </summary>
        [Test] 
        public void TestDateTime() 
        {
            DateTime orderDate = (DateTime) dataMapper.QueryForObject("GetDate", 1);

            System.DateTime date = new DateTime(2003, 2, 15, 8, 15, 00);

            Assert.AreEqual(date.ToString(), orderDate.ToString());
        }

        /// <summary>
        ///  Test a DateTime implicit resultClass
        /// </summary>
        [Test] 
        public void TestDateTimeWithoutResultClass() 
        {
            DateTime orderDate = Convert.ToDateTime(dataMapper.QueryForObject("GetDateWithoutResultClass", 1));

            System.DateTime date = new DateTime(2003, 2, 15, 8, 15, 00);

            Assert.AreEqual(date.ToString(), orderDate.ToString());
        }

        /// <summary>
        ///  Test a decimal resultClass
        /// </summary>
        [Test] 
        public void TestDecimal() 
        {
            decimal price = (decimal) dataMapper.QueryForObject("GetDecimal", 1);

            Assert.AreEqual((decimal)1.56, price);
        }

        /// <summary>
        ///  Test a decimal implicit resultClass
        /// </summary>
        [Test] 
        public void TestDecimalWithoutResultClass() 
        {
            decimal price = Convert.ToDecimal(dataMapper.QueryForObject("GetDecimalWithoutResultClass", 1));

            Assert.AreEqual((decimal)1.56, price);
        }

        /// <summary>
        ///  Test a double resultClass
        /// </summary>
        [Test] 
        public void TestDouble() 
        {
            double price = (double) dataMapper.QueryForObject("GetDouble", 1);

            Assert.AreEqual(99.5f, price);
        }

        /// <summary>
        ///  Test a double implicit resultClass
        /// </summary>
        [Test] 
        public void TestDoubleWithoutResultClass() 
        {
            double price = Convert.ToDouble(dataMapper.QueryForObject("GetDoubleWithoutResultClass", 1));

            Assert.AreEqual(99.5f, price);
        }

        /// <summary>
        ///  IBATISNET-25 Error applying ResultMap when using 'Guid' in resultClass
        /// </summary>
        [Test] 
        public void TestGuid() 
        {
            Guid newGuid = new Guid("CD5ABF17-4BBC-4C86-92F1-257735414CF4");

            Guid guid = (Guid) dataMapper.QueryForObject("GetGuid", 1);

            Assert.AreEqual(newGuid, guid);
        }

        /// <summary>
        /// Test a Guid implicit resultClass
        /// </summary>
        [Test] 
        public void TestGuidWithoutResultClass()
        {
            Guid newGuid = new Guid("CD5ABF17-4BBC-4C86-92F1-257735414CF4");

            string guidString = Convert.ToString(dataMapper.QueryForObject("GetGuidWithoutResultClass", 1));

            Guid guid = new Guid(guidString);

            Assert.AreEqual(newGuid, guid);
        }

        /// <summary>
        ///  Test a int16 resultClass
        /// </summary>
        [Test] 
        public void TestInt16() 
        {
            short integer = (short) dataMapper.QueryForObject("GetInt16", 1);

            Assert.AreEqual(32111, integer);
        }

        /// <summary>
        ///  Test a int16 implicit resultClass
        /// </summary>
        [Test] 
        public void TestInt16WithoutResultClass() 
        {
            short integer = Convert.ToInt16(dataMapper.QueryForObject("GetInt16WithoutResultClass", 1));

            Assert.AreEqual(32111, integer);
        }

        /// <summary>
        ///  Test a int 32 resultClass
        /// </summary>
        [Test] 

        public void TestInt32() 
        {
            int integer = (int) dataMapper.QueryForObject("GetInt32", 1);

            Assert.AreEqual(999999, integer);
        }

        /// <summary>
        ///  Test a int 32 implicit resultClass
        /// </summary>
        [Test] 

        public void TestInt32WithoutResultClass() 
        {
            int integer = Convert.ToInt32(dataMapper.QueryForObject("GetInt32WithoutResultClass", 1));

            Assert.AreEqual(999999, integer);
        }

        /// <summary>
        ///  Test a int64 resultClass
        /// </summary>
        [Test] 
        public void TestInt64() 
        {
            long bigInt = (long) dataMapper.QueryForObject("GetInt64", 1);

            Assert.AreEqual(9223372036854775800, bigInt);
        }

        /// <summary>
        ///  Test a int64 implicit resultClass
        /// </summary>
        [Test] 
        public void TestInt64WithoutResultClass() 
        {
            long bigInt = Convert.ToInt64(dataMapper.QueryForObject("GetInt64WithoutResultClass", 1));

            Assert.AreEqual(9223372036854775800, bigInt);
        }

        /// <summary>
        ///  Test a single/float resultClass
        /// </summary>
        [Test] 
        public void TestSingle() 
        {
            float price = (float)dataMapper.QueryForObject("GetSingle", 1);

            Assert.AreEqual(92233.5, price);
        }

        /// <summary>
        ///  Test a single/float implicit resultClass
        /// </summary>
        [Test] 
        public void TestSingleWithoutResultClass() 
        {
            double price = Convert.ToDouble(dataMapper.QueryForObject("GetSingleWithoutResultClass", 1));

            Assert.AreEqual(92233.5, price);
        }

        /// <summary>
        ///  Test a string resultClass
        /// </summary>
        [Test] 
        public void TestString() 
        {
            string cardType = dataMapper.QueryForObject("GetString", 1) as string;

            Assert.AreEqual("VISA", cardType);
        }

        /// <summary>
        ///  Test a string implicit resultClass
        /// </summary>
        [Test] 
        public void TestStringWithoutResultClass() 
        {
            string cardType = Convert.ToString(dataMapper.QueryForObject("GetStringWithoutResultClass", 1));

            Assert.AreEqual("VISA", cardType);
        }

        /// <summary>
        ///  Test a TimeSpan resultClass
        /// </summary>
        [Test] 
        [Ignore("To do")]
        public void TestTimeSpan() 
        {
            Guid newGuid = Guid.NewGuid();;
            Category category = new Category();
            category.Name = "toto";
            category.Guid = newGuid;

            int key = (int)dataMapper.Insert("InsertCategory", category);

            Guid guid = (Guid)dataMapper.QueryForObject("GetGuid", key);

            Assert.AreEqual(newGuid, guid);
        }

        /// <summary>
        ///  Test a TimeSpan implicit resultClass
        /// </summary>
        [Test] 
        [Ignore("To do")]
        public void TestTimeSpanWithoutResultClass() 
        {

        }
        #endregion
    }
}