using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataAccessLayer.Logic
{
    public class SQL_EditDAL
    {
        #region ".  VARIABLES.  "

            private String _Tabla;
            private String _Sujijo;
            private String _SQL;
            private String _PK;
            private Hashtable _PKs = new Hashtable();

        #endregion

        #region ".  PROPERTIES.  "

            public String Tabla
                {
                    get => _Tabla;
                    set => _Tabla = value;
                }

            public String Sujijo
                {
                    get => _Sujijo;
                    set => _Sujijo = value;
                }

            public String SQL
                {
                    get => _SQL;
                    set => _SQL = value;
                }

            public String PK
            {
                get => _PK;
                set => _PK = value;
            }

            public Hashtable PKs
            {
                    get => _PKs;
                    set => _PKs = value;
                }

        #endregion
    }
}
