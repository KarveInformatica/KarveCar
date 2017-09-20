using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Logic
{
    public class ErroresDAL
    {
        #region "   .   VARAIBLES.  "        

        String _Name = "";
        String _BdTable = "";
        String _BdField = "";                
        String _Message = "";

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

        public String Message
        {
            get => _Message;
            set => _Message = value;
        }

        #endregion
    }
}
