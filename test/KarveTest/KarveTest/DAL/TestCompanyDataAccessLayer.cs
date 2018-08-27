using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;


namespace KarveTest.DAL
{
    [TestFixture]
    class TestCompanyDataAccessLayer: TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IConfigurationService _serviceConf;
        private ICompanyDataServices _companyDataService;
        private IDataServices _dataServices;
        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
           
            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _companyDataService = _dataServices.GetCompanyDataServices();
                //  _commissionAgentDataServices = _dataServices.GetCommissionAgentDataServices();
              //  Assert.NotNull(_commissionAgentDataServices);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Should_Load_CorrectlyCompanies()
        {
            var listOfCompanies = await _companyDataService.GetAsyncAllCompanySummary();
            Assert.Greater(listOfCompanies.Count<CompanySummaryViewObject>(), 0);
        }
        [Test]
        public async Task Should_Load_ACompanyCorrectly()
        {
            // arrange
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                    var code = "00";
                    var company = await _companyDataService.GetAsyncCompanyDo(code);
                    Assert.NotNull(company);
                    Assert.NotNull(company.Value);
                    Assert.AreEqual(company.Value.CODIGO, code);
                    Assert.NotNull(company.Value.Province);
                    Assert.NotNull(company.Value.City);
            }
        }
        [Test]
        public async Task Should_Save_ACompanyCorrectly()
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                var companies = await conn.GetAsyncAll<SUBLICEN>();
                SUBLICEN subl = companies.FirstOrDefault();
                if (subl!=null)
                {
                    var code = subl.CODIGO;
                    var company = await _companyDataService.GetAsyncCompanyDo(code);
                    CompanyViewObject viewObject = company.Value;
                    var dateNow = DateTime.Now.ToString("yyyyMMddHH:mm");
                    viewObject.ULTMODI = dateNow;
                    var id = _companyDataService.GetNewId();
                    viewObject.CODIGO = id;
                    company = _companyDataService.GetNewCompanyDo(id);
                    company.Value = viewObject;
                    bool saved = await _companyDataService.SaveAsync(company);
                    var newItem = await _companyDataService.GetAsyncCompanyDo(id);
                    Assert.IsTrue(saved);
                    Assert.AreEqual(id, newItem.Value.CODIGO);
                }

            }
        }
        [Test]
        public async Task Should_Update_ACompanyCorrectly()
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                var companies = await _companyDataService.GetAsyncAllCompanySummary();
                var summary = companies.FirstOrDefault();
                var code  = summary.Code;
                var dataObject = await _companyDataService.GetAsyncCompanyDo(code);
                dataObject.Value.POBLACION = "Madrid";
                bool saved = await _companyDataService.SaveAsync(dataObject);
                Assert.IsTrue(saved);
            }
        }
        [Test]
        public void Should_Throws_WithNullIdCompany()
        {
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                var companyId = _companyDataService.GetNewId();
                var company = _companyDataService.GetNewCompanyDo(companyId);
                var officeId = _dataServices.GetOfficeDataServices().GetNewId();
                CompanyViewObject c = company.Value;
                Random random = new Random();
                c.NOMBRE = null;
                c.CODIGO = null;
                c.POBLACION = "Barcelona";
                c.PROVINCIA = "08";
                c.CP = "08100";
                c.FAX = "3489498";
                c.TELEFONO = "349019";
                c.ULTMODI = DateTime.Now.ToString("yyyyMMddHH:mm");
                c.NIF = "Y17267";
                c.RESPDNI = "Y7376161";
                c.USUARIO = "CV";
                c.OBS1 = "Great company";
                c.USUARIOWEB_EMP = "karlos";
                c.PWDWEB_EMP = "Password";
                c.FEC_ALTA = DateTime.Now;
                c.FEC_BAJA = DateTime.Now.AddDays(30);
                c.DIRECCION = "Calle Rocafort 239";
                if (c != null)
                {
                    c.Offices = new List<OfficeViewObject>()
                    {
                        new OfficeViewObject()
                        {
                            Codigo = officeId,
                            Nombre = "LaViaZia",
                            DIRECCION="CalleToma",
                            PROVINCIA="08",
                            CP="08",
                            NACIO="34",
                            POBLACION="Barcelona"
                        }
                    };
                }
                // prepare
                company.Value = c;
                Assert.Throws<Exception>(async () => await _companyDataService.SaveAsync(company));
             
            }
        }

        [Test]
        public async Task Should_Delete_ACompanyCorrectly()
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                // prepare
                var companies = await _companyDataService.GetPagedSummaryDoAsync(1,2);
                var summary = companies.FirstOrDefault();
                if (summary != null)
                {
                    var code = summary.Code;
                    var dataObject = await _companyDataService.GetAsyncCompanyDo(code);
                    bool retValue = await _companyDataService.DeleteCompanyAsyncDo(dataObject);
                    var supposedToBeDelete = await _companyDataService.GetAsyncCompanyDo(code);
                    Assert.IsTrue(retValue);
                    Assert.IsFalse(supposedToBeDelete.Value.IsValid);
                }
            }
        }
        [Test]
        public async Task Should_Add_CompanyCorrectly()
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                var companyId = _companyDataService.GetNewId();
                var company = _companyDataService.GetNewCompanyDo(companyId);
                var officeId = _dataServices.GetOfficeDataServices().GetNewId();
                CompanyViewObject c = company.Value;
                Random random = new Random();
                c.NOMBRE = "Karve" + random.Next() % 1000;
                c.POBLACION = "Barcelona";
                c.PROVINCIA = "08";
                c.CP = "08100";
                c.FAX = "3489498";
                c.TELEFONO = "349019";
                c.ULTMODI = DateTime.Now.ToString("yyyyMMddHH:mm");
                c.NIF = "Y17267"  ;
                c.RESPDNI = "Y7376161"  ;
                c.USUARIO = "CV";
                c.OBS1 = "Great company";
                c.USUARIOWEB_EMP = "karlos";
                c.PWDWEB_EMP = "Password";
                c.FEC_ALTA = DateTime.Now;
                c.FEC_BAJA = DateTime.Now.AddDays(30);
                c.DIRECCION = "Calle Rocafort 239";
                if (c != null)
                {
                    c.Offices = new List<OfficeViewObject>()
                    {
                        new OfficeViewObject()
                        {
                            Codigo = officeId,
                            Nombre = "LaViaZia",
                            DIRECCION="CalleToma",
                            PROVINCIA="08",
                            CP="08",
                            NACIO="34",
                            POBLACION="Barcelona"
                        }
                    };
                }
                // prepare
                company.Value = c;
                bool value = await _companyDataService.SaveAsync(company);
                Assert.IsTrue(value);
                var companyValue =  await _companyDataService.GetAsyncCompanyDo(companyId);
                Assert.NotNull(companyValue);
                Assert.AreEqual(companyValue.Value.NOMBRE, c.NOMBRE);
                Assert.AreEqual(companyValue.Value.TELEFONO, c.TELEFONO);
                Assert.AreEqual(companyValue.Value.NIF, c.NIF);
                Assert.AreEqual(companyValue.Value.CP, c.CP);
            }
        }

    }
}
