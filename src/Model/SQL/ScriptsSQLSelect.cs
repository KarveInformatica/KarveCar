namespace KarveCar.Model.SQL
{
    public partial class ScriptsSQL
    {
        #region SELECT
        public const string SELECT_BASICA = "SELECT {0} FROM {1}";
        public const string SELECT_ALL_BASICA = "SELECT * FROM {0}";
        public const string SELECT_GRUPO_VEHICULO = "SELECT GRU.CODIGO, GRU.USUARIO, GRU.ULTMODI, GRU.CRS, " +
                                                    "       GRU.NOMBRE, GRU.FBAJA_GH, GRU.HORAS_FRIGO_GR, " +
                                                    "       GRU.MODELOS, GRU.CATEGO, " +
                                                    "           (SELECT CAT.NOMBRE " + 
                                                    "            FROM CATEGO AS CAT " +
                                                    "            WHERE CAT.CODIGO = GRU.CATEGO), " +
                                                    "       GRU.OBS1, " +
                                                    "       GRU.CDW, GRU.SCDW, GRU.FIANZA_DEPOSITO, " +
                                                    "       GRU.TP, GRU.FRANQUICIA, " +
                                                    "       GRU.PAI, GRU.CESION, GRU.MESES_ITV, " +
                                                    "       GRU.FSOR, GRU.FSOR_AERO, " +
                                                    "       GRU.EDADMINI, GRU.EDADMINAVISO, GRU.ANTIGUIMINI " +
                                                    "FROM GRUPOS AS GRU " +
                                                    "ORDER BY GRU.CODIGO";
        #endregion
    }
}
