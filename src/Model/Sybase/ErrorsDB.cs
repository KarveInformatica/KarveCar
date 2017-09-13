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
                case -157: //Cannot convert a text to a date
                    //Comprobar que se pase un valor válido como fecha
                    ErrorsMessage.ShowMessage(e, Resources.msgError157);
                    break;
                case -158: //Value out of range for destination
                    //Comprobar el tamaño del valor que se desea insertar
                    ErrorsMessage.ShowMessage(e, Resources.msgError158);
                    break;
                case -193: //Primary key already exists
                    //Comprobar que la clave primaria no exista en la tabla
                    ErrorsMessage.ShowMessage(e, Resources.msgError193);
                    break;
                case -683: //Rigth truncation of string data
                    //Comprobar la longitud del string que se desea insertar
                    ErrorsMessage.ShowMessage(e, Resources.msgError683);
                    break;
                default:
                    ErrorsMessage.ShowMessage(e, "default");
                    break;
            }
        }
    }
}
