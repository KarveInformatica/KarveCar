namespace KarveCar.Model.SQL
{
    public partial class ScriptsSQL
    {
        #region INSERT
        //public const string INSERT... = "INSERT...";

        public const string INSERT_MARCA = "INSERT INTO MARCAS " +
                                           "    (CODIGO, USUARIO, ULTMODI, NOMBRE, FBAJA, PROVEE, " +
                                           "     CONDICIONES, PACTADAS, LOCUTOR, FECHA, OBS) " +
                                           "VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', " +
                                           "       '{6}', '{7}', '{8}', {9}, '{10}')";
        #endregion
    }
}
