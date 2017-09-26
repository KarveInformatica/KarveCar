using System.Windows.Media;
using KarveGrid.Column.Types;
using Telerik.WinControls.UI;

namespace KarveGrid.Column
{
    public class DataGridColumn : GridViewDataColumn, IMixinDataBaseExtension
    {
        public enum eColumnType
        {
            Pk,
            Date,
            Hour,
            Text,
            Observation,
            Numeric
        }

        
        private eColumnType _eColumnType;


        public int Item { get => MDataBaseExtension.GetItem(this); set => MDataBaseExtension.SetItem(this, value); }
        public string ExtendedFieldName { get => MDataBaseExtension.GetExtendedFieldName(this); set => MDataBaseExtension.SetExtendedFieldName(this, value); }
        public string Table { get => MDataBaseExtension.GetTable(this); set => MDataBaseExtension.SetTable(this, value); }
        public string ExpressionDb { get => MDataBaseExtension.GetExpressionDb(this); set => MDataBaseExtension.SetTable(this, value); }
        public System.Drawing.Color BackGroundColor { get => MDataBaseExtension.GetBackgroundColor(this); set => MDataBaseExtension.SetBackgroundColor(this, value); }
        

        public string AliasField {
            get { return FieldName; }
            set { FieldName = value; }
        }
        
        public eColumnType Columnn {
            get { return _eColumnType; }
            set {
                _eColumnType = value;
                ExtractColumnProperties();
            }
        }

        private void ExtractColumnProperties()
        {
            switch (_eColumnType) {
                case eColumnType.Pk:
                    ColumnPk();
                    break;
                case eColumnType.Date:
                    ColumnDate();
                    break;
            }

        }

        private void ColumnPk()
        {
            BackGroundColor = System.Drawing.Color.SkyBlue;
            base.Width = 80;
        }

        private void ColumnDate()
        {
            string sAlias = Table;
            if (!string.IsNullOrEmpty(sAlias))
                sAlias = sAlias + ".";
            ExpressionDb = " DATEFORMAT(" + sAlias + base.FieldName + ", 'dd/mm/yyyy') ";
            base.Width = 100;
            base.AllowResize = false;
        }

    }
}
