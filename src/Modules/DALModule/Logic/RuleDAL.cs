using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer.Logic
{
    public class RuleDAL
    {

        #region "   .   ENUMS.  "

        public enum Comparaciones
        {
            Igual = 0,
            Distinto = 1,
            MayorQue = 2,
            MayorIgualQue = 3,
            MenorQue = 4,
            MenorIgualQue = 5
        }

        #endregion

        #region "   .   VARAIBLES.  "        

        String _Name = "";
        String _BdTable = "";
        String _BdField = "";
        Boolean _Status = false;
        String _ColumnName_Ext = "";
        String _TableName_Ext = "";
        String _Where_Ext = "";
        String _Message = "";
        String _DataTableName = "";
        Comparaciones _Comparacion = 0;
        String _ValueCompara = "";

        #endregion

        #region "   .   PROPERTIES.  "

        public String Name
        {
            get => _Name;
            set => _Name = value;
        }

        public String BdTable
        {
            get => _BdTable;
            set => _BdTable = value;
        }

        public String BdField
        {
            get => _BdField;
            set => _BdField = value;
        }

        public Boolean Status
        {
            get => _Status;
            set => _Status = value;
        }

        public String ColumnName_Ext
        {
            get => _ColumnName_Ext;
            set => _ColumnName_Ext = value;
        }

        public String TableName_Ext
        {
            get => _TableName_Ext;
            set => _TableName_Ext = value;
        }

        public String Where_Ext
        {
            get => _Where_Ext;
            set => _Where_Ext = value;
        }

        public String Message
        {
            get => _Message;
            set => _Message = value;
        }

        public String DataTableName
        {
            get => _DataTableName;
            set => _DataTableName = value;
        }

        public Comparaciones Comparacion
        {
            get => _Comparacion;
            set => _Comparacion = value;
        }

        public String ValueCompara
        {
            get => _ValueCompara;
            set => _ValueCompara = value;
        }

        #endregion

    }
}
