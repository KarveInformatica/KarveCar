using KarveCommon.Generic;

namespace KarveDataAccessLayer.DataObjects
{
    public class GrupoVehiculoPrecioPorDefectoDataObject : GenericPropertyChanged
    {
        #region Constructores
        public GrupoVehiculoPrecioPorDefectoDataObject() { }
        public GrupoVehiculoPrecioPorDefectoDataObject(int codigo, string descripcion, decimal precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            //this.tipotramo = "Por Tramo y Grupo"; //tipotramo;
            this.precio = precio;
        }
        #endregion

        #region Propiedades
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChanged("Code");
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        private string tipotramo = "Por Tramo y Grupo";
        public string TipoTramo
        {
            get { return tipotramo; }
                set
            {
                tipotramo = value;
                OnPropertyChanged("TipoTramo");
            }
        }

        private decimal precio;
        public decimal Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                OnPropertyChanged("Precio");
            }
        }
        #endregion
    }
}
