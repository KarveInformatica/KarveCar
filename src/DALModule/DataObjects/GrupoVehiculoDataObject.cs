using static KarveCommon.Generic.RecopilatorioEnumerations;
using System;

namespace DataAccessLayer.DataObjects
{
    public class GrupoVehiculoDataObject : BaseAuxDataObject
    {
        #region Constructores
        public GrupoVehiculoDataObject() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public GrupoVehiculoDataObject(string codigo, string usuario, string ultimamodificacion, string acriss,
                                       string definicion, DateTime fechabaja, byte horasfrigo,
                                       string modelo, char tipovehiculocodigo, string tipovehiculodescripcion, string notas,
                                       decimal cdw, decimal plus, decimal fianza,
                                       decimal tp, decimal franquicia,
                                       decimal pai, decimal cesion, int mesesitv,
                                       byte fsordowntown, byte fsoraeropuerto,
                                       byte edadminimapermitidaaviso, byte edadminimapermitidabloqueo, byte antiguedadminimacarnet)
        {
            base.Codigo = codigo;
            base.Usuario = usuario;
            base.UltimaModificacion = ultimamodificacion;            
            base.Definicion = definicion;
            this.acriss = acriss;

            this.fechabaja = fechabaja;
            this.horasfrigo = horasfrigo;

            this.modelo = modelo;
            this.tipovehiculocodigo = tipovehiculocodigo;
            this.tipovehiculodescripcion = tipovehiculodescripcion;
            this.notas = notas;

            this.cdw = cdw;
            this.plus = plus;
            this.fianza = fianza;

            this.tp = tp;
            this.franquicia = franquicia;

            this.pai = pai;
            this.cesion = cesion;
            this.mesesitv = mesesitv;

            this.fsordowntown = fsordowntown;
            this.fsoraeropuerto = fsoraeropuerto;

            this.edadminimapermitidaaviso = edadminimapermitidaaviso;
            this.edadminimapermitidabloqueo = edadminimapermitidabloqueo;
            this.antiguedadminimacarnet = antiguedadminimacarnet;
        }
        #endregion

        #region Propiedades
        private string acriss;
        public string Acriss
        {
            get { return acriss; }
            set
            {
                acriss = value;
                OnPropertyChanged("Acriss");
            }
        }

        private DateTime fechabaja;
        internal DateTime FechaBaja
        {
            get { return fechabaja; }
            set
            {
                fechabaja = value;
                OnPropertyChanged("FechaBaja");
            }
        }

        private byte horasfrigo;
        internal byte HorasFrigo
        {
            get { return horasfrigo; }
            set
            {
                horasfrigo = value;
                OnPropertyChanged("HorasFrigo");
            }
        }

        private string modelo;
        public string Modelo
        {
            get { return modelo; }
            set
            {
                modelo = value;
                OnPropertyChanged("Modelo");
            }
        }

        private char tipovehiculocodigo;
        public char TipoVehiculoCodigo
        {
            get { return tipovehiculocodigo; }
            set
            {
                tipovehiculocodigo = value;
                OnPropertyChanged("TipoVehiculoCodigo");
            }
        }

        private string tipovehiculodescripcion;
        public string TipoVehiculoDescripcion
        {
            get { return tipovehiculodescripcion; }
            set
            {
                tipovehiculodescripcion = value;
                OnPropertyChanged("TipoVehiculoDescripcion");
            }
        }

        private string notas;
        internal string Notas
        {
            get { return notas; }
            set
            {
                notas = value;
                OnPropertyChanged("Notas");
            }
        }

        private decimal cdw;
        internal decimal CDW
        {
            get { return cdw; }
            set
            {
                cdw = value;
                OnPropertyChanged("CDW");
            }
        }

        private decimal plus;
        internal decimal Plus
        {
            get { return plus; }
            set
            {
                plus = value;
                OnPropertyChanged("Plus");
            }
        }

        private decimal fianza;
        internal decimal Fianza
        {
            get { return fianza; }
            set
            {
                fianza = value;
                OnPropertyChanged("Fianza");
            }
        }

        private decimal tp;
        internal decimal TP
        {
            get { return tp; }
            set
            {
                tp = value;
                OnPropertyChanged("TP");
            }
        }

        private decimal franquicia;
        internal decimal Franquicia
        {
            get { return franquicia; }
            set
            {
                franquicia = value;
                OnPropertyChanged("Franquicia");
            }
        }

        private decimal pai;
        internal decimal PAI
        {
            get { return pai; }
            set
            {
                pai = value;
                OnPropertyChanged("PAI");
            }
        }

        private decimal cesion;
        internal decimal Cesion
        {
            get { return cesion; }
            set
            {
                cesion = value;
                OnPropertyChanged("Cesion");
            }
        }

        private int mesesitv;
        internal int MesesITV
        {
            get { return mesesitv; }
            set
            {
                mesesitv = value;
                OnPropertyChanged("MesesITV");
            }
        }

        private byte fsordowntown;
        internal byte FSORDowntown
        {
            get { return fsordowntown; }
            set
            {
                fsordowntown = value;
                OnPropertyChanged("FSORDowntown");
            }
        }

        private byte fsoraeropuerto;
        internal byte FSORAeropuerto
        {
            get { return fsoraeropuerto; }
            set
            {
                fsoraeropuerto = value;
                OnPropertyChanged("FSORAeropuerto");
            }
        }

        private byte edadminimapermitidaaviso;
        internal byte EdadMinimaPermitidaAviso
        {
            get { return edadminimapermitidaaviso; }
            set
            {
                edadminimapermitidaaviso = value;
                OnPropertyChanged("EdadMinimaPermitidaAviso");
            }
        }

        private byte edadminimapermitidabloqueo;
        internal byte EdadMinimaPermitidaBloqueo
        {
            get { return edadminimapermitidabloqueo; }
            set
            {
                edadminimapermitidabloqueo = value;
                OnPropertyChanged("EdadMinimaPermitidaBloqueo");
            }
        }

        private byte antiguedadminimacarnet;
        internal byte AntiguedadMinimaCarnet
        {
            get { return antiguedadminimacarnet; }
            set
            {
                antiguedadminimacarnet = value;
                OnPropertyChanged("AntiguedadMinimaCarnet");
            }
        }
        #endregion
    }
}
