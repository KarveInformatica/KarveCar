namespace KarveGrid.Column.Types.DataGridDecimalColumn_Subtypes
{
    public class DataGridPriceColumn : DataGridDecimalColumn
    { 
        public DataGridPriceColumn()
        {
            this.DecimalFormattedPlaces = DataGridDecimalColumn.DecimalPrice;
        }
    }
}
