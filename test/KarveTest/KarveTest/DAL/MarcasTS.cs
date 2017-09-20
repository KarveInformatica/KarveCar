using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using DataAccessLayer.Logic;
using NUnit.Framework;
using System.Windows;


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
                _MD = new MarcasDAL();
                _MD.ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";

                List<SQL_EditDAL> SQLS = new List<SQL_EditDAL>();
                SQLS.Add
                    (new SQL_EditDAL()
                    {
                        SQL = "SELECT CODIGO,NOMBRE,PACTADAS,FECHA,LOCUTOR,PROVEE FROM MARCAS ",
                        Tabla = "MARCAS",
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
        public void LoadMarca() { DataSet DS = _MD.LoadRegistro("AA");}
        [Test]
        public void  ModificarMarca()
        {
            DataSet DS =_MD.LoadRegistro("AA");
            if (DS != null)
                {
                if (DS.Tables.Count != 0)
                {
                    DataRow DR = DS.Tables[0].Rows[0];                    
                    DR["NOMBRE"] = "";
                    Boolean bResult = _MD.Save();
                    if (bResult)
                    {MessageBox.Show("Datos Guardados"); }
                    else { MessageBox.Show(DameCadenaErrores()); }
                }
                else MessageBox.Show("Registro no encontrado");
            }
        }

        private String DameCadenaErrores()
            {
            String _Errores = "";
            foreach (ErroresDAL _Err in _MD.Errores)
            {
                _Errores += (_Errores != ""  ? Environment.NewLine : "") + _Err.Message + " [" + _Err.BdTable + "." + _Err.BdField + "]";
            }
            return _Errores;
            }

        [Test]
        public void AgregarMarca()
        {
            DataSet DS = _MD.AddRegistro();
            DataRow DR = DS.Tables[0].NewRow();

            DR["CODIGO"] = "AF";
            DR["NOMBRE"] = "INSERT MARCA";
            DS.Tables[0].Rows.Add(DR);
            _MD.Save();
        }
        [Test]
        public void DeleteMarca()
        {
            DataSet DS = _MD.LoadRegistro("AF");
            _MD.DelReg();
        }


    }
}
