using System;
using System.Collections;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ResultClassTest.
    /// </summary>
    [TestFixture] 
    public class ParameterClass : BaseTest
    {
        /// <summary>
        ///  Test passing DBNull.Value to a statement.
        /// </summary>
        [Test]
        public void TestDBNullValue()
        {
            int accountsWithNullEmail = (int)dataMapper.QueryForObject("GetCountOfAccountsWithNullEmail", null);

            Hashtable map = new Hashtable();
            map["DBNullValue"] = DBNull.Value;
            int rowsAffected = dataMapper.Update("UpdateNullEmailToDBNull", map);

            Assert.AreEqual(accountsWithNullEmail, rowsAffected);
        }
    }
}