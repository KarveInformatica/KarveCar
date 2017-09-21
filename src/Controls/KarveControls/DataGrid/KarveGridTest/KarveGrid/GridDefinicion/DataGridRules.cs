using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveGrid.GridDefinicion
{
    public class DataGridRules : IDictionary<string, DataGridRule>
    {

        public void Add(DataGridRule TablaQuery)
        {
            TablaQuery.Item = this.Count;
            base.Add(TablaQuery.Name, TablaQuery);
        }

        public void Remove(object Key)
        {
            base.Remove(Key);
            int i = 0;
            dynamic HC = (from c in this.Valuesorderby c.Itemc);
            ArrayList RS = new ArrayList();
            foreach (DataGridRule ctr in HC)
            {
                ctr.Item = i;
                i += 1;
            }
        }

        public ArrayList Order()
        {
            dynamic HC = (from c in this.Valuesorderby c.Itemc);
            ArrayList RS = new ArrayList();
            foreach (DataGridRule ctr in HC)
            {
                RS.Add(ctr);
            }
            return RS;
        }

        public bool Existe(string Value)
        {
            return this.ContainsKey(Value);
        }

        public DataGridRule DameItemExiste(string Value)
        {
            dynamic HC = (from c in this.Valueswhere c.Name == Valueorderby c.Itemc);
            if (HC.Count != 0)
            {
                return HC(0);
            }
            else
            {
                return null;
            }
        }

        public void Modify(DataGridRule TablaQuery)
        {
            base.Item(TablaQuery.Name) = TablaQuery;
        }

        public string DameWhere()
        {
            string _sWhere = "";
            DataGridRule RL = new DataGridRule();
            string _sClausula = "";
            string _sCampo = "";
            string _sOperador = "";
            foreach (RL in Order())
            {
                if (RL.Item > 0)
                    _sOperador = RL.OperadorVal;
                if (!string.IsNullOrEmpty(RL.Expresion))
                {
                    _sClausula = RL.Expresion;
                }
                else
                {
                    _sClausula = DameClausula(RL);
                }
                _sWhere = _sWhere + _sOperador + _sClausula;
            }
            if (!string.IsNullOrEmpty(_sWhere))
                _sWhere = " WHERE " + _sWhere;
            return _sWhere;
        }

        public string DameClausula(DataGridRule RL)
        {
            string _sClausula = "";
            string _sCampo = "";

            _sCampo = "";

            if (!string.IsNullOrEmpty(RL.ExpresionBD))
            {
                _sCampo = RL.ExpresionBD;
            }
            else if (!string.IsNullOrEmpty(RL.AliasCampo) & RL.AliasCampo != RL.Campo)
            {
                _sCampo = RL.AliasCampo;
            }
            else
            {
                _sCampo = RL.Tabla + ".";
                _sCampo += RL.Campo;
            }

            if (RL.Criterio == DataGridRule.euCriterio.Contiene)
            {
                _sClausula = _sCampo + RL.CriterioVal + "'%" + RL.Valor + "%'";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.NoContiene)
            {
                _sClausula = _sCampo + RL.CriterioVal + "'%" + RL.Valor + "%'";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.Distinto)
            {
                _sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "'";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.Igual)
            {
                _sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "'";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.Empieza)
            {
                _sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "%'";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.Termina)
            {
                _sClausula = _sCampo + RL.CriterioVal + "'%" + RL.Valor + "'";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.EsNulo)
            {
                _sClausula = _sCampo + " IS NULL ";
            }
            else if (RL.Criterio == DataGridRule.euCriterio.NoEsNulo)
            {
                _sClausula = _sCampo + " IS NOT NULL ";
            }
            else
            {
                _sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "'";
            }

            return _sClausula;
        }

    }
}
