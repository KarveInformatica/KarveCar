using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public class GenericSql
    {
        public static string CHANGED_VALUE = "ChangedValue";
        public static string FIELD = "Field";
        public static string DATATABLE = "DataTable";
        public static string TABLENAME = "TableName";

        public const string SupplierSummaryQuery =
            "SELECT PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF , TIPOPROVE.NOMBRE as Provvedor, COMERCIAL as Comercial, " +
            "TELEFONO as Telefono, DIRECCION as Direccion, CP, POBLACION,EMAIL, F_AEAT, FORMA, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGastos, " +
            "PROVEE2.PLAZO as Plazo, PROVEE2.PLAZO2 as Plazo2, PROVEE2.PLAZO3 as Palzo3, PROVEE2.DIA as Dia, PROVEE2.DIA2 as Dia2, PROVEE2.DIA3 as Dia3, " +
            "PROVEE1.MESVACA as MesVacaciones, PROVEE1.MESVACA2 as MesVacaciones2, PROVEE1.ULTMODI as UltimaModifica, PROVEE1.USUARIO as Usuario FROM PROVEE1, " +
            "PROVEE2, TIPOPROVE WHERE PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE AND PROVEE1.TIPO=TIPOPROVE.NUM_TIPROVE";
        public const string SupplierQuery =
            "SELECT PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF,COMERCIAL as Comercial, " +
            "TELEFONO as Telefono, DIRECCION as Direccion, CP, POBLACION,EMAIL, F_AEAT, FORMA, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGastos, " +
            "PROVEE2.PLAZO as Plazo, PROVEE2.PLAZO2 as Plazo2, PROVEE2.PLAZO3 as Palzo3, PROVEE2.DIA as Dia, PROVEE2.DIA2 as Dia2, PROVEE2.DIA3 as Dia3, " +
            "PROVEE1.MESVACA as MesVacaciones, PROVEE1.MESVACA2 as MesVacaciones2, PROVEE1.ULTMODI as UltimaModifica, PROVEE1.USUARIO as Usuario FROM PROVEE1, " +
            "PROVEE2 WHERE PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE";

        public const string DelegationQuery = "SELECT cldIdDelega as Numero, cldDelegacion as Nombre,  " +
            "cldDireccion1 as Direccion, " +
            "cldDireccion2 as Direccion2, " +
            "cldCP as CP, cldIdProvincia as IdProvincia, cldPoblacion as Poblacion " +
            "FROM ProDelega  WHERE cldIdCliente={0} ORDER BY cldIdCliente";
        
    }
}
