using KRibbon.Model.Generic;
using KRibbon.Properties;
using System.Collections.Generic;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Model.Classes
{
    public class CanalCliente : GenericPropertyChanged
    {
        #region List<DBCriterios>
        public static List<TemplateInfoDB> templateinfodb = new List<TemplateInfoDB>()
        {
            new TemplateInfoDB(){ nombrepropiedadobj = "Codigo",
                                  nombrecolumnadb    = "CODIGO",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcCodigo },
            new TemplateInfoDB(){ nombrepropiedadobj = "Nombre",
                                  nombrecolumnadb    = "NOMBRE",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcDefinicion }
        };
        #endregion

        #region Constructores
        public CanalCliente() { }
        public CanalCliente(string codigo, string nombre)
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
            get
            { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        #endregion
    }
}
