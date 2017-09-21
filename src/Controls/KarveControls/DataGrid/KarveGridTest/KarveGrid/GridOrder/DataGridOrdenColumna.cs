namespace KarveGrid.GridOrder
{
    public class DataGridOrdenColumna
    {

        public enum euCriterio
        {
            Asc,
            Desc
        }

        //*
        euCriterio _eCriterio;
        //*
        int _Item;
        //*
        string _sName;
        string _sCampo;
        //*
        string _sExpresion;
        //*
        string _sExpresionBD;
        //*
        string _sCriterio;
        //*
        string _sAliasTabla;
        //*
        string _sAliasCampo;

        public int Item {
            get { return _Item; }
            set { _Item = value; }
        }

        public string Name {
            get { return _sName; }
            set { _sName = value; }
        }

        public string Expresion {
            get { return _sExpresion; }
            set { _sExpresion = value; }
        }

        public string ExpresionBD {
            get { return _sExpresionBD; }
            set { _sExpresionBD = value; }
        }

        public string AliasTabla {
            get { return _sAliasTabla; }
            set { _sAliasTabla = value; }
        }

        public euCriterio Criterio {
            get { return _eCriterio; }
            set {
                _eCriterio = value;
                switch (_eCriterio) {
                    case euCriterio.Asc:
                        _sCriterio = " ASC ";
                        break;
                    case euCriterio.Desc:
                        _sCriterio = " DESC ";
                        break;
                }
            }
        }

        public string CriterioString {
            get { return _sCriterio; }
        }

        public string Campo {
            get { return _sCampo; }
            set { _sCampo = value; }
        }

        public string AliasCampo {
            get { return _sAliasCampo; }
            set { _sAliasCampo = value; }
        }

    }
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
