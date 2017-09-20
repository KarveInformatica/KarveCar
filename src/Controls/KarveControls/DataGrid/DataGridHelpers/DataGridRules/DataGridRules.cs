
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataGridRules : Dictionary<object, DataGridRule>
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
        dynamic HC = from c in Values orderby c.Item select c;
        ArrayList RS = new ArrayList();
        foreach (DataGridRule ctr in HC)
        {
            ctr.Item = i;
            i += 1;
        }
    }

    public IList<DataGridRule> Order()
	{
		dynamic HC = from c in Values orderby c.Item select c;
		IList<DataGridRule> RS = new List<DataGridRule>();
		foreach (DataGridRule ctr in HC) {
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
		dynamic HC = (from c in Values where c.Name == Value orderby c.Item select c);
		if (HC.Count != 0) {
			return HC(0);
		} else {
			return null;
		}
	}

	public void Modify(DataGridRule TablaQuery)
	{
        
        base[TablaQuery.Name] = TablaQuery;
	}

	public string DameWhere()
	{
		string _sWhere = "";
		DataGridRule RL = new DataGridRule();
		string _sClausula = "";
		string _sCampo = "";
		string _sOperador = "";
	    IList<DataGridRule> orders = Order();
		//*====================================================================
		foreach (DataGridRule rule in orders) {
			if (rule.Item > 0)
				_sOperador =rule.OperadorVal;
			if (!string.IsNullOrEmpty(rule.Expresion)) {
				_sClausula = rule.Expresion;
			} else {
				_sClausula = DameClausula(rule);
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

		if (!string.IsNullOrEmpty(RL.ExpresionBD)) {
			_sCampo = RL.ExpresionBD;
		} else if (!string.IsNullOrEmpty(RL.AliasCampo) & RL.AliasCampo != RL.Campo) {
			_sCampo = RL.AliasCampo;
		} else {
			_sCampo = RL.Tabla + ".";
			_sCampo += RL.Campo;
		}

		if (RL.Criterio == DataGridRule.euCriterio.Contiene) {
			_sClausula = _sCampo + RL.CriterioVal + "'%" + RL.Valor + "%'";
		} else if (RL.Criterio == DataGridRule.euCriterio.NoContiene) {
			_sClausula = _sCampo + RL.CriterioVal + "'%" + RL.Valor + "%'";
		} else if (RL.Criterio == DataGridRule.euCriterio.Distinto) {
			_sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "'";
		} else if (RL.Criterio == DataGridRule.euCriterio.Igual) {
			_sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "'";
		} else if (RL.Criterio == DataGridRule.euCriterio.Empieza) {
			_sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "%'";
		} else if (RL.Criterio == DataGridRule.euCriterio.Termina) {
			_sClausula = _sCampo + RL.CriterioVal + "'%" + RL.Valor + "'";
		} else if (RL.Criterio == DataGridRule.euCriterio.EsNulo) {
			_sClausula = _sCampo + " IS NULL ";
		} else if (RL.Criterio == DataGridRule.euCriterio.NoEsNulo) {
			_sClausula = _sCampo + " IS NOT NULL ";
		} else {
			_sClausula = _sCampo + RL.CriterioVal + "'" + RL.Valor + "'";
		}

		return _sClausula;
	}

}