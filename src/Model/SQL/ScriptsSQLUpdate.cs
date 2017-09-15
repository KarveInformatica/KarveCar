namespace KarveCar.Model.SQL
{
    public partial class ScriptsSQL
    {
        #region UPDATE
        //public const string UPDATE... = "UPDATE...";

        public const string UPDATE_MARCA = "UPDATE MARCAS " +
                                           "SET USUARIO = '{0}', ULTMODI = '{1}', NOMBRE = '{2}', " +
                                           "    FBAJA = {3}, PROVEE = '{4}', CONDICIONES = '{5}', " +
                                           "    PACTADAS = '{6}', LOCUTOR = '{7}', FECHA = {8}, OBS = '{9}' " +
                                           "WHERE CODIGO LIKE '{10}'";
        #endregion
    }
}
