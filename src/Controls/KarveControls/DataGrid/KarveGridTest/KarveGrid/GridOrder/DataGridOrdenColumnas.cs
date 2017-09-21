namespace KarveGrid.GridOrder
{
    public class DataGridOrdenColumnas : System.Collections.ArrayList
    {
        //*--------------------------------------------------------------------------
        //*  ESTA COLECCIÓN PERMITE REPES, POR ESO LA CREO ARRAY LIST
        //*--------------------------------------------------------------------------

        public void Add(DataGridordenColumna Columnas)
        {
            try {
                Columnas.Item = this.Count;
                base.Add(Columnas);
            } catch {
            }
        }

        public string DameOrder()
        {
            string _sOrder = "";
            DataGridOrdenColumna RL = new DataGridOrdenColumna();
            string _sClausula = "";
            string _sCampo = "";
            string _sOperador = "";
            //*====================================================================
            foreach ( RL in this.ToArray) {
                if (RL.Item > 0)
                    _sOperador = ", ";
                if (!string.IsNullOrEmpty(RL.Expresion)) {
                    _sClausula = RL.Expresion + " " + RL.CriterioString;
                } else if (!string.IsNullOrEmpty(RL.ExpresionBD)) {
                    _sClausula = "(" + RL.ExpresionBD + ") " + RL.CriterioString;
                } else if (!string.IsNullOrEmpty(RL.AliasCampo)) {
                    _sClausula = RL.AliasCampo + " " + RL.CriterioString;
                } else {
                    _sCampo = "";
                    _sClausula = "";
                    //*------------------------------------------------------------
                    if (!string.IsNullOrEmpty(RL.AliasTabla))
                        _sCampo = RL.AliasTabla + ".";
                    _sCampo += RL.Campo;
                    _sClausula += _sCampo + " " + RL.CriterioString;
                }
                _sOrder = _sOrder + _sOperador + _sClausula;
            }
            if (!string.IsNullOrEmpty(_sOrder))
                _sOrder = " ORDER BY " + _sOrder;
            return _sOrder;
        }

    }
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
