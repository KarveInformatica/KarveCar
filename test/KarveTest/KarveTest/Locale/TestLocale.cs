using System;
using System.Collections;
using System.Globalization;
using System.Resources;
using DataAccessLayer;
using KarveCommon.Generic;
using KarveDataServices;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TestStack.White.UIItems.Actions;
using KarveLocale;
using KarveLocale.Properties;

namespace KarveTest.Locale
{
    /// <summary>
    /// This text fixture is used to match and exclude.
    /// </summary>
    [TestFixture]
    public class TestLocale: KarveTest.DAL.TestBase
    {
        private IDataServices _dataServices;
        private ILocaleDataServices _localeDataServices;
        public void Setup()
        {
            ISqlExecutor executor = base.SetupSqlQueryExecutor();
            _dataServices = new DataServiceImplementation(executor);
            _localeDataServices = _dataServices.GetDataService<ILocaleDataServices>();
        }
        [Test]
        public void Should_Load_LocalizationResources_From_File()
        {
            // arrange 
            CultureInfo info = new CultureInfo("es-ES");
            // act 
            Resources res =LocaleResourceFactory.GetLanguageLocale(info, Enumerations.ResourceSource.File);
            Assert.NotNull(res);
        }
        [Test]
        public void Should_Load_LocalizationResources_From_Database()
        {
            CultureInfo info = new CultureInfo("es-ES");
            Resources res = LocaleResourceFactory.GetLanguageLocale(info, Enumerations.ResourceSource.DataBase);
            Assert.NotNull(res);
        }

        [Test]
        public void Should_Read_Resources_From_Custom_ResourceManager()
        {
            DataBaseObjectDataProvider objectDataProvider = new DataBaseObjectDataProvider();
            CultureInfo infoCulture = new CultureInfo("es-ES");
            Resources res = objectDataProvider.GetLocaleLanguageResource(infoCulture);
            Assert.NotNull(res);
        }

        [Test]
        public void Should_BeAbleToIterateFromResourceManager()
        {
            // arrange
            Assert.NotNull(_localeDataServices);
            DataBaseObjectDataProvider.ResourceManagerDataBase rmdb =
                new DataBaseObjectDataProvider.ResourceManagerDataBase(_localeDataServices);
            // act.
            CultureInfo info = new CultureInfo("es-ES");
            ResourceSet set = rmdb.GetResourceSet(info, false, false);
            // execute.
            try
            {
               IDictionaryEnumerator enumeratorDict = set.GetEnumerator();
               Assert.NotNull(enumeratorDict);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}
