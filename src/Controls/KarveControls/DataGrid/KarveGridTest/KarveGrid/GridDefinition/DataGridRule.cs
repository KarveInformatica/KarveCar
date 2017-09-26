using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KarveGrid.Column.Types;
using KarveGrid.GridOrder;
using Telerik.WinControls.Data;

namespace KarveGrid.GridDefinition
{
    public class DataGridRule: IMixinDataBaseExtension
    {
        #region "Variables "


        public enum SortingCriteria
        {
            Contains,
            StartsWith,
            EndsWith,
            IsEqualTo,
            IsGreaterThan,
            IsGreaterThanOrEqualTo,
            IsLessThan,
            IsLessThanOrEqualTo,
            IsNull,
            IsNotNull,
            NotContains,
            Ends,
            EndsWidth,
            IsNotEqualTo
        }
        public enum FilterType
        {
            Text,
            Data,
            Composed
        }

        public enum OperatorRule
        {
            And,
            Or
        }
        private SortingCriteria _eCriterio = SortingCriteria.Contains;
        private OperatorRule _eOperador = OperatorRule.And;
        private DataGridRules _rules = new DataGridRules();

        internal static SortingCriteria TranslateFromFilter(FilterOperator @operator)
        {
            throw new NotImplementedException();
        }

        private string _sCriterio;
        private object _sValue;
        private string _sField;
        private string _sAlias;
        private string _sName;
        private string _sExpresion;

        private FilterType _type;

        


        #endregion

        #region "   .   PROPIEDADES.    "

        public int Item { get => MDataBaseExtension.GetItem(this); set => MDataBaseExtension.SetItem(this, value); }
        public string ExtendedFieldName { get => MDataBaseExtension.GetExtendedFieldName(this); set => MDataBaseExtension.SetExtendedFieldName(this, value); }
        public string Table { get => MDataBaseExtension.GetTable(this); set => MDataBaseExtension.SetTable(this, value); }
        public string ExpressionDb { get => MDataBaseExtension.GetExpressionDb(this); set => MDataBaseExtension.SetTable(this, value); }
        public System.Drawing.Color BackGroundColor { get => MDataBaseExtension.GetBackgroundColor(this); set => MDataBaseExtension.SetBackgroundColor(this, value); }
        /// <summary>
        ///  This is an helper class for this.
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public static Telerik.WinControls.Data.FilterOperator TranslateFilter(SortingCriteria sc)
        {
            switch (sc)
            {
                case DataGridRule.SortingCriteria.Contains:
                    return Telerik.WinControls.Data.FilterOperator.Contains;
                case DataGridRule.SortingCriteria.StartsWith:
                    return Telerik.WinControls.Data.FilterOperator.StartsWith;
                case DataGridRule.SortingCriteria.EndsWidth:
                    return Telerik.WinControls.Data.FilterOperator.EndsWith;
                case DataGridRule.SortingCriteria.IsEqualTo:
                    return Telerik.WinControls.Data.FilterOperator.IsEqualTo;
                case DataGridRule.SortingCriteria.IsGreaterThan:
                    return Telerik.WinControls.Data.FilterOperator.IsGreaterThan;
                case DataGridRule.SortingCriteria.IsGreaterThanOrEqualTo:
                    return Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo;
                case DataGridRule.SortingCriteria.IsLessThan:
                    return Telerik.WinControls.Data.FilterOperator.IsLessThan;
                case DataGridRule.SortingCriteria.IsLessThanOrEqualTo:
                    return Telerik.WinControls.Data.FilterOperator.IsLessThanOrEqualTo;
                case DataGridRule.SortingCriteria.IsNotEqualTo:
                    return Telerik.WinControls.Data.FilterOperator.IsNotEqualTo;
                case DataGridRule.SortingCriteria.IsNull:
                    return Telerik.WinControls.Data.FilterOperator.IsNull;
                case DataGridRule.SortingCriteria.IsNotNull:
                    return Telerik.WinControls.Data.FilterOperator.IsNotNull;
                case DataGridRule.SortingCriteria.NotContains:
                    return Telerik.WinControls.Data.FilterOperator.NotContains;
                default:
                    return Telerik.WinControls.Data.FilterOperator.StartsWith;
            }
        }

        public string OrderBy
        {
            get { return _sCriterio; }
        }

        public string OperadorVal
        {
            get
            {
                if (_eOperador == OperatorRule.And)
                {
                    return " AND ";
                }
                else if (_eOperador == OperatorRule.Or)
                {
                    return " OR ";
                }
                return " ";
            }
        }


        [DefaultValue("And")]
        public OperatorRule Operador
        {
            get { return _eOperador; }
            set { _eOperador = value; }
        }

        public object Value
        {
            get { return _sValue; }
            set { _sValue = value; }
        }

        public string ExtendedField
        {
            get { return _sField; }
            set { _sField = value; }
        }

        public string AliasField
        {
            get { return _sAlias; }
            set { _sAlias = value; }
        }


        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        public string Expresion
        {
            get => _sExpresion; set { _sExpresion = value; }
        }

        public SortingCriteria Criterio
        {
            get { return _eCriterio; }
            set
            {
                _eCriterio = value;
                switch (_eCriterio)
                {
                    case SortingCriteria.IsEqualTo:
                        _sCriterio = " = ";
                        break;
                    case SortingCriteria.IsNotEqualTo:
                        _sCriterio = " <> ";
                        break;
                    case SortingCriteria.IsLessThan:
                        _sCriterio = " < ";
                        break;
                    case SortingCriteria.IsGreaterThan:
                        _sCriterio = " > ";
                        break;
                    case SortingCriteria.IsGreaterThanOrEqualTo:
                        _sCriterio = " >= ";
                        break;
                    case SortingCriteria.IsLessThanOrEqualTo:
                        _sCriterio = " <= ";
                        break;
                    case SortingCriteria.IsNull:
                        _sCriterio = " IS NULL ";
                        break;
                    case SortingCriteria.IsNotNull:
                        _sCriterio = " IS NOT NULL ";
                        break;
                    case SortingCriteria.NotContains:
                        _sCriterio = " NOT LIKE ";
                        break;
                    case SortingCriteria.StartsWith:
                        _sCriterio = " LIKE ";
                        break;
                    case SortingCriteria.Ends:
                        _sCriterio = " LIKE ";
                        break;
                }
            }
        }

        public DataGridRules Rules
        {
            get => _rules;
            set => value = _rules;
        }
        public FilterType CurrentFilterType
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion

    }
    
}
