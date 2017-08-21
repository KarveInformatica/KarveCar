using iAnywhere.Data.SQLAnywhere;
using KarveCar.Properties;

namespace KarveCar.Model.Sybase
{
    public class ErrorsDB
    {
        /// <summary>
        /// Comprueba el SAException e.NativeError, para poder mostrar el mensaje de error correspondiente según el idioma seleccionado
        /// </summary>
        /// <param name="e"></param>
        static public void MessageError(SAException e)
        {
            switch (e.NativeError)
            {
                case -83: //Specified DataBase not found
                    //Comprobrar que el DataBaseName en la connectionstring sean correctos en AuxiliaresModel.GetValuesFromDBObsCollection
                    ErrorsMessage.ShowMessage(e, Resources.msgError83);
                    break;
                case -100: //DataBase Server not found
                    //Comprobar que EngineName o Host en la connectionstring sean correctos en AuxiliaresModel.GetValuesFromDBObsCollection
                    ErrorsMessage.ShowMessage(e, Resources.msgError100);
                    break;
                case -103: //Invalid User Id or Password
                    //Comprobar que el user/pass en la connectionstring sean correctos en AuxiliaresModel.GetValuesFromDBObsCollection
                    ErrorsMessage.ShowMessage(e, Resources.msgError103);
                    break;
                case -131: //Syntax Error in SQL sentence
                    //Comprobar la sintasi correcta en SQL/SqlScript***
                    ErrorsMessage.ShowMessage(e, Resources.msgError131);
                    break;
                case -141: //Table not found
                    //Comprobar que coindida el nombre de la tabla de la BBDD con el especificado en 
                    //VariablesGlobales.Dictionary<EOpcion, DatosInfoRibbonButton>
                    ErrorsMessage.ShowMessage(e, Resources.msgError141);
                    break;
                default:
                    ErrorsMessage.ShowMessage(e, "default");
                    break;
            }
        }
    }
}
