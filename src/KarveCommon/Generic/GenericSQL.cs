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

        public const string ElementsSummaryQuery = "select * from elementos where eleIdCodigo='{0}'";

        public const string AccountSummaryQuery = "select codigo,descrip,cc from cu1";

        public const string SupplierSummaryQuery =
            "SELECT PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF , TIPOPROVE.NOMBRE as Provvedor, COMERCIAL as Comercial, " +
            "TELEFONO as Telefono, DIRECCION as Direccion, CP, POBLACION,F_AEAT, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGastos, " +
             "PROVEE1.ULTMODI as UltimaModifica, PROVEE1.USUARIO as Usuario FROM PROVEE1, " +
            "PROVEE2, TIPOPROVE WHERE PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE AND PROVEE1.TIPO=TIPOPROVE.NUM_TIPROVE";
        public const string SupplierQuery =
            "SELECT PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF,COMERCIAL as Comercial, " +
            "TELEFONO as Telefono, DIRECCION as Direccion, CP, POBLACION,EMAIL, F_AEAT, FORMA, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGastos, " +
            "PROVEE2.PLAZO as Plazo, PROVEE2.PLAZO2 as Plazo2, PROVEE2.PLAZO3 as Palzo3, PROVEE2.DIA as Dia, PROVEE2.DIA2 as Dia2, PROVEE2.DIA3 as Dia3, " +
            "PROVEE1.MESVACA as MesVacaciones, PROVEE1.MESVACA2 as MesVacaciones2, PROVEE1.ULTMODI as UltimaModifica, PROVEE1.USUARIO as Usuario FROM PROVEE1, " +
            "PROVEE2 WHERE PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE";

        public const string ClientsQuery = "SELECT CLIENTES1.NUMERO_CLI as Numero, NOMBRE as Nombre, NIF, DIRECCION as Direccion, " +
                                           "POBLACION as POBLACION, PROVINCIA.PROV as Provincia, PAIS.PAIS as Pais, " +
                                           "TELEFONO, FAX, MOVIL, ALTA as FechaAlta FROM CLIENTES1 INNER JOIN CLIENTES2 " +
                                           "ON CLIENTES1.NUMERO_CLI = CLIENTES2.NUMERO_CLI LEFT OUTER JOIN PROVINCIA " +
                                           "ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA LEFT OUTER JOIN PAIS ON PAIS.SIGLAS = NACIOPER";
                                           
        public const string DelegationQuery = "SELECT cldIdDelega, cldDelegacion,  " +
            "cldDireccion1, " +
            "cldDireccion2, " +
            "cldCP, cldIdProvincia, cldPoblacion " +
            "FROM ProDelega  WHERE cldIdCliente={0} ORDER BY cldIdCliente";

        public const string ClientesGenericQuery = "Select CLIENTES1.NUMERO_CLI, NOMBRE, DIRECCION, NIF, POBLACION FROM CLIENTES1";

        public const string CommissionAgentSummaryQuery =
            "SELECT NUM_COMI as Numero, NOMBRE as Nombre, PERSONA as Persona, NIF as Nif, DIRECCION as Direccion, POBLACION as Poblacion, " +
            "PROVINCIA.PROV as Provincia, PAIS.PAIS as Pais FROM COMISIO " +
            " LEFT JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS " +
            " LEFT JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS;";
        public const string DelegationGenericQuery = "SELECT TOP 1 cldIdDelega as Numero, cldDelegacion as Nombre,  " +
                                                     "cldDireccion1 as Direccion, cldDireccion2 as Direccion2, cldCP as CP," +
                                                     "cldIdProvincia as IdProvincia, cldPoblacion as Poblacion FROM ProDelega;";
          
        public const string ContactsQuery = "SELECT ccoContacto as Nombre, ccoCargo as Cargo, ccoDepto as Departemento, ccoTelefono as Telefono, ccoMovil as Movil, ccoFax as Fax," +
                                             "ccoMail as Email FROM ProContactos CC FULL OUTER JOIN ProDelega CD ON (CC.ccoIdCliente = CD.cldIdCliente AND " +
                                             "CC.ccoIdDelega = CD.cldIdDelega) WHERE ccoIdCliente={0} ORDER BY ccoIdDelega, ccoContacto";
        // codigo vehicles.
        public const string VehiclesSummaryQuery = "select vehiculo1.codiint As Numero, matricula as Matricula, marca as Marca, modelo as Modelo, grupo as Grupo, oficina as Oficina, VEHICULO2.KM as Kilometers FROM VEHICULO1 " +
                                                   "LEFT OUTER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT";
        // codigo vehicles summary paged.
        public const string VehiclesSummaryQueryPaged = "select TOP {0} START AT {1} vehiculo1.codiint, matricula, marca, modelo, grupo, oficina, VEHICULO2.KM FROM VEHICULO1 " +
                                                        "LEFT OUTER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT";

        public const string ClientsSummaryQuery = "select NUMERO_CLI as Codigo, " +
                                                   "NOMBRE as Nombre, " +
                                                   "NIF as Nif," + 
                                                   "DIRECCION as Direccion, " +
                                                   "POBLACION as Poblacion, " +
                                                   "PROVINCIA.PROV as Provincia, " +
                                                   "PAIS.PAIS as Pais, " +
                                                   "TELEFONO as Telefono, " +
                                                   "MOVIL as Movil" +
                                                   "from CLIENTES1 " +
                                                   "LEFT OUTER JOIN PROVINCIA " +
                                                   "ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA " +
                                                   "LEFT OUTER JOIN PAIS " +
                                                   "ON PAIS.SIGLAS = CLIENTES1.NACIOPER";
    }
}
