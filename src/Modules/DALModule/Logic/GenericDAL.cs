using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class GenericDAL
    {
        #region ". VARIABLES.   "

        private Boolean _IsNewReg = false;
        private String _ConnectionString = "";
        private String _sPk = "";
        private ISqlQueryExecutor _DAL;
        private List<Logic.SQL_EditDAL> _SQL = new List<Logic.SQL_EditDAL>();

        private List<Logic.RuleDAL> _RulesAdd = new List<Logic.RuleDAL>();
        private List<Logic.RuleDAL> _RulesDel = new List<Logic.RuleDAL>();
        private List<Logic.RuleDAL> _RulesMod = new List<Logic.RuleDAL>();

        private List<Logic.ErroresDAL> _Errores = new List<Logic.ErroresDAL>();

        DataSet DS_GENERIC = new DataSet("DS_GENERIC");

        #endregion

        #region ". PROPERTIES.   "

        public String ConnectionString
            {
            get => _ConnectionString;

            set { _ConnectionString = value; _DAL = new OleDbQueryExecutor(_ConnectionString); }
            }

        public List<Logic.SQL_EditDAL> SQL
            {
            get => _SQL;
            set => _SQL = value;
            }

        public String PK
            {   
            get => _sPk;
            set => _sPk = value;
            }

        public List<Logic.RuleDAL> RuleAdd
        {
            get => _RulesAdd;
            set => _RulesAdd = value;
        }

        public List<Logic.RuleDAL> RulesDel
        {
            get => _RulesDel;
            set => _RulesDel = value;
        }

        public List<Logic.RuleDAL> RulesMod
        {
            get => _RulesMod;
            set => _RulesMod = value;
        }

        public List<Logic.ErroresDAL> Errores
        {
            get => _Errores;
            set => _Errores = value;
        }

        #endregion

        #region ". CONSTRUCTOR.   "

        public GenericDAL()
        {
            if (_ConnectionString != "") { _DAL = new OleDbQueryExecutor(_ConnectionString); }
                    
        }

        #endregion

        #region ". LOAD REGISTRO.   "

        private String PreparaRegistro(String sPK)
        {
            String _SQLin = "";
            foreach (Logic.SQL_EditDAL _SQLu in _SQL)
            {
                _SQLin += _SQLu.SQL + " WHERE " + _SQLu.PK +  " = " + SetApost(sPK);
                _SQLin += ";";
            }
            return _SQLin;
        }

        private List<String> PreparaNombreDataTable()
            {
            List<String> _TBL = new List<string>();
            foreach (Logic.SQL_EditDAL _SQLu in _SQL)
                {
                _TBL.Add(_SQLu.Tabla);
                }
            return _TBL;
            }

        private String SetApost(String sValue)
        {
            return "'" + sValue + "'";
        }

        public DataSet LoadRegistro(string sPk)
        {
            _sPk = sPk;
            String _SQLin = PreparaRegistro(sPk);
            List<String> _TBL = new List<string>();
            _TBL = PreparaNombreDataTable();
            DS_GENERIC = _DAL.LoadDataSetByTables(_SQLin,_TBL);
            return DS_GENERIC;
        }

        #endregion

        #region ". GUARDAR REGISTRO.   "

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
                String _SQLin = PreparaRegistro(_sPk);
                _DAL.BeginTransaction();
                _DAL.UpdateDataSet(_SQLin, ref DS_GENERIC);
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

        #region ". ADD REGISTRO.   "

        private String PreparaRegistroNuevo()
            {
            String _SQLin = "";
            foreach (Logic.SQL_EditDAL _SQLu in _SQL)
                {
                    _SQLin += _SQLu.SQL + " WHERE 0 = 1 ";
                    _SQLin += ";";
                }
            return _SQLin;
            }

        public DataSet AddRegistro()
        {            
            String _SQLa = PreparaRegistroNuevo();
            DS_GENERIC = _DAL.LoadDataSet(_SQLa);            
            _IsNewReg = (DS_GENERIC != null);
            return DS_GENERIC;                     
        }

        #endregion

        #region ". VALIDATE REGISTRO.   "

        private Boolean Validate()
        {
            try
            {
                if (_IsNewReg) { return ValidateAddRegistro(); }
                else { return ValidateModiRegistro(); };
            }
            catch (Exception) { return false; }            
        }

        private Boolean ValidateModiRegistro()
        {            
            return PreparaValidaciones(_RulesMod);
        }

        private Boolean ValidateDeleteRegistro()
        {
            return PreparaValidaciones(_RulesDel);
        }

        private Boolean ValidateAddRegistro()
        {
            return PreparaValidaciones(_RulesAdd);
        }

        private Boolean PreparaValidaciones(List<Logic.RuleDAL> _Rules)
        {
            Boolean ok = false;
            //-----------------------------
            if (_Rules.Count != 0)
            { 
                foreach (Logic.RuleDAL _Rule in _Rules)
            {
                if (
                    _Rule.BdTable != "" &&
                    _Rule.BdField != "" &&
                    _Rule.ColumnName_Ext != "" && 
                    _Rule.TableName_Ext != "" && 
                    _Rule.Where_Ext != ""
                   ) //Sí Busca por dato relacionado, los acumulamos en un DataSet para Consultarlos todos a la vez y macheamos resultados.
                    { ComparaValorRelacional(_Rule);}
                else 
                if (
                    _Rule.BdTable != "" &&
                    _Rule.BdField != ""                         
                   ) //Sí Compara por valor.                       
                    {ComparaValor(_Rule);}
            }
                ok= true;
            }
            else ok = true;
            //-----------------------------
            if (ok) {ok = ValidaStatus(_Rules); }
            return ok;
        }

        private void ComparaValorRelacional(Logic.RuleDAL _RL)
        { }

        private void ComparaValor(Logic.RuleDAL _RL)
        {
            DataTable DT = BuscaDataTable(_RL.BdTable);
            if (DT != null)
            {
                if (DT.Rows.Count != 0 && BuscaDataField(DT, _RL.BdField))
                {
                    foreach (DataRow DR in DT.Rows)
                    {
                        String _sValue = DR[_RL.BdField].ToString();

                        switch (_RL.Comparacion)
                        {
                            case Logic.RuleDAL.Comparaciones.Igual: _RL.Status = (DR[_RL.BdField].ToString() == _RL.ValueCompara); break;
                            case Logic.RuleDAL.Comparaciones.Distinto: _RL.Status = (DR[_RL.BdField].ToString() != _RL.ValueCompara); break;
                        }

                    }
                }
            }
        }

        private Boolean ValidaStatus(List<Logic.RuleDAL> _Rules)
            {
            Boolean ok = true;
            _Errores.Clear();
            foreach (Logic.RuleDAL _Rule in _Rules)
            {
                if (ok) { ok = _Rule.Status; };
                PreparaListaErrores(_Rule);
            }
            return ok;
        }

        private DataTable BuscaDataTable(String _Table)
        {
            try
            { return DS_GENERIC.Tables[_Table];}              
            catch (Exception) { return null;}
        }

        private Boolean BuscaDataField(DataTable _Table, String _Field)
            {
            try
                { 
                return true;
                }
            catch (Exception) {return false;}                
            }

        private void PreparaListaErrores(Logic.RuleDAL RL)
            {
            if (RL.Status != true)
                {
                Logic.ErroresDAL _Err = new Logic.ErroresDAL();

                _Err.Name = RL.Name;
                _Err.BdTable = RL.BdTable;
                _Err.BdField = RL.BdField;
                _Err.Message = RL.Message;
                _Errores.Add(_Err);
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
                foreach (DataTable _Table in DS_GENERIC.Tables)
                {
                    foreach (DataRow _Row in _Table.Rows)
                    {
                        _Row.Delete();
                    }                    
                }
                _DAL.UpdateDataSet(PreparaRegistro(_sPk), ref DS_GENERIC);
                _DAL.Commit();
                return true;
            }
            catch (Exception e)
            {
                _DAL.Rollback();                
                return false;
                throw new Exception(e.Message);
            }

        }

        #endregion

    }
}
