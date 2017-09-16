using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KarveCommon.Generic;

namespace KarveDataAccessLayer
{
    public class MarcasDAL
    {
        #region ". VARIABLES.   "
        private string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
        private ISqlQueryExecutor _DAL;

        String _SQL = "SELECT * FROM MARCAS";
        DataSet DS_MARCAS = new DataSet("MARCAS");
        #endregion

        #region ". CONSTRUCTOR.   "

        public MarcasDAL()
        {
            _DAL = new OleDbQueryExecutor(ConnectionString);
        }

        #endregion

        #region ". METODOS.   "

        #region ". LOAD MARCAS.   "

        public DataSet GetMarcas(string _sPk)
        {            
            _SQL = _SQL + _sPk;
            DS_MARCAS =   _DAL.LoadDataSet(_SQL);            
            return DS_MARCAS;            
        }

        #endregion

        #region ". LOAD MARCAS.   "

        public DataSet AddMarcas()
        {
            _SQL = _SQL + " WHERE 0 = 1";
            DS_MARCAS = _DAL.LoadDataSet(_SQL);
            return DS_MARCAS;
        }

        #endregion

        #region ". VALIDATE MARCAS.   "

        private Boolean Validate()
        {
            return true;
        }

        #endregion

        #region ". GUARDAR MARCA.   "

        public bool Save()
        {
            if (Validate())
            {
                return SaveIn();
            }
            else
            {
                return false;
            }
        }                

        private bool SaveIn()
        {
            try
            {
                _DAL.BeginTransaction();
                _DAL.UpdateDataSet(_SQL, ref DS_MARCAS);
                _DAL.Commit();
                return true;
            }
            catch 
            {
                _DAL.Rollback();
                return false;
            }

        }

        #endregion

        #region ". BORRAR MARCA.   "
        public bool DelReg()
        {
            try
            {
                _DAL.BeginTransaction();
                //*-------- MARCAMOS ROW PARA BORRAR                    
                foreach (DataTable _Table in DS_MARCAS.Tables)
                {
                    _Table.Rows[0].Delete();
                }
                _DAL.UpdateDataSet(_SQL, ref DS_MARCAS);
                _DAL.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _DAL.Rollback();                    
                return false;
            }

        }

        #endregion

        #endregion
    }

}
