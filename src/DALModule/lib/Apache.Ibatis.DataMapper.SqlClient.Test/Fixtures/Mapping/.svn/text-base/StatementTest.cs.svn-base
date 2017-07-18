using System;
using System.Collections;
using System.Data;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.DataMapper.Model;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ParameterMapTest.
    /// </summary>
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
        /// Interface mapping
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA-283")]
        public void Result_mapping_on_interface_should_work()
        {
            BaseAccount account = new BaseAccount();

            dataMapper.QueryForObject<IAccount>("GetInterfaceAccount", 1, account);

            Assert.AreEqual(1, account.Id, "account.Id");
            Assert.AreEqual("Joe", account.FirstName, "account.FirstName");
            Assert.AreEqual("Dalton", account.LastName, "account.LastName");
            Assert.AreEqual("Joe.Dalton@somewhere.com", account.EmailAddress, "account.EmailAddress");
        }


        [Test]
        public void QueryForDatatable_with_resulclass_should_work()
        {
            DataTable dataTable = dataMapper.QueryForDataTable("SimpleAccountDataTable", 1);
            DataRow[] currentRows = dataTable.Select(null, null, DataViewRowState.CurrentRows);

            //if (currentRows.Length < 1)
            //    Console.WriteLine("No Current Rows Found");
            //else
            //{
            //    foreach (DataColumn column in dataTable.Columns)
            //        Console.Write("\t{0}", column.ColumnName);

            //    Console.WriteLine("\tRowState");

            //    foreach (DataRow row in currentRows)
            //    {
            //        foreach (DataColumn column in dataTable.Columns)
            //            Console.Write("\t{0}", row[column]);

            //        Console.WriteLine("\t" + row.RowState);
            //    }
            //}


            Assert.That(dataTable, Is.Not.Null);
            Assert.That(currentRows.Length, Is.GreaterThan(0));
            Assert.That(dataTable.Columns[0].ColumnName, Is.EqualTo("Account_ID"));
            Assert.That(dataTable.Columns[1].ColumnName, Is.EqualTo("Account_FirstName"));
            Assert.That(currentRows[0][0], Is.EqualTo(1));
            Assert.That(currentRows[0][1], Is.EqualTo("Joe"));
        }

        [Test]
        public void QueryForDatatable_with_resulmap_should_work()
        {
            DataTable dataTable = dataMapper.QueryForDataTable("SimpleAccountDataTableViaResultMap", 1);

            DataRow[] currentRows = dataTable.Select(null, null, DataViewRowState.CurrentRows);

            Assert.That(dataTable, Is.Not.Null);
            Assert.That(currentRows.Length, Is.GreaterThan(0));
            Assert.That(dataTable.Columns[0].ColumnName, Is.EqualTo("Id"));
            Assert.That(dataTable.Columns[0].DataType, Is.EqualTo(typeof(int)));

            Assert.That(dataTable.Columns[1].ColumnName, Is.EqualTo("FirstName"));
            Assert.That(dataTable.Columns[1].DataType, Is.EqualTo(typeof(string)));

            Assert.That(currentRows[0][0], Is.EqualTo(1));
            Assert.That(currentRows[0][1], Is.EqualTo("Joe"));
        }

        [Test]
        public void Statement_with_SqlSource_should_work()
        {
            Account account = dataMapper.QueryForObject<Account>("SimpleSqlSource", null);

            AssertAccount1(account);
        }

        [Test]
        public void Statement_with_SqlSource_and_parameter_should_work()
        {
            Account account = dataMapper.QueryForObject<Account>("SqlSourceWithParameter", 1);

            AssertAccount1(account);
        }

        [Test]
        public void Statement_with_SqlSource_and_inline_parameter_should_work()
        {
            IDictionary param = new Hashtable();
            param.Add("Id", 1);

            Account account = dataMapper.QueryForObject<Account>("SqlSourceWithInlineParameter", param);

            AssertAccount1(account);
        }

        /// <summary>
        /// Test Open connection with a connection string
        /// </summary>
        [Test]
        public void TestOpenConnection()
        {
            ISession session = sessionFactory.OpenSession();
            Account account = dataMapper.QueryForObject("SelectWithProperty", null) as Account;
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
            Account account = dataMapper.QueryForObject("SelectWithProperty", null) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject Via ColumnName
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaColumnName()
        {
            Account account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject Via ColumnIndex
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaColumnIndex()
        {
            Account account = dataMapper.QueryForObject("GetAccountViaColumnIndex", 1) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject Via ResultClass
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaResultClass()
        {
            Account account = dataMapper.QueryForObject("GetAccountViaResultClass", 1) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject With simple ResultClass : string
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithSimpleResultClass()
        {
            string email = dataMapper.QueryForObject("GetEmailAddressViaResultClass", 1) as string;
            Assert.AreEqual("Joe.Dalton@somewhere.com", email);
        }

        /// <summary>
        /// Test ExecuteQueryForObject With simple ResultMap : string
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithSimpleResultMap()
        {
            string email = dataMapper.QueryForObject("GetEmailAddressViaResultMap", 1) as string;
            Assert.AreEqual("Joe.Dalton@somewhere.com", email);
        }

        /// <summary>
        /// Test Primitive ReturnValue : System.DateTime
        /// </summary>
        [Test]
        public void TestPrimitiveReturnValue()
        {
            DateTime CardExpiry = (DateTime)dataMapper.QueryForObject("GetOrderCardExpiryViaResultClass", 1);
            Assert.AreEqual(new DateTime(2003, 02, 15, 8, 15, 00), CardExpiry);
        }

        /// <summary>
        /// Test ExecuteQueryForObject with result object : Account
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithResultObject()
        {
            Account account = new Account();
            Account testAccount = dataMapper.QueryForObject("GetAccountViaColumnName", 1, account) as Account;
            AssertAccount1(account);
            Assert.IsTrue(account == testAccount);
        }

        /// <summary>
        /// Test ExecuteQueryForObject as Hashtable
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectAsHashtable()
        {
            Hashtable account = (Hashtable)dataMapper.QueryForObject("GetAccountAsHashtable", 1);
            AssertAccount1AsHashtable(account);
        }

        /// <summary>
        /// Test ExecuteQueryForObject as Hashtable ResultClass
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectAsHashtableResultClass()
        {
            Hashtable account = (Hashtable)dataMapper.QueryForObject("GetAccountAsHashtableResultClass", 1);
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

            LineItem testItem = dataMapper.QueryForObject("GetSpecificLineItem", param) as LineItem;

            Assert.IsNotNull(testItem);
            Assert.AreEqual("TSM-12", testItem.Code);
        }

        /// <summary>
        /// Test Query Dynamic Sql Element
        /// </summary>
        [Test]
        public void TestQueryDynamicSqlElement()
        {
            IList list = dataMapper.QueryForList("GetDynamicOrderedEmailAddressesViaResultMap", "Account_ID");

            Assert.AreEqual("Joe.Dalton@somewhere.com", (string)list[0]);

            list = dataMapper.QueryForList("GetDynamicOrderedEmailAddressesViaResultMap", "Account_FirstName");

            Assert.AreEqual("Averel.Dalton@somewhere.com", (string)list[0]);

        }

        /// <summary>
        /// Test Execute QueryForList With ResultMap With Dynamic Element
        /// </summary>
        [Test]
        public void TestExecuteQueryForListWithResultMapWithDynamicElement()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsViaResultMapWithDynamicElement", "LIKE");

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, ((Account)list[0]).Id);
            Assert.AreEqual(2, ((Account)list[1]).Id);
            Assert.AreEqual(4, ((Account)list[2]).Id);

            list = dataMapper.QueryForList("GetAllAccountsViaResultMapWithDynamicElement", "=");

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Test Get Account Via Inline Parameters
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectViaInlineParameters()
        {
            Account account = new Account();
            account.Id = 1;

            Account testAccount = dataMapper.QueryForObject("GetAccountViaInlineParameters", account) as Account;

            AssertAccount1(testAccount);
        }

        /// <summary>
        /// Test ExecuteQuery For Object With Enum property
        /// </summary>
        [Test]
        public void TestExecuteQueryForObjectWithEnum()
        {
            Enumeration enumClass = dataMapper.QueryForObject("GetEnumeration", 1) as Enumeration;

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
        public void TestQueryForListWithHashtableResultMap()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsAsHashMapViaResultMap", null);

            AssertAccount1AsHashtable((Hashtable)list[0]);
            Assert.AreEqual(5, list.Count);

            Assert.AreEqual(1, ((Hashtable)list[0])["Id"]);
            Assert.AreEqual(2, ((Hashtable)list[1])["Id"]);
            Assert.AreEqual(3, ((Hashtable)list[2])["Id"]);
            Assert.AreEqual(4, ((Hashtable)list[3])["Id"]);
            Assert.AreEqual(5, ((Hashtable)list[4])["Id"]);
        }

        /// <summary>
        /// Test QueryForList with Hashtable ResultClass
        /// </summary>
        [Test]
        public void TestQueryForListWithHashtableResultClass()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsAsHashtableViaResultClass", null);

            AssertAccount1AsHashtableForResultClass((Hashtable)list[0]);
            Assert.AreEqual(5, list.Count);

            Assert.AreEqual(1, ((Hashtable)list[0])[BaseTest.ConvertKey("Id")]);
            Assert.AreEqual(2, ((Hashtable)list[1])[BaseTest.ConvertKey("Id")]);
            Assert.AreEqual(3, ((Hashtable)list[2])[BaseTest.ConvertKey("Id")]);
            Assert.AreEqual(4, ((Hashtable)list[3])[BaseTest.ConvertKey("Id")]);
            Assert.AreEqual(5, ((Hashtable)list[4])[BaseTest.ConvertKey("Id")]);
        }

        /// <summary>
        /// Test QueryForList with IList ResultClass
        /// </summary>
        [Test]
        public void TestQueryForListWithIListResultClass()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsAsArrayListViaResultClass", null);

            IList listAccount = (IList)list[0];
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
            IList list = dataMapper.QueryForList("GetAllAccountsViaResultMap", null);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, ((Account)list[0]).Id);
            Assert.AreEqual(2, ((Account)list[1]).Id);
            Assert.AreEqual(3, ((Account)list[2]).Id);
            Assert.AreEqual(4, ((Account)list[3]).Id);
            Assert.AreEqual(5, ((Account)list[4]).Id);
        }


        /// <summary>
        /// Test QueryForList with ResultObject : 
        /// AccountCollection strongly typed collection
        /// </summary>
        [Test]
        public void TestQueryForListWithResultObject()
        {
            AccountCollection accounts = new AccountCollection();

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
        /// Test QueryForList with ListClass : LineItemCollection
        /// </summary>
        [Test]
        public void TestQueryForListWithListClass()
        {
            LineItemCollection linesItem = dataMapper.QueryForList("GetLineItemsForOrderWithListClass", 6) as LineItemCollection;

            Assert.IsNotNull(linesItem);
            Assert.AreEqual(2, linesItem.Count);
            Assert.AreEqual("ASM-45", linesItem[0].Code);
            Assert.AreEqual("QSM-39", linesItem[1].Code);
        }

        /// <summary>
        /// Test QueryForList with no result.
        /// </summary>
        [Test]
        public void TestQueryForListWithNoResult()
        {
            IList list = dataMapper.QueryForList("GetNoAccountsViaResultMap", null);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Test QueryForList with ResultClass : Account.
        /// </summary>
        [Test]
        public void TestQueryForListResultClass()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsViaResultClass", null);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, ((Account)list[0]).Id);
            Assert.AreEqual(2, ((Account)list[1]).Id);
            Assert.AreEqual(3, ((Account)list[2]).Id);
            Assert.AreEqual(4, ((Account)list[3]).Id);
            Assert.AreEqual(5, ((Account)list[4]).Id);
        }

        /// <summary>
        /// Test QueryForList with simple resultClass : string
        /// </summary>
        [Test]
        public void TestQueryForListWithSimpleResultClass()
        {
            IList list = dataMapper.QueryForList("GetAllEmailAddressesViaResultClass", null);

            Assert.AreEqual("Joe.Dalton@somewhere.com", (string)list[0]);
            Assert.AreEqual("Averel.Dalton@somewhere.com", (string)list[1]);
            Assert.IsNull(list[2]);
            Assert.AreEqual("Jack.Dalton@somewhere.com", (string)list[3]);
            Assert.AreEqual("gilles.bayon@nospam.org", (string)list[4]);
        }

        /// <summary>
        /// Test  QueryForList with simple ResultMap : string
        /// </summary>
        [Test]
        public void TestQueryForListWithSimpleResultMap()
        {
            IList list = dataMapper.QueryForList("GetAllEmailAddressesViaResultMap", null);

            Assert.AreEqual("Joe.Dalton@somewhere.com", (string)list[0]);
            Assert.AreEqual("Averel.Dalton@somewhere.com", (string)list[1]);
            Assert.IsNull(list[2]);
            Assert.AreEqual("Jack.Dalton@somewhere.com", (string)list[3]);
            Assert.AreEqual("gilles.bayon@nospam.org", (string)list[4]);
        }


        [Test]
        public void TestQueryWithRowDelegate()
        {
            RowDelegate handler = new RowDelegate(this.RowHandler);

            IList list = dataMapper.QueryWithRowDelegate("GetAllAccountsViaResultMap", null, handler);

            Assert.AreEqual(5, _index);
            Assert.AreEqual(5, list.Count);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, ((Account)list[0]).Id);
            Assert.AreEqual(2, ((Account)list[1]).Id);
            Assert.AreEqual(3, ((Account)list[2]).Id);
            Assert.AreEqual(4, ((Account)list[3]).Id);
            Assert.AreEqual(5, ((Account)list[4]).Id);

        }

        #endregion

        #region  Map Tests

        /// <summary>
        /// Test ExecuteQueryForMap : Hashtable.
        /// </summary>
        [Test]
        public void TestExecuteQueryForMap()
        {
            IDictionary map = dataMapper.QueryForMap("GetAllAccountsViaResultClass", null, "FirstName");

            Assert.AreEqual(5, map.Count);
            AssertAccount1(((Account)map["Joe"]));

            Assert.AreEqual(1, ((Account)map["Joe"]).Id);
            Assert.AreEqual(2, ((Account)map["Averel"]).Id);
            Assert.AreEqual(3, ((Account)map["William"]).Id);
            Assert.AreEqual(4, ((Account)map["Jack"]).Id);
            Assert.AreEqual(5, ((Account)map["Gilles"]).Id);
        }

        /// <summary>
        /// Test ExecuteQueryForMap With Cache : Hashtable.
        /// </summary>
        [Test]
        public void TestExecuteQueryForMapWithCache()
        {
            IDictionary map = dataMapper.QueryForMap("GetAllAccountsCache", null, "FirstName");

            int firstId = HashCodeProvider.GetIdentityHashCode(map);

            Assert.AreEqual(5, map.Count);
            AssertAccount1(((Account)map["Joe"]));

            Assert.AreEqual(1, ((Account)map["Joe"]).Id);
            Assert.AreEqual(2, ((Account)map["Averel"]).Id);
            Assert.AreEqual(3, ((Account)map["William"]).Id);
            Assert.AreEqual(4, ((Account)map["Jack"]).Id);
            Assert.AreEqual(5, ((Account)map["Gilles"]).Id);

            map = dataMapper.QueryForMap("GetAllAccountsCache", null, "FirstName");

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
        public void TestExecuteQueryForMap2()
        {
            IDictionary map = dataMapper.QueryForMap("GetAllOrderWithLineItems", null, "PostalCode");

            Assert.AreEqual(11, map.Count);
            Order order = ((Order)map["T4H 9G4"]);

            Assert.AreEqual(2, order.LineItemsIList.Count);
        }

        /// <summary>
        /// Test ExecuteQueryForMap with value property :
        /// "FirstName" as key, "EmailAddress" as value
        /// </summary>
        [Test]
        public void TestExecuteQueryForMapWithValueProperty()
        {
            IDictionary map = dataMapper.QueryForMap("GetAllAccountsViaResultClass", null, "FirstName", "EmailAddress");

            Assert.AreEqual(5, map.Count);

            Assert.AreEqual("Joe.Dalton@somewhere.com", map["Joe"]);
            Assert.AreEqual("Averel.Dalton@somewhere.com", map["Averel"]);
            Assert.IsNull(map["William"]);
            Assert.AreEqual("Jack.Dalton@somewhere.com", map["Jack"]);
            Assert.AreEqual("gilles.bayon@nospam.org", map["Gilles"]);
        }

        /// <summary>
        /// Test ExecuteQueryForWithJoined
        /// </remarks>
        [Test]
        public void TestExecuteQueryForWithJoined()
        {
            Order order = dataMapper.QueryForObject("GetOrderJoinWithAccount", 10) as Order;

            Assert.IsNotNull(order.Account);

            order = dataMapper.QueryForObject("GetOrderJoinWithAccount", 11) as Order;

            Assert.IsNull(order.Account);
        }

        /// <summary>
        /// Test ExecuteQueryFor With Complex Joined
        /// </summary>
        /// <remarks>
        /// A->B->C
        ///  ->E
        ///  ->F
        /// </remarks>
        [Test]
        public void TestExecuteQueryForWithComplexJoined()
        {
            A a = dataMapper.QueryForObject("SelectComplexJoined", null) as A;

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.B);
            Assert.IsNotNull(a.B.C);
            Assert.IsNull(a.B.D);
            Assert.IsNotNull(a.E);
            Assert.IsNull(a.F);
        }
        #endregion

        #region Extends statement

        /// <summary>
        /// Test base Extends statement
        /// </summary>
        [Test]
        public void TestExtendsGetAllAccounts()
        {
            IList list = dataMapper.QueryForList("GetAllAccounts", null);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, ((Account)list[0]).Id);
            Assert.AreEqual(2, ((Account)list[1]).Id);
            Assert.AreEqual(3, ((Account)list[2]).Id);
            Assert.AreEqual(4, ((Account)list[3]).Id);
            Assert.AreEqual(5, ((Account)list[4]).Id);
        }

        /// <summary>
        /// Test Extends statement GetAllAccountsOrderByName extends GetAllAccounts
        /// </summary>
        [Test]
        public void TestExtendsGetAllAccountsOrderByName()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsOrderByName", null);

            AssertAccount1((Account)list[3]);
            Assert.AreEqual(5, list.Count);

            Assert.AreEqual(2, ((Account)list[0]).Id);
            Assert.AreEqual(5, ((Account)list[1]).Id);
            Assert.AreEqual(4, ((Account)list[2]).Id);
            Assert.AreEqual(1, ((Account)list[3]).Id);
            Assert.AreEqual(3, ((Account)list[4]).Id);
        }

        /// <summary>
        /// Test Extends statement GetOneAccount extends GetAllAccounts
        /// </summary>
        [Test]
        public void TestExtendsGetOneAccount()
        {
            Account account = dataMapper.QueryForObject("GetOneAccount", 1) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test Extends statement GetSomeAccount extends GetAllAccounts
        /// </summary>
        [Test]
        public void TestExtendsGetSomeAccount()
        {
            Hashtable param = new Hashtable();
            param.Add("lowID", 2);
            param.Add("hightID", 4);

            IList list = dataMapper.QueryForList("GetSomeAccount", param);

            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(2, ((Account)list[0]).Id);
            Assert.AreEqual(3, ((Account)list[1]).Id);
            Assert.AreEqual(4, ((Account)list[2]).Id);
        }

        [Test]
        public void TestDummyAccount()
        {
            Hashtable param = new Hashtable();
            param.Add("?lowID", 2);
            param.Add("?hightID", 4);

            IList list = dataMapper.QueryForList("GetDummy", param);

            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(2, ((Account)list[0]).Id);
            Assert.AreEqual(3, ((Account)list[1]).Id);
            Assert.AreEqual(4, ((Account)list[2]).Id);
        }

        #endregion

        #region Update tests

        /// <summary>
        /// Test Insert with post GeneratedKey
        /// </summary>
        [Test]
        public void TestInsertPostKey()
        {
            LineItem item = new LineItem();

            item.Id = 350;
            item.Code = "blah";
            item.Order = new Order();
            item.Order.Id = 9;
            item.Price = 44.00m;
            item.Quantity = 1;

            object key = dataMapper.Insert("InsertLineItemPostKey", item);

            Assert.AreEqual(99, key);
            Assert.AreEqual(99, item.Id);

            Hashtable param = new Hashtable();
            param.Add("Order_ID", 9);
            param.Add("LineItem_ID", 350);
            LineItem testItem = (LineItem)dataMapper.QueryForObject("GetSpecificLineItem", param);
            Assert.IsNotNull(testItem);
            Assert.AreEqual(350, testItem.Id);
        }

        /// <summary>
        /// Test Insert pre GeneratedKey
        /// </summary>
        [Test]
        public void TestInsertPreKey()
        {
            LineItem item = new LineItem();

            item.Id = 10;
            item.Code = "blah";
            item.Order = new Order();
            item.Order.Id = 9;
            item.Price = 44.00m;
            item.Quantity = 1;

            object key = dataMapper.Insert("InsertLineItemPreKey", item);

            Assert.AreEqual(99, key);
            Assert.AreEqual(99, item.Id);

            Hashtable param = new Hashtable();
            param.Add("Order_ID", 9);
            param.Add("LineItem_ID", 99);

            LineItem testItem = (LineItem)dataMapper.QueryForObject("GetSpecificLineItem", param);

            Assert.IsNotNull(testItem);
            Assert.AreEqual(99, testItem.Id);
        }

        /// <summary>
        /// Test Test Insert No Key
        /// </summary>
        [Test]
        public void TestInsertNoKey()
        {
            LineItem item = new LineItem();

            item.Id = 100;
            item.Code = "blah";
            item.Order = new Order();
            item.Order.Id = 9;
            item.Price = 44.00m;
            item.Quantity = 1;

            object key = dataMapper.Insert("InsertLineItemNoKey", item);

            Assert.IsNull(key);
            Assert.AreEqual(100, item.Id);

            Hashtable param = new Hashtable();
            param.Add("Order_ID", 9);
            param.Add("LineItem_ID", 100);

            LineItem testItem = (LineItem)dataMapper.QueryForObject("GetSpecificLineItem", param);

            Assert.IsNotNull(testItem);
            Assert.AreEqual(100, testItem.Id);
        }

        /// <summary>
        /// Test Insert account via public fields
        /// </summary>
        [Test]
        [Ignore("No more supported")]
        public void TestInsertAccountViaPublicFields()
        {
            AccountBis account = new AccountBis();

            account.Id = 10;
            account.FirstName = "Luky";
            account.LastName = "Luke";
            account.EmailAddress = "luly.luke@somewhere.com";

            dataMapper.Insert("InsertAccountViaPublicFields", account);

            Account testAccount = dataMapper.QueryForObject("GetAccountViaColumnName", 10) as Account;

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(10, testAccount.Id);
        }

        [Test]
        public void TestInsertOrderViaProperties()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            Order order = new Order();
            order.Id = 99;
            order.CardExpiry = "09/11";
            order.Account = account;
            order.CardNumber = "154564656";
            order.CardType = "Visa";
            order.City = "Lyon";
            order.Date = DateTime.Now;
            order.PostalCode = "69004";
            order.Province = "Rhone";
            order.Street = "rue Durand";

            dataMapper.Insert("InsertOrderViaPublicFields", order);
        }

        /// <summary>
        /// Test Insert account via public fields
        /// </summary>
        [Test]
        public void TestInsertDynamic()
        {
            Account account = new Account();

            account.Id = 10;
            account.FirstName = "Luky";
            account.LastName = "luke";
            account.EmailAddress = null;

            dataMapper.Insert("InsertAccountDynamic", account);

            Account testAccount = dataMapper.QueryForObject("GetAccountViaColumnIndex", 10) as Account;

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(10, testAccount.Id);
            Assert.AreEqual("no_email@provided.com", testAccount.EmailAddress);

            account.Id = 11;
            account.FirstName = "Luky";
            account.LastName = "luke";
            account.EmailAddress = "luly.luke@somewhere.com";

            dataMapper.Insert("InsertAccountDynamic", account);

            testAccount = dataMapper.QueryForObject("GetAccountViaColumnIndex", 11) as Account;

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(11, testAccount.Id);
            Assert.AreEqual("luly.luke@somewhere.com", testAccount.EmailAddress);
        }

        /// <summary>
        /// Test Insert account via inline parameters
        /// </summary>
        [Test]
        public void TestInsertAccountViaInlineParameters()
        {
            Account account = new Account();

            account.Id = 10;
            account.FirstName = "Luky";
            account.LastName = "Luke";
            account.EmailAddress = "luly.luke@somewhere.com";

            dataMapper.Insert("InsertAccountViaInlineParameters", account);

            Account testAccount = dataMapper.QueryForObject("GetAccountViaColumnIndex", 10) as Account;

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(10, testAccount.Id);
        }

        /// <summary>
        /// Test Insert account via parameterMap
        /// </summary>
        [Test]
        public void TestInsertAccountViaParameterMap()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            account = dataMapper.QueryForObject("GetAccountNullableEmail", 6) as Account;

            AssertAccount6(account);
        }

        /// <summary>
        /// Test Insert account via parameterMap
        /// </summary>
        [Test]
        public void TestInsertEnumViaParameterMap()
        {
            Enumeration enumClass = new Enumeration();
            enumClass.Id = 99;
            enumClass.Day = Days.Thu;
            enumClass.Color = Colors.Blue;
            enumClass.Month = Months.May;

            dataMapper.Insert("InsertEnumViaParameterMap", enumClass);

            enumClass = null;
            enumClass = dataMapper.QueryForObject("GetEnumeration", 99) as Enumeration;

            Assert.AreEqual(enumClass.Day, Days.Thu);
            Assert.AreEqual(enumClass.Color, Colors.Blue);
            Assert.AreEqual(enumClass.Month, Months.May);
        }

        /// <summary>
        /// Test Update via parameterMap
        /// </summary>
        [Test]
        public void TestUpdateViaParameterMap()
        {
            Account account = (Account)dataMapper.QueryForObject("GetAccountViaColumnName", 1);

            account.EmailAddress = "new@somewhere.com";
            dataMapper.Update("UpdateAccountViaParameterMap", account);

            account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;

            Assert.AreEqual("new@somewhere.com", account.EmailAddress);
        }

        /// <summary>
        /// Test Update via parameterMap V2
        /// </summary>
        [Test]
        public void TestUpdateViaParameterMap2()
        {
            Account account = (Account)dataMapper.QueryForObject("GetAccountViaColumnName", 1);

            account.EmailAddress = "new@somewhere.com";
            dataMapper.Update("UpdateAccountViaParameterMap2", account);

            account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;

            Assert.AreEqual("new@somewhere.com", account.EmailAddress);
        }

        /// <summary>
        /// Test Update with inline parameters
        /// </summary>
        [Test]
        public void TestUpdateWithInlineParameters()
        {
            Account account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;

            account.EmailAddress = "new@somewhere.com";
            dataMapper.Update("UpdateAccountViaInlineParameters", account);

            account = (Account)dataMapper.QueryForObject("GetAccountViaColumnName", 1);

            Assert.AreEqual("new@somewhere.com", account.EmailAddress);
        }

        /// <summary>
        /// Test Execute Update With Parameter Class
        /// </summary>
        [Test]
        public void TestExecuteUpdateWithParameterClass()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            bool checkForInvalidTypeFailedAppropriately = false;

            try
            {
                dataMapper.Update("DeleteAccount", new object());
            }
            catch (IbatisException e)
            {
                Console.WriteLine("TestExecuteUpdateWithParameterClass :" + e.Message);
                checkForInvalidTypeFailedAppropriately = true;
            }

            dataMapper.Update("DeleteAccount", account);

            account = dataMapper.QueryForObject("GetAccountViaColumnName", 6) as Account;

            Assert.IsNull(account);
            Assert.IsTrue(checkForInvalidTypeFailedAppropriately);
        }

        /// <summary>
        /// Test Execute Delete
        /// </summary>
        [Test]
        public void TestExecuteDelete()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            account = null;
            account = dataMapper.QueryForObject("GetAccountViaColumnName", 6) as Account;

            Assert.IsTrue(account.Id == 6);

            int rowNumber = dataMapper.Delete("DeleteAccount", account);
            Assert.IsTrue(rowNumber == 1);

            account = dataMapper.QueryForObject("GetAccountViaColumnName", 6) as Account;

            Assert.IsNull(account);
        }

        /// <summary>
        /// Test Execute Delete
        /// </summary>
        [Test]
        public void TestDeleteWithComments()
        {
            int rowNumber = dataMapper.Delete("DeleteWithComments", null);

            Assert.IsTrue(rowNumber == 3);
        }

        /// <summary>
        /// Test Execute delete Via Inline Parameters
        /// </summary>
        [Test]
        public void TestDeleteViaInlineParameters()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            int rowNumber = dataMapper.Delete("DeleteAccountViaInlineParameters", 6);

            Assert.IsTrue(rowNumber == 1);
        }

        #endregion

        #region Row delegate

        private int _index = 0;

        public void RowHandler(object obj, object paramterObject, IList list)
        {
            _index++;
            Assert.AreEqual(_index, ((Account)obj).Id);
            list.Add(obj);
        }

        #endregion

        #region Tests using syntax

        /// <summary>
        /// Test Using syntax 
        /// </summary>
        [Test]
        public void Using_syntax_should_close_session()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                Account account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;
                AssertAccount1(account);
            }// compiler will call Dispose on ISession
        }

        /// <summary>
        /// Test usage of auto commit for an insert
        /// </summary>
        [Test]
        public void AutoClose_session_on_Insert_should_work()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            account = (Account)dataMapper.QueryForObject("GetAccountNullableEmail", 6);
            AssertAccount6(account);
        }

        /// <summary>
        /// Test usage of auto commit for a query
        /// </summary>
        [Test]
        public void AutoClose_session_should_work()
        {
            Account account = (Account)dataMapper.QueryForObject("GetAccountNullableEmail", 1);

            AssertAccount1(account);
        }


        #endregion

        #region JIRA Tests

        /// <summary>
        /// Test a constructor argument with select tag.
        /// </remarks>
        [Test]
        [Category("JIRA")]
        [Description("JIRA182")]
        public void LazyLoad_on_virtual_property_should_work()
        {
            Order order = (Order)dataMapper.QueryForObject("JIRA182", 5);

            Assert.IsTrue(order.Id == 5);
            Assert.IsNotNull(order.Account);
            Assert.AreEqual(5, order.Account.Id);
        }

        /// <summary>
        /// QueryForDictionary does not process select property
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA220")]
        public void TestJIRA220()
        {
            IDictionary map = dataMapper.QueryForMap("JIAR220", null, "PostalCode");

            Assert.AreEqual(11, map.Count);
            Order order = ((Order)map["T4H 9G4"]);

            Assert.AreEqual(2, order.LineItemsIList.Count);
        }

        /// <summary>
        /// Test JIRA 30 (repeating property)
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA30")]
        public void TestJIRA30()
        {
            Account account = new Account();
            account.Id = 1;
            account.FirstName = "Joe";
            account.LastName = "Dalton";
            account.EmailAddress = "Joe.Dalton@somewhere.com";

            Account result = dataMapper.QueryForObject("GetAccountWithRepeatingProperty", account) as Account;

            AssertAccount1(result);
        }

        /// <summary>
        /// Test Bit column 
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA42")]
        public void TestJIRA42()
        {
            Other other = new Other();

            other.Int = 100;
            other.Bool = true;
            other.Long = 789456321;

            dataMapper.Insert("InsertBool", other);
        }

        /// <summary>
        /// Test for access a result map in a different namespace 
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA45")]
        public void TestJIRA45()
        {
            Account account = dataMapper.QueryForObject("GetAccountJIRA45", 1) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test : Whitespace is not maintained properly when CDATA tags are used
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA110")]
        public void TestJIRA110()
        {
            Account account = dataMapper.QueryForObject("Get1Account", null) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test : Whitespace is not maintained properly when CDATA tags are used
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA110")]
        public void TestJIRA110Bis()
        {
            IList list = dataMapper.QueryForList("GetAccounts", null);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test for cache stats only being calculated on CachingStatments
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA113")]
        [Ignore]
        public void Cache_stats_should_only_be_calculated_on_CachingStatments()
        {
            IModelStore modelStore = ((IModelStoreAccessor)dataMapper).ModelStore;
            modelStore.FlushCaches();

            // taken from TestFlushDataCache()
            // first query is not cached, second query is: 50% cache hit
            IList list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);
            int firstId = HashCodeProvider.GetIdentityHashCode(list);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);
            int secondId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreEqual(firstId, secondId);

            //string cacheStats = modelStore.GetDataCacheStats();

            //Assert.IsNotNull(cacheStats);
        }

        #endregion

        #region CustomTypeHandler tests

        /// <summary>
        /// Test CustomTypeHandler 
        /// </summary>
        [Test]
        public void TestExecuteQueryWithCustomTypeHandler()
        {
            IList list = dataMapper.QueryForList("GetAllAccountsViaCustomTypeHandler", null);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, ((Account)list[0]).Id);
            Assert.AreEqual(2, ((Account)list[1]).Id);
            Assert.AreEqual(3, ((Account)list[2]).Id);
            Assert.AreEqual(4, ((Account)list[3]).Id);
            Assert.AreEqual(5, ((Account)list[4]).Id);

            Assert.IsFalse(((Account)list[0]).CartOption);
            Assert.IsFalse(((Account)list[1]).CartOption);
            Assert.IsTrue(((Account)list[2]).CartOption);
            Assert.IsTrue(((Account)list[3]).CartOption);
            Assert.IsTrue(((Account)list[4]).CartOption);

            Assert.IsTrue(((Account)list[0]).BannerOption);
            Assert.IsTrue(((Account)list[1]).BannerOption);
            Assert.IsFalse(((Account)list[2]).BannerOption);
            Assert.IsFalse(((Account)list[3]).BannerOption);
            Assert.IsTrue(((Account)list[4]).BannerOption);
        }

        /// <summary>
        /// Test CustomTypeHandler Oui/Non
        /// </summary>
        [Test]
        public void TestCustomTypeHandler()
        {
            Other other = new Other();
            other.Int = 99;
            other.Long = 1966;
            other.Bool = true;
            other.Bool2 = false;

            dataMapper.Insert("InsertCustomTypeHandler", other);

            Other anOther = dataMapper.QueryForObject("SelectByInt", 99) as Other;

            Assert.IsNotNull(anOther);
            Assert.AreEqual(99, anOther.Int);
            Assert.AreEqual(1966, anOther.Long);
            Assert.AreEqual(true, anOther.Bool);
            Assert.AreEqual(false, anOther.Bool2);
        }

        /// <summary>
        /// Test CustomTypeHandler Oui/Non
        /// </summary>
        [Test]
        public void TestInsertInlineCustomTypeHandlerV1()
        {
            Other other = new Other();
            other.Int = 99;
            other.Long = 1966;
            other.Bool = true;
            other.Bool2 = false;

            dataMapper.Insert("InsertInlineCustomTypeHandlerV1", other);

            Other anOther = dataMapper.QueryForObject("SelectByInt", 99) as Other;

            Assert.IsNotNull(anOther);
            Assert.AreEqual(99, anOther.Int);
            Assert.AreEqual(1966, anOther.Long);
            Assert.AreEqual(true, anOther.Bool);
            Assert.AreEqual(false, anOther.Bool2);
        }

        /// <summary>
        /// Test CustomTypeHandler Oui/Non
        /// </summary>
        [Test]
        public void TestInsertInlineCustomTypeHandlerV2()
        {
            Other other = new Other();
            other.Int = 99;
            other.Long = 1966;
            other.Bool = true;
            other.Bool2 = false;

            dataMapper.Insert("InsertInlineCustomTypeHandlerV2", other);

            Other anOther = dataMapper.QueryForObject("SelectByInt", 99) as Other;

            Assert.IsNotNull(anOther);
            Assert.AreEqual(99, anOther.Int);
            Assert.AreEqual(1966, anOther.Long);
            Assert.AreEqual(true, anOther.Bool);
            Assert.AreEqual(false, anOther.Bool2);
        }
        #endregion
    }
}