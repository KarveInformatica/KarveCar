using KarveCar.Model.Generic;
using KarveCar.Properties;
using System.Collections.Generic;
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Classes
{
    public class GrupoTarifa : GenericPropertyChanged
    {       
        #region List<DBCriterios>
        public static List<TemplateInfoDB> templateinfodb = new List<TemplateInfoDB>()
        {
            new TemplateInfoDB(){ nombrepropiedadobj = "Codigo",
                                  nombrecolumnadb    = "COD_GT",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcCodigo },
            new TemplateInfoDB(){ nombrepropiedadobj = "Nombre",
                                  nombrecolumnadb    = "NOMBRE",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcDefinicion },
            new TemplateInfoDB(){ nombrepropiedadobj = "UltModi",
                                  nombrecolumnadb    = "ULTMODI",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcUltModi }
        };
        #endregion

        #region Constructores
        public GrupoTarifa() { }
        public GrupoTarifa(string codigoAux, string nombre, string ultmodi)
        {
            this.codigo = codigoAux;
            this.nombre = nombre;
            this.ultmodi = ultmodi;
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

        private string ultmodi;
        public string UltModi
        {
            get { return ultmodi; }
            private set
            {
                ultmodi = value;
                OnPropertyChanged("UltModi");
            }
        }
        #endregion
    }
}
