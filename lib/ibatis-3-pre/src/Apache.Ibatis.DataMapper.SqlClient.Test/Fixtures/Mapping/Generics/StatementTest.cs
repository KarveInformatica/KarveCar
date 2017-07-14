#region Apache Notice
/*****************************************************************************
 * $Revision: 470514 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008, 2005 The Apache Software Foundation
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


using System;
using System.Collections;
using System.Collections.Generic;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Generics
{
    [TestFixture]
    public class StatementTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void Init()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "order-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "line-item-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "enumeration-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "other-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */
        }

        #endregion

        #region Object Query tests

        /// <summary>
        /// Test Open connection with a connection string
        /// </summary>
        [Test]
        public void TestOpenConnection()
        {
            ISessionFactory sessionFactory = ((IModelStoreAccessor)dataMapper).ModelStore.SessionFactory;

            ISession session = sessionFactory.OpenSession();
            Account account = dataMapper.QueryForObject<Account>("SelectWithProperty", null);
            session.Close();

            AssertAccount1(account);
        }

        /// <summary>
        /// Test use a statement with property subtitution
        /// (JIRA 22)
        /// </summary>
        [Test]
        public void TestSelectWithProperty()
        {
            Account account = dataMapper.QueryForObject<Account>("SelectWithProperty", null);
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject Via ColumnName
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaColumnName()
        {
            Account account = dataMapper.QueryForObject<Account>("GetAccountViaColumnName", 1);
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject Via ColumnIndex
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaColumnIndex()
        {
            Account account = dataMapper.QueryForObject<Account>("GetAccountViaColumnIndex", 1);
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject Via ResultClass
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaResultClass()
        {
            Account account = dataMapper.QueryForObject<Account>("GetAccountViaResultClass", 1);
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject With simple ResultClass : string
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithSimpleResultClass()
        {
            string email = dataMapper.QueryForObject<string>("GetEmailAddressViaResultClass", 1);
            Assert.AreEqual("Joe.Dalton@somewhere.com", email);
        }

        /// <summary>
        /// Test ExecuteQueryForObject With simple ResultMap : string
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithSimpleResultMap()
        {
            string email = dataMapper.QueryForObject<string>("GetEmailAddressViaResultMap", 1);
            Assert.AreEqual("Joe.Dalton@somewhere.com", email);
        }

        /// <summary>
        /// Test Primitive ReturnValue : System.DateTime
        /// </summary>
        [Test]
        public void TestPrimitiveReturnValue()
        {
            DateTime CardExpiry = dataMapper.QueryForObject<DateTime>("GetOrderCardExpiryViaResultClass", 1);
            Assert.AreEqual(new DateTime(2003, 02, 15, 8, 15, 00), CardExpiry);
        }

        /// <summary>
        /// Test ExecuteQueryForObject with result object : Account
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithResultObject()
        {
            Account account = new Account();
            Account testAccount = dataMapper.QueryForObject<Account>("GetAccountViaColumnName", 1, account);
            AssertAccount1(account);
            Assert.IsTrue(account == testAccount);
        }

        /// <summary>
        /// Test ExecuteQueryForObject as Hashtable
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectAsHashtable()
        {
            Hashtable account = dataMapper.QueryForObject<Hashtable>("GetAccountAsHashtable", 1);
            AssertAccount1AsHashtable(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject as Hashtable ResultClass
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectAsHashtableResultClass()
        {
            Hashtable account = dataMapper.QueryForObject<Hashtable>("GetAccountAsHashtableResultClass", 1);
            AssertAccount1AsHashtableForResultClass(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject via Hashtable
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaHashtable()
        {
            Hashtable param = new Hashtable();
            param.Add("LineItem_ID", 4);
            param.Add("Order_ID", 9);

            LineItem testItem = dataMapper.QueryForObject<LineItem>("GetSpecificLineItem", param);

            Assert.IsNotNull(testItem);
            Assert.AreEqual("TSM-12", testItem.Code);
        }

        /// <summary>
        /// Test Query Dynamic Sql Element
        /// </summary>
        [Test]
        public void TestQueryDynamicSqlElement()
        {
            IList<string> list = dataMapper.QueryForList<string>("GetDynamicOrderedEmailAddressesViaResultMap", "Account_ID");

            Assert.AreEqual("Joe.Dalton@somewhere.com", list[0]);

            list = dataMapper.QueryForList<string>("GetDynamicOrderedEmailAddressesViaResultMap", "Account_FirstName");

            Assert.AreEqual("Averel.Dalton@somewhere.com", list[0]);

        }

        /// <summary>
        /// Test Execute QueryForList With ResultMap With Dynamic Element
        /// </summary>
        [Test]
        public void TestExecuteQueryForListWithResultMapWithDynamicElement()
        {
            IList<Account> list = dataMapper.QueryForList<Account>("GetAllAccountsViaResultMapWithDynamicElement", "LIKE");

            AssertAccount1(list[0]);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual(4, list[2].Id);

            list = dataMapper.QueryForList<Account>("GetAllAccountsViaResultMapWithDynamicElement", "=");

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Test Simple Dynamic Substitution
        /// </summary>
        [Test]
        [Ignore("No longer supported.")]
        public void TestSimpleDynamicSubstitution()
        {
            string statement = "select" + "    Account_ID          as Id," + "    Account_FirstName   as FirstName," + "    Account_LastName    as LastName," + "    Account_Email       as EmailAddress" + "  from Accounts" + "  WHERE Account_ID = #id#";

            Hashtable param = new Hashtable();
            param.Add("id", 1);
            param.Add("statement", statement);


            IList list = dataMapper.QueryForList("SimpleDynamicSubstitution", param);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test Get Account Via Inline Parameters
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaInlineParameters()
        {
            Account account = new Account();
            account.Id = 1;

            Account testAccount = dataMapper.QueryForObject<Account>("GetAccountViaInlineParameters", account);

            AssertAccount1(testAccount);
        }

        /// <summary>
        /// Test ExecuteQuery For Object With Enum property
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithEnum()
        {
            Enumeration enumClass = dataMapper.QueryForObject<Enumeration>("GetEnumeration", 1);

            Assert.AreEqual(enumClass.Day, Days.Sat);
            Assert.AreEqual(enumClass.Color, Colors.Red);
            Assert.AreEqual(enumClass.Month, Months.August);

            enumClass = dataMapper.QueryForObject("GetEnumeration", 3) as Enumeration;

            Assert.AreEqual(enumClass.Day, Days.Mon);
            Assert.AreEqual(enumClass.Color, Colors.Blue);
            Assert.AreEqual(enumClass.Month, Months.September);
        }

        #endregion

        #region  List Query tests

        /// <summary>
        /// Test QueryForList with Hashtable ResultMap
        /// </summary>
        [Test]
        public void TestQueryForListWithGeneric()
        {
            List<Account> accounts = new List<Account>();

            dataMapper.QueryForList("GetAllAccountsViaResultMap", null, (IList)accounts);

            AssertAccount1(accounts[0]);
            Assert.AreEqual(5, accounts.Count);
            Assert.AreEqual(1, accounts[0].Id);
            Assert.AreEqual(2, accounts[1].Id);
            Assert.AreEqual(3, accounts[2].Id);
            Assert.AreEqual(4, accounts[3].Id);
            Assert.AreEqual(5, accounts[4].Id);
        }

        /// <summary>
        /// Test QueryForList with Hashtable ResultMap
        /// </summary>
        [Test]
        public void TestQueryForListWithHashtableResultMap()
        {
            IList<Hashtable> list = dataMapper.QueryForList<Hashtable>("GetAllAccountsAsHashMapViaResultMap", null);

            AssertAccount1AsHashtable(list[0]);
            Assert.AreEqual(5, list.Count);

            Assert.AreEqual(1, list[0]["Id"]);
            Assert.AreEqual(2, list[1]["Id"]);
            Assert.AreEqual(3, list[2]["Id"]);
            Assert.AreEqual(4, list[3]["Id"]);
            Assert.AreEqual(5, list[4]["Id"]);
        }

        /// <summary>
        /// Test QueryForList with Hashtable ResultClass
        /// </summary>
        [Test]
        public void TestQueryForListWithHashtableResultClass()
        {
            IList<Hashtable> list = dataMapper.QueryForList<Hashtable>("GetAllAccountsAsHashtableViaResultClass", null);

            AssertAccount1AsHashtableForResultClass(list[0]);
            Assert.AreEqual(5, list.Count);

            Assert.AreEqual(1, list[0][ConvertKey("Id")]);
            Assert.AreEqual(2, list[1][ConvertKey("Id")]);
            Assert.AreEqual(3, list[2][ConvertKey("Id")]);
            Assert.AreEqual(4, list[3][ConvertKey("Id")]);
            Assert.AreEqual(5, list[4][ConvertKey("Id")]);
        }

        /// <summary>
        /// Test QueryForList with IList ResultClass
        /// </summary>
        [Test]
        public void TestQueryForListWithIListResultClass()
        {
            IList<IList> list = dataMapper.QueryForList<IList>("GetAllAccountsAsArrayListViaResultClass", null);

            IList listAccount = list[0];
            Assert.AreEqual(1, listAccount[0]);
            Assert.AreEqual("Joe", listAccount[1]);
            Assert.AreEqual("Dalton", listAccount[2]);
            Assert.AreEqual("Joe.Dalton@somewhere.com", listAccount[3]);

            Assert.AreEqual(5, list.Count);

            listAccount = (IList)list[0];
            Assert.AreEqual(1, listAccount[0]);
            listAccount = (IList)list[1];
            Assert.AreEqual(2, listAccount[0]);
            listAccount = (IList)list[2];
            Assert.AreEqual(3, listAccount[0]);
            listAccount = (IList)list[3];
            Assert.AreEqual(4, listAccount[0]);
            listAccount = (IList)list[4];
            Assert.AreEqual(5, listAccount[0]);
        }

        /// <summary>
        /// Test QueryForList With ResultMap, result collection as ArrayList
        /// </summary>
        [Test]
        public void TestQueryForListWithResultMap()
        {
            IList<Account> list = dataMapper.QueryForList<Account>("GetAllAccountsViaResultMap", null);

            AssertAccount1(list[0]);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual(3, list[2].Id);
            Assert.AreEqual(4, list[3].Id);
            Assert.AreEqual(5, list[4].Id);
        }

        /// <summary>
        /// Test QueryForList with ResultObject : 
        /// AccountCollection strongly typed collection
        /// </summary>
        [Test]
        public void TestQueryForListWithResultObject()
        {
            IList<Account> accounts = new List<Account>();

            dataMapper.QueryForList("GetAllAccountsViaResultMap", null, accounts);

            AssertAccount1(accounts[0]);
            Assert.AreEqual(5, accounts.Count);
            Assert.AreEqual(1, accounts[0].Id);
            Assert.AreEqual(2, accounts[1].Id);
            Assert.AreEqual(3, accounts[2].Id);
            Assert.AreEqual(4, accounts[3].Id);
            Assert.AreEqual(5, accounts[4].Id);
        }


        /// <summary>
        /// Test QueryForList with no result.
        /// </summary>
        [Test]
        public void TestQueryForListWithNoResult()
        {
            IList<Account> list = dataMapper.QueryForList<Account>("GetNoAccountsViaResultMap", null);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Test QueryForList with ResultClass : Account.
        /// </summary>
        [Test]
        public void TestQueryForListResultClass()
        {
            IList<Account> list = dataMapper.QueryForList<Account>("GetAllAccountsViaResultClass", null);

            AssertAccount1(list[0]);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual(3, list[2].Id);
            Assert.AreEqual(4, list[3].Id);
            Assert.AreEqual(5, list[4].Id);
        }

        /// <summary>
        /// Test QueryForList with simple resultClass : string
        /// </summary>
        [Test]
        public void TestQueryForListWithSimpleResultClass()
        {
            IList<string> list = dataMapper.QueryForList<string>("GetAllEmailAddressesViaResultClass", null);

            Assert.AreEqual("Joe.Dalton@somewhere.com", list[0]);
            Assert.AreEqual("Averel.Dalton@somewhere.com", list[1]);
            Assert.IsNull(list[2]);
            Assert.AreEqual("Jack.Dalton@somewhere.com", list[3]);
            Assert.AreEqual("gilles.bayon@nospam.org", list[4]);
        }

        /// <summary>
        /// Test  QueryForList with simple ResultMap : string
        /// </summary>
        [Test]
        public void TestQueryForListWithSimpleResultMap()
        {
            IList<string> list = dataMapper.QueryForList<string>("GetAllEmailAddressesViaResultMap", null);

            Assert.AreEqual("Joe.Dalton@somewhere.com", list[0]);
            Assert.AreEqual("Averel.Dalton@somewhere.com", list[1]);
            Assert.IsNull(list[2]);
            Assert.AreEqual("Jack.Dalton@somewhere.com", list[3]);
            Assert.AreEqual("gilles.bayon@nospam.org", list[4]);
        }


        [Test]
        public void TestQueryWithRowDelegate()
        {
            _index = 0;
            RowDelegate<Account> handler = new RowDelegate<Account>(this.RowHandler);

            IList<Account> list = dataMapper.QueryWithRowDelegate<Account>("GetAllAccountsViaResultMap", null, handler);

            Assert.AreEqual(5, _index);
            Assert.AreEqual(5, list.Count);
            AssertAccount1(list[0]);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual(3, list[2].Id);
            Assert.AreEqual(4, list[3].Id);
            Assert.AreEqual(5, list[4].Id);

        }

        /// <summary>
        /// Test QueryForList with constructor use on result object
        /// </summary>
        [Test, Description("JIRA 172")]
        public void Use_QueryForList_with_constructor_on_resul_object()
        {
            IList<Order> list = dataMapper.QueryForList<Order>("GetManyOrderWithConstructor", null);
            Assert.IsTrue(list.Count > 0);
        }

        #endregion

        #region Row delegate

        private int _index = 0;

        public void RowHandler(object obj, object paramterObject, IList<Account> list)
        {
            _index++;

            Assert.AreEqual(_index, ((Account)obj).Id);
            list.Add(((Account)obj));
        }

        #endregion

        #region QueryForDictionary
        /// <summary>
        /// Test ExecuteQueryForDictionary 
        /// </summary>
        [Test]
        public void TestExecuteQueryForDictionary()
        {
            IDictionary<string, Account> map = dataMapper.QueryForDictionary<string, Account>("GetAllAccountsViaResultClass", null, "FirstName");

            Assert.AreEqual(5, map.Count);
            AssertAccount1(map["Joe"]);

            Assert.AreEqual(1, map["Joe"].Id);
            Assert.AreEqual(2, map["Averel"].Id);
            Assert.AreEqual(3, map["William"].Id);
            Assert.AreEqual(4, map["Jack"].Id);
            Assert.AreEqual(5, map["Gilles"].Id);
        }

        /// <summary>
        /// Test ExecuteQueryForDictionary With Cache.
        /// </summary>
        [Test]
        public void TestExecuteQueryQueryForDictionaryWithCache()
        {
            IDictionary<string, Account> map = dataMapper.QueryForDictionary<string, Account>("GetAllAccountsCache", null, "FirstName");

            int firstId = HashCodeProvider.GetIdentityHashCode(map);

            Assert.AreEqual(5, map.Count);
            AssertAccount1(map["Joe"]);

            Assert.AreEqual(1, map["Joe"].Id);
            Assert.AreEqual(2, map["Averel"].Id);
            Assert.AreEqual(3, map["William"].Id);
            Assert.AreEqual(4, map["Jack"].Id);
            Assert.AreEqual(5, map["Gilles"].Id);

            map = dataMapper.QueryForDictionary<string, Account>("GetAllAccountsCache", null, "FirstName");

            int secondId = HashCodeProvider.GetIdentityHashCode(map);

            Assert.AreEqual(firstId, secondId);
        }

        /// <summary>
        /// Test ExecuteQueryForMap : Hashtable.
        /// </summary>
        /// <remarks>
        /// If the keyProperty is an integer, you must acces the map
        /// by map[integer] and not by map["integer"]
        /// </remarks>
        [Test]
        public void TestExecuteQueryForDictionary2()
        {
            IDictionary<string, Order> map = dataMapper.QueryForDictionary<string, Order>("GetAllOrderWithLineItems", null, "PostalCode");

            Assert.AreEqual(11, map.Count);
            Order order = map["T4H 9G4"];

            Assert.AreEqual(2, order.LineItemsIList.Count);
        }

        /// <summary>
        /// Test ExecuteQueryForMap with value property :
        /// "FirstName" as key, "EmailAddress" as value
        /// </summary>
        [Test]
        public void TestExecuteQueryForDictionaryWithValueProperty()
        {
            IDictionary<string, string> map = dataMapper.QueryForDictionary<string, string>("GetAllAccountsViaResultClass", null, "FirstName", "EmailAddress");

            Assert.AreEqual(5, map.Count);

            Assert.AreEqual("Joe.Dalton@somewhere.com", map["Joe"]);
            Assert.AreEqual("Averel.Dalton@somewhere.com", map["Averel"]);
            Assert.IsNull(map["William"]);
            Assert.AreEqual("Jack.Dalton@somewhere.com", map["Jack"]);
            Assert.AreEqual("gilles.bayon@nospam.org", map["Gilles"]);
        }

        #endregion
    }
}