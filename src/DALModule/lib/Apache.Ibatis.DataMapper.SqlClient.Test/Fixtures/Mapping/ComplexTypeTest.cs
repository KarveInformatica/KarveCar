using System.Collections;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ComplexTypeTest.
    /// </summary>
    [TestFixture] 
    public class ComplexTypeTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void Init() 
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        #region Complex type tests

        /// <summary>
        /// Complex type test
        /// </summary>
        [Test] 
        public void TestMapObjMap() 
        {
            Hashtable map = new Hashtable();
            Complex obj = new Complex();
            obj.Map = new Hashtable();
            obj.Map.Add("Id", 1);
            map.Add("obj", obj);
		    
            int id = (int)dataMapper.QueryForObject("ComplexMap", map);

            Assert.AreEqual(id, obj.Map["Id"]);
        }

        /// <summary>
        /// Complex type insert inline default null test
        /// </summary>
        [Test] 
        public void TestInsertMapObjMapAcctInlineDefaultNull() 
        {
            Hashtable map = new Hashtable();
            Account acct = NewAccount6();
            Complex obj = new Complex();
            obj.Map = new Hashtable();
            obj.Map.Add("acct", acct);
            map.Add("obj", obj);

            dataMapper.Insert("InsertComplexAccountViaInlineDefaultNull", map);

            Account account = (Account) dataMapper.QueryForObject("GetAccountNullableEmail", 6);

            AssertAccount6(account);
        }

        #endregion


    }
}