using Telerik.WinControls.UI;

namespace KarveControls.KarveGrid.Column.Types
{
    public class DataGridDecimalColumn : GridViewDecimalColumn, IMixinDataBaseExtension
    {
        public const int DecimalCols = 2;
        public const int DecimalPercentage = 2;
        public const int DecimalPrice = 2;
        public const int DecimalSubtotal = 2;


        public DataGridDecimalColumn()
        {
            this.DecimalFormattedPlaces = DecimalCols;
        }
        #region "Propiedades"
        public int Item { get => MDataBaseExtension.GetItem(this); set => MDataBaseExtension.SetItem(this, value); }
        public string ExtendedFieldName { get => MDataBaseExtension.GetExtendedFieldName(this); set => MDataBaseExtension.SetExtendedFieldName(this, value); }
        public string Table { get => MDataBaseExtension.GetTable(this); set => MDataBaseExtension.SetTable(this, value); }
        public string ExpressionDb { get => MDataBaseExtension.GetExpressionDb(this); set => MDataBaseExtension.SetTable(this, value); }
        public System.Drawing.Color BackGroundColor { get => MDataBaseExtension.GetBackgroundColor(this); set => MDataBaseExtension.SetBackgroundColor(this, value); }


        public string AliasField {
            get { return FieldName; }
            set { FieldName = value; }
        }


        public override bool ReadOnly {
            get { return base.ReadOnly; }
            set {
                base.ReadOnly = value;
                if (value) {
                    BackGroundColor = DefaultColors.DefaultReadOnlyColor;
                }
            }
        }
        public int DecimalFormattedPlaces {
            get { return this.DecimalPlaces; }
            set {
                this.DecimalPlaces = value;

                this.FormatString = "{0:N" + value + "}";
            }
        }
        #endregion

    }
}
