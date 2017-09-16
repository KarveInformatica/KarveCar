using static KarveCommon.Generic.RecopilatorioEnumerations;
using System;

namespace KarveDataAccessLayer.DataObjects
{
    public class GrupoVehiculoDataObject : BaseAuxDataObject
    {
        #region Constructores
        public GrupoVehiculoDataObject() { this.ControlCambio = EControlCambio.Null; }
        public GrupoVehiculoDataObject(string codigo, string usuario, string ultimamodificacion, string acriss,
                                       string definicion, DateTime fechabaja, byte horasfrigo,
                                       string modelo, string tipovehiculocodigo, string tipovehiculodescripcion, string notas,
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

        private DateTime? fechabaja;
        public DateTime? FechaBaja
        {
            get { return fechabaja; }
            set
            {
                fechabaja = value;
                OnPropertyChanged("FechaBaja");
            }
        }

        private byte horasfrigo;
        public byte HorasFrigo
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

        private string tipovehiculocodigo;
        public string TipoVehiculoCodigo
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
        public string Notas
        {
            get { return notas; }
            set
            {
                notas = value;
                OnPropertyChanged("Notas");
            }
        }

        private decimal cdw;
        public decimal CDW
        {
            get { return cdw; }
            set
            {
                cdw = value;
                OnPropertyChanged("CDW");
            }
        }

        private decimal plus;
        public decimal Plus
        {
            get { return plus; }
            set
            {
                plus = value;
                OnPropertyChanged("Plus");
            }
        }

        private decimal fianza;
        public decimal Fianza
        {
            get { return fianza; }
            set
            {
                fianza = value;
                OnPropertyChanged("Fianza");
            }
        }

        private decimal tp;
        public decimal TP
        {
            get { return tp; }
            set
            {
                tp = value;
                OnPropertyChanged("TP");
            }
        }

        private decimal franquicia;
        public decimal Franquicia
        {
            get { return franquicia; }
            set
            {
                franquicia = value;
                OnPropertyChanged("Franquicia");
            }
        }

        private decimal pai;
        public decimal PAI
        {
            get { return pai; }
            set
            {
                pai = value;
                OnPropertyChanged("PAI");
            }
        }

        private decimal cesion;
        public decimal Cesion
        {
            get { return cesion; }
            set
            {
                cesion = value;
                OnPropertyChanged("Cesion");
            }
        }

        private int mesesitv;
        public int MesesITV
        {
            get { return mesesitv; }
            set
            {
                mesesitv = value;
                OnPropertyChanged("MesesITV");
            }
        }

        private byte fsordowntown;
        public byte FSORDowntown
        {
            get { return fsordowntown; }
            set
            {
                fsordowntown = value;
                OnPropertyChanged("FSORDowntown");
            }
        }

        private byte fsoraeropuerto;
        public byte FSORAeropuerto
        {
            get { return fsoraeropuerto; }
            set
            {
                fsoraeropuerto = value;
                OnPropertyChanged("FSORAeropuerto");
            }
        }

        private byte edadminimapermitidaaviso;
        public byte EdadMinimaPermitidaAviso
        {
            get { return edadminimapermitidaaviso; }
            set
            {
                edadminimapermitidaaviso = value;
                OnPropertyChanged("EdadMinimaPermitidaAviso");
            }
        }

        private byte edadminimapermitidabloqueo;
        public byte EdadMinimaPermitidaBloqueo
        {
            get { return edadminimapermitidabloqueo; }
            set
            {
                edadminimapermitidabloqueo = value;
                OnPropertyChanged("EdadMinimaPermitidaBloqueo");
            }
        }

        private byte antiguedadminimacarnet;
        public byte AntiguedadMinimaCarnet
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
