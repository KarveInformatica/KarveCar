using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
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
            Assert.Greater(listOfCompanies.Count<CompanySummaryDto>(), 0);
        }
        [Test]
        public async Task Should_Load_ACompanyCorrectly()
        {
            // arrange
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var companies = await connection.GetAsyncAll<SUBLICEN>();
                SUBLICEN sublicen = companies.FirstOrDefault();
                if (sublicen!=null)
                {
                    var code = "00";
                    var company = await _companyDataService.GetAsyncCompanyDo(code);
                    Assert.NotNull(company);
                    Assert.NotNull(company.Value);
                    Assert.AreEqual(company.Value.CODIGO, code);
                    Assert.NotNull(company.Value.Province);
                    Assert.NotNull(company.Value.City);
                    Assert.Greater(company.Value.Offices.Count(), 0);
                }
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
                    CompanyDto dto = company.Value;
                    var dateNow = DateTime.Now.ToString("yyyyMMddHH:mm");
                    dto.ULTMODI = dateNow;
                    var id = _companyDataService.GetNewId();
                    dto.CODIGO = id;
                    company = _companyDataService.GetNewCompanyDo(id);
                    company.Value = dto;
                    bool saved = await _companyDataService.SaveAsync(company);
                    var newItem = await _companyDataService.GetAsyncCompanyDo(id);
                    Assert.IsTrue(saved);
                    Assert.AreEqual(newItem.Value.CODIGO, id);
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
        public async Task Should_Delete_ACompanyCorrectly()
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                // prepare
                var companies = await _companyDataService.GetAsyncAllCompanySummary();
                var summary = companies.FirstOrDefault();
                if (summary != null)
                {
                    var code = summary.Code;
                    var dataObject = await _companyDataService.GetAsyncCompanyDo(code);
                    bool retValue = await _companyDataService.DeleteCompanyAsyncDo(dataObject);
                    var supposedToBeDelete = await _companyDataService.GetAsyncCompanyDo(code);
                    Assert.IsTrue(retValue);
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
                CompanyDto c = company.Value;
                c.NOMBRE = "Karve2000";
                if (c != null)
                {
                    c.Offices = new List<OfficeDtos>()
                    {
                        new OfficeDtos()
                        {
                            Codigo = officeId,
                            Nombre = "LaViaZia",
                            DIRECCION="CalleToma",
                            PROVINCIA="08",
                            CP="08",
                            POBLACION="Barcelona"
                        }
                    };
                }
                // prepare
                company.Value = c;
                bool value = await _companyDataService.SaveAsync(company);
                Assert.IsTrue(value);
            }
        }

    }
}
