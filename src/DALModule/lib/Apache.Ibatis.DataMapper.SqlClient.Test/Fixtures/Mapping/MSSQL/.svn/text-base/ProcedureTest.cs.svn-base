using System;
using System.Collections;
using System.Collections.Specialized;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;

using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.MSSQL
{
    /// <summary>
    /// Summary description for ProcedureTest.
    /// </summary>
    [TestFixture] 
    [Category("MSSQL")]
    public class ProcedureTest : BaseTest
    {
		
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void Init() 
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-procedure.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-procedure.sql", false);
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-procedureWithReturn.sql", false);
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectAccount.sql", false);
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectAllAccount.sql", false);
            InitScript(sessionFactory.DataSource, scriptDirectory + "swap-procedure.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectAccountWithOutPutParam.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_InsertAccountWithDefault.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectAccountViaOuputParam.sql");

        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        #region Specific statement store procedure tests for sql server

        [Test]
        public void Procedure_with_inline_parameter_should_work()
        {
            // parameter syntax
            //@{propertyName,column=string,type=string,dbype=Varchar,direction=Input,nullValue=N/A,handler=string}

            Account account = dataMapper.QueryForObject<Account>("SPWithInlineParameter", 1);
            Assert.AreEqual(1, account.Id);
        }

        [Test]
        public void Procedure_with_inline_output_parameter_should_work()
        {
            Hashtable map = new Hashtable();
            map.Add("Account_ID", 1);
            map.Add("OutPut", 0);
            Account account = dataMapper.QueryForObject<Account>("SPWithInlineParameterAndOutPutParam", map);

            Assert.That(map["OutPut"], Is.EqualTo(987));

            AssertAccount1(account);
        }

        [Test]
        public void Procedure_with_complex_inline_parameter_should_work()
        {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.EmailAddress = "no_email@provided.com";
            account.CartOption = false;

            dataMapper.Insert("InsertAccountViaStoreProcedure", account);

            Account testAccount = dataMapper.QueryForObject<Account>("GetAccountViaColumnName", 99);

            Assert.IsNotNull(testAccount);
            Assert.That(testAccount.Id, Is.EqualTo(99));
            Assert.That(testAccount.EmailAddress, Is.EqualTo("no_email@provided.com"));
            Assert.That(testAccount.CartOption, Is.False);
        }

        [Test]
        public void Procedure_with_default_parameter_should_work()
        {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";

            dataMapper.Insert("InsertAccountViaSPWithDefaultParameter", account);

            Account testAccount = dataMapper.QueryForObject<Account>("GetAccountViaColumnName", 99);

            Assert.IsNotNull(testAccount);
            Assert.That(testAccount.Id, Is.EqualTo(99));
            Assert.That(testAccount.EmailAddress, Is.EqualTo("no_email@provided.com"));
            Assert.That(testAccount.BannerOption, Is.False);
            Assert.That(testAccount.CartOption, Is.False);
        }

        [Test]
        public void Procedure_with_dynamic_parameter_should_work()
        {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.NullBannerOption = false;

            dataMapper.Insert("InsertAccountViaSPWithDynamicParameter", account);

            Account testAccount = dataMapper.QueryForObject<Account>("GetAccountViaColumnName", 99);

            Assert.IsNotNull(testAccount);
            Assert.That(testAccount.Id, Is.EqualTo(99));
            Assert.That(testAccount.EmailAddress, Is.EqualTo("no_email@provided.com"));
            Assert.That(testAccount.BannerOption, Is.False);
            Assert.That(testAccount.CartOption, Is.False);

            account.Id = 100;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.NullBannerOption = null;

            dataMapper.Insert("InsertAccountViaSPWithDynamicParameter", account);
        }

        /// <summary>
        /// Test XML parameter.
        /// </summary>
        [Test]
        public void Output_param_should_be_returned()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Account_ID", 1);
            hashtable.Add("OutPut", 0);
            Account account = dataMapper.QueryForObject<Account>("SelectAccountWithOutPutParam", hashtable);

            Assert.That(hashtable["OutPut"], Is.EqualTo(987));

            AssertAccount1(account);
        }

        /// <summary>
        /// ResultClass via Output param should be returned.
        /// </summary>
        [Test]
        public void ResultClass_via_output_param_should_be_returned()
        {
            Account account = new Account();
            account.Id = 1;

            dataMapper.QueryForObject<Account>("SelectAccountViaOutputParameter", account);

            AssertAccount1(account);
        }

        /// <summary>
        /// ResultClass via Output param should be returned.
        /// </summary>
        [Test]
        public void ResultClass_via_inline_output_param_should_be_returned()
        {
            Account account = new Account();
            account.Id = 1;

            dataMapper.QueryForObject<Account>("SelectAccountViaOutputParameterInlineParameter", account);

            AssertAccount1(account);
        }

        /// <summary>
        /// ResultClass via Output param should be returned even when
        /// the output is null
        /// </summary>
        [Test]
        public void ResultClass_via_output_param_and_null_should_be_returned()
        {
            Account account = new Account();
            account.Id = 99;

            dataMapper.QueryForObject<Account>("SelectAccountViaOutputParameter", account);

            Assert.That(account.EmailAddress, Is.EqualTo("no_email@provided.com"));
            Assert.That(account.FirstName, Is.Null);
            Assert.That(account.LastName, Is.Null);
        }

        /// <summary>
        /// ResultClass via Output param should be returned even when
        /// the output is null
        /// </summary>
        [Test]
        public void ResultClass_via_inline_output_param_and_null_should_be_returned()
        {
            Account account = new Account();
            account.Id = 99;

            dataMapper.QueryForObject<Account>("SelectAccountViaOutputParameterInlineParameter", account);

            Assert.That(account.EmailAddress, Is.EqualTo("no_email@provided.com"));
            Assert.That(account.FirstName, Is.Null);
            Assert.That(account.LastName, Is.Null);
        }

        /// <summary>
        /// Test an insert with via a store procedure and getting the generatedKey from a t-sql return statement
        /// </summary>
        [Test]
        public void InsertTestIdentityViaProcedureWithReturn ( )
        {
            Category category = new Category ( );
            category.Name = "Mapping object relational";

            int categoryID = ( int ) dataMapper.Insert ( "InsertCategoryViaStoreProcedureWithReturn", category );
            Assert.That(categoryID, Is.EqualTo(1));
            Assert.That(category.Id, Is.EqualTo(1));

            Category category2 = new Category ( );
            category2.Name = "Nausicaa";

            int categoryID2 = ( int ) dataMapper.Insert ( "InsertCategoryViaStoreProcedureWithReturn", category2 );
            Assert.That(categoryID2, Is.EqualTo(2));
            Assert.That(category2.Id, Is.EqualTo(2));

            Category category3 = dataMapper.QueryForObject<Category> ( "GetCategory", categoryID2 ) ;
            Category category4 = dataMapper.QueryForObject<Category> ( "GetCategory", categoryID );
            
            Assert.AreEqual ( categoryID2, category3.Id );
            Assert.AreEqual ( category2.Name, category3.Name );

            Assert.AreEqual ( categoryID, category4.Id );
            Assert.AreEqual ( category.Name, category4.Name );
        }

        /// <summary>
        /// Test XML parameter.
        /// </summary>
        [Test]
        [Category("MSSQL.2005")]
        public void TestXMLParameter()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectByIdList.sql");	

            string accountIds = "<Accounts><id>3</id><id>4</id></Accounts>";

            IList accounts = dataMapper.QueryForList("SelectAccountViaXML", accountIds);
            Assert.IsTrue(accounts.Count == 2);
        }

        /// <summary>
        /// Test get an account via a store procedure.
        /// </summary>
        [Test]
        public void GetAllAccountViaProcedure()
        {
            IList accounts = dataMapper.QueryForList("SelectAllAccountViaSP", null);
            Assert.IsTrue( accounts.Count==5);
        }
	    
        /// <summary>
        /// Test get an account via a store procedure.
        /// </summary>
        [Test] 
        public void GetAccountViaProcedure0()
        {
            IDictionary map = new HybridDictionary();
            map.Add("Account_ID", 1);
            Account account = dataMapper.QueryForObject("GetAccountViaSP0", map) as Account;
            Assert.AreEqual(1, account.Id );
        }
		
        /// <summary>
        /// Test get an account via a store procedure.
        /// </summary>
        [Test] 
        public void GetAccountViaProcedure1()
        {
            Account account = dataMapper.QueryForObject("GetAccountViaSP1", 1) as Account;
            Assert.AreEqual(1, account.Id );
        }
		
        /// <summary>
        /// Test get an account via a store procedure.
        /// </summary>
        [Test] 
        public void GetAccountViaProcedure2()
        {
            Hashtable hash = new Hashtable();
            hash.Add("Account_ID",1);
            Account account = dataMapper.QueryForObject("GetAccountViaSP2", hash) as Account;
            Assert.AreEqual(1, account.Id );
        }
		
        /// <summary>
        /// Test an insert with identity key via a store procedure.
        /// </summary>
        [Test] 
        public void InsertTestIdentityViaProcedure()
        {
            Category category = new Category();
            category.Name = "Mapping object relational";

            dataMapper.Insert("InsertCategoryViaStoreProcedure", category);
            Assert.AreEqual(1, category.Id );

            category = new Category();
            category.Name = "Nausicaa";

            dataMapper.QueryForObject("InsertCategoryViaStoreProcedure", category);
            Assert.AreEqual(2, category.Id );
        }

        /// <summary>
        /// Test store procedure with output parameters
        /// </summary>
        [Test]
        public void TestProcedureWithOutputParameters() 
        {
            string first = "Joe.Dalton@somewhere.com";
            string second = "Averel.Dalton@somewhere.com";

            Hashtable map = new Hashtable();
            map.Add("email1", first);
            map.Add("email2", second);

            dataMapper.QueryForObject("SwapEmailAddresses", map);

            Assert.AreEqual(first, map["email2"]);
            Assert.AreEqual(second, map["email1"]);
        }

        /// <summary>
        /// Test store procedure with input parameters
        /// passe via Hashtable
        /// </summary>
        [Test]
        public void TestProcedureWithInputParametersViaHashtable() 
        {
            Hashtable map = new Hashtable();
            map.Add("Id", 0);
            map.Add("Name", "Toto");
            map.Add("Guid", Guid.NewGuid());

            dataMapper.Insert("InsertCategoryViaStoreProcedureWithMap", map);
            Assert.AreEqual(1, map["Id"] );

        }

        /// <summary>
        /// Test Insert Account via store procedure
        /// </summary>
        [Test] 
        public void TestInsertAccountViaStoreProcedure() {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.EmailAddress = "Achille.Talon@somewhere.com";

            dataMapper.Insert("InsertAccountViaStoreProcedure", account);

            Account testAccount = dataMapper.QueryForObject("GetAccountViaColumnName", 99) as Account;

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(99, testAccount.Id);
        }

        #endregion
    }
}