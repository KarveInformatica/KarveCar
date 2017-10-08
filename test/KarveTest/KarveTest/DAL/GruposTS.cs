using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Logic;
using NUnit.Framework;

namespace KarveTest
{
    class GruposTS
    {

        [TestFixture]
        public class GrupoTS
        {
            GruposDAL _MD;
            [OneTimeSetUp]
            public void SetUp()
            {
                //    _dataServices = null;
                try
                {
                    _MD = new GruposDAL();
                    _MD.ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
                  
                    List<SQL_EditDAL> SQLS = new List<SQL_EditDAL>();
                    SQLS.Add
                        (new SQL_EditDAL()
                            {
                                SQL  = "SELECT CODIGO,NOMBRE,EDADMINI,ANTIGUIMINI,FRANQUICIA,TP,PAI,CDW,SCDW,OBS1,CRS,ULTMODI,USUARIO,CATEGO FROM GRUPOS ",
                                Tabla = "GRUPOS",
                                PK = "CODIGO"
                            }
                        );
                    _MD.SQL = SQLS;

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
            public void AgregarGrupo()
            {
                DataSet DS = _MD.AddRegistro();
                Assert.NotNull(DS);
                Assert.Greater(DS.Tables.Count, 0);
                DataRow DR = DS.Tables[0].NewRow();
                DR["CODIGO"] = "AF";
                DR["NOMBRE"] = "INSERT GRUPO";
                DS.Tables[0].Rows.Add(DR);
                _MD.Save();

            }
            [Test]
            public void LoadGrupo()
            {
                DataSet DS = _MD.LoadRegistro("A");
            }
            [Test]
            public void ModificarGrupo()
            {
                DataSet DS = _MD.LoadRegistro("A");
                DataRow DR = DS.Tables[0].Rows[0];
                DR["NOMBRE"] = "PRUEBA UPDATE";
                _MD.Save();
            }
            [Test]
            public void DeleteGrupo()
            {
                DataSet DS = _MD.LoadRegistro("A");
                _MD.DelReg();
            }
        }
    }
}
