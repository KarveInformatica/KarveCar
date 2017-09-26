using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveGrid.Column;
using KarveGrid.GridDefinition;
using Telerik.WinControls.Data;

namespace KarveGrid.GridFilters
{
    internal abstract class BaseFilter : IKarveGridFilter
    {
        public abstract void Apply(DataGridColumns dataGridColumns, ref DataGridRules rules);

        protected bool UpdateRules(FilterDescriptor filter, DataGridRule rule, ref DataGridRules rules)
        {
            bool needChange = false;
            string name = filter.Value as string;
            bool validOperator = (filter.Operator != FilterOperator.IsNull);
            DataGridRule tempGridRule = null;
            if (string.IsNullOrEmpty(name) && (validOperator))
            {
                rules.Remove(rule.Name);
            }
            else
            {
                if (rules.Exists(rule.Name))
                {
                    tempGridRule = rules[rule.Name];
                    rule.Item = tempGridRule.Item;
                    if (rule.Criterio != tempGridRule.Criterio)
                    {
                        needChange = true;
                    }
                    rules.Modify(rule);
                }
                else
                {
                    rules.Add(rule);
                }

            }
            return needChange;
        }
    }
}
