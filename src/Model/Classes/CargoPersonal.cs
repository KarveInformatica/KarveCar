using KarveCar.Model.Generic;
using KarveCar.Properties;
using System.Collections.Generic;
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Classes
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
