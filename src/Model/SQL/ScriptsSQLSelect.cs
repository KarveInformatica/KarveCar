namespace KarveCar.Model.SQL
{
    public partial class ScriptsSQL
    {
        #region SELECT
        public const string SELECT_BASICA = "SELECT {0} FROM {1}";
        public const string SELECT_ALL_BASICA = "SELECT * FROM {0}";
        public const string SELECT_GRUPO_VEHICULO = "SELECT GRU.CODIGO, GRU.USUARIO, GRU.ULTMODI, GRU.CRS, " +
                                                    "       GRU.NOMBRE, GRU.FBAJA_GH, GRU.HORAS_FRIGO_GR, "  +
                                                    "       GRU.MODELOS, GRU.CATEGO, GRU.OBS1, " +
                                                    "           (SELECT CAT.NOMBRE "   + 
                                                    "            FROM CATEGO AS CAT "  +
                                                    "            WHERE CAT.CODIGO = GRU.CATEGO), " +
                                                    "       GRU.OBS1, " +
                                                    "       GRU.CDW, GRU.SCDW, GRU.FIANZA_DEPOSITO, " +
                                                    "       GRU.TP, GRU.FRANQUICIA, " +
                                                    "       GRU.PAI, GRU.CESION, GRU.MESES_ITV, " +
                                                    "       GRU.FSOR, GRU.FSOR_AERO, " +
                                                    "       GRU.EDADMINI, GRU.EDADMINAVISO, GRU.ANTIGUIMINI " +
                                                    "FROM GRUPOS AS GRU " +
                                                    "ORDER BY GRU.CODIGO";

        public const string SELECT_TIPO_VEHICULO = "SELECT CODIGO, NOMBRE, ULTMODI, USUARIO FROM CATEGO";

        public const string SELECT_PRECIO_POR_DEFECTO = "SELECT PRE.GRUPO, PRE.CONCEPTO, CON.NOMBRE, PRE.PRECIO " +
                                                        "FROM PRECIOS_GRUPO AS PRE " +
                                                        "INNER JOIN CONCEP_FACTUR AS CON " +
                                                        "    ON PRE.CONCEPTO = CON.CODIGO " +
                                                        "    WHERE PRE.GRUPO = '{0}' " +
                                                        "ORDER BY PRE.CONCEPTO";

        public const string SELECT_MARCA = "SELECT TOP 10 MAR.CODIGO, MAR.USUARIO, MAR.ULTMODI, MAR.NOMBRE, " +
                                           "MAR.FBAJA, MAR.PROVEE, PRO.NOMBRE AS NOMBRE_PROVEEDOR, MAR.CONDICIONES, " +
                                           "MAR.PACTADAS, MAR.LOCUTOR, MAR.FECHA, MAR.OBS " +
                                           "FROM MARCAS AS MAR " +
                                           "    LEFT JOIN PROVEE1 AS PRO " +
                                           "        ON MAR.PROVEE = PRO.NUM_PROVEE " +
                                           "ORDER BY MAR.CODIGO";

        public const string SELECT_PROVEEDOR_MARCA = "SELECT NUM_PROVEE, NOMBRE " +
                                                     "FROM PROVEE1 " +
                                                     "ORDER BY NUM_PROVEE";


        #endregion
    }
}
