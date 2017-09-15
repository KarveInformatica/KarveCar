using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using NUnit.Framework;


namespace KarveTest.DAL
{
    [TestFixture]
    public class MarcasTS
    {
        MarcasDAL _MD;
        [OneTimeSetUp]
        public void SetUp()
        {
            //    _dataServices = null;
            try
            {
                //IKarveDataMapper mapper = new BaseDataMapper();
                //_dataServices = new DataServiceImplementation(mapper);
                //_supplierDataServices = _dataServices.GetSupplierDataServices();
                _MD = new MarcasDAL();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [OneTimeTearDown]
        public void Teardown()
        {

        }
        [Test]
        public void  ModificarMarca()
        {
            DataSet DS =_MD.GetMarcas(" WHERE CODIGO = 'AA'");
            DataRow DR = DS.Tables[0].Rows[0];
            DR["NOMBRE"] = "PRUEBA UPDATE";
            _MD.Save();
        }
        [Test]
        public void AgregarMarca()
        {
            DataSet DS = _MD.AddMarcas();
            DataRow DR = DS.Tables[0].NewRow();
            DR["CODIGO"] = "AD";
            DR["NOMBRE"] = "INSERT AD";
            DS.Tables[0].Rows.Add(DR);
            _MD.Save();
        }

        [Test]
        public void DeleteMarca()
        {
            DataSet DS = _MD.GetMarcas(" WHERE CODIGO = 'AD'");
            _MD.DelReg();
        }


    }
}
