using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Generic
{
    /// <summary>
    /// Plantilla con la info para los campos de la datagrid, y de su correspondiente campo en la DB:<para/>
    /// nombrepropiedadobj -> nombre de la propiedad dentro del objeto<para/>
    /// nombrecolumnadb    -> nombre de la columna en la DB<para/>
    /// tipodatocolumnadb  -> tipo de dato de la columna en la DB<para/>
    /// datagridheader     -> header de la columna del datagrid que mostrará los datos devueltos desde la DB<para/>
    /// </summary>
    public class TemplateInfoDB
    {
        public string nombrepropiedadobj { get; set; }
        public string nombrecolumnadb { get; set ; }
        public ETipoDato tipodatocolumnadb { get; set; }
        public string datagridheader { get; set; }  
    }
}
