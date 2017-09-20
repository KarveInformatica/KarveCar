using System.ComponentModel;

namespace KarveControls.DataGrid.DataGridHelpers.DataGridRules
{
    public class DataGridRule
    {

        #region "   .   VARIABLES.  "

        public enum euCriterio
        {
            Igual,
            Menor_Que,
            MenorIgual_Que,
            Mayor_Que,
            MayorIgual_Que,
            Distinto,
            EsNulo,
            NoEsNulo,
            Contiene,
            NoContiene,
            Empieza,
            Termina
        }

        public enum TipoFiltro
        {
            Texto,
            Fecha,
            Compuesto
        }

        public enum euOperadorRule
        {
            eAnd,
            eOr
        }

        //*
        int _Item;
        //*
        string _sName;
        //*
        string _sExpresion;
        string _sExpresionBD;
        //*
        euCriterio _eCriterio;
        //*
        euOperadorRule _eOperador = euOperadorRule.eAnd;
        //*
        string _sOperador;
        //*
        string _sCriterio;
        //*
        string _sValue;
        //*
        string _sField;
        //*
        string _sAlias;
        //*
        string _Tabla;
        //*
        TipoFiltro _tipo;
        //*
        DataGridRules _Rules = new DataGridRules();


        #endregion

        #region "   .   PROPIEDADES.    "

        public string CriterioVal {
            get { return _sCriterio; }
        }

        public string OperadorVal {
            get {
                if (_eOperador == euOperadorRule.eAnd) {
                    return " AND ";
                } else if (_eOperador == euOperadorRule.eOr) {
                    return " OR ";
                }
                return " ";
            }
        }

        public int Item {
            get { return _Item; }
            set { _Item = value; }
        }

        [DefaultValue("eAnd")]
        public euOperadorRule Operador {
            get { return _eOperador; }
            set { _eOperador = value; }
        }

        public string Valor {
            get { return _sValue; }
            set { _sValue = value; }
        }

        public string Campo {
            get { return _sField; }
            set { _sField = value; }
        }

        public string AliasCampo {
            get { return _sAlias; }
            set { _sAlias = value; }
        }

        public string Tabla {
            get { return _Tabla; }
            set { _Tabla = value; }
        }

        public string Name {
            get { return _sName; }
            set { _sName = value; }
        }

        public string Expresion {
            get { return _sExpresion; }
            set { _sExpresion = value; }
        }

        public euCriterio Criterio {
            get { return _eCriterio; }
            set {
                _eCriterio = value;
                switch (_eCriterio) {
                    case euCriterio.Igual:
                        _sCriterio = " = ";
                        break;
                    case euCriterio.Distinto:
                        _sCriterio = " <> ";
                        break;
                    case euCriterio.Menor_Que:
                        _sCriterio = " < ";
                        break;
                    case euCriterio.Mayor_Que:
                        _sCriterio = " > ";
                        break;
                    case euCriterio.MayorIgual_Que:
                        _sCriterio = " >= ";
                        break;
                    case euCriterio.MenorIgual_Que:
                        _sCriterio = " <= ";
                        break;
                    case euCriterio.EsNulo:
                        _sCriterio = " IS NULL ";
                        break;
                    case euCriterio.NoEsNulo:
                        _sCriterio = " IS NOT NULL ";
                        break;
                    case euCriterio.NoContiene:
                        _sCriterio = " NOT LIKE ";
                        break;
                    case euCriterio.Contiene:
                        _sCriterio = " LIKE ";
                        break;
                    case euCriterio.Empieza:
                        _sCriterio = " LIKE ";
                        break;
                    case euCriterio.Termina:
                        _sCriterio = " LIKE ";
                        break;
                }
            }
        }

        public TipoFiltro Tipo {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public DataGridRules Rules {
            get { return _Rules; }
            set { _Rules = value; }
        }

        public string ExpresionBD {
            get { return _sExpresionBD; }
            set { _sExpresionBD = value; }
        }

        #endregion

    }
}
