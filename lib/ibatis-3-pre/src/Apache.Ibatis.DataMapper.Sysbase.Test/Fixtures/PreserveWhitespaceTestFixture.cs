﻿using System.Collections;
using System.Collections.Specialized;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Logging.Impl;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.Sysbase.Test.Fixtures
{
    [TestFixture]
    public class PreserveWhitespaceTestFixture : BaseTest
    {
        [Test]
        public void PreserveWhitespace()
        {
            LogManager.Adapter = new ConsoleOutLoggerFA(new NameValueCollection());

            /*InitScript(SessionFactory.DataSource, "../../Scripts/account-init.sql");

            ICollection items = Ibatis.DataMapper.DataMapper
                DataMapper.QueryForList("Account.GetAllAccounts1", null);
            Assert.IsTrue(items.Count > 1);

            items = Ibatis.DataMapper.DataMapper.QueryForList("Account.GetAllAccounts2", null);
            Assert.IsTrue(items.Count > 1);
            */
        }
    }
}
