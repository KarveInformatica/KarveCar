using KRibbon.Model.Generic;
using KRibbon.Properties;
using System.Collections.Generic;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Model.Classes
{
    public class CargoPersonal : GenericPropertyChanged
    {
        #region List<DBCriterios>
        public static List<TemplateInfoDB> templateinfodb = new List<TemplateInfoDB>()
        {
            new TemplateInfoDB(){ nombrepropiedadobj = "Codigo",
                                  nombrecolumnadb    = "COD_CAT",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcCodigo },
            new TemplateInfoDB(){ nombrepropiedadobj = "Nombre",
                                  nombrecolumnadb    = "NOM_CAT",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcDefinicion }
        };
        #endregion

        #region Constructores
        public CargoPersonal() { }
        public CargoPersonal(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        #endregion
    }
}
